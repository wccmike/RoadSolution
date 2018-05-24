using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RoadSolution.DBUtils;
using System.Globalization; 
namespace RoadSolution.DAL
{
    /// <summary>
    /// 数据访问类Problem。
    /// </summary>
    public class Problem
    {
        public Problem()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ProblemID", "Problem");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ProblemID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Problem where ProblemID='" + ProblemID + "'");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(RoadSolution.Model.Problem model)
        {
            model.ProblemID = GetMaxId().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Problem(");
            strSql.Append("ProblemID,BigClass,SmallClass,Title,AuthorID,Address,Description,ProblemShot,UploadDate,UploadTime,Road,Lat,Lng,IsHandled,IsReviewed,ReviewShot,HandleDate,HandleTime,ReviewDate,ReviewTime");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + model.ProblemID + "',");
            strSql.Append("'" + model.BigClass + "',");
            strSql.Append("'" + model.SmallClass + "',");
            strSql.Append("'" + model.Title + "',");
            strSql.Append("'" + model.AuthorID + "',");
            strSql.Append("'" + model.Address + "',");
            strSql.Append("'" + model.Description + "',");
            strSql.Append("'" + model.ProblemShot + "',");
            strSql.Append("'" + model.UploadDate + "',");
            strSql.Append("'" + model.UploadTime + "',");
            strSql.Append("'" + model.Road + "',");
            strSql.Append("" + model.Lat + ",");
            strSql.Append("" + model.Lng + ",");
            strSql.Append("" + model.IsHandled + ",");
            strSql.Append("" + model.IsReviewed + ",");
            strSql.Append("'" + model.ReviewShot + "',");
            strSql.Append("'" + model.HandleDate + "',");
            strSql.Append("'" + model.HandleTime + "',");
            strSql.Append("'" + model.ReviewDate + "',");
            strSql.Append("'" + model.ReviewTime + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
            return model.ProblemID;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RoadSolution.Model.Problem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Problem set ");
            strSql.Append("BigClass='" + model.BigClass + "',");
            strSql.Append("SmallClass='" + model.SmallClass + "',");
            strSql.Append("Title='" + model.Title + "',");
            strSql.Append("AuthorID='" + model.AuthorID + "',");
            strSql.Append("Address='" + model.Address + "',");
            strSql.Append("Description='" + model.Description + "',");
            strSql.Append("ProblemShot='" + model.ProblemShot + "',");
            strSql.Append("UploadDate='" + model.UploadDate + "',");
            strSql.Append("UploadTime='" + model.UploadTime + "',");
            strSql.Append("Road='" + model.Road + "',");
            strSql.Append("Lat=" + model.Lat + ",");
            strSql.Append("Lng=" + model.Lng + ",");

            string strIsHandled = model.IsHandled ? "1" : "0";
            string strIsReviewed = model.IsReviewed ? "1" : "0";

            strSql.Append("IsHandled=" + strIsHandled + ",");


            strSql.Append("IsReviewed=" + strIsReviewed + ",");
            strSql.Append("ReviewShot='" + model.ReviewShot + "',");
            //string strHandleTime = model.HandleTime.ToString()=="0001/1/1 0:00:00"? "":model.HandleTime.ToString("yyyy-MM-dd HH-mm-ss.fff") ;
            //string strReviewTime = model.ReviewTime.ToString() == "0001/1/1 0:00:00" ? "" : model.ReviewTime.ToString("yyyy-MM-dd HH-mm-ss.fff");
            if (model.HandleDate!="")
                strSql.Append("HandleDate='" + model.HandleDate + "',");
            if (model.HandleTime.ToString() != "0001/1/1 0:00:00")
                strSql.Append("HandleTime='" + model.HandleTime + "',");
            if (model.ReviewDate != "")
                strSql.Append("ReviewDate='" + model.ReviewDate + "',");
            if (model.ReviewTime.ToString() != "0001/1/1 0:00:00")
                strSql.Append("ReviewTime='" + model.ReviewTime + "',");
            strSql.Remove(strSql.Length-1, 1);
            strSql.Append(" where ProblemID='" + model.ProblemID + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ProblemID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Problem ");
            strSql.Append(" where ProblemID='" + ProblemID + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RoadSolution.Model.Problem GetModel(string ProblemID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Problem ");
            strSql.Append(" where ProblemID='" + ProblemID + "'");
            RoadSolution.Model.Problem model = new RoadSolution.Model.Problem();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            model.ProblemID = ProblemID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.BigClass = ds.Tables[0].Rows[0]["BigClass"].ToString();
                model.SmallClass = ds.Tables[0].Rows[0]["SmallClass"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.AuthorID = ds.Tables[0].Rows[0]["AuthorID"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.ProblemShot = ds.Tables[0].Rows[0]["ProblemShot"].ToString();
                model.UploadDate = ds.Tables[0].Rows[0]["UploadDate"].ToString();
                if (ds.Tables[0].Rows[0]["UploadTime"].ToString() != "")
                {
                    model.UploadTime = DateTime.Parse(ds.Tables[0].Rows[0]["UploadTime"].ToString());
                }
                model.Road = ds.Tables[0].Rows[0]["Road"].ToString();
                if (ds.Tables[0].Rows[0]["Lat"].ToString() != "")
                {
                    model.Lat = decimal.Parse(ds.Tables[0].Rows[0]["Lat"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Lng"].ToString() != "")
                {
                    model.Lng = decimal.Parse(ds.Tables[0].Rows[0]["Lng"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsHandled"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsHandled"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsHandled"].ToString().ToLower() == "true"))
                    {
                        model.IsHandled = true;
                    }
                    else
                    {
                        model.IsHandled = false;
                    }
                }

                if (ds.Tables[0].Rows[0]["IsReviewed"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsReviewed"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsReviewed"].ToString().ToLower() == "true"))
                    {
                        model.IsReviewed = true;
                    }
                    else
                    {
                        model.IsReviewed = false;
                    }
                }

                model.ReviewShot = ds.Tables[0].Rows[0]["ReviewShot"].ToString();
                model.HandleDate = ds.Tables[0].Rows[0]["HandleDate"].ToString();
                if (ds.Tables[0].Rows[0]["HandleTime"].ToString() != "")
                {
                    model.HandleTime = DateTime.Parse(ds.Tables[0].Rows[0]["HandleTime"].ToString());
                }
                model.ReviewDate = ds.Tables[0].Rows[0]["ReviewDate"].ToString();
                if (ds.Tables[0].Rows[0]["ReviewTime"].ToString() != "")
                {
                    model.ReviewTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReviewTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Problem ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ProblemID ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet ListProblemsAllAttrBySearch(string BigClass, string SmallClass, string Title, string UploadDate, string UploadDateMax, string Road, string ProblemID, bool IsHandled, bool IsReviewed)
        {
            string strSql = "SELECT * FROM Problem WHERE 1=1  ";
            if (!"-1".Equals(BigClass))
                strSql += " AND BigClass='" + BigClass + "'";
            if (!"-1".Equals(SmallClass))
                strSql += " AND SmallClass='" + SmallClass + "'";
            if (!"".Equals(Title))
                strSql += " AND Title LIKE '%" + Title + "%'";
            if (!"".Equals(UploadDate))
                strSql += " AND '" + UploadDate + "'<=cast(UploadDate AS varchar(20))";
            if (!"".Equals(UploadDateMax))
                strSql += " AND cast(UploadDate AS varchar(20))<='" + UploadDateMax + "'";
            if (!"".Equals(Road))
                strSql += " AND Road LIKE '%" + Road + "%'";
            if (!"".Equals(ProblemID))
                strSql += " AND ProblemID LIKE '%" + ProblemID + "%'";
            if (IsHandled)
            {
                strSql += " AND IsHandled=1";
            }
            else
            {
                strSql += " AND IsHandled=0";
            }
            if (IsReviewed)
            {
                strSql += " AND IsReviewed=1";
            }
            else
            {
                strSql += " AND IsReviewed=0";
            }
            DataSet ds = DbHelperSQL.Query(strSql);
            //DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            //dtFormat.ShortDatePattern = "yyyy/MM/dd HH:mm:ss";
            //    for(int i=0;i<ds.Tables[0].Rows.Count;i++){
            //       string beforeData = ds.Tables[0].Rows[i]["UploadDate"].ToString();
            //       DateTime dt = Convert.ToDateTime(beforeData, dtFormat);
            //       string strdt = dt.ToString("yyyy-MM-dd");
            //       ds.Tables[0].Rows[i]["UploadDate"] = (Object)strdt;
            //       Object test2 = (Object)strdt;
            //       Object test = ds.Tables[0].Rows[i]["UploadDate"];
            //       Console.WriteLine(test.ToString().Substring(0,10));
            //    }
            return ds;
        }
        public int CountProblemBySearch(string UploadDateBegin, string UploadDateEnd, string IsHandled, string IsReviewed)
        {
            int boolIsHandled = IsHandled == "true" ? 1 : 0;
            int boolIsReviewed = IsReviewed == "true" ? 1 : 0;
            string strSql = " SELECT count(*) FROM [haha2].[dbo].[Problem] WHERE 1=1 ";
            if (!"".Equals(UploadDateBegin))
            {
                strSql+=" AND '"+UploadDateBegin+"'<=cast(UploadDate AS varchar(20))";
            }
            if (!"".Equals(UploadDateEnd))
            {
                strSql += "  AND cast(UploadDate AS varchar(20))<='" + UploadDateEnd + "'";
            }
            strSql += " AND IsHandled= " + boolIsHandled + "";
            strSql += " AND IsReviewed= " + boolIsReviewed + "";
            int resultSingle = int.Parse(DbHelperSQL.GetSingle(strSql).ToString());
            return resultSingle;

        }
        public DataSet ListAllAttrAndAuthornameBySearch(string BigClass, string SmallClass, string Title, string UploadDate, string Road, int IsHandled, int IsReviewed, string ProblemID)
        {
            string strSql = "SELECT ProblemID, BigClass, SmallClass, Title, AuthorID, Address, Description, ProblemShot, UploadDate, UploadTime, p.Road, Lat, Lng, IsHandled, IsReviewed, ReviewShot, HandleDate, HandleTime, ReviewDate, ReviewTime, Name FROM Problem p, [User] u , Userinfo ui WHERE p.AuthorID=u.UserID AND u.UserID=ui.UserID ";
            if (!"-1".Equals(BigClass))
                strSql += " AND BigClass='" + BigClass + "'";
            if (!"-1".Equals(SmallClass))
                strSql += " AND SmallClass='" + SmallClass + "'";
            if (!"".Equals(Title))
                strSql += " AND Title LIKE '%" + Title + "%'";
            //if (!"".Equals(UploadDate))
            //    strSql += " AND '" + UploadDate + "'<=cast(UploadDate AS varchar(20))";
            if (!"".Equals(UploadDate))
                strSql += " AND '" + UploadDate + "'=cast(UploadDate AS varchar(20))";
            //if (!"".Equals(UploadDateMax))
            //    strSql += " AND cast(UploadDate AS varchar(20))<='" + UploadDateMax + "'";
            if (!"".Equals(Road))
                strSql += " AND p.Road LIKE '%" + Road + "%'";
            if (!"".Equals(ProblemID))
                strSql += " AND ProblemID LIKE '%" + ProblemID + "%'";
            strSql += " AND IsHandled= " + IsHandled + "";
            strSql += " AND IsReviewed= " + IsReviewed + "";
            DataSet ds = DbHelperSQL.Query(strSql);
            return ds;
        }
        #endregion  成员方法
    }
}
