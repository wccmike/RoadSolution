using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RoadSolution.DBUtils;
namespace RoadSolution.BLL
{
    /// <summary>
    /// 业务逻辑类Problem 的摘要说明。
    /// </summary>
    public class Problem
    {
        private static readonly RoadSolution.DAL.Problem dal = new RoadSolution.DAL.Problem();
        public Problem()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ProblemID)
        {
            return dal.Exists(ProblemID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(RoadSolution.Model.Problem model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RoadSolution.Model.Problem model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ProblemID)
        {
            dal.Delete(ProblemID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RoadSolution.Model.Problem GetModel(string ProblemID)
        {
            return dal.GetModel(ProblemID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public string ListProblemsAllAttrBySearch(string BigClass, string SmallClass, string Title, string UploadDate, string UploadDateMax, string Road, string ProblemID, bool IsHandled, bool IsReviewed)
        {
            DataSet virginData = dal.ListProblemsAllAttrBySearch(BigClass, SmallClass, Title, UploadDate, UploadDateMax, Road, ProblemID, IsHandled, IsReviewed);
            //    for(int i=0;i<virginData.Tables[0].Rows.Count;i++){
            //virginData.Tables[0].Rows[i]["UploadDate"]=virginData.Tables[0].Rows[i]["UploadDate"].ToString().
            //    }
            //          IMPORTANT !!!
            DataSet afterData = RoadSolution.DBUtils.DatasetJsonUtil.ParseDataSetInsideDateTypeToStringType(virginData);
            string json = RoadSolution.DBUtils.DatasetJsonUtil.DatasetToJson(afterData);
            return json;
        }
        public int CountProblemBySearch(string UploadDateBegin, string UploadDateEnd, string IsHandled, string IsReviewed)
        {
            int resultSingle = dal.CountProblemBySearch(UploadDateBegin, UploadDateEnd, IsHandled, IsReviewed);
            return resultSingle;
        }
        public string ListAllAttrAndAuthorname(string BigClass, string SmallClass, string Title, string UploadDate, string Road, int IsHandled, int IsReviewed, string ProblemID)
        {
            DataSet virginDs = dal.ListAllAttrAndAuthornameBySearch(BigClass, SmallClass, Title, UploadDate, Road, IsHandled, IsReviewed, ProblemID);
            //string test1 = RoadSolution.DBUtils.DatasetJsonUtil.DatasetToJson(virginDs);
            string[] col = { "ProblemID", "BigClass", "SmallClass", "Title", "AuthorID", "Address", "Description", "ProblemShot", "UploadDate", "UploadTime", "Road", "Lat", "Lng", "IsHandled", "IsReviewed", "ReviewShot", "HandleDate", "HandleTime", "ReviewDate", "ReviewTime", "Name" };
            DataSet afterDs = RoadSolution.DBUtils.DatasetJsonUtil.DealDateProblem(virginDs,col);
            string json = RoadSolution.DBUtils.DatasetJsonUtil.DatasetToJson(afterDs);
            return json;
        }
        #endregion  成员方法
    }
}


