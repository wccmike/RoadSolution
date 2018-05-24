using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class recheckupload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            string pid = Request.QueryString["ProblemID"];

            //FupPhoto
            //判断是否有待上船的文件
            if (FupPhoto.HasFile)
            {
                //设置文件保存的路径
                string strPath = Server.MapPath("~/upload/recheckPhoto/")  + Guid.NewGuid().ToString("N") + FupPhoto.FileName;
                //
                //保存文件
                FupPhoto.SaveAs(strPath);

                //pid
                RoadSolution.BLL.Problem problemBll = new RoadSolution.BLL.Problem();
                RoadSolution.Model.Problem problem= problemBll.GetModel(pid);
                problem.ReviewShot = strPath;
                problemBll.Update(problem);
            }
            
        }
    }
}