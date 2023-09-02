using System;

namespace HelpDesk.Common.Models
{
    [Serializable]
    public class ParamDb
    {
        public string[]? ServerIp { get; set; }
        public string? ServerPort { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
        public string? NameDb { get; set; }
        public int[]? VersionDb { get; set; }
        public bool IsDemoMode { get; set; }
    }
}
