using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //把JSON对象转为USER对象
                System.Web.Script.Serialization.JavaScriptSerializer jss = new
                    System.Web.Script.Serialization.JavaScriptSerializer();
                string userjson = Session["userJSON"].ToString();
                //JavaScriptSerializer的反序列化函数
                RoadSolution.Model.User user = jss.Deserialize<RoadSolution.Model.User>(userjson);
                //USERNAME发给页面的LABLE
                LblUsername.Text = user.Username;
            }
        }

        protected void HlkLogout_Unload(object sender, EventArgs e)
        {
            Session.Abandon();//清空session
        }
    }
}