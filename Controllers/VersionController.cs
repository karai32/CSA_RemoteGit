using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using KlientServ.Models;

namespace KlientServ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            var versionInfo = new Versions
            {
                Company = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company,
                Product = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product,
                ProductVersion = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion
            };

            return Ok(versionInfo);
        }
    }
}
