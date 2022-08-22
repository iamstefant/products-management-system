using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.DataAccess.Models
{
    [Table("Computer", Schema = "Dbo")]
    public class Computer
    {
        [Key]
        public int ComputerId { get; set; }
        public string? ComputerName { get; set; }
        public string? OwnerName { get; set; }
        public string? Cpu { get; set; }
        public string? Ram { get; set; }
        public string? Gpu { get; set; }
        public string? Hdd { get; set; }
       public virtual IList<ComputerInstallation>? ComputerInstallation{ get; set; }
       // public virtual ICollection<OracleProducts>? OracleProducts { get; set; }
    }
}
