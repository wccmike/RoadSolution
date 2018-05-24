using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Collections;

namespace WebUI
{
    /// <summary>
    /// ActionAboutUser1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class ActionAboutUser1 : System.Web.Services.WebService
    {

        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}
        //[WebMethod]
        //public string QueryPerson(string Name, string TypeID, string Road)
        //{
        //    //TODO
        //    //处理业务逻辑
        //    RoadSolution.BLL.User userbll = new RoadSolution.BLL.User();
        //    string resultjson = userbll.ListJsonByKeyword(Name, TypeID, Road);
        //    //RESPONSE
        //    return resultjson;
        //}

        //[WebMethod]
        //public string ChangePassword(string OldPassword, string Password)
        //{
        //    //RoadSolution.BLL.User userbll = new RoadSolution.BLL.User();
        //    //string ujson = Session["userJSON"].ToString();
        //    //System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
        //    //RoadSolution.Model.User user = jss.Deserialize<RoadSolution.Model.User>(ujson);
        //    //bool isSuccess = userbll.UploadUserPassword(user.UserID, OldPassword, Password);
        //    //if (isSuccess)
        //    //{
        //    //    return "Success";
        //    //}
        //    //return "Fail";

        //    //return Session["userJSON"].ToString();
        //    return "te";
        //}

        
    }
}
