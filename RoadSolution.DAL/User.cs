using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RoadSolution.DBUtils;

namespace RoadSolution.DAL
{
    /// <summary>
    /// 数据访问类User。
    /// </summary>
    public class User
    {
        public User()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("UserID", "User");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from User where UserID='" + UserID + "'");
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
        public string Add(RoadSolution.Model.User model)
        {
            //model.UserID = GetMaxId().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [User](");
            strSql.Append("UserID,TypeID,Username,Password");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + model.UserID + "',");
            strSql.Append("'" + model.TypeID + "',");
            strSql.Append("'" + model.Username + "',");
            strSql.Append("'" + model.Password + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
            return model.UserID;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RoadSolution.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update User set ");
            strSql.Append("TypeID='" + model.TypeID + "',");
            strSql.Append("Username='" + model.Username + "',");
            strSql.Append("Password='" + model.Password + "'");
            strSql.Append(" where UserID='" + model.UserID + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete User ");
            strSql.Append(" where UserID='" + UserID + "'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RoadSolution.Model.User GetModel(string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from User ");
            strSql.Append(" where UserID='" + UserID + "'");
            RoadSolution.Model.User model = new RoadSolution.Model.User();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            model.UserID = UserID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.TypeID = ds.Tables[0].Rows[0]["TypeID"].ToString();
                model.Username = ds.Tables[0].Rows[0]["Username"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
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
            strSql.Append("select * from User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by UserID ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 用名字+密码+账户类型，查用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public RoadSolution.Model.User GetByNamePwdTypeid(string name, string pwd, string typeid)
        {
            string strSql = String.Format(
                "select * from [User] where [Username]='{0}' and [Password]='{1}' and [TypeID]='{2}'",
                name, pwd, typeid
                );
            RoadSolution.Model.User u = new RoadSolution.Model.User();
            DataSet ds = DbHelperSQL.Query(strSql);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            u.Username = ds.Tables[0].Rows[0]["Username"].ToString();
            u.Password = ds.Tables[0].Rows[0]["Password"].ToString();
            u.UserID = ds.Tables[0].Rows[0]["UserID"].ToString();
            u.TypeID = ds.Tables[0].Rows[0]["TypeID"].ToString();
            return u;

        }
        /// <summary>
        /// 根据搜关键词列岀USER的结果集
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="TypeID"></param>
        /// <param name="Road"></param>
        /// <returns></returns>
        public DataSet ListByKeyword(string Name, string TypeID, string Road)
        {
            string strSql = "SELECT u.UserID, ut.TypeID, Username, Password, Department , Road, Name, Gender, Photo," +
                " Age , WorkID , TypeName FROM [User] u, [Userinfo] ui,[Usertype] ut WHERE u.UserID=ui.UserID AND ut.TypeID=u.TypeID ";
            //若用户INPUT了哪项，加哪项约束
            if (!"".Equals(Name))
                strSql += "	AND Name LIKE '%" + Name + "%'";
            if (!"".Equals(Road))
                strSql += "	AND Road LIKE '%" + Road + "%'";
            if (!"-1".Equals(TypeID))
                strSql += "	AND ut.TypeID = '" + TypeID + "'";
            DataSet result = DbHelperSQL.Query(strSql);
            if (result == null)
                return null;
            return result;
        }
        public string GetPasswordByUserId(string UserId)
        {
            string strSql = String.Format("SELECT Password FROM [User] WHERE UserID='{0}'", UserId);
            string result = DbHelperSQL.GetSingle(strSql).ToString();
            return result;
        }
        public void UpdatePasswordByUserId(string UserId, string Password)
        {
            string strSql = String.Format("UPDATE [User] SET Password='{0}' WHERE UserID='{1}'", Password, UserId);
            DbHelperSQL.ExecuteSql(strSql);
        }
        #endregion  成员方法
    }
}


