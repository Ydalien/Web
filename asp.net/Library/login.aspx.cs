using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
    }
    protected void login_btn_Click(object sender, EventArgs e)
    {
        //获取用户在页面上的输入
        string userName = login_username.Text.Trim();	
        string userPassWord = login_password.Text.Trim();

        // 新建数据库连接conn，连接到SQL SERVER数据库
        // 新建DataReader对象
        SqlDataReader dr;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        // 新建Command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT [userPassWord],[userId] FROM [User] where userName=@userName";
        cmd.CommandType = CommandType.Text;
        // 添加查询参数对象,并给参数赋值
        SqlParameter para = new SqlParameter("@userName", SqlDbType.NChar, 12);
        para.Value = userName;
        cmd.Parameters.Add(para);
        // 打开conn连接，检索User表的userPassWord字段
        try   
        {
            conn.Open();
            dr = cmd.ExecuteReader();
            //如果用户存在
            if (dr.Read())  
            {   // 如果密码正确，显示登录成功
                if (dr.GetString(0).Trim() == userPassWord)
                {   // 登录成功后记下该用户登录名，以便后续功能使用
                    Session.Add("userName", userName);
                    Session.Add("userId", Convert.ToString(dr.GetInt32(1)));
                    Response.Redirect("/main.aspx");
                }
                else		
                {
                    //如果密码错误，给出提示
                    Response.Write("<Script Language=JavaScript>alert(\"密码错误，请重新输入密码！\")</Script>");
                }
            }
            else  //如果用户为管理员
            {
                dr.Close();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "SELECT [adminPassWord] FROM [Admin] where adminName=@userName";
                cmd2.CommandType = CommandType.Text;
                //给参数赋值
                SqlParameter para2 = new SqlParameter("@userName", SqlDbType.NChar, 10);
                para2.Value = userName;
                cmd2.Parameters.Add(para2);
                dr = cmd2.ExecuteReader();

                if (dr.Read())
                {   // 如果密码正确，显示登录成功
                    if (dr.GetString(0).Trim() == userPassWord)
                    {   // 登录成功后记下该用户登录名，以便后续功能使用
                        Session.Add("adminName", userName);
                        Response.Redirect("/main.aspx");
                    }
                    else
                    {
                        //如果密码错误，给出提示
                        Response.Write("<Script Language=JavaScript>alert(\"密码错误，请重新输入密码！\")</Script>");
                    }
                }
                else  //如果用户不存在
                {
                    Response.Write("<Script Language=JavaScript>alert(\"对不起，用户不存在！\")</Script>");
                }

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