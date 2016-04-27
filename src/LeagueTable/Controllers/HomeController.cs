using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using LeagueTable.API;
using Newtonsoft.Json;
using LeagueTable.Models;
using LeagueTable.ViewModels;
using LeagueTable.Calculations;

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
            return View(LeagueTable);
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
