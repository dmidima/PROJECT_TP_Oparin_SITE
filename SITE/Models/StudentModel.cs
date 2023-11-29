namespace SITE.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime BirthData { get; set; }

        public bool Deleted { get; set; }

        public decimal Prise { get; set; }

        public string FullName { get; set; }
    }
}
