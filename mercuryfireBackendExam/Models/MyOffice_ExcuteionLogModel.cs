namespace mercuryfireBackendExam.Models
{
    public class MyOffice_ExcuteionLogModel
    {
        public long DeLog_AutoID { get; set; }
        public string DeLog_StoredPrograms { get; set; } = string.Empty;
        public Guid DeLog_GroupID { get; set; }
        public Boolean DeLog_isCustomDebug { get; set; }
        public string DeLog_ExecutionProgram { get; set; } = string.Empty;
        public string DeLog_ExecutionInfo { get; set; } = string.Empty;
        public Boolean DeLog_verifyNeeded { get; set; }
        public DateTime DeLog_ExDateTime { get; set; }
    }
}
