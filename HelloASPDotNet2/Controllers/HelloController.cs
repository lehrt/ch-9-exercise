using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloASPDotNet2.Controllers
{
    //[Route("/helloworld")] //** now this some DRY shit
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet] //says this method will only respond to get requests
        [Route("/helloworld/")] //attribute routing, so you dont have to do /(name of controller)/(method name)(AKA conventional routing).. can just do /helloworld/
        public IActionResult Index()
        {
            //string html1 = "<h1>Hello world</h1";
            string html = "<form method='post' action = '/helloworld/welcome'>" + //action, once this page submits, where does it go next, etc. how 'name' gets to next
                "<input type='text' name='name' />" +
                //"<input type='submit' value='Greet Me!'/>" + "</form>";
                "<select>";

            return Content(html, "text/html");
        }

        [HttpGet]
        [Route("helloworld/greetuser/")]
        public IActionResult GreetUser()
        {
            string openingFormTag = "<form method='get' action ='/helloworld/welcome/'>";
            string closingFormTag = "</form>";
            string name = "<label> Your name <input type='text' name = 'name' /> </label>";
            string languageInput = "<select name='language'> <option value=''> *Select a language* </option> <option value = '1'> English </option> <option value = '2'> Korean </option> <option value = '3'> Chinese </option> <option value = '4'> Arabic </option> <option value = '5'> Spanish </option> </select>";
            string button = "<button action ='/helloworld/welcome/'>Greet Me!</button>";
            string html = $"{openingFormTag}{name}{languageInput}{button}{closingFormTag}";

            //string userInput = "<form method='post' action='/helloworld/welcome/>" + "< label >" + "Your name" + "< input type = 'text' name = 'name' />" + "</ label >";
            return Content(html, "text/html");
        }
        // GET hello/welcome ("localhost:5000/hello/welcome?name=Theresa"), 1 way get could get a name
        //[Route("/helloworld/welcome/{name?}")]//allows name to be passed with attribute routing. Here name? becomes optional, 'name' is not. 
        //[Route("/helloworld/welcome/{name}/{Language+Of+Choice?}")]

        //[HttpGet("welcome/{name}/{Language+Of+Choice}")]//gets rid of need for route attribute
        //[HttpPost] //now it responds to post requests

        //public IActionResult Welcome(string name = "World")
        //{
        //    return Content("<h1> Welcome to my app, " + name + "!</h1>", "text/html");
        //}
        [HttpGet]
        [Route("/helloworld/welcome/")]
        public IActionResult Welcome(string name = "!", int language = 1)
        {
            string html;
            if (language == 1)
            {
                html = $"<h1> Welcome {name}!</h1>";
            }
            else if (language == 2)
            {
                html = $"<h1>어서 오십시오</span> {name}!</h1>";
            }
            else if (language == 3)
            {
                html = $"<h1> Huan ying {name}!</h1>";
            }
            else if (language == 4)
            {
                html = $"<h1> Marhaban {name}!</h1>";
            }
            else
            {
                html = $"<h1> Bien venidos {name}!</h1>";
            }

            return Content(html, "text/html");
        }
    }
}
