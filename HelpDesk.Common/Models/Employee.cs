namespace HelpDesk.Common.Models
{
    public class Employee : User
    {
        public string Function { get; set; }
        public string Department { get; set; }
    }
}
