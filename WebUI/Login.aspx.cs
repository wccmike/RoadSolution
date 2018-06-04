using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using RoadSolution.BLL;

namespace WebUI
{
    public partial class Login : System.Web.UI.Page
    {
        RoadSolution.BLL.User userbll = new RoadSolution.BLL.User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [Usertype]", con);
                    con.Open();
                    DLType.DataTextField = "TypeName";
                    DLType.DataValueField = "TypeID";
                    DLType.DataSource = cmd.ExecuteReader();
                    DLType.DataBind();
                    ListItem li = new ListItem("选一个账户类型", "-1");
                    DLType.Items.Insert(0, li);
                }
                //string jsondata = "{\"msg\":\"aname\"}";
                //Response.Write(jsondata);
                //Response.End();
            }
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //存USERNAME,PWD,TYPEID
            string strname = uname.Text.Trim();
            string strpwd = pwd.Text.Trim();
            string tID = DLType.SelectedValue;
            //执行LOGIN,判断是否取到值
            RoadSolution.Model.User u = userbll.Login(strname, strpwd, tID);
            if (u == null)
            {
                parname.InnerHtml = "无用户或密码错误";
                return;
            }
            //把USER对象转为JSON对象
            System.Web.Script.Serialization.JavaScriptSerializer jss = new 
                System.Web.Script.Serialization.JavaScriptSerializer();
            string ujson = jss.Serialize(u);//JavaScriptSerializer的序列化函数
            //Session["userJSON"] = ujson;
            HttpCookie cookie = new HttpCookie("userJSON");
            cookie.Value = ujson;
            cookie.Expires = DateTime.Now.AddHours(8.0);
            Response.AppendCookie(cookie);
            //string url = "";
            //RoadSolution.DBUtils.PostParseJsonUtil.HttpPost(url, ujson);
            Response.Redirect("~/main.html");

        }
    }
}