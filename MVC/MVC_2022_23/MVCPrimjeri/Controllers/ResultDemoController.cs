using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCPrimjeri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPrimjeri.Controllers
{
    public class ResultDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //https://localhost:44327/resultdemo/greetuser
        public IActionResult GreetUser()
        {
            //vraćamo obični string koji će se prikazati u browseru
            return Content("Hello user");

            //bit će prikazano kao html, da nismo naveli prikazalo bi kao običan tekst
            //return Content("<div><b>Hello user</b></div>", "text/html");

            //bit će prikazano kao xml, da nismo naveli prikazalo bi kao običan tekst
            //return Content("<div><b>Hello user</b></div>", "text/xml");

        }

        //poziv = https://localhost:44329/resultdemo/NekiView?pozdrav
        //ako ne proslijedimo parametar ispisat će Neka poruka
        //nemamo view pa ovo neće raditi
        public IActionResult NekiView(string message = "Neka poruka")
        {
            ViewBag.Message = message;
            return View();
        }


        #region Redirect
        //https://localhost:44327/resultdemo/gotourl
        public IActionResult GoToUrl()
        {
            //Status code: 302
            //A 302 Found message is an HTTP response status code indicating that the requested resource has been temporarily moved to a different URI.
            return Redirect("http://www.google.com");
        }

        //https://localhost:44327/resultdemo/GoToUrlPermanently
        public IActionResult GoToUrlPermanently()
        {
            //Status code: 301
            //A 301 Moved Permanently is an HTTP response status code indicating that the requested resource has been permanently moved to a new URL
            return RedirectPermanent("http://www.google.com");
        }


        //preusmjerava na neku drugu metodu, u ovom slučaju Contact, i prosljeđuje parametar je metoda Contact prima parametar message
        //https://localhost:44327/resultdemo/GoToContactsAction
        public IActionResult GoToContactsAction()
        {
            return RedirectToAction("Contact", new { message = "Redirect iz druge metode" });
        }

        #endregion Redirect


        //vratit će neku datoteku za download kao odgovor, u ovom slučaju file kojeg imamo u css folderu
        //https://localhost:44327/resultdemo/DownloadFile
        public IActionResult DownloadFile()
        {
            return File("/css/site.css", "text/plain", "newsite.css");
        }

        //vraća odgovor kao Json ({"productCode":1,"name":"Bajadera","cost":5})
        //https://localhost:44327/resultdemo/ShowNewProducts
        public IActionResult ShowNewProducts()
        {
            Product prod = new Product();
            prod.ProductCode = 1;
            prod.Name = "Bajadera";
            prod.Cost = 5;
            return Json(prod);
        }

        //https://localhost:44327/resultdemo/EmptyResultDemo
        public IActionResult EmptyResultDemo()
        {
            //Status code: 200 (Ok)
            return new EmptyResult();
        }

        //https://localhost:44327/resultdemo/NoContentResultDemo
        public IActionResult NoContentResultDemo()
        {
            //Status code: 204
            return NoContent();
        }


        #region BadRequest
        //vratit će 400 i u browseru će se prikazati standardni prikaz za error 400
        //https://localhost:44327/resultdemo/BadRequestResultDemo
        public IActionResult BadRequestResultDemo()
        {
            return BadRequest("Krivi podaci");
        }

        //https://localhost:44327/resultdemo/ReturnBadRequest
        //vratit će u ovom slučaju 400 i u browseru će se prikazati standardni prikaz za error 400
        //možemo vratiti bilo koji StatusCode na ovaj način, ovisno o potrebama 
        public IActionResult ReturnBadRequest()
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        #endregion BadRequest


        #region Unauthorized
        //dobijemo stranicu s greškom 401
        //https://localhost:44327/resultdemo/UnauthorizedResultDemo
        public IActionResult UnauthorizedResultDemo()
        {
            return Unauthorized();
        }

        #endregion Unauthorized


        //404 status code
        //https://localhost:44327/resultdemo/NotFoundDemo
        public IActionResult NotFoundDemo()
        {
            return NotFound();
        }

        //Status code 200
        //https://localhost:44327/resultdemo/ReturnOk
        public IActionResult ReturnOk()
        {
            return new OkObjectResult(new { Message = "Ok" });
        }

    }
}
