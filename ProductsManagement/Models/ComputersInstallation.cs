using Microsoft.EntityFrameworkCore;

namespace ProductsManagement.Models
{
    [Keyless]
    public class ComputersInstallation
    {
        public int? ProductId { get; set; }
        public int? ComputerId { get; set; }
        public DateTime DateOfInstallation { get; set; }
        public string? PersonOfInstallation { get; set; }
    }
}
