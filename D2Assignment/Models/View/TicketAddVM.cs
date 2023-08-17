using D2Assignment.Models.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace D2Assignment.Models.View
{
    public class TicketAddVM
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public bool IsClosed { get; set; }
        public Severity Severity { get; set; }
        [Required]
        [StringLength(50,MinimumLength =5)]
        public string Description { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [DisplayName("Assignees")]
        public List<int> AssigneesId { get; set; } = new();
    }
}
