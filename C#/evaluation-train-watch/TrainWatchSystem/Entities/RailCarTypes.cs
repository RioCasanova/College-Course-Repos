#nullable disable
#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion
namespace TrainWatchSystem.Entities
{
    [Table("RailCarTypes")]
    public class RailCarTypes
    {
        [Key]
        public int RailCarTypeID { get; set; }

        [Required(ErrorMessage = "Name is required and limited to 30 characters")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Name is limited to 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Commodity is required and limited to 100 characters")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Commodity is limited to 100 characters")]
        public string Commodity { get; set; }
    }
}
