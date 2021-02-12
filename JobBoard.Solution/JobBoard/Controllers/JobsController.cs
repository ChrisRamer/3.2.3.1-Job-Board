using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using JobBoard.Models;

namespace JobBoard.Controllers
{
	public class JobsController : Controller
	{
		[HttpGet("/jobs")]
		public ActionResult Index()
		{
			List<Job> allJobs = Job.GetAll();
			return View(allJobs);
		}

		[HttpGet("/jobs/new")]
		public ActionResult New()
		{
			return View();
		}

		[HttpPost("/jobs")]
		public ActionResult Create(string title, string description, string expectations, int wage, string contactInfo)
		{
			Job newJob = new Job(title, description, expectations, wage, contactInfo);
			return RedirectToAction("Index", newJob);
		}

		[Route("/jobs/delete")]
		public ActionResult DeleteAll()
		{
			Job.ClearAll();
			return View();
		}

		[HttpGet("/jobs/{id}")]
		public ActionResult Show(int id)
		{
			Job foundJob = Job.Find(id);
			return View(foundJob);
		}
	}
}