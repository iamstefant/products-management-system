using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsManagement.Models
{
    
    public class Computers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int ComputerId { get; set; }
        public string? ComputerName { get; set; }
        public string? OwnerName { get; set; }
        public string? Cpu { get; set; }
        public string? Ram { get; set; }
        public string? Gpu { get; set; }
        public string? Hdd { get; set; }

    }
}
