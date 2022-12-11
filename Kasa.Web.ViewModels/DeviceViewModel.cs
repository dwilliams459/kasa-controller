using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasa.Web.ViewModels
{
    public class DeviceViewModel
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Model { get; set; }
        public string? MAC { get; set; }
        public string? Maker { get; set; }
        public string? IP { get; set; }
        public int? DeviceTypeId { get; set; }
        public string DeviceTypeName { get; set; }
    }
}
