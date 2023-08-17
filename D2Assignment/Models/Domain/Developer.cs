using System.Runtime.Versioning;
using System.Xml.Linq;
using System.Collections.Generic;

namespace D2Assignment.Models.Domain
{
    public class Developer
    {
        public int Id { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;



        public Developer(int id,string fname,string lname)
        {
            Id = id; Fname=fname; Lname=lname;
        }
        public static List<Developer> GetDevelopers() => new()
    {
        new (1, "Reham","Ahmed"),
        new (2, "Ethar","Abdelrahman"),
        new (3, "Jamal","Ali"),
        new (4, "Ali","Mohammed"),
        new (5, "Abdelrahman","Youssef"),
        new (6, "Marwa","Mohamed"),
        new (7, "Manar","Ahmed"),
        };

       public override string ToString() => $"{Fname} {Lname}";

    }


}
