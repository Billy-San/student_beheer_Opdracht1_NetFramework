using Microsoft.AspNetCore.Mvc;

namespace StudentenBeheer.Controllers
{
    public class Hallo_IedereenController : Controller
    {
        public string Index()
        {
            return "";
        }

        public string Welkom(string voornaam, string achternaam)
        {
            return " Welkom " + voornaam + " " + achternaam;
        }

    }
}
