using System.Diagnostics.Metrics;

namespace D2Assignment.Models.Domain
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsClosed { get; set; }
        public Severity Severity { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public Ticket()
        {
            Id = Guid.NewGuid();
        }

        public Ticket(DateTime createdDate,string description,bool isClosed,int departmentID,Department department,Severity severity)
        {
            Id = Guid.NewGuid();
            CreatedDate = createdDate;
            Description = description;
            IsClosed = isClosed;
            DepartmentId = departmentID;
            Severity = severity;
         
        }
    }
}
