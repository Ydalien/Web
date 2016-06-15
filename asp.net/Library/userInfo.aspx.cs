using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 新建数据库连接conn，连接到SQL SERVER数据库
        // 新建DataReader对象
        SqlDataReader dr;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        // 新建Command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM [User] where userId=@userId";
        cmd.CommandType = CommandType.Text;
        // 添加查询参数对象,并给参数赋值
        SqlParameter para = new SqlParameter("@userId", SqlDbType.Int, 10);
        para.Value = Convert.ToInt32(Session["userId"]);
        cmd.Parameters.Add(para);
        try
        {
            conn.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                label_account.Text = dr.GetString(1);
                label_password.Text = dr.GetString(2);
                label_info.Text = dr.GetString(3);


            }
            else
            {
                Response.Write("<Script Language=JavaScript>alert(\"用户不存在！\")</Script>");
                Response.Redirect("/login.aspx");
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
        Response.Redirect("/main.aspx");
    }
    protected void top_loginout_Click(object sender, EventArgs e)
    {
        Session["userName"] = null;
        Session["adminName"] = null;
        Response.Redirect("/login.aspx");
    }

}