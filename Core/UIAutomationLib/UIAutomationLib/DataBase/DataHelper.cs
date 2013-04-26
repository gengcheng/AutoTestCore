using System;
using System.Data;
using System.Configuration;
//using MySql.Data.MySqlClient;
using System.Data.OracleClient;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// DataHelper 的摘要说明
/// </summary>
public class DataHelper
{
	private DataHelper()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

     /// <summary>
    /// use StoreProcedure
    /// compiler will call Dispose on connection object when quit using
    /// </summary>
    /// <param name="connectionString">连接字符串,存在web.config中</param>
    /// <param name="strSql">StoreProcedure name</param>
    /// <param name="paramName">存储过程参数，参数个数不定</param>
    /// <returns>datatable</returns>
    public static DataTable GetTable(string connectionString, string strSql, params OracleParameter[] commandParams)
    {
        if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            OracleCommand cmd = new OracleCommand(strSql, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (commandParams != null)
            {
                foreach (OracleParameter p in commandParams)
                {
                    if (p != null)
                    {
                        //在向服务器发送空参数值时，用户必须指定 DBNull，而不是 Null。系统中的空值是一个不具有任何值的空对象。DBNull 用于表示空值
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                                (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(p);
                    }
                }
            }

            OracleDataAdapter sda = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "MyTable");
            return ds.Tables["MyTable"];
        }

    }

    public static int GetUpdateResult(string connectionString, string strSql, params OracleParameter[] commandParams)
    {
        if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            OracleCommand cmd = new OracleCommand(strSql, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (commandParams != null)
            {
                foreach (OracleParameter p in commandParams)
                {
                    if (p != null)
                    {
                        //在向服务器发送空参数值时，用户必须指定 DBNull，而不是 Null。系统中的空值是一个不具有任何值的空对象。DBNull 用于表示空值
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                                (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(p);
                    }
                }
            }
           
           connection.Open();
           int result = 0;
            result = cmd.ExecuteNonQuery();
            connection.Close();
            return result;
        }

    }

    public static List<string> ExecuteQuery(string strConn, string strSql, string strColumn, params OracleParameter[] commandParams)
    {
        using (OracleConnection msc = new OracleConnection(strConn))
        {
            msc.Open();
            OracleCommand cmd = new OracleCommand(strSql, msc);
            cmd.CommandType = CommandType.StoredProcedure;
            if (commandParams != null)
            {
                foreach (OracleParameter p in commandParams)
                {
                    if (p != null)
                    {
                        //在向服务器发送空参数值时，用户必须指定 DBNull，而不是 Null。系统中的空值是一个不具有任何值的空对象。DBNull 用于表示空值
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                                (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(p);
                    }
                }
            }
            OracleDataReader sdr = cmd.ExecuteReader();
            List<string> al = new List<string>();
            while (sdr.Read())
            {
                al.Add(sdr[strColumn].ToString());
            }
            sdr.Close();
            msc.Close();
            return al;
        }
    }

    public static List<string> ExecuteQuery(string strConn, string strSql, string strColumn) {
        using (OracleConnection msc = new OracleConnection(strConn)) {
            msc.Open();
            OracleCommand cmd = new OracleCommand(strSql, msc);
            cmd.CommandType = CommandType.Text;
            
            OracleDataReader sdr = cmd.ExecuteReader();
            List<string> al = new List<string>();
            while (sdr.Read()) {
                al.Add(sdr[strColumn].ToString());
            }
            sdr.Close();
            msc.Close();
            return al;
        }
    }

    public static string FormateDate(string inDate)
    {
        if (!string.IsNullOrEmpty(inDate))
        {
            char[] S = { '/', '/' };
            string[] strArray = inDate.Split(S);
            if (strArray.Length == 3)
            {
                return strArray[2].ToString() + "/" + strArray[0].ToString() + "/" + strArray[1].ToString();
            }
            else
                return "Error";
        }
        else
            return null;

    }

    public static string FormateDateToUSA(string inDate)
    {
        if (!String.IsNullOrEmpty(inDate))
        {
            char[] S = { '-', '-' };
            string[] strArray = inDate.Split(S);
            if (strArray.Length == 3)
            {
                return strArray[1].ToString() + "/" + strArray[2].ToString() + "/" + strArray[0].ToString();
            }
            else
                return "Error";
        }
        else
            return null;

    }
}
