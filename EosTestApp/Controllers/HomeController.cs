using EosTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EosTestApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.ActivitySpheres.ToListAsync());
        }
        public IActionResult CreateActivitySphere()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateActivitySphere(ActivitySphere activitySpheres)
        {
            db.ActivitySpheres.Add(activitySpheres);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ActionName("DeleteActivitySphere")]
        public async Task<IActionResult> ConfirmDeleteActivitySphere(int? id)
        {
            if (id != null)
            {
                ActivitySphere activitySphere = await db.ActivitySpheres.FirstOrDefaultAsync(p => p.Id == id);
                if (activitySphere != null)
                    return View(activitySphere);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteActivitySphere(int? id)
        {
            if (id != null)
            {
                ActivitySphere activitySphere = await db.ActivitySpheres.FirstOrDefaultAsync(p => p.Id == id);
                if (activitySphere != null)
                {
                    db.ActivitySpheres.Remove(activitySphere);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> Organizations()
        {
            return View(await db.Organizations.Include(u => u.ActivitySphere).OrderBy(s => s.ActivitySphere.Name).ToListAsync());
        }
        public IActionResult CreateOrganization()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrganization(Organization organization)
        {
            db.Organizations.Add(organization);
            await db.SaveChangesAsync();
            return RedirectToAction("Organizations");
        }
        [HttpGet]
        [ActionName("DeleteOrganization")]
        public async Task<IActionResult> ConfirmDeleteOrganization(int? id)
        {
            if (id != null)
            {
                Organization organization = await db.Organizations.FirstOrDefaultAsync(p => p.Id == id);
                if (organization != null)
                    return View(organization);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrganization(int? id)
        {
            if (id != null)
            {
                Organization organization = await db.Organizations.FirstOrDefaultAsync(p => p.Id == id);
                if (organization != null)
                {
                    db.Organizations.Remove(organization);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Organizations");
                }
            }
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
