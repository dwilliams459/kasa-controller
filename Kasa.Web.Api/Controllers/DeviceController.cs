using Kasa.Web.Data.Models;
using Kasa.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kasa.Web.Api.Controllers
{
    [ApiController]
    [Route("Devices")]
    public class DeviceController : ControllerBase
    {
        private HomeAutomationContext _ctx;

        public DeviceController(HomeAutomationContext context)
        {
            _ctx = context;
        }

        [HttpGet]
        public async Task<List<DeviceViewModel>> Get()
        {
            var devices = _ctx.Devices.Include(d => d.DeviceType)
                .Select(d => new DeviceViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    DeviceTypeId = d.DeviceType.Id,
                    DeviceTypeName = d.DeviceType.Name,
                    IP = d.Ip,
                    MAC = d.Mac,
                    Maker = d.Maker,
                    Model = d.Model
                });

            return await devices.ToListAsync();
        }

        //[HttpGet(Name = "Ping")]
        //public async Task<string> Ping()
        //{
        //    return DateTime.Now.ToString("MM-dd-yy HH-mm-ss");
        //}
    }
}
