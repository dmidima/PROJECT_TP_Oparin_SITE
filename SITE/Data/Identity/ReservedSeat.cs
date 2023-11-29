using System.ComponentModel.DataAnnotations.Schema;

namespace SITE.Data.Identity
{
    [Table("ReservedSeats", Schema = "data")]
    public class ReservedSeat
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string DataTimeRoute { get; set; }

        public int SeatNumber { get; set; }

        public string NameRoute { get; set; }
    }
}
