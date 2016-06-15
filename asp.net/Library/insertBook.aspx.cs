using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class insertBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
    }
    protected void top_loginout_Click(object sender, EventArgs e)
    {
        Session["userName"] = null;
        Session["adminName"] = null;
        Response.Redirect("/login.aspx");
    }

    protected void insertBooks_Click(object sender, EventArgs e)
    {
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
        para.Value = bookNameTextBox.Text;
        cmd.Parameters.Add(para);
        try
        {
            conn.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Response.Write("<Script Language=JavaScript>alert(\"书本已存在\")</Script>");
            }
            else
            {
                dr.Close();
                conn.Close();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "Insert into [Book]([bookName],[auhor],[pree],[date],[bookInfo]) values(@bookName,@author,@press,@date,@bookInfo)";

                SqlParameter para1 = new SqlParameter("@bookName", SqlDbType.NChar, 10);
                para1.Value = bookNameTextBox.Text;
                cmd2.Parameters.Add(para1);
                SqlParameter para2 = new SqlParameter("@author", SqlDbType.NChar, 10);
                para2.Value = authorTextBox.Text;
                cmd2.Parameters.Add(para2);
                SqlParameter para3 = new SqlParameter("@press", SqlDbType.NChar, 10);
                para3.Value = pressTextBox.Text;
                cmd2.Parameters.Add(para3);
                SqlParameter para4 = new SqlParameter("@date", SqlDbType.Date);
                para4.Value = Convert.ToDateTime(dateTextBox.Text);
                cmd2.Parameters.Add(para4);
                SqlParameter para5 = new SqlParameter("@bookInfo", SqlDbType.NChar, 10);
                para5.Value = bookInfoTextBox.Text;
                cmd2.Parameters.Add(para5);
                conn.Open();
                cmd2.ExecuteNonQuery();

                Response.Write("<Script Language=JavaScript>alert(\"成功添加\")</Script>");


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