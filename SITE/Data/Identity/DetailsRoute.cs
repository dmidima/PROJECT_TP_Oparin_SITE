using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;
using System.ComponentModel.DataAnnotations.Schema;

namespace SITE.Data.Identity
{
    [Table("DetailsRoutes", Schema = "data")]
    public class DetailsRoute
    {
        public int Id { get; set; }

        //public int NumberR { get; set; }

        public string Name { get; set; }

        public string Day { get; set; }

        public string? DepartureTime { get; set; }

        public int RouteNumber { get; set; }

        public string Transport { get; set; }

        public string TravelTime { get; set; }

        public string Distance { get; set; }

        public decimal Prise { get; set; }
    }
}
