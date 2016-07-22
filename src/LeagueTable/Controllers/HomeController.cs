using System.Collections.Generic;
using System.Threading.Tasks;
using LeagueTable.API;
using Newtonsoft.Json;
using LeagueTable.Models;
using LeagueTable.ViewModels;
using LeagueTable.Calculations;
using Microsoft.AspNetCore.Mvc;

namespace LeagueTable.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string t = await Access.getLeagueTable();
            LogData LeagueTable = JsonConvert.DeserializeObject<LogData>(t);
            List<WinOrLoseViewModel> ViewModel = Calculate.whoCanWinOrLose(LeagueTable);
            return View(ViewModel);
        }

        public async Task<IActionResult> log()
        {
            string t = await Access.getLeagueTable();
            LogData LeagueTable = JsonConvert.DeserializeObject<LogData>(t);
            return View("Log", LeagueTable);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
