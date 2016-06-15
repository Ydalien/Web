using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class borrow : System.Web.UI.Page
{
    protected int bookId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            username.Text = "欢迎，" + Session["userName"];
        }
        else if (Session["adminName"] != null)
        {
            username.Text = "欢迎，" + Session["adminName"];
        }
        else
        {
            Response.Redirect("/login.aspx");
        }
        this.bookId = Convert.ToInt32(Request["bookId"]);
        selectBook(bookId);

    }

    protected void top_loginout_Click(object sender, EventArgs e)
    {
        Session["userName"] = null;
        Session["adminName"] = null;
        Response.Redirect("/login.aspx");
    }

    //初始化书本信息
    public void selectBook(int bookId)
    {
        SqlDataReader dr;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        // 新建Command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM [Book] where bookId=@bookId";
        cmd.CommandType = CommandType.Text;
        // 添加查询参数对象,并给参数赋值
        SqlParameter para = new SqlParameter("@bookId", SqlDbType.Int, 10);
        para.Value = bookId;
        cmd.Parameters.Add(para);
        try
        {
            conn.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                label_bookname.Text = dr.GetString(1);
                label_author.Text = dr.GetString(2);
                label_press.Text = dr.GetString(3);
                label_date.Text = Convert.ToString(dr.GetDateTime(4)).Substring(0,10);
                label_bookInfo.Text = dr.GetString(5);
            }
            else
            {
                Response.Write("<Script Language=JavaScript>alert(\"未知错误！\")</Script>");
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

    protected void borrowBtn_Click(object sender, EventArgs e)
    {
        int userId;
        if (Session["userId"] != null)
        {
            userId = Convert.ToInt32(Session["userId"]);
            borrowBook(bookId, userId);
        }
        else
        {
            Response.Write("<Script Language=JavaScript>alert(\"请勿用管理权限借书\")</Script>");
        }
        
    }

    //借书
    protected void borrowBook(int bookId,int userId)
    {
        SqlDataReader dr;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        // 新建Command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT [borrowId] FROM [Borrow] where bookId=@bookId";
        cmd.CommandType = CommandType.Text;
        // 添加查询参数对象,并给参数赋值
        SqlParameter para = new SqlParameter("@bookId", SqlDbType.Int, 10);
        para.Value = bookId;
        cmd.Parameters.Add(para);
        try
        {
            conn.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Response.Write("<Script Language=JavaScript>alert(\"书被借阅中\")</Script>");
            }
            else
            {
                dr.Close();
                conn.Close();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "Insert into [Borrow]([userId],[bookId],[time]) values(@userId,@bookId,@time)";

                SqlParameter para1 = new SqlParameter("@bookId", SqlDbType.Int, 10);
                para1.Value = bookId;
                cmd2.Parameters.Add(para1);
                SqlParameter para2 = new SqlParameter("@userId", SqlDbType.Int, 10);
                para2.Value = userId;
                cmd2.Parameters.Add(para2);
                SqlParameter para3= new SqlParameter("@time", SqlDbType.Date);
                para3.Value = DateTime.Now;
                cmd2.Parameters.Add(para3);
                conn.Open();   		
                cmd2.ExecuteNonQuery();

                Response.Write("<Script Language=JavaScript>alert(\"成功借阅\")</Script>");
       

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

}