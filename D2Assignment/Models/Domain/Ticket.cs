using Microsoft.ServiceBus.Messaging;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace D2Assignment.Models.Domain
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FormattedCreationDate => CreatedDate.ToString("dd-MM-yyyy");

        public bool IsClosed { get; set; }
        public Severity Severity { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Developer> Assignees { get; set; } = new();


        public Ticket()
        {
            Id = Guid.NewGuid();
        }

        public Ticket(DateTime createdDate , string description,bool isClosed,int departmentID,Department department,Severity severity,List<Developer>developers)
        {
            Id = Guid.NewGuid();
            CreatedDate = createdDate;
            Description = description;
            IsClosed = isClosed;
            DepartmentId = departmentID;
            Department = department;
            Severity = severity;
            Assignees = developers;
        }




    }
}
