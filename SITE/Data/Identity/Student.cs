using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations.Schema;

namespace SITE.Data.Identity
{
    [Table("Students", Schema = "data")]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime BirthData { get; set; }

        public bool Deleted { get; set; }

        public decimal Prise { get; set; }
    }
}
