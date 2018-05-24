using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoadSolution.DBUtils;
using System.Data;
namespace RoadSolution.DAL
{
    public class Userinfo
	{
		public Userinfo()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID("UserID", "Userinfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Userinfo where UserID='"+UserID+"'");
			object obj=DbHelperSQL.GetSingle(strSql.ToString());
			int cmdresult;
			if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
			{
				cmdresult=0;
			}
			else
			{
				cmdresult=int.Parse(obj.ToString());
			}
			if(cmdresult==0)
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
		public string Add(RoadSolution.Model.Userinfo model)
		{
            model.UserID = GetMaxId().ToString();
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Userinfo(");
			strSql.Append("UserID,Department,Road,Name,Gender,Photo,Age,WorkID");
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append("'"+model.UserID+"',");
			strSql.Append("'"+model.Department+"',");
			strSql.Append("'"+model.Road+"',");
			strSql.Append("'"+model.Name+"',");
			strSql.Append("'"+model.Gender+"',");
			strSql.Append("'"+model.Photo+"',");
			strSql.Append(""+model.Age+",");
			strSql.Append("'"+model.WorkID+"'");
			strSql.Append(")");
			DbHelperSQL.ExecuteSql(strSql.ToString());
			return model.UserID;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(RoadSolution.Model.Userinfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Userinfo set ");
			strSql.Append("Department='"+model.Department+"',");
			strSql.Append("Road='"+model.Road+"',");
			strSql.Append("Name='"+model.Name+"',");
			strSql.Append("Gender='"+model.Gender+"',");
			strSql.Append("Photo='"+model.Photo+"',");
			strSql.Append("Age="+model.Age+",");
			strSql.Append("WorkID='"+model.WorkID+"'");
			strSql.Append(" where UserID='"+model.UserID+"'");
			DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string UserID)
		{
				StringBuilder strSql=new StringBuilder();
				strSql.Append("delete Userinfo ");
				strSql.Append(" where UserID='"+UserID+"'");
				DbHelperSQL.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public RoadSolution.Model.Userinfo GetModel(string UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from Userinfo ");
			strSql.Append(" where UserID='"+UserID+"'");
			RoadSolution.Model.Userinfo model=new RoadSolution.Model.Userinfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			model.UserID=UserID;
			if(ds.Tables[0].Rows.Count>0)
			{
				model.Department=ds.Tables[0].Rows[0]["Department"].ToString();
				model.Road=ds.Tables[0].Rows[0]["Road"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Gender=ds.Tables[0].Rows[0]["Gender"].ToString();
				model.Photo=ds.Tables[0].Rows[0]["Photo"].ToString();
				if(ds.Tables[0].Rows[0]["Age"].ToString()!="")
				{
					model.Age=int.Parse(ds.Tables[0].Rows[0]["Age"].ToString());
				}
				model.WorkID=ds.Tables[0].Rows[0]["WorkID"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from Userinfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by UserID ");
			return DbHelperSQL.Query(strSql.ToString());
		}
		#endregion  成员方法
	}



}
