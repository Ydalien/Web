using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class returnBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            InitData();
            if (Request["bookId"] != null)
            {
                rebook(Request["bookId"]);
            }
        
    }

    // 按时间降序，读取借书数据
    private void InitData()   
    {    // 新建数据库连接conn，连接到SQL SERVER数据库
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        DataSet ds = new DataSet(); // 新建DataSet对象
        SqlDataAdapter da = new SqlDataAdapter("SELECT Borrow.borrowId,Borrow.bookId,Borrow.time,Book.bookName FROM Borrow JOIN Book ON Borrow.bookId=Book.bookId WHERE Borrow.userId="+Session["userId"], conn);
        conn.Open(); // 打开数据库连接
        da.Fill(ds); // 将检索的记录行填充到DataSet对象ds中
        conn.Close(); // 关闭数据库连接
        books.DataSource = ds;  //设置数据源
        books.DataBind();   //绑定数据源
        if (ds == null)
        {
            info.Text = "没有记录";
        }
        else
        {
            info.Text = "";
        }
        
    }

    private void rebook(string bookId)
    {

        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        // 新建Command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "DELETE FROM Borrow WHERE bookId="+bookId+" AND userId="+Session["userId"];
        cmd.CommandType = CommandType.Text;
        try
        {
            conn.Open(); 
            cmd.ExecuteNonQuery();
            Response.Redirect("/main.aspx");
  
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





    protected void borrowBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("/main.aspx");
    }
    protected void top_loginout_Click(object sender, EventArgs e)
    {
        Session["userName"] = null;
        Session["adminName"] = null;
        Response.Redirect("/login.aspx");
    }



}