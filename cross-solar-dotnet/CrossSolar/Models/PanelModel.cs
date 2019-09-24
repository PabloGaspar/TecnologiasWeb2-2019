using System.ComponentModel.DataAnnotations;

namespace CrossSolar.Models
{
    public class PanelModel
    {
        public int Id { get; set; }

        [Required]
        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Range(-180, 180)] public double Longitude { get; set; }

        [Required] public string Serial { get; set; }

        public string Brand { get; set; }
    }
}