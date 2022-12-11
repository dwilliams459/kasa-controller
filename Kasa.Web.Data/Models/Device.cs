using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kasa.Web.Data.Models
{
    public partial class Device
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Model { get; set; }
        public string Mac { get; set; } = null!;
        public string? Maker { get; set; }
        public string? Ip { get; set; }

        [Column("DeviceType")]
        public int? DeviceTypeId { get; set; }

        [ForeignKey("DeviceTypeId")]
        public DeviceType DeviceType { get; set; }
    }
}
