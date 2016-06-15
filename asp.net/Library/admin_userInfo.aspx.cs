using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_userInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
       
        if (!this.IsPostBack)
            InitData();
 

    }
    protected void top_loginout_Click(object sender, EventArgs e)
    {
        Session["userName"] = null;
        Session["adminName"] = null;
        Response.Redirect("/login.aspx");
    }
    protected void insertUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("/insertUser.aspx");
    }

    private void InitData()
    {    // 新建数据库连接conn，连接到SQL SERVER数据库
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        DataSet ds = new DataSet(); // 新建DataSet对象
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [User]", conn);
        conn.Open(); // 打开数据库连接
        da.Fill(ds); // 将检索的记录行填充到DataSet对象ds中
        conn.Close(); // 关闭数据库连接
        users.DataSource = ds;  //设置数据源
        users.DataBind();   //绑定数据源
        if (ds == null || ds.Tables[0].Rows.Count == 0)
        {
            info.Text = "没有记录";
        }
        else
        {
            info.Text = "";
        }

    }


    protected void users_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        // 新建Command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "DELETE FROM [User] WHERE userId=" + users.Rows[e.RowIndex].Cells[0].Text;
        cmd.CommandType = CommandType.Text;
        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect("/admin_userInfo.aspx");

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
  
    protected void users_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        // 新建Command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "UPDATE [User] SET userName =N'" + ((TextBox)(users.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim()
            + "',userPassWord=N'" + ((TextBox)(users.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim()
            + "',userInfo=N'" + ((TextBox)(users.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim()
            +"' WHERE userId="+users.Rows[e.RowIndex].Cells[0].Text.Trim();
        cmd.CommandType = CommandType.Text;
        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            users.EditIndex = -1;
            InitData();
            Response.Redirect("/admin_userInfo.aspx");
           
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
    protected void users_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        users.EditIndex = -1;
        if (selectName.Text == null || selectName.Text.Equals(""))
        {
            InitData();
        }
        else
        {
            selectOneUser();
        }
    }
    protected void users_RowEditing(object sender, GridViewEditEventArgs e)
    {
        users.EditIndex = e.NewEditIndex;
        if (selectName.Text == null || selectName.Text.Equals(""))
        {
            InitData();
        }
        else
        {
            selectOneUser();
        }
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        selectOneUser();
    }

    protected void selectOneUser()
    {
        // 新建数据库连接conn，连接到SQL SERVER数据库
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        DataSet ds = new DataSet(); // 新建DataSet对象
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [User] WHERE userName='" + selectName.Text.Trim() + "'", conn);
        conn.Open(); // 打开数据库连接
        da.Fill(ds); // 将检索的记录行填充到DataSet对象ds中
        conn.Close(); // 关闭数据库连接
        if (ds == null || ds.Tables[0].Rows.Count == 0)
        {
            info.Text = "没有记录";
        }
        else
        {
            info.Text = "";
            users.DataSource = ds;  //设置数据源
            users.DataBind();   //绑定数据源

        }

    }
}