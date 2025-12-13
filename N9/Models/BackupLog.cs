using System;

namespace N9.Models
{
    public class BackupLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime BackupTime { get; set; }
        public string FilePath { get; set; }
        public bool IsRestore { get; set; }
    }
}
