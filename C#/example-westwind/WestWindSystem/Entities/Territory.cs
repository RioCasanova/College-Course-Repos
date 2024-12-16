#nullable disable
#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace WestWindSystem.Entities
{
    [Table("Territories")]
    public class Territory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "TerritoryID is required and limited to 20 characters")]
        public string TerritoryID { get; set; }

        [Required(ErrorMessage = "TerritoryDescriptiom is required and limited to 50 characters")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "TerritoryDescriptiom is limited to 50 characters")]
        public string TerritoryDescription { get; set; }
    }
}
