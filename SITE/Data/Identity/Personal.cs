using System.ComponentModel.DataAnnotations.Schema;

namespace SITE.Data.Identity
{
    [Table("Personals", Schema = "data")]
    public class Personal
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Job { get; set; }

        public string WorkTime { get; set; }
    }
}
