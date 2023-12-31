﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PaqueteTuristico.Models
{
    public class TourPackage
    {
        public TourPackage() {
            this.DayliActivities = new HashSet<DayliActivities>();
        }
        [Key]
        public int PackageId { get; set; }
        public int ProvinceId { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public int MealId { get; set; }
        public int? VehicleId { get; set; }
        public int?  ModalityId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int PeopleCant {  get; set; }
        [Column(TypeName = "date")]
        [Required]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        [Required]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal Totalprice { get; set; }

        public ICollection<DayliActivities>  DayliActivities { get; set; }

    }
}
