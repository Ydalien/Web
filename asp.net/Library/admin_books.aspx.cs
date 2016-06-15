using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_books : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminName"] == null)
        {
            Response.Redirect("/login.aspx");
        }
        if (!this.IsPostBack)
            InitData();
       
    }
    protected void insertBook_Click(object sender, EventArgs e)
    {
        Response.Redirect("/insertBook.aspx");
    }
    protected void top_loginout_Click(object sender, EventArgs e)
    {
        Session["userName"] = null;
        Session["adminName"] = null;
        Response.Redirect("/login.aspx");
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        // 新建Command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "UPDATE [Book] SET bookName =N'" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim()
            + "',auhor=N'" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim()
            + "',pree=N'" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim()
            + "',date=N'" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim()
            + "',bookInfo=N'" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim()
            + "' WHERE bookId=" + GridView1.Rows[e.RowIndex].Cells[0].Text.Trim();
        cmd.CommandType = CommandType.Text;
        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            InitData();
            Response.Redirect("/admin_books.aspx");

        }
        catch (SqlException sqlException)
        {
            Response.Write(sqlException.Message);  //显示连接异常
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        // 新建Command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "DELETE FROM [Book] WHERE bookId=" + GridView1.Rows[e.RowIndex].Cells[0].Text;
        cmd.CommandType = CommandType.Text;

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect("/admin_books.aspx");

        }
        catch (SqlException sqlException)
        {
            Response.Write(sqlException.Message);  //显示连接异常
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        if (bookname.Text == null || bookname.Text.Equals(""))
        {
            InitData();
        }
        else
        {
            selectOneBook();
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        if (bookname.Text == null || bookname.Text.Equals(""))
        {
            InitData();
        }
        else
        {
            selectOneBook();
        }
    }

    private void InitData()
    {    // 新建数据库连接conn，连接到SQL SERVER数据库
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        DataSet ds = new DataSet(); // 新建DataSet对象
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Book]", conn);
        conn.Open(); // 打开数据库连接
        da.Fill(ds); // 将检索的记录行填充到DataSet对象ds中
        conn.Close(); // 关闭数据库连接
        GridView1.DataSource = ds;  //设置数据源
        GridView1.DataBind();   //绑定数据源
        if (ds == null || ds.Tables[0].Rows.Count == 0)
        {
            info.Text = "没有记录";
        }
        else
        {
            info.Text = "";
        }

    }

    protected void btn_Click(object sender, EventArgs e)
    {
        selectOneBook();
    }

    protected void selectOneBook()
    {
        // 新建数据库连接conn，连接到SQL SERVER数据库
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        DataSet ds = new DataSet(); // 新建DataSet对象
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Book] WHERE bookName='" + bookname.Text.Trim()+"'", conn);
        conn.Open(); // 打开数据库连接
        da.Fill(ds); // 将检索的记录行填充到DataSet对象ds中
        conn.Close(); // 关闭数据库连接
        if (ds == null ||ds.Tables[0].Rows.Count==0)
        {
            info.Text = "没有记录";
        }
        else
        {
            info.Text = "";
            GridView1.DataSource = ds;  //设置数据源
            GridView1.DataBind();   //绑定数据源
            
        }


    }
}