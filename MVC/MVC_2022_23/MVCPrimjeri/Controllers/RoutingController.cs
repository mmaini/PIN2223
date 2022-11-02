using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPrimjeri.Controllers
{
    [Route("Admin/[controller]")]
    public class RoutingController : Controller
    {
        //https://localhost:44327/admin/routing/
        public IActionResult Index()
        {
            return Ok("Admin");
        }

        //https://localhost:44327/admin/routing/test
        //https://localhost:44327/admin/routing/routing/test
        //https://localhost:44327/admin/routing/routing/test/5
        [Route("Test")]
        [Route("Routing/Test")]
        [Route("Routing/Test/{id?}")]
        public IActionResult Test(int id)
        {
            return Ok(id);
        }

    }
}
