using System.Diagnostics.Metrics;

namespace D2Assignment.Models.Domain
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static List<Department> GetDepartments() => new()
    {
        new (1, "Dept1"),
        new (2, "Dept2"),
        new (3, "Dept3"),
        new (4, "Dept4"),
        new (5, "Dept5")
        
    };

        public override string ToString() => Name;
    }
}


