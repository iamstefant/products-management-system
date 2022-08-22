using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.DataAccess.Models
{
    [Table("OracleProduct", Schema = "Dbo")]
    public class OracleProduct
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public virtual IList<ComputerInstallation>? ComputerInstallation { get; set; }

        //public virtual ICollection<Computers>? Computers { get; set; }
    }
}
