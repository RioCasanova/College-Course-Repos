using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace WestWindSystem.Entities
{
    #region Additional Namespaces
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    #endregion
    [Table("Regions")]
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        [Required(ErrorMessage = "Region description is required")]
        [StringLength(50, ErrorMessage = "Region Description is limited to 50 characters")]
        public string RegionDescription { get; set;}
    }
}
