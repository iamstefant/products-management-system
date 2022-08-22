using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.DataAccess.Models
{
    [Table("ComputerInstallation", Schema = "Dbo")]
    public class ComputerInstallation
    {
        [Key]
        public int Id { get; set; }      
        public DateTime DateOfInstallation { get; set; }
        public string? PersonOfInstallation { get; set; }

        public int? ComputerId { get; set; }
        public Computer? Computer { get; set; }

        public int ProductId { get; set; }
        public OracleProduct? OracleProduct { get; set; }
    }
}
