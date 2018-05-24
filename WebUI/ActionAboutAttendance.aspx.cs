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
    public partial class ActionAboutAttendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string QueryAttendanceInAttendancePage(string Name, string Department, string DateBegin, string DateEnd)
        {
            RoadSolution.BLL.Attendance attBll = new RoadSolution.BLL.Attendance();
            string s = attBll.ListAllAttrNUserinfoBySearch(Name, Department, DateBegin, DateEnd);
            return s;
        }
    }
}