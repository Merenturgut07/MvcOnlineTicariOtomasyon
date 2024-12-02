using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariMesajController : Controller
    {
        // GET: CariMesaj
        Context c=new Context();
        public ActionResult Index()
        {
            return View();
        }
    }
}