using Dapper;
using mercuryfireBackendExam.DBUtility;
using mercuryfireBackendExam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace mercuryfireBackendExam.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class mercuryfireController : ControllerBase
    {
        private readonly SqlDb _sqldb;
        public mercuryfireController(SqlDb sqldb)
        {
            _sqldb = sqldb;
        }

        [HttpPost(Name = "InsertMyoffice_ACPD")]
        public JsonResult Post()
            {
                var sql = @"Insert Into Myoffice_ACPD (ACPD_SID, ACPD_Cname, ACPD_Ename, ACPD_Sname, ACPD_Email, ACPD_Status, ACPD_Stop, ACPD_StopMemo, ACPD_LoginID
    , ACPD_LoginPWD, ACPD_Memo, ACPD_NowDateTime, ACPD_NowID, ACPD_UPDDateTime, ACPD_UPDID) Values (@ACPD_SID, @ACPD_Cname, @ACPD_Ename, @ACPD_Sname, @ACPD_Email
    , @ACPD_Status, @ACPD_Stop, @ACPD_StopMemo, @ACPD_LoginID, @ACPD_LoginPWD, @ACPD_Memo, @ACPD_NowDateTime, @ACPD_NowID, @ACPD_UPDDateTime, @ACPD_UPDID)";
                var param = new Myoffice_ACPDModel()
                {
                    ACPD_Cname = "測試",
                    ACPD_Ename = "test",
                    ACPD_Sname = "test",
                    ACPD_Email = "test@gmail.com",
                    ACPD_Status = 0,
                    ACPD_Stop = false,
                    ACPD_StopMemo = "運作正常",
                    ACPD_LoginID = "userId",
                    ACPD_LoginPWD = "password",
                    ACPD_Memo = "",
                    ACPD_NowDateTime = DateTime.Now,
                    ACPD_NowID = "userId",
                    ACPD_UPDDateTime = DateTime.Now,
                    ACPD_UPDID = "userId"
                };

                using (var connection = _sqldb.GetConnection())
                {
                {
                    connection.Open();

                    //取得新的SID
                    var parameters = new DynamicParameters();
                    parameters.Add("@TableName", "MyOffice_ACPD", DbType.String, ParameterDirection.Input);
                    parameters.Add("@ReturnSID", dbType: DbType.String, size: 20, direction: ParameterDirection.Output);

                    connection.Execute("NEWSID", parameters, commandType: CommandType.StoredProcedure);

                    param.ACPD_SID = parameters.Get<string>("@ReturnSID");

                    // 寫入Myoffice_ACPD資料表
                    int rowsAffected = connection.Execute(sql, param);
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        return new JsonResult(new { success = true, message = "成功" });
                    }
                    else
                    {
                        return new JsonResult(new { success = false, message = "失敗" });
                    }
                }
            }
        }

        [HttpPut(Name = "UpdateMyoffice_ACPD")]
        public JsonResult Put(string sid)
        {
            var sql = @"Update Myoffice_ACPD
Set 
    ACPD_Cname = @ACPD_Cname,
    ACPD_Ename = @ACPD_Ename,
    ACPD_Sname = @ACPD_Sname,
    ACPD_Email = @ACPD_Email,
    ACPD_Status = @ACPD_Status,
    ACPD_Stop = @ACPD_Stop,
    ACPD_StopMemo = @ACPD_StopMemo,
    ACPD_LoginID = @ACPD_LoginID,
    ACPD_LoginPWD = @ACPD_LoginPWD,
    ACPD_Memo = @ACPD_Memo,
    ACPD_NowDateTime = @ACPD_NowDateTime,
    ACPD_NowID = @ACPD_NowID,
    ACPD_UPDDateTime = @ACPD_UPDDateTime,
    ACPD_UPDID = @ACPD_UPDID
Where ACPD_SID = @ACPD_SID;";

            var param = new Myoffice_ACPDModel()
            {
                ACPD_SID = sid,
                ACPD_Cname = "測試",
                ACPD_Ename = "test",
                ACPD_Sname = "test",
                ACPD_Email = "test@gmail.com",
                ACPD_Status = 0,
                ACPD_Stop = false,
                ACPD_StopMemo = "運作正常",
                ACPD_LoginID = "userId",
                ACPD_LoginPWD = "password",
                ACPD_Memo = "我被更新了",
                ACPD_NowDateTime = DateTime.Now,
                ACPD_NowID = "userId",
                ACPD_UPDDateTime = DateTime.Now,
                ACPD_UPDID = "userId"
            };

            using (var connection = _sqldb.GetConnection())
            {
                {
                    connection.Open();

                    // 更新Myoffice_ACPD資料表
                    int rowsAffected = connection.Execute(sql, param);
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        return new JsonResult(new { success = true, message = "成功" });
                    }
                    else
                    {
                        return new JsonResult(new { success = false, message = "失敗" });
                    }
                }
            }
        }

        [HttpDelete(Name = "DeleteMyoffice_ACPD")]
        public JsonResult Delete(string sid)
        {
            var sql = @"Delete From Myoffice_ACPD Where ACPD_SID = @ACPD_SID";

            using (var connection = _sqldb.GetConnection())
            {
                {
                    connection.Open();

                    // 刪除Myoffice_ACPD資料表
                    int rowsAffected = connection.Execute(sql, new { ACPD_SID = sid });
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        return new JsonResult(new { success = true, message = "成功" });
                    }
                    else
                    {
                        return new JsonResult(new { success = false, message = "失敗" });
                    }
                }
            }
        }
    }
}

