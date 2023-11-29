using System.ComponentModel.DataAnnotations.Schema;

namespace SITE.Data.Identity
{
    [Table("Bookings", Schema = "data")]
    public class Booking
    {

        public int Id { get; set; }

        public DateTime DateBook { get; set; }
        
        public string TimeBook { get; set; }

        public int Seat { get; set; }

        public string? Email { get; set; }

        public string? otkyda { get; set; }

        public string? kyda { get; set; }

        public string? sostoania { get; set; }
    }
}
