using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            username.Text = "欢迎，" + Session["userName"];
            btn2.Text = "  还书";
            btn3.Text = "个人资料";
        }
        else if (Session["adminName"] != null)
        {
            username.Text = "欢迎，" + Session["adminName"];
            btn2.Text = "管理书籍";
            btn3.Text = "管理用户";
        }
        else
        {
            Response.Redirect("/login.aspx");
        }
    }
    protected void top_loginout_Click(object sender, EventArgs e)
    {
        Session["userName"] = null;
        Session["adminName"] = null;
        Response.Redirect("/login.aspx");
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        String bookName = bookname.Text;
        // 新建数据库连接conn，连接到SQL SERVER数据库
        // 新建DataReader对象
        SqlDataReader dr;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        // 新建Command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT [bookId] FROM [Book] where bookName=@bookName";
        cmd.CommandType = CommandType.Text;
        // 添加查询参数对象,并给参数赋值
        SqlParameter para = new SqlParameter("@bookName", SqlDbType.NChar, 10);
        para.Value = bookName;
        cmd.Parameters.Add(para);
        try
        {
            conn.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Response.Redirect("/borrow.aspx?bookId=" + dr.GetInt32(0));
            }
            else
            {
                Response.Write("<Script Language=JavaScript>alert(\"书本不存在！\")</Script>");
            }
            dr.Close();  //关闭DataReader对象
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
    protected void btn3_Click(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            //个人信息
            Response.Redirect("/userInfo.aspx");
        }
        else if (Session["adminName"] != null)
        {
            //管理用户
            Response.Redirect("/admin_userInfo.aspx");
        }
        else
        {
            Response.Redirect("/login.aspx");
        }
    }
    protected void btn2_Click(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            //还书
            Response.Redirect("/returnBook.aspx");
        }
        else if (Session["adminName"] != null)
        {
            //管理书籍
            Response.Redirect("/admin_books.aspx");
        }
        else
        {
            Response.Redirect("/login.aspx");
        }
    }
}