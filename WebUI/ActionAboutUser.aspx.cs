using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebUI
{
    public partial class ActionAboutUser : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    string input = Request.QueryString["data"];
            //    System.Web.Script.Serialization.JavaScriptSerializer jss = new
            //        System.Web.Script.Serialization.JavaScriptSerializer();
            //     RoadSolution.Model.User user = jss.Deserialize<RoadSolution.Model.User>(input);
            //    response.write "function(user.Username,user.Pwd,user.typeid)" 
            //     Type t = user.GetType();
            //     MethodInfo method = t.GetMethod("");
            //    method.Invoke(userBLL,)
            //}

            
        }

        [WebMethod]
        public static string QueryPerson(string Name, string TypeID, string Road)
        {
            //TODO
            //处理业务逻辑
            RoadSolution.BLL.User userbll = new RoadSolution.BLL.User();
            string resultjson = userbll.ListJsonByKeyword(Name, TypeID, Road);
            //RESPONSE
            return resultjson;
        }

        //[WebMethod]
        //public static string ChangePassword(string OldPassword, string Password)
        //{
        //    //RoadSolution.BLL.User userbll = new RoadSolution.BLL.User();
        //    //bool isSuccess = userbll.UploadUserPassword(Session["userJSON"].UserId, OldPassword, Password);
        //    //if (isSuccess)
        //    //{
        //    //    return "{\"msg\":\"Success\"}";
        //    //}
        //    //return "{\"msg\":\"Fail\"}";
        //    return null;
        //}

        [WebMethod]
        public static string QueryProblemInRecheckPage(string BigClass,string SmallClass,string Title,string UploadDate,string Road,string ProblemID){
            RoadSolution.BLL.Problem problembll = new RoadSolution.BLL.Problem();
            string json = problembll.ListProblemsAllAttrBySearch(BigClass, SmallClass, Title, UploadDate, UploadDate, Road, ProblemID, true, false);
            
            
            //System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //RoadSolution.Model.Problem problem = jss.Deserialize<RoadSolution.Model.Problem>(json);
            //problem.UploadDate 
            return json;
        }
        [WebMethod]
        public static int QueryProblemInRangeStatPage(string UploadDateBegin, string UploadDateEnd, string IsHandled, string IsReviewed)
        {
            RoadSolution.BLL.Problem problembll = new RoadSolution.BLL.Problem();
            int resultSingle = problembll.CountProblemBySearch(UploadDateBegin, UploadDateEnd, IsHandled, IsReviewed);
            return resultSingle;

        }
        [WebMethod]
        public static string QueryProblemInProblemQueryPage(string BigClass, string SmallClass, string Title, string UploadDate, string Road, string IsHandled, string IsReviewed, string ProblemID)
        {
            //IsReviewed, string ProblemID
            int intIsReviewed = 0;
            if ("true".Equals(IsReviewed))
                intIsReviewed = 1;
            int intIsHandled = 0;
            if ("true".Equals(IsHandled))
                intIsHandled = 1;
            
            RoadSolution.BLL.Problem problembll = new RoadSolution.BLL.Problem();
            string result = problembll.ListAllAttrAndAuthorname(BigClass, SmallClass, Title, UploadDate, Road, intIsHandled, intIsReviewed, ProblemID);
            return result;
        }
        [WebMethod]
        public static string QueryProblemInProblemDealPage(string BigClass, string SmallClass, string Title, string UploadDate, string Road, string IsHandled, string IsReviewed, string ProblemID)
        {
            int intIsReviewed = 0;
            if ("true".Equals(IsReviewed))
                intIsReviewed = 1;
            int intIsHandled = 0;
            if ("true".Equals(IsHandled))
                intIsHandled = 1;
            RoadSolution.BLL.Problem problembll = new RoadSolution.BLL.Problem();
            string result = problembll.ListAllAttrAndAuthorname(BigClass, SmallClass, Title, UploadDate, Road, intIsHandled, intIsReviewed, ProblemID);
            return result;
        }
        //[WebMethod(EnableSession = true)]
        //public static string Test1()
        //{
        //    string se = HttpContext.Current.Session["userJSON"].ToString();
            
        //    return se;
        //}
        [WebMethod]
        public static void RegisterUser(string Username, string Password, string TypeID)
        {
            RoadSolution.BLL.User ubll = new RoadSolution.BLL.User();
            RoadSolution.Model.User u = new RoadSolution.Model.User();
            u.Username = Username;
            u.Password = Password;
            u.TypeID = TypeID;
            u.UserID=Guid.NewGuid().ToString();
            ubll.Add(u);
        }
    }
}