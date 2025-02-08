﻿namespace mercuryfireBackendExam.Models
{
    public class Myoffice_ACPDModel
    {
        public string ACPD_SID { get; set; } = string.Empty;
        public string ACPD_Cname { get; set; } = string.Empty;
        public string ACPD_Ename { get; set; } = string.Empty;
        public string ACPD_Sname { get; set; } = string.Empty;
        public string ACPD_Email { get; set; } = string.Empty;
        public int ACPD_Status { get; set; }
        public Boolean ACPD_Stop { get; set; }
        public string ACPD_StopMemo { get; set; } = string.Empty;
        public string ACPD_LoginID { get; set; } = string.Empty;
        public string ACPD_LoginPWD { get; set; } = string.Empty;
        public string ACPD_Memo { get; set; } = string.Empty;
        public DateTime ACPD_NowDateTime { get; set; }
        public string ACPD_NowID { get; set; } = string.Empty;
        public DateTime ACPD_UPDDateTime { get; set; }
        public string ACPD_UPDID { get; set; } = string.Empty;
    }
}
