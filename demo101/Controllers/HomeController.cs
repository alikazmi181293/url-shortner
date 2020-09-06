using demo101.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo101.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public string GetRandomUrl()
        {
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
        public string ShortUrl(string Url)
        {
            if (Url.Trim() != "")
            {
                string shortUrl = GetRandomUrl();
                while (db.urlShortners.Any(ur => ur.long_url == Url))
                {
                    shortUrl = GetRandomUrl();
                }

                UrlShortner data = new UrlShortner();
                data.id = 1;
                data.long_url = Url;
                data.short_url = shortUrl;
                data.clicked = 1;
                data.created_by = "test";
                data.created_date = DateTime.Now;
                data.modfied_by = "test";
                data.modified_date = DateTime.Now;
                data.token = "";
                data.deleted = false;
                db.urlShortners.Add(data);
                db.SaveChanges();
                return shortUrl;
            }
            return "";
        }
        public void RedirectLink()
        {
             string url = Request["aspxerrorpath"]?.Replace("/", "");
             string longUrl = db.urlShortners.Where(u => u.short_url == url).Select(s => s.long_url).FirstOrDefault().ToString();
             Response.RedirectPermanent(longUrl, true);
        }
    }
}