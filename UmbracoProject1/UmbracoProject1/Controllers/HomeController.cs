using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using UmbracoProject1.Models;
using Umbraco.Cms.Web;
using Umbraco.Cms.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace UmbracoProject1.Controllers
{
	public class HomeController : SurfaceController
	{
		public HomeController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
		{
		}

		private const bool V = true;
		public readonly DataContext _context;
		public HomeController(DataContext context) => _context =context;

		[HttpGet]
		public ActionResult GetAllMovie()
		{
			List<Movies> move = _context.Movies.ToList();
			return PartialView("AllMovies");
		}


			public ActionResult GetById(int id)
			{
			var moveId = _context.Movies.FirstOrDefault(e => e.Id == id);
			return PartialView(moveId);
			}


		[HttpPost]
		public ActionResult Add(Movies model)
		{
			if (!ModelState == true)
			{
				return (ModelState);

			}
			else
			{
           		_context.Add(model);
				_context.SaveChanges();
			}
			return PartialView(ModelState);
		}

        [HttpPost]
        public ActionResult Delete(int id)
        {
			var move = _context.Movies.FirstOrDefault(e=> e.Id == id);
			if(move!= null)
			{
				_context.Movies.Remove(move);
				_context.SaveChanges();
			}
			else
			{
				throw new Exception("Not Found in DataBase");
			}
            return RedirectToAction("AllMovies");
        }
    }
}
