using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSolutionAPIWithRepositoryPattern.Models
{
    public class RoomModel
    {
        [Required]
        [Key]
        public int RoomNumber { get; set; }

        [Required]
        public string CostPerTwelveHours { get; set; }

        public string IsOccupied { get; set; }
    }
}
