#nullable disable
#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace TrainWatchSystem.Entities
{
    [Table("RollingStock")]
    public class RollingStock
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(24, MinimumLength = 1, ErrorMessage = "ReportingMark is required and limited to 24 characters")]
        public string ReportingMark { get; set; }

        [Required(ErrorMessage = "Owner field is required and limited to 50 characters")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Owner is limited to 50 characters")]
        public string Owner { get; set; }

        [Required(ErrorMessage = "LightWeight field is required")]
        public int LightWeight { get; set; }

        [Required(ErrorMessage = "LoadLimit field is required")]
        public int LoadLimit { get; set; }

        [Required(ErrorMessage = "Capacity field is required")]
        public int Capacity { get; set; }
        public int ?RailCarTypeID { get; set; }
        public int ?YearBuilt { get; set; }

        [Required(ErrorMessage = "InService field is required")]
        public bool InService { get; set; }

        [StringLength(250, ErrorMessage = "Notes is limited to 250 characters")]
        public string ?Notes { get; set; }
    }
}
