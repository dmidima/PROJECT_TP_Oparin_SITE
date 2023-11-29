using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace SITE.Data.Identity
{
    [Table("Transports", Schema = "data")]
    public class Transport
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Brand { get; set; }

        public int PlaceCount { get; set; }

        public string RouteNum { get; set; }

    }
}
