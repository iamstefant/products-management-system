using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagementBusenssLogic.ViewModels.ComputerViewModels
{
    public class ComputerViewModel
    {
        public int ComputerId { get; set; }
        public string? ComputerName { get; set; }
        public string? OwnerName { get; set; }
        public string? Cpu { get; set; }
        public string? Ram { get; set; }
        public string? Gpu { get; set; }
        public string? Hdd { get; set; }
    }
}
