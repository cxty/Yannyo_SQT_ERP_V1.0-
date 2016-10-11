using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Yannyo.Data;
using Yannyo.Config;
using Yannyo.Common;
using Yannyo.Entity;

namespace Yannyo.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        #region  StaffInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsStaffInfo(string sName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbStaffInfo");
            strSql.Append(" where sName=@sName ");
            SqlParameter[] parameters = {
					new SqlParameter("@sName", SqlDbType.VarChar,50)};
            parameters[0].Value = sName;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddStaffInfo(StaffInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbStaffInfo(");
            strSql.Append("sName,sSex,sType,sState,sAppendTime,sTel,sCarID,sEmail,DepartmentsClassID)");
            strSql.Append(" values (");
            strSql.Append("@sName,@sSex,@sType,@sState,@sAppendTime,@sTel,@sCarID,@sEmail,@DepartmentsClassID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sName", SqlDbType.VarChar,50),
					new SqlParameter("@sSex", SqlDbType.Char,2),
					new SqlParameter("@sType", SqlDbType.Int,4),
					new SqlParameter("@sState", SqlDbType.Int,4),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime),
                    new SqlParameter("@sTel", SqlDbType.VarChar,50),
                                        new SqlParameter("@sCarID", SqlDbType.VarChar,50),
                                        new SqlParameter("@sEmail", SqlDbType.VarChar,50),
                                        new SqlParameter("@DepartmentsClassID", SqlDbType.Int,4),};
            parameters[0].Value = model.sName;
            parameters[1].Value = model.sSex;
            parameters[2].Value = model.sType;
            parameters[3].Value = model.sState;
            parameters[4].Value = model.sAppendTime;
            parameters[5].Value = model.sTel;
            parameters[6].Value = model.sCarID;
            parameters[7].Value = model.sEmail;
            parameters[8].Value = model.DepartmentsClassID;

            object obj = DbHelper.ExecuteScalar(CommandType.Text,strSql.ToString(), parameters);
            if (obj == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateStaffInfo(StaffInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbStaffInfo set ");
            strSql.Append("sName=@sName,");
            strSql.Append("sSex=@sSex,");
            strSql.Append("sType=@sType,");
            strSql.Append("sState=@sState,");
            strSql.Append("sAppendTime=@sAppendTime,");
            strSql.Append("sTel=@sTel,");
            strSql.Append("sCarID=@sCarID,");
            strSql.Append("sEmail=@sEmail,");
            strSql.Append("DepartmentsClassID=@DepartmentsClassID");
            strSql.Append(" where StaffID=@StaffID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@sName", SqlDbType.VarChar,50),
					new SqlParameter("@sSex", SqlDbType.Char,2),
					new SqlParameter("@sType", SqlDbType.Int,4),
					new SqlParameter("@sState", SqlDbType.Int,4),
					new SqlParameter("@sAppendTime", SqlDbType.DateTime),
                    new SqlParameter("@sTel", SqlDbType.VarChar,50),
                                        new SqlParameter("@sCarID", SqlDbType.VarChar,50),
                                        new SqlParameter("@sEmail", SqlDbType.VarChar,50),
                                        new SqlParameter("@DepartmentsClassID", SqlDbType.Int,4),};
            parameters[0].Value = model.StaffID;
            parameters[1].Value = model.sName;
            parameters[2].Value = model.sSex;
            parameters[3].Value = model.sType;
            parameters[4].Value = model.sState;
            parameters[5].Value = model.sAppendTime;
            parameters[6].Value = model.sTel;
            parameters[7].Value = model.sCarID;
            parameters[8].Value = model.sEmail;
            parameters[9].Value = model.DepartmentsClassID;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteStaffInfo(int StaffID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStaffInfo ");
            strSql.Append(" where StaffID=@StaffID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4)};
            parameters[0].Value = StaffID;

            DbHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteStaffInfo(string StaffID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStaffInfo ");
            strSql.Append(" where StaffID in(" + StaffID + ")");

            DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public StaffInfo GetStaffInfoModel(int StaffID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StaffID,sName,sSex,sType,sState,sAppendTime,sTel,sCarID,sEmail,DepartmentsClassID,(select dClassName from tbDepartmentsClassInfo where DepartmentsClassID=.tbStaffInfo.DepartmentsClassID) as DepartmentsClassName from tbStaffInfo ");
            strSql.Append(" where StaffID=@StaffID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4)};
            parameters[0].Value = StaffID;

            StaffInfo model = new StaffInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DepartmentsClassID"].ToString() != "")
                {
                    model.DepartmentsClassID = int.Parse(ds.Tables[0].Rows[0]["DepartmentsClassID"].ToString());
                }
                model.DepartmentsClassName = ds.Tables[0].Rows[0]["DepartmentsClassName"].ToString();
                model.sName = ds.Tables[0].Rows[0]["sName"].ToString();
                model.sSex = ds.Tables[0].Rows[0]["sSex"].ToString();
                model.sTel = ds.Tables[0].Rows[0]["sTel"].ToString();
                model.sCarID = ds.Tables[0].Rows[0]["sCarID"].ToString();
                model.sEmail = ds.Tables[0].Rows[0]["sEmail"].ToString();
                if (ds.Tables[0].Rows[0]["sType"].ToString() != "")
                {
                    model.sType = int.Parse(ds.Tables[0].Rows[0]["sType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sState"].ToString() != "")
                {
                    model.sState = int.Parse(ds.Tables[0].Rows[0]["sState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sAppendTime"].ToString() != "")
                {
                    model.sAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["sAppendTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public StaffInfo GetStaffInfoModelByUserID(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StaffID,sName,sSex,sType,sState,sAppendTime,sTel,sCarID,sEmail,DepartmentsClassID,(select dClassName from tbDepartmentsClassInfo where DepartmentsClassID=.tbStaffInfo.DepartmentsClassID) as DepartmentsClassName from tbStaffInfo ");
            strSql.Append(" where StaffID=(select top 1 StaffID from tbUserInfo where UserID=@UserID ) ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            StaffInfo model = new StaffInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DepartmentsClassID"].ToString() != "")
                {
                    model.DepartmentsClassID = int.Parse(ds.Tables[0].Rows[0]["DepartmentsClassID"].ToString());
                }
                model.DepartmentsClassName = ds.Tables[0].Rows[0]["DepartmentsClassName"].ToString();
                model.sName = ds.Tables[0].Rows[0]["sName"].ToString();
                model.sSex = ds.Tables[0].Rows[0]["sSex"].ToString();
                model.sTel = ds.Tables[0].Rows[0]["sTel"].ToString();
                model.sCarID = ds.Tables[0].Rows[0]["sCarID"].ToString();
                model.sEmail = ds.Tables[0].Rows[0]["sEmail"].ToString();
                if (ds.Tables[0].Rows[0]["sType"].ToString() != "")
                {
                    model.sType = int.Parse(ds.Tables[0].Rows[0]["sType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sState"].ToString() != "")
                {
                    model.sState = int.Parse(ds.Tables[0].Rows[0]["sState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sAppendTime"].ToString() != "")
                {
                    model.sAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["sAppendTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public StaffInfo GetStaffInfoModelByName(string sName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StaffID,sName,sSex,sType,sState,sAppendTime,sTel,sCarID,sEmail,DepartmentsClassID,(select dClassName from tbDepartmentsClassInfo where DepartmentsClassID=.tbStaffInfo.DepartmentsClassID) as DepartmentsClassName from tbStaffInfo ");
            strSql.Append(" where sName=@sName ");
            SqlParameter[] parameters = {
					new SqlParameter("@sName", SqlDbType.VarChar,50)};
            parameters[0].Value = sName;

            StaffInfo model = new StaffInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DepartmentsClassID"].ToString() != "")
                {
                    model.DepartmentsClassID = int.Parse(ds.Tables[0].Rows[0]["DepartmentsClassID"].ToString());
                }
                model.DepartmentsClassName = ds.Tables[0].Rows[0]["DepartmentsClassName"].ToString();
                model.sName = ds.Tables[0].Rows[0]["sName"].ToString();
                model.sSex = ds.Tables[0].Rows[0]["sSex"].ToString();
                model.sTel = ds.Tables[0].Rows[0]["sTel"].ToString();
                model.sCarID = ds.Tables[0].Rows[0]["sCarID"].ToString();
                model.sEmail = ds.Tables[0].Rows[0]["sEmail"].ToString();
                if (ds.Tables[0].Rows[0]["sType"].ToString() != "")
                {
                    model.sType = int.Parse(ds.Tables[0].Rows[0]["sType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sState"].ToString() != "")
                {
                    model.sState = int.Parse(ds.Tables[0].Rows[0]["sState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sAppendTime"].ToString() != "")
                {
                    model.sAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["sAppendTime"].ToString());
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
        public DataSet GetStaffInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StaffID,sName,sSex,sType,sState,sAppendTime,sTel,sCarID,sEmail,DepartmentsClassID,(select dClassName from tbDepartmentsClassInfo where DepartmentsClassID=.tbStaffInfo.DepartmentsClassID) as DepartmentsClassName ");
            strSql.Append(" FROM tbStaffInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text,strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetStaffInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@showFName", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tbStaffInfo";
            parameters[1].Value = "StaffID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName + ",(select dClassName from tbDepartmentsClassInfo where DepartmentsClassID=.tbStaffInfo.DepartmentsClassID) as DepartmentsClassName ";
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "UP_" + BaseConfigs.GetTablePrefix + "GetRecordByPage", parameters);
            if (ds.Tables.Count > 1)
            {
                int total = (int)ds.Tables[0].Rows[0][0];

                if (total % PageSize == 0)
                {
                    pagetotal = total / PageSize;
                }
                else
                {
                    pagetotal = total / PageSize + 1;
                }
                return ds.Tables[1];
            }
            else
            {
                pagetotal = 0;
                return null;
            }
        }

        #endregion  成员方法

        #region StaffDataInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsStaffDataInfo(int StaffID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbStaffDataInfo");
            strSql.Append(" where StaffID=@StaffID");
            SqlParameter[] parameters = {
            	new SqlParameter("@StaffID", SqlDbType.Int,4),
			};
            parameters[0].Value = StaffID;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddStaffDataInfo(StaffDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbStaffDataInfo(");
            strSql.Append("StaffID,sBirthDay,sPolitical,sBirthplace,sHometown,sEducation,sProfessional,sHealth,sHeight,sWeight,sSpecialty,sHobbies,sContactAddress,sPhotos,sEmployment,sCanBeDate,sTreatment)");
            strSql.Append(" values (");
            strSql.Append("@StaffID,@sBirthDay,@sPolitical,@sBirthplace,@sHometown,@sEducation,@sProfessional,@sHealth,@sHeight,@sWeight,@sSpecialty,@sHobbies,@sContactAddress,@sPhotos,@sEmployment,@sCanBeDate,@sTreatment)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@sBirthDay", SqlDbType.VarChar,10),
					new SqlParameter("@sPolitical", SqlDbType.VarChar,50),
					new SqlParameter("@sBirthplace", SqlDbType.VarChar,50),
					new SqlParameter("@sHometown", SqlDbType.VarChar,256),
					new SqlParameter("@sEducation", SqlDbType.VarChar,50),
					new SqlParameter("@sProfessional", SqlDbType.VarChar,50),
					new SqlParameter("@sHealth", SqlDbType.VarChar,50),
					new SqlParameter("@sHeight", SqlDbType.Int,4),
					new SqlParameter("@sWeight", SqlDbType.Int,4),
					new SqlParameter("@sSpecialty", SqlDbType.VarChar,512),
					new SqlParameter("@sHobbies", SqlDbType.VarChar,512),
					new SqlParameter("@sContactAddress", SqlDbType.VarChar,512),
					new SqlParameter("@sPhotos", SqlDbType.VarChar,128),
					new SqlParameter("@sEmployment", SqlDbType.Int,4),
					new SqlParameter("@sCanBeDate", SqlDbType.VarChar,50),
					new SqlParameter("@sTreatment", SqlDbType.Money,8)};
            parameters[0].Value = model.StaffID;
            parameters[1].Value = model.sBirthDay;
            parameters[2].Value = model.sPolitical;
            parameters[3].Value = model.sBirthplace;
            parameters[4].Value = model.sHometown;
            parameters[5].Value = model.sEducation;
            parameters[6].Value = model.sProfessional;
            parameters[7].Value = model.sHealth;
            parameters[8].Value = model.sHeight;
            parameters[9].Value = model.sWeight;
            parameters[10].Value = model.sSpecialty;
            parameters[11].Value = model.sHobbies;
            parameters[12].Value = model.sContactAddress;
            parameters[13].Value = model.sPhotos;
            parameters[14].Value = model.sEmployment;
            parameters[15].Value = model.sCanBeDate;
            parameters[16].Value = model.sTreatment;

            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateStaffDataInfo(StaffDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbStaffDataInfo set ");
            strSql.Append("StaffID=@StaffID,");
            strSql.Append("sBirthDay=@sBirthDay,");
            strSql.Append("sPolitical=@sPolitical,");
            strSql.Append("sBirthplace=@sBirthplace,");
            strSql.Append("sHometown=@sHometown,");
            strSql.Append("sEducation=@sEducation,");
            strSql.Append("sProfessional=@sProfessional,");
            strSql.Append("sHealth=@sHealth,");
            strSql.Append("sHeight=@sHeight,");
            strSql.Append("sWeight=@sWeight,");
            strSql.Append("sSpecialty=@sSpecialty,");
            strSql.Append("sHobbies=@sHobbies,");
            strSql.Append("sContactAddress=@sContactAddress,");
            strSql.Append("sPhotos=@sPhotos,");
            strSql.Append("sEmployment=@sEmployment,");
            strSql.Append("sCanBeDate=@sCanBeDate,");
            strSql.Append("sTreatment=@sTreatment");
            strSql.Append(" where StaffDataID=@StaffDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@sBirthDay", SqlDbType.VarChar,10),
					new SqlParameter("@sPolitical", SqlDbType.VarChar,50),
					new SqlParameter("@sBirthplace", SqlDbType.VarChar,50),
					new SqlParameter("@sHometown", SqlDbType.VarChar,256),
					new SqlParameter("@sEducation", SqlDbType.VarChar,50),
					new SqlParameter("@sProfessional", SqlDbType.VarChar,50),
					new SqlParameter("@sHealth", SqlDbType.VarChar,50),
					new SqlParameter("@sHeight", SqlDbType.Int,4),
					new SqlParameter("@sWeight", SqlDbType.Int,4),
					new SqlParameter("@sSpecialty", SqlDbType.VarChar,512),
					new SqlParameter("@sHobbies", SqlDbType.VarChar,512),
					new SqlParameter("@sContactAddress", SqlDbType.VarChar,512),
					new SqlParameter("@sPhotos", SqlDbType.VarChar,128),
					new SqlParameter("@sEmployment", SqlDbType.Int,4),
					new SqlParameter("@sCanBeDate", SqlDbType.VarChar,50),
					new SqlParameter("@sTreatment", SqlDbType.Money,8),
					new SqlParameter("@StaffDataID", SqlDbType.Int,4)};
            parameters[0].Value = model.StaffID;
            parameters[1].Value = model.sBirthDay;
            parameters[2].Value = model.sPolitical;
            parameters[3].Value = model.sBirthplace;
            parameters[4].Value = model.sHometown;
            parameters[5].Value = model.sEducation;
            parameters[6].Value = model.sProfessional;
            parameters[7].Value = model.sHealth;
            parameters[8].Value = model.sHeight;
            parameters[9].Value = model.sWeight;
            parameters[10].Value = model.sSpecialty;
            parameters[11].Value = model.sHobbies;
            parameters[12].Value = model.sContactAddress;
            parameters[13].Value = model.sPhotos;
            parameters[14].Value = model.sEmployment;
            parameters[15].Value = model.sCanBeDate;
            parameters[16].Value = model.sTreatment;
            parameters[17].Value = model.StaffDataID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteStaffDataInfo(int StaffDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStaffDataInfo ");
            strSql.Append(" where StaffDataID=@StaffDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffDataID", SqlDbType.Int,4)
};
            parameters[0].Value = StaffDataID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteStaffDataInfoList(string StaffDataIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStaffDataInfo ");
            strSql.Append(" where StaffDataID in (" + StaffDataIDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public StaffDataInfo GetStaffDataInfoModel(int StaffDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StaffDataID,StaffID,sBirthDay,sPolitical,sBirthplace,sHometown,sEducation,sProfessional,sHealth,sHeight,sWeight,sSpecialty,sHobbies,sContactAddress,sPhotos,sEmployment,sCanBeDate,sTreatment from tbStaffDataInfo ");
            strSql.Append(" where StaffDataID=@StaffDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffDataID", SqlDbType.Int,4)
};
            parameters[0].Value = StaffDataID;

            StaffDataInfo model = new StaffDataInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StaffDataID"].ToString() != "")
                {
                    model.StaffDataID = int.Parse(ds.Tables[0].Rows[0]["StaffDataID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                model.sBirthDay = ds.Tables[0].Rows[0]["sBirthDay"].ToString();
                model.sPolitical = ds.Tables[0].Rows[0]["sPolitical"].ToString();
                model.sBirthplace = ds.Tables[0].Rows[0]["sBirthplace"].ToString();
                model.sHometown = ds.Tables[0].Rows[0]["sHometown"].ToString();
                model.sEducation = ds.Tables[0].Rows[0]["sEducation"].ToString();
                model.sProfessional = ds.Tables[0].Rows[0]["sProfessional"].ToString();
                model.sHealth = ds.Tables[0].Rows[0]["sHealth"].ToString();
                if (ds.Tables[0].Rows[0]["sHeight"].ToString() != "")
                {
                    model.sHeight = int.Parse(ds.Tables[0].Rows[0]["sHeight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sWeight"].ToString() != "")
                {
                    model.sWeight = int.Parse(ds.Tables[0].Rows[0]["sWeight"].ToString());
                }
                model.sSpecialty = ds.Tables[0].Rows[0]["sSpecialty"].ToString();
                model.sHobbies = ds.Tables[0].Rows[0]["sHobbies"].ToString();
                model.sContactAddress = ds.Tables[0].Rows[0]["sContactAddress"].ToString();
                model.sPhotos = ds.Tables[0].Rows[0]["sPhotos"].ToString();
                if (ds.Tables[0].Rows[0]["sEmployment"].ToString() != "")
                {
                    model.sEmployment = int.Parse(ds.Tables[0].Rows[0]["sEmployment"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sCanBeDate"].ToString() != "")
                {
                    model.sCanBeDate = ds.Tables[0].Rows[0]["sCanBeDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sTreatment"].ToString() != "")
                {
                    model.sTreatment = decimal.Parse(ds.Tables[0].Rows[0]["sTreatment"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public StaffDataInfo GetStaffDataInfoModelByStaffID(int StaffID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StaffDataID,StaffID,sBirthDay,sPolitical,sBirthplace,sHometown,sEducation,sProfessional,sHealth,sHeight,sWeight,sSpecialty,sHobbies,sContactAddress,sPhotos,sEmployment,sCanBeDate,sTreatment from tbStaffDataInfo ");
            strSql.Append(" where StaffID=@StaffID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4)
};
            parameters[0].Value = StaffID;

            StaffDataInfo model = new StaffDataInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StaffDataID"].ToString() != "")
                {
                    model.StaffDataID = int.Parse(ds.Tables[0].Rows[0]["StaffDataID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                model.sBirthDay = ds.Tables[0].Rows[0]["sBirthDay"].ToString();
                model.sPolitical = ds.Tables[0].Rows[0]["sPolitical"].ToString();
                model.sBirthplace = ds.Tables[0].Rows[0]["sBirthplace"].ToString();
                model.sHometown = ds.Tables[0].Rows[0]["sHometown"].ToString();
                model.sEducation = ds.Tables[0].Rows[0]["sEducation"].ToString();
                model.sProfessional = ds.Tables[0].Rows[0]["sProfessional"].ToString();
                model.sHealth = ds.Tables[0].Rows[0]["sHealth"].ToString();
                if (ds.Tables[0].Rows[0]["sHeight"].ToString() != "")
                {
                    model.sHeight = int.Parse(ds.Tables[0].Rows[0]["sHeight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sWeight"].ToString() != "")
                {
                    model.sWeight = int.Parse(ds.Tables[0].Rows[0]["sWeight"].ToString());
                }
                model.sSpecialty = ds.Tables[0].Rows[0]["sSpecialty"].ToString();
                model.sHobbies = ds.Tables[0].Rows[0]["sHobbies"].ToString();
                model.sContactAddress = ds.Tables[0].Rows[0]["sContactAddress"].ToString();
                model.sPhotos = ds.Tables[0].Rows[0]["sPhotos"].ToString();
                if (ds.Tables[0].Rows[0]["sEmployment"].ToString() != "")
                {
                    model.sEmployment = int.Parse(ds.Tables[0].Rows[0]["sEmployment"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sCanBeDate"].ToString() != "")
                {
                    model.sCanBeDate = ds.Tables[0].Rows[0]["sCanBeDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sTreatment"].ToString() != "")
                {
                    model.sTreatment = decimal.Parse(ds.Tables[0].Rows[0]["sTreatment"].ToString());
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
        public DataSet GetStaffDataInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StaffDataID,StaffID,sBirthDay,sPolitical,sBirthplace,sHometown,sEducation,sProfessional,sHealth,sHeight,sWeight,sSpecialty,sHobbies,sContactAddress,sPhotos,sEmployment,sCanBeDate,sTreatment ");
            strSql.Append(" FROM tbStaffDataInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetStaffDataInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" StaffDataID,StaffID,sBirthDay,sPolitical,sBirthplace,sHometown,sEducation,sProfessional,sHealth,sHeight,sWeight,sSpecialty,sHobbies,sContactAddress,sPhotos,sEmployment,sCanBeDate,sTreatment ");
            strSql.Append(" FROM tbStaffDataInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetStaffDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            SqlParameter[] parameters = {
					  new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@showFName", SqlDbType.VarChar,1000),
					};
            parameters[0].Value = "tbStaffDataInfo";
            parameters[1].Value = "StaffDataID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName;
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "UP_" + BaseConfigs.GetTablePrefix + "GetRecordByPage", parameters);
            if (ds.Tables.Count > 1)
            {
                int total = (int)ds.Tables[0].Rows[0][0];

                if (total % PageSize == 0)
                {
                    pagetotal = total / PageSize;
                }
                else
                {
                    pagetotal = total / PageSize + 1;
                }
                return ds.Tables[1];
            }
            else
            {
                pagetotal = 0;
                return null;
            }
        }

        #endregion

        #region StaffEduDataInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsStaffEduDataInfo(int StaffID,string eDate, string eSchools)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbStaffEduDataInfo");
            strSql.Append(" where StaffID=@StaffID and eDate=@eDate and eSchools=@eSchools");
            SqlParameter[] parameters = {
                                                new SqlParameter("@StaffID", SqlDbType.Int,4),
                                                new SqlParameter("@eDate", SqlDbType.VarChar,50),
                                                new SqlParameter("@eSchools", SqlDbType.VarChar,512),
           };
            parameters[0].Value = StaffID;
            parameters[1].Value = eDate;
            parameters[2].Value = eSchools;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddStaffEduDataInfo(StaffEduDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbStaffEduDataInfo(");
            strSql.Append("StaffID,eDate,eSchools,eContent)");
            strSql.Append(" values (");
            strSql.Append("@StaffID,@eDate,@eSchools,@eContent)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@eDate", SqlDbType.VarChar,50),
					new SqlParameter("@eSchools", SqlDbType.VarChar,512),
					new SqlParameter("@eContent", SqlDbType.VarChar,512)};
            parameters[0].Value = model.StaffID;
            parameters[1].Value = model.eDate;
            parameters[2].Value = model.eSchools;
            parameters[3].Value = model.eContent;

            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        ///添加教育
        /// </summary>
        /// <param name="EduDataJson"></param>
        /// <returns></returns>
        public bool AddStaffEduDataInfoByJson(StaffEduDataJson EduDataJson)
        {
            try
            {
                if (EduDataJson != null)
                {
                    StringBuilder strSql = new StringBuilder();
                    foreach (StaffEduDataInfo sd in EduDataJson.EduDataListJson)
                    {
                        if (sd != null)
                        {
                            strSql.Append("insert into tbStaffEduDataInfo(");
                            strSql.Append("StaffID,eDate,eSchools,eContent)");
                            strSql.Append(" values (");
                            strSql.Append("" + sd.StaffID + ",'" + sd.eDate + "','" + sd.eSchools + "','" + sd.eContent + "');");
                        }
                    }
                    DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString());
                    return true;
                }
                else {
                    return false;
                }
            }
            catch {
                return false;
            }
        }

        public bool UpdateStaffEduDataInfoByJson(StaffEduDataJson EduDataJson, int StaffID)
        {
            try
            {
                if (EduDataJson != null)
                {
                    StringBuilder strSql = new StringBuilder();
                    string StaffEduDataIDStr = "";
                    foreach (StaffEduDataInfo sd in EduDataJson.EduDataListJson)
                    {
                        if (sd != null)
                        {
                            if (sd.StaffEduDataID > 0)
                            {
                                StaffEduDataIDStr += sd.StaffEduDataID+",";
                                strSql.Append("update tbStaffEduDataInfo set ");
                                strSql.Append("eDate='" + sd.eDate + "',eSchools='" + sd.eSchools + "',eContent='" + sd.eContent + "' where StaffID=" + StaffID + " and StaffEduDataID=" + sd.StaffEduDataID + ";");
                            }
                        }
                    }

                    if (StaffEduDataIDStr.Trim() != "")
                    {
                        StaffEduDataIDStr = Utils.ReSQLSetTxt(StaffEduDataIDStr);
                        strSql.Append("delete from tbStaffEduDataInfo where StaffEduDataID not in (" + StaffEduDataIDStr + ")  and StaffID= " + StaffID + " ;");
                    }

                    foreach (StaffEduDataInfo sd in EduDataJson.EduDataListJson)
                    {
                        if (sd != null)
                        {
                            if (sd.StaffEduDataID <= 0)
                            {
                                strSql.Append("insert into tbStaffEduDataInfo(");
                                strSql.Append("StaffID,eDate,eSchools,eContent)");
                                strSql.Append(" values (");
                                strSql.Append("" + StaffID + ",'" + sd.eDate + "','" + sd.eSchools + "','" + sd.eContent + "');");
                            }
                        }
                    }
                    DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateStaffEduDataInfo(StaffEduDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbStaffEduDataInfo set ");
            strSql.Append("StaffID=@StaffID,");
            strSql.Append("eDate=@eDate,");
            strSql.Append("eSchools=@eSchools,");
            strSql.Append("eContent=@eContent");
            strSql.Append(" where StaffEduDataID=@StaffEduDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@eDate", SqlDbType.VarChar,50),
					new SqlParameter("@eSchools", SqlDbType.VarChar,512),
					new SqlParameter("@eContent", SqlDbType.VarChar,512),
					new SqlParameter("@StaffEduDataID", SqlDbType.Int,4)};
            parameters[0].Value = model.StaffID;
            parameters[1].Value = model.eDate;
            parameters[2].Value = model.eSchools;
            parameters[3].Value = model.eContent;
            parameters[4].Value = model.StaffEduDataID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteStaffEduDataInfo(int StaffEduDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStaffEduDataInfo ");
            strSql.Append(" where StaffEduDataID=@StaffEduDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffEduDataID", SqlDbType.Int,4)
};
            parameters[0].Value = StaffEduDataID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteStaffEduDataInfoList(string StaffEduDataIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStaffEduDataInfo ");
            strSql.Append(" where StaffEduDataID in (" + StaffEduDataIDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public StaffEduDataInfo GetStaffEduDataInfoModel(int StaffEduDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StaffEduDataID,StaffID,eDate,eSchools,eContent from tbStaffEduDataInfo ");
            strSql.Append(" where StaffEduDataID=@StaffEduDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffEduDataID", SqlDbType.Int,4)
};
            parameters[0].Value = StaffEduDataID;

            StaffEduDataInfo model = new StaffEduDataInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StaffEduDataID"].ToString() != "")
                {
                    model.StaffEduDataID = int.Parse(ds.Tables[0].Rows[0]["StaffEduDataID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                model.eDate = ds.Tables[0].Rows[0]["eDate"].ToString();
                model.eSchools = ds.Tables[0].Rows[0]["eSchools"].ToString();
                model.eContent = ds.Tables[0].Rows[0]["eContent"].ToString();
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
        public DataSet GetStaffEduDataInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StaffEduDataID,StaffID,eDate,eSchools,eContent ");
            strSql.Append(" FROM tbStaffEduDataInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetStaffEduDataInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" StaffEduDataID,StaffID,eDate,eSchools,eContent ");
            strSql.Append(" FROM tbStaffEduDataInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetStaffEduDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            SqlParameter[] parameters = {
					  new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@showFName", SqlDbType.VarChar,1000),
					};
            parameters[0].Value = "tbStaffEduDataInfo";
            parameters[1].Value = "StaffEduDataID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName;
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "UP_" + BaseConfigs.GetTablePrefix + "GetRecordByPage", parameters);
            if (ds.Tables.Count > 1)
            {
                int total = (int)ds.Tables[0].Rows[0][0];

                if (total % PageSize == 0)
                {
                    pagetotal = total / PageSize;
                }
                else
                {
                    pagetotal = total / PageSize + 1;
                }
                return ds.Tables[1];
            }
            else
            {
                pagetotal = 0;
                return null;
            }
        }
        #endregion

        #region StaffFamilyDataInfo
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsStaffFamilyDataInfo(int StaffID, string fName, string fTitle)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbStaffFamilyDataInfo");
            strSql.Append(" where StaffID=@StaffID and fName=@fName and fTitle=@fTitle");
            SqlParameter[] parameters = {
                                            new SqlParameter("@StaffID", SqlDbType.Int,4),
                                            new SqlParameter("@fName", SqlDbType.VarChar,50),
                                            new SqlParameter("@fTitle", SqlDbType.VarChar,50),
            };
            parameters[0].Value = StaffID;
            parameters[1].Value = fName;
            parameters[2].Value = fTitle;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddStaffFamilyDataInfo(StaffFamilyDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbStaffFamilyDataInfo(");
            strSql.Append("StaffID,fTitle,fName,fAge,fEnterprise,fWork,fAddress,fTel)");
            strSql.Append(" values (");
            strSql.Append("@StaffID,@fTitle,@fName,@fAge,@fEnterprise,@fWork,@fAddress,@fTel)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@fTitle", SqlDbType.VarChar,50),
					new SqlParameter("@fName", SqlDbType.VarChar,50),
					new SqlParameter("@fAge", SqlDbType.VarChar,50),
					new SqlParameter("@fEnterprise", SqlDbType.VarChar,512),
					new SqlParameter("@fWork", SqlDbType.VarChar,50),
					new SqlParameter("@fAddress", SqlDbType.VarChar,512),
					new SqlParameter("@fTel", SqlDbType.VarChar,50)};
            parameters[0].Value = model.StaffID;
            parameters[1].Value = model.fTitle;
            parameters[2].Value = model.fName;
            parameters[3].Value = model.fAge;
            parameters[4].Value = model.fEnterprise;
            parameters[5].Value = model.fWork;
            parameters[6].Value = model.fAddress;
            parameters[7].Value = model.fTel;

            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public bool AddStaffFamilyDataInfoByJson(StaffFamilyDataJson FamilyDataJson)
        {
            try
            {
                if (FamilyDataJson != null)
                {
                    StringBuilder strSql = new StringBuilder();
                    foreach (StaffFamilyDataInfo sd in FamilyDataJson.FamilyDataListJson)
                    {
                        if (sd != null)
                        {
                            strSql.Append("insert into tbStaffFamilyDataInfo(");
                            strSql.Append("StaffID,fTitle,fName,fAge,fEnterprise,fWork,fAddress,fTel)");
                            strSql.Append(" values (");
                            strSql.Append("" + sd.StaffID + ",'" + sd.fTitle + "','" + sd.fName + "','" + sd.fAge + "','" + sd.fEnterprise + "','" + sd.fWork + "','" + sd.fAddress + "','" + sd.fTel + "');");
                        }
                    }
                    DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateStaffFamilyDataInfo(StaffFamilyDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbStaffFamilyDataInfo set ");
            strSql.Append("StaffID=@StaffID,");
            strSql.Append("fTitle=@fTitle,");
            strSql.Append("fName=@fName,");
            strSql.Append("fAge=@fAge,");
            strSql.Append("fEnterprise=@fEnterprise,");
            strSql.Append("fWork=@fWork,");
            strSql.Append("fAddress=@fAddress,");
            strSql.Append("fTel=@fTel");
            strSql.Append(" where StaffFamilyDataID=@StaffFamilyDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@fTitle", SqlDbType.VarChar,50),
					new SqlParameter("@fName", SqlDbType.VarChar,50),
					new SqlParameter("@fAge", SqlDbType.VarChar,50),
					new SqlParameter("@fEnterprise", SqlDbType.VarChar,512),
					new SqlParameter("@fWork", SqlDbType.VarChar,50),
					new SqlParameter("@fAddress", SqlDbType.VarChar,512),
					new SqlParameter("@fTel", SqlDbType.VarChar,50),
					new SqlParameter("@StaffFamilyDataID", SqlDbType.Int,4)};
            parameters[0].Value = model.StaffID;
            parameters[1].Value = model.fTitle;
            parameters[2].Value = model.fName;
            parameters[3].Value = model.fAge;
            parameters[4].Value = model.fEnterprise;
            parameters[5].Value = model.fWork;
            parameters[6].Value = model.fAddress;
            parameters[7].Value = model.fTel;
            parameters[8].Value = model.StaffFamilyDataID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateStaffFamilyDataInfoByJson(StaffFamilyDataJson FamilyDataJson, int StaffID)
        {
            try
            {
                if (FamilyDataJson != null)
                {
                    StringBuilder strSql = new StringBuilder();
                    string StaffFamilyDataIDStr = "";
                    foreach (StaffFamilyDataInfo sd in FamilyDataJson.FamilyDataListJson)
                    {
                        if (sd != null)
                        {
                            if (sd.StaffFamilyDataID > 0)
                            {
                                StaffFamilyDataIDStr += sd.StaffFamilyDataID + ",";
                                strSql.Append("update tbStaffFamilyDataInfo set ");
                                strSql.Append("fTitle='" + sd.fTitle + "',fName='" + sd.fName + "',fAge='" + sd.fAge + "',fEnterprise='" + sd.fEnterprise + "',fWork='" + sd.fWork + "',fAddress='" + sd.fAddress + "',fTel='" + sd.fTel + "' where StaffID=" + StaffID + " and StaffFamilyDataID=" + sd.StaffFamilyDataID + ";");
                            }
                        }
                    }

                    if (StaffFamilyDataIDStr.Trim() != "")
                    {
                        StaffFamilyDataIDStr = Utils.ReSQLSetTxt(StaffFamilyDataIDStr);
                        strSql.Append("delete from tbStaffFamilyDataInfo where StaffWorkDataID not in (" + StaffFamilyDataIDStr + ")  and StaffID=" + StaffID + " ;");
                    }

                    foreach (StaffFamilyDataInfo sd in FamilyDataJson.FamilyDataListJson)
                    {
                        if (sd != null)
                        {
                            if (sd.StaffFamilyDataID <= 0)
                            {
                                strSql.Append("insert into tbStaffFamilyDataInfo(");
                                strSql.Append("StaffID,fTitle,fName,fAge,fEnterprise,fWork,fAddress,fTel)");
                                strSql.Append(" values (");
                                strSql.Append("" + StaffID + ",'" + sd.fTitle + "','" + sd.fName + "','" + sd.fAge + "','" + sd.fEnterprise + "','" + sd.fWork + "','" + sd.fAddress + "','" + sd.fTel + "');");
                            }
                        }
                    }
                    DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteStaffFamilyDataInfo(int StaffFamilyDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStaffFamilyDataInfo ");
            strSql.Append(" where StaffFamilyDataID=@StaffFamilyDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffFamilyDataID", SqlDbType.Int,4)
};
            parameters[0].Value = StaffFamilyDataID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteStaffFamilyDataInfoList(string StaffFamilyDataIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStaffFamilyDataInfo ");
            strSql.Append(" where StaffFamilyDataID in (" + StaffFamilyDataIDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public StaffFamilyDataInfo GetStaffFamilyDataInfoModel(int StaffFamilyDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StaffFamilyDataID,StaffID,fTitle,fName,fAge,fEnterprise,fWork,fAddress,fTel from tbStaffFamilyDataInfo ");
            strSql.Append(" where StaffFamilyDataID=@StaffFamilyDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffFamilyDataID", SqlDbType.Int,4)
};
            parameters[0].Value = StaffFamilyDataID;

            StaffFamilyDataInfo model = new StaffFamilyDataInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StaffFamilyDataID"].ToString() != "")
                {
                    model.StaffFamilyDataID = int.Parse(ds.Tables[0].Rows[0]["StaffFamilyDataID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                model.fTitle = ds.Tables[0].Rows[0]["fTitle"].ToString();
                model.fName = ds.Tables[0].Rows[0]["fName"].ToString();
                model.fAge = ds.Tables[0].Rows[0]["fAge"].ToString();
                model.fEnterprise = ds.Tables[0].Rows[0]["fEnterprise"].ToString();
                model.fWork = ds.Tables[0].Rows[0]["fWork"].ToString();
                model.fAddress = ds.Tables[0].Rows[0]["fAddress"].ToString();
                model.fTel = ds.Tables[0].Rows[0]["fTel"].ToString();
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
        public DataSet GetStaffFamilyDataInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StaffFamilyDataID,StaffID,fTitle,fName,fAge,fEnterprise,fWork,fAddress,fTel ");
            strSql.Append(" FROM tbStaffFamilyDataInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetStaffFamilyDataInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" StaffFamilyDataID,StaffID,fTitle,fName,fAge,fEnterprise,fWork,fAddress,fTel ");
            strSql.Append(" FROM tbStaffFamilyDataInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetStaffFamilyDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            SqlParameter[] parameters = {
					  new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@showFName", SqlDbType.VarChar,1000),
					};
            parameters[0].Value = "tbStaffFamilyDataInfo";
            parameters[1].Value = "StaffFamilyDataID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName;
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "UP_" + BaseConfigs.GetTablePrefix + "GetRecordByPage", parameters);
            if (ds.Tables.Count > 1)
            {
                int total = (int)ds.Tables[0].Rows[0][0];

                if (total % PageSize == 0)
                {
                    pagetotal = total / PageSize;
                }
                else
                {
                    pagetotal = total / PageSize + 1;
                }
                return ds.Tables[1];
            }
            else
            {
                pagetotal = 0;
                return null;
            }
        }
        #endregion

        #region StaffWorkDataInfo
        // <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsStaffWorkDataInfo(int StaffID, string wDate, string wEnterprise)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbStaffWorkDataInfo");
            strSql.Append(" where StaffID=@StaffID and wDate=@wDate and wEnterprise=@wEnterprise");
            SqlParameter[] parameters = {
                                            new SqlParameter("@StaffID", SqlDbType.Int,4),
                                            new SqlParameter("@wDate", SqlDbType.VarChar,50),
                                            new SqlParameter("@wEnterprise", SqlDbType.VarChar,512),
            };
            parameters[0].Value = StaffID;
            parameters[1].Value = wDate;
            parameters[2].Value = wEnterprise;

            return ((int)DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters)) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddStaffWorkDataInfo(StaffWorkDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbStaffWorkDataInfo(");
            strSql.Append("StaffID,wDate,wEnterprise,wTel,wJobs,wIncome)");
            strSql.Append(" values (");
            strSql.Append("@StaffID,@wDate,@wEnterprise,@wTel,@wJobs,@wIncome)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@wDate", SqlDbType.VarChar,50),
					new SqlParameter("@wEnterprise", SqlDbType.VarChar,512),
					new SqlParameter("@wTel", SqlDbType.VarChar,50),
					new SqlParameter("@wJobs", SqlDbType.VarChar,50),
					new SqlParameter("@wIncome", SqlDbType.VarChar,50)};
            parameters[0].Value = model.StaffID;
            parameters[1].Value = model.wDate;
            parameters[2].Value = model.wEnterprise;
            parameters[3].Value = model.wTel;
            parameters[4].Value = model.wJobs;
            parameters[5].Value = model.wIncome;

            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public bool AddStaffWorkDataInfoByJson(StaffWorkDataJson WorkDataJson)
        {
            try
            {
                if (WorkDataJson != null)
                {
                    StringBuilder strSql = new StringBuilder();
                    foreach (StaffWorkDataInfo sd in WorkDataJson.WorkDataListJson)
                    {
                        if (sd != null)
                        {
                            strSql.Append("insert into tbStaffWorkDataInfo(");
                            strSql.Append("StaffID,wDate,wEnterprise,wTel,wJobs,wIncome)");
                            strSql.Append(" values (");
                            strSql.Append("" + sd.StaffID + ",'" + sd.wDate + "','" + sd.wEnterprise + "','" + sd.wTel + "','" + sd.wJobs + "','" + sd.wIncome + "');");
                        }
                    }
                    DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateStaffWorkDataInfoByJson(StaffWorkDataJson WorkDataJson, int StaffID)
        {
            try
            {
                if (WorkDataJson != null)
                {
                    StringBuilder strSql = new StringBuilder();
                    string StaffWorkDataIDStr = "";
                    foreach (StaffWorkDataInfo sd in WorkDataJson.WorkDataListJson)
                    {
                        if (sd != null)
                        {
                            if (sd.StaffWorkDataID > 0)
                            {
                                StaffWorkDataIDStr += sd.StaffWorkDataID + ",";
                                strSql.Append("update tbStaffWorkDataInfo set ");
                                strSql.Append("wDate='" + sd.wDate + "',wEnterprise='" + sd.wEnterprise + "',wTel='" + sd.wTel + "',wJobs='" + sd.wJobs + "',wIncome='" + sd.wIncome + "' where StaffID=" + StaffID + " and StaffWorkDataID=" + sd.StaffWorkDataID + ";");
                            }
                        }
                    }

                    if (StaffWorkDataIDStr.Trim() != "")
                    {
                        StaffWorkDataIDStr = Utils.ReSQLSetTxt(StaffWorkDataIDStr);
                        strSql.Append("delete from tbStaffWorkDataInfo where StaffWorkDataID not in (" + StaffWorkDataIDStr + ") and StaffID=" + StaffID + " ;");
                    }

                    foreach (StaffWorkDataInfo sd in WorkDataJson.WorkDataListJson)
                    {
                        if (sd != null)
                        {
                            if (sd.StaffWorkDataID <= 0)
                            {
                                strSql.Append("insert into tbStaffWorkDataInfo(");
                                strSql.Append("StaffID,wDate,wEnterprise,wTel,wJobs,wIncome)");
                                strSql.Append(" values (");
                                strSql.Append("" + StaffID + ",'" + sd.wDate + "','" + sd.wEnterprise + "','" + sd.wTel + "','" + sd.wJobs + "','" + sd.wIncome + "');");
                            }
                        }
                    }
                    DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateStaffWorkDataInfo(StaffWorkDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbStaffWorkDataInfo set ");
            strSql.Append("StaffID=@StaffID,");
            strSql.Append("wDate=@wDate,");
            strSql.Append("wEnterprise=@wEnterprise,");
            strSql.Append("wTel=@wTel,");
            strSql.Append("wJobs=@wJobs,");
            strSql.Append("wIncome=@wIncome");
            strSql.Append(" where StaffWorkDataID=@StaffWorkDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@wDate", SqlDbType.VarChar,50),
					new SqlParameter("@wEnterprise", SqlDbType.VarChar,512),
					new SqlParameter("@wTel", SqlDbType.VarChar,50),
					new SqlParameter("@wJobs", SqlDbType.VarChar,50),
					new SqlParameter("@wIncome", SqlDbType.VarChar,50),
					new SqlParameter("@StaffWorkDataID", SqlDbType.Int,4)};
            parameters[0].Value = model.StaffID;
            parameters[1].Value = model.wDate;
            parameters[2].Value = model.wEnterprise;
            parameters[3].Value = model.wTel;
            parameters[4].Value = model.wJobs;
            parameters[5].Value = model.wIncome;
            parameters[6].Value = model.StaffWorkDataID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteStaffWorkDataInfo(int StaffWorkDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStaffWorkDataInfo ");
            strSql.Append(" where StaffWorkDataID=@StaffWorkDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffWorkDataID", SqlDbType.Int,4)
};
            parameters[0].Value = StaffWorkDataID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteStaffWorkDataInfoList(string StaffWorkDataIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStaffWorkDataInfo ");
            strSql.Append(" where StaffWorkDataID in (" + StaffWorkDataIDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public StaffWorkDataInfo GetStaffWorkDataInfoModel(int StaffWorkDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StaffWorkDataID,StaffID,wDate,wEnterprise,wTel,wJobs,wIncome from tbStaffWorkDataInfo ");
            strSql.Append(" where StaffWorkDataID=@StaffWorkDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffWorkDataID", SqlDbType.Int,4)
};
            parameters[0].Value = StaffWorkDataID;

            StaffWorkDataInfo model = new StaffWorkDataInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StaffWorkDataID"].ToString() != "")
                {
                    model.StaffWorkDataID = int.Parse(ds.Tables[0].Rows[0]["StaffWorkDataID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                model.wDate = ds.Tables[0].Rows[0]["wDate"].ToString();
                model.wEnterprise = ds.Tables[0].Rows[0]["wEnterprise"].ToString();
                model.wTel = ds.Tables[0].Rows[0]["wTel"].ToString();
                model.wJobs = ds.Tables[0].Rows[0]["wJobs"].ToString();
                model.wIncome = ds.Tables[0].Rows[0]["wIncome"].ToString();
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
        public DataSet GetStaffWorkDataInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StaffWorkDataID,StaffID,wDate,wEnterprise,wTel,wJobs,wIncome ");
            strSql.Append(" FROM tbStaffWorkDataInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetStaffWorkDataInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" StaffWorkDataID,StaffID,wDate,wEnterprise,wTel,wJobs,wIncome ");
            strSql.Append(" FROM tbStaffWorkDataInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetStaffWorkDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            SqlParameter[] parameters = {
					  new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@showFName", SqlDbType.VarChar,1000),
					};
            parameters[0].Value = "tbStaffWorkDataInfo";
            parameters[1].Value = "StaffWorkDataID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName;
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "UP_" + BaseConfigs.GetTablePrefix + "GetRecordByPage", parameters);
            if (ds.Tables.Count > 1)
            {
                int total = (int)ds.Tables[0].Rows[0][0];

                if (total % PageSize == 0)
                {
                    pagetotal = total / PageSize;
                }
                else
                {
                    pagetotal = total / PageSize + 1;
                }
                return ds.Tables[1];
            }
            else
            {
                pagetotal = 0;
                return null;
            }
        }
        #endregion

        #region StaffAnalysisDataInfo
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddStaffAnalysisDataInfo(StaffAnalysisDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbStaffAnalysisDataInfo(");
            strSql.Append("StaffID,aWearing,aEducation,aWork,aCommunication,aConfidence,aLeadership,aJobstability,aComputer,aEnglish,aWritten,aEvaluation,aEvaluationMSG,aDateTime,aAppendTime)");
            strSql.Append(" values (");
            strSql.Append("@StaffID,@aWearing,@aEducation,@aWork,@aCommunication,@aConfidence,@aLeadership,@aJobstability,@aComputer,@aEnglish,@aWritten,@aEvaluation,@aEvaluationMSG,@aDateTime,@aAppendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@aWearing", SqlDbType.Int,4),
					new SqlParameter("@aEducation", SqlDbType.Int,4),
					new SqlParameter("@aWork", SqlDbType.Int,4),
					new SqlParameter("@aCommunication", SqlDbType.Int,4),
					new SqlParameter("@aConfidence", SqlDbType.Int,4),
					new SqlParameter("@aLeadership", SqlDbType.Int,4),
					new SqlParameter("@aJobstability", SqlDbType.Int,4),
					new SqlParameter("@aComputer", SqlDbType.Int,4),
					new SqlParameter("@aEnglish", SqlDbType.Int,4),
					new SqlParameter("@aWritten", SqlDbType.Int,4),
					new SqlParameter("@aEvaluation", SqlDbType.Int,4),
					new SqlParameter("@aEvaluationMSG", SqlDbType.VarChar,512),
					new SqlParameter("@aDateTime", SqlDbType.DateTime),
					new SqlParameter("@aAppendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.StaffID;
            parameters[1].Value = model.aWearing;
            parameters[2].Value = model.aEducation;
            parameters[3].Value = model.aWork;
            parameters[4].Value = model.aCommunication;
            parameters[5].Value = model.aConfidence;
            parameters[6].Value = model.aLeadership;
            parameters[7].Value = model.aJobstability;
            parameters[8].Value = model.aComputer;
            parameters[9].Value = model.aEnglish;
            parameters[10].Value = model.aWritten;
            parameters[11].Value = model.aEvaluation;
            parameters[12].Value = model.aEvaluationMSG;
            parameters[13].Value = model.aDateTime;
            parameters[14].Value = model.aAppendTime;

            object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateStaffAnalysisDataInfo(StaffAnalysisDataInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbStaffAnalysisDataInfo set ");
            strSql.Append("StaffID=@StaffID,");
            strSql.Append("aWearing=@aWearing,");
            strSql.Append("aEducation=@aEducation,");
            strSql.Append("aWork=@aWork,");
            strSql.Append("aCommunication=@aCommunication,");
            strSql.Append("aConfidence=@aConfidence,");
            strSql.Append("aLeadership=@aLeadership,");
            strSql.Append("aJobstability=@aJobstability,");
            strSql.Append("aComputer=@aComputer,");
            strSql.Append("aEnglish=@aEnglish,");
            strSql.Append("aWritten=@aWritten,");
            strSql.Append("aEvaluation=@aEvaluation,");
            strSql.Append("aEvaluationMSG=@aEvaluationMSG,");
            strSql.Append("aDateTime=@aDateTime,");
            strSql.Append("aAppendTime=@aAppendTime");
            strSql.Append(" where StaffAnalysisDataID=@StaffAnalysisDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4),
					new SqlParameter("@aWearing", SqlDbType.Int,4),
					new SqlParameter("@aEducation", SqlDbType.Int,4),
					new SqlParameter("@aWork", SqlDbType.Int,4),
					new SqlParameter("@aCommunication", SqlDbType.Int,4),
					new SqlParameter("@aConfidence", SqlDbType.Int,4),
					new SqlParameter("@aLeadership", SqlDbType.Int,4),
					new SqlParameter("@aJobstability", SqlDbType.Int,4),
					new SqlParameter("@aComputer", SqlDbType.Int,4),
					new SqlParameter("@aEnglish", SqlDbType.Int,4),
					new SqlParameter("@aWritten", SqlDbType.Int,4),
					new SqlParameter("@aEvaluation", SqlDbType.Int,4),
					new SqlParameter("@aEvaluationMSG", SqlDbType.VarChar,512),
					new SqlParameter("@aDateTime", SqlDbType.DateTime),
					new SqlParameter("@aAppendTime", SqlDbType.DateTime),
					new SqlParameter("@StaffAnalysisDataID", SqlDbType.Int,4)};
            parameters[0].Value = model.StaffID;
            parameters[1].Value = model.aWearing;
            parameters[2].Value = model.aEducation;
            parameters[3].Value = model.aWork;
            parameters[4].Value = model.aCommunication;
            parameters[5].Value = model.aConfidence;
            parameters[6].Value = model.aLeadership;
            parameters[7].Value = model.aJobstability;
            parameters[8].Value = model.aComputer;
            parameters[9].Value = model.aEnglish;
            parameters[10].Value = model.aWritten;
            parameters[11].Value = model.aEvaluation;
            parameters[12].Value = model.aEvaluationMSG;
            parameters[13].Value = model.aDateTime;
            parameters[14].Value = model.aAppendTime;
            parameters[15].Value = model.StaffAnalysisDataID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteStaffAnalysisDataInfo(int StaffAnalysisDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStaffAnalysisDataInfo ");
            strSql.Append(" where StaffAnalysisDataID=@StaffAnalysisDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffAnalysisDataID", SqlDbType.Int,4)
};
            parameters[0].Value = StaffAnalysisDataID;

            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteStaffAnalysisDataInfoList(string StaffAnalysisDataIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStaffAnalysisDataInfo ");
            strSql.Append(" where StaffAnalysisDataID in (" + StaffAnalysisDataIDlist + ")  ");
            int rows = DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public StaffAnalysisDataInfo GetStaffAnalysisDataInfoModel(int StaffAnalysisDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StaffAnalysisDataID,StaffID,aWearing,aEducation,aWork,aCommunication,aConfidence,aLeadership,aJobstability,aComputer,aEnglish,aWritten,aEvaluation,aEvaluationMSG,aDateTime,aAppendTime from tbStaffAnalysisDataInfo ");
            strSql.Append(" where StaffAnalysisDataID=@StaffAnalysisDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffAnalysisDataID", SqlDbType.Int,4)
};
            parameters[0].Value = StaffAnalysisDataID;

            StaffAnalysisDataInfo model = new StaffAnalysisDataInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StaffAnalysisDataID"].ToString() != "")
                {
                    model.StaffAnalysisDataID = int.Parse(ds.Tables[0].Rows[0]["StaffAnalysisDataID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aWearing"].ToString() != "")
                {
                    model.aWearing = int.Parse(ds.Tables[0].Rows[0]["aWearing"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aEducation"].ToString() != "")
                {
                    model.aEducation = int.Parse(ds.Tables[0].Rows[0]["aEducation"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aWork"].ToString() != "")
                {
                    model.aWork = int.Parse(ds.Tables[0].Rows[0]["aWork"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aCommunication"].ToString() != "")
                {
                    model.aCommunication = int.Parse(ds.Tables[0].Rows[0]["aCommunication"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aConfidence"].ToString() != "")
                {
                    model.aConfidence = int.Parse(ds.Tables[0].Rows[0]["aConfidence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aLeadership"].ToString() != "")
                {
                    model.aLeadership = int.Parse(ds.Tables[0].Rows[0]["aLeadership"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aJobstability"].ToString() != "")
                {
                    model.aJobstability = int.Parse(ds.Tables[0].Rows[0]["aJobstability"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aComputer"].ToString() != "")
                {
                    model.aComputer = int.Parse(ds.Tables[0].Rows[0]["aComputer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aEnglish"].ToString() != "")
                {
                    model.aEnglish = int.Parse(ds.Tables[0].Rows[0]["aEnglish"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aWritten"].ToString() != "")
                {
                    model.aWritten = int.Parse(ds.Tables[0].Rows[0]["aWritten"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aEvaluation"].ToString() != "")
                {
                    model.aEvaluation = int.Parse(ds.Tables[0].Rows[0]["aEvaluation"].ToString());
                }
                model.aEvaluationMSG = ds.Tables[0].Rows[0]["aEvaluationMSG"].ToString();
                if (ds.Tables[0].Rows[0]["aDateTime"].ToString() != "")
                {
                    model.aDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["aDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aAppendTime"].ToString() != "")
                {
                    model.aAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["aAppendTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public StaffAnalysisDataInfo GetStaffAnalysisDataInfoModelByStaffID(int StaffID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StaffAnalysisDataID,StaffID,aWearing,aEducation,aWork,aCommunication,aConfidence,aLeadership,aJobstability,aComputer,aEnglish,aWritten,aEvaluation,aEvaluationMSG,aDateTime,aAppendTime from tbStaffAnalysisDataInfo ");
            strSql.Append(" where StaffID=@StaffID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4)
};
            parameters[0].Value = StaffID;

            StaffAnalysisDataInfo model = new StaffAnalysisDataInfo();
            DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StaffAnalysisDataID"].ToString() != "")
                {
                    model.StaffAnalysisDataID = int.Parse(ds.Tables[0].Rows[0]["StaffAnalysisDataID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aWearing"].ToString() != "")
                {
                    model.aWearing = int.Parse(ds.Tables[0].Rows[0]["aWearing"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aEducation"].ToString() != "")
                {
                    model.aEducation = int.Parse(ds.Tables[0].Rows[0]["aEducation"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aWork"].ToString() != "")
                {
                    model.aWork = int.Parse(ds.Tables[0].Rows[0]["aWork"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aCommunication"].ToString() != "")
                {
                    model.aCommunication = int.Parse(ds.Tables[0].Rows[0]["aCommunication"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aConfidence"].ToString() != "")
                {
                    model.aConfidence = int.Parse(ds.Tables[0].Rows[0]["aConfidence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aLeadership"].ToString() != "")
                {
                    model.aLeadership = int.Parse(ds.Tables[0].Rows[0]["aLeadership"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aJobstability"].ToString() != "")
                {
                    model.aJobstability = int.Parse(ds.Tables[0].Rows[0]["aJobstability"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aComputer"].ToString() != "")
                {
                    model.aComputer = int.Parse(ds.Tables[0].Rows[0]["aComputer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aEnglish"].ToString() != "")
                {
                    model.aEnglish = int.Parse(ds.Tables[0].Rows[0]["aEnglish"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aWritten"].ToString() != "")
                {
                    model.aWritten = int.Parse(ds.Tables[0].Rows[0]["aWritten"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aEvaluation"].ToString() != "")
                {
                    model.aEvaluation = int.Parse(ds.Tables[0].Rows[0]["aEvaluation"].ToString());
                }
                model.aEvaluationMSG = ds.Tables[0].Rows[0]["aEvaluationMSG"].ToString();
                if (ds.Tables[0].Rows[0]["aDateTime"].ToString() != "")
                {
                    model.aDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["aDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aAppendTime"].ToString() != "")
                {
                    model.aAppendTime = DateTime.Parse(ds.Tables[0].Rows[0]["aAppendTime"].ToString());
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
        public DataSet GetStaffAnalysisDataInfoList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StaffAnalysisDataID,StaffID,aWearing,aEducation,aWork,aCommunication,aConfidence,aLeadership,aJobstability,aComputer,aEnglish,aWritten,aEvaluation,aEvaluationMSG,aDateTime,aAppendTime ");
            strSql.Append(" FROM tbStaffAnalysisDataInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetStaffAnalysisDataInfoList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" StaffAnalysisDataID,StaffID,aWearing,aEducation,aWork,aCommunication,aConfidence,aLeadership,aJobstability,aComputer,aEnglish,aWritten,aEvaluation,aEvaluationMSG,aDateTime,aAppendTime ");
            strSql.Append(" FROM tbStaffAnalysisDataInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelper.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetStaffAnalysisDataInfoList(int PageSize, int PageIndex, string strWhere, out int pagetotal, int OrderType, string showFName)
        {
            SqlParameter[] parameters = {
					  new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@showFName", SqlDbType.VarChar,1000),
					};
            parameters[0].Value = "tbStaffAnalysisDataInfo";
            parameters[1].Value = "StaffAnalysisDataID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Value = showFName;
            DataSet ds = DbHelper.ExecuteDataset(CommandType.StoredProcedure, "UP_" + BaseConfigs.GetTablePrefix + "GetRecordByPage", parameters);
            if (ds.Tables.Count > 1)
            {
                int total = (int)ds.Tables[0].Rows[0][0];

                if (total % PageSize == 0)
                {
                    pagetotal = total / PageSize;
                }
                else
                {
                    pagetotal = total / PageSize + 1;
                }
                return ds.Tables[1];
            }
            else
            {
                pagetotal = 0;
                return null;
            }
        }
        #endregion

        #region  人员岗位_月报表
        /// <summary>
        /// 获得人员岗位上离岗年份
        /// </summary>
        /// <returns></returns>
        public DataTable getStaffDate()
        {
            StringBuilder btr = new StringBuilder();
            btr.Append("select distinct(datepart(YEAR,sDateTime)) as sDateTime from tbStaffStoresInfo where sType=0 order by sDateTime desc");

            return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
        }
        /// <summary>
        /// 获得去年所有加入人员数量
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable getStaffLastYear(DateTime dt)
        {
            dt = dt.AddDays(-365);
            StringBuilder btr = new StringBuilder();
            btr.Append("select COUNT(1) countYear from tbStaffStoresInfo where sType=0 and datediff(YEAR,sDateTime,'" + dt + "')=0");

            return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
        }

        /// <summary>
        /// 获得每月的人员加入总数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable getStaffOfMonth(string dt)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@inyDate", SqlDbType.VarChar, 20),
                    };
            parameters[0].Value = dt;

            return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_" + BaseConfigs.GetTablePrefix + "ReprotOfStaffByMonth", parameters).Tables[0];
        }
        /// <summary>
        /// 获得人员上下岗明细
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="dType"></param>
        /// <returns></returns>
        public DataTable getStaffDetails(DateTime bDate, DateTime eDate, int dType)
        {
            StringBuilder btr = new StringBuilder();

            btr.Append(" select pp.sName,di.dClassName,pp.sDateTime from (");
            btr.Append("  select si.sName,si.DepartmentsClassID,s.sDateTime from(");
            btr.Append("  select distinct(StaffID),convert(varchar,datepart(year,sDateTime))+'-'+convert(varchar,datepart(MONTH,sDateTime))+'-'+convert(varchar,datepart(DAY,sDateTime)) as sDateTime");
            btr.Append("    from tbStaffStoresInfo where sType='" + dType + "' and sDateTime between '" + bDate + "' and '" + eDate + "') as s");
            btr.Append("     left join tbStaffInfo as si on s.StaffID=si.StaffID) as pp left join tbDepartmentsClassInfo as di");
            btr.Append("     on di.DepartmentsClassID=pp.DepartmentsClassID order by pp.sDateTime desc");
            return DbHelper.ExecuteDataset(CommandType.Text, btr.ToString()).Tables[0];
        }
        #endregion
    }
}
