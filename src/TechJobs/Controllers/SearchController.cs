using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results


        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType.Equals("all"))
            {
                ViewBag.columns = ListController.columnChoices;
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.title = "Jobs with " + ": " + searchTerm;
                ViewBag.jobs = jobs;
                return View("Index");

            }
            else
            {
                ViewBag.columns = ListController.columnChoices;
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Jobs with " + ": " + searchTerm;
                ViewBag.jobs = jobs;
                return View("Index");
            }

        }
    }
}
