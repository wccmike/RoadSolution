using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RoadSolution.DBUtils
{
    public abstract class DatasetJsonUtil
    {
        /// <summary>
        /// DataSet转换成Json格式
        /// </summary>
        /// <paramname="ds">DataSet</param>
        ///<returns></returns>
        public static string DatasetToJson(DataSet ds, int total = -1)
        {
            StringBuilder json = new StringBuilder();

            foreach (DataTable dt in ds.Tables)
            {
                //{"total":5,"rows":[
                json.Append("{\"total\":");
                if (total == -1)
                {
                    json.Append(dt.Rows.Count);
                }
                else
                {
                    json.Append(total);
                }
                json.Append(",\"rows\":[");
                json.Append(DataTableToJson(dt));
                json.Append("]}");
            }
            return json.ToString();
        }



        /// <summary>
        /// dataTable转换成Json格式
        /// </summary>
        /// <paramname="dt"></param>
        ///<returns></returns>
        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");

                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                if (dt.Columns.Count > 0)
                {
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                }
                jsonBuilder.Append("},");
            }
            if (dt.Rows.Count > 0)
            {
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            }

            return jsonBuilder.ToString();
        }

        public static DataSet ParseDataSetInsideDateTypeToStringType(DataSet argDataSet)
        {
            DataSet dsResultFinal = new DataSet();
            DataTable dtResult = new DataTable();
            
            //克隆表结构
            DataTable midData = argDataSet.Tables[0];
            dtResult = midData.Clone();
            foreach (DataColumn col in dtResult.Columns)
            {
                if (col.ColumnName == "UploadDate" || col.ColumnName == "HandleDate" || col.ColumnName == "ReviewDate")
                {
                    //修改列类型
                    col.DataType = typeof(String);
                }
            }
            foreach (DataRow row in midData.Rows)
            {
                DataRow rowNew = dtResult.NewRow();
                string[] sqlColNames = {"ProblemID","BigClass","SmallClass","Title","AuthorID","Address","Description","ProblemShot","UploadDate","UploadTime","Road","Lat","Lng","IsHandled","IsReviewed","ReviewShot","HandleDate","HandleTime","ReviewDate","ReviewTime" };
                for (int i = 0; i < sqlColNames.Length; i++)
                {
                    if (sqlColNames[i] == "UploadDate" || sqlColNames[i] == "HandleDate" || sqlColNames[i] == "ReviewDate")
                    {
                        //修改记录值
                        string strDate = "";

                        if (row[sqlColNames[i]].ToString() != "")
                        {
                            DateTime dt = (DateTime)row[sqlColNames[i]];
                            strDate = dt.ToString("yyyy-MM-dd");
                        }


                        rowNew[sqlColNames[i]] = strDate;
                        continue;
                    }
                    rowNew[sqlColNames[i]] = row[sqlColNames[i]];
                }
                dtResult.Rows.Add(rowNew);
            }
            dsResultFinal.Tables.Add(dtResult.Copy());
            return dsResultFinal;
        }

        public static DataSet DealDateProblem(DataSet argDataSet,string[] arg)
        {
            DataSet dsResultFinal = new DataSet();
            DataTable dtResult = new DataTable();

            //克隆表结构
            DataTable midData = argDataSet.Tables[0];
            dtResult = midData.Clone();
            foreach (DataColumn col in dtResult.Columns)
            {
                if (col.ColumnName == "UploadDate" || col.ColumnName == "HandleDate" || col.ColumnName == "ReviewDate" || col.ColumnName == "Date")
                {
                    //修改列类型
                    col.DataType = typeof(String);
                }
            }
            foreach (DataRow row in midData.Rows)
            {
                DataRow rowNew = dtResult.NewRow();
                //string[] sqlColNames = { "ProblemID", "BigClass", "SmallClass", "Title", "AuthorID", "Address", "Description", "ProblemShot", "UploadDate", "UploadTime", "Road", "Lat", "Lng", "IsHandled", "IsReviewed", "ReviewShot", "HandleDate", "HandleTime", "ReviewDate", "ReviewTime" };
                for (int i = 0; i < arg.Length; i++)
                {
                    if (arg[i] == "UploadDate" || arg[i] == "HandleDate" || arg[i] == "ReviewDate" || arg[i] == "Date")
                    {
                        //修改记录值
                        string strDate = "";

                        if (row[arg[i]].ToString() != "")
                        {
                            DateTime dt = (DateTime)row[arg[i]];
                            strDate = dt.ToString("yyyy-MM-dd");
                        }


                        rowNew[arg[i]] = strDate;
                        continue;
                    }
                    rowNew[arg[i]] = row[arg[i]];
                }
                dtResult.Rows.Add(rowNew);
            }
            dsResultFinal.Tables.Add(dtResult.Copy());
            return dsResultFinal;
        }
    }
}
