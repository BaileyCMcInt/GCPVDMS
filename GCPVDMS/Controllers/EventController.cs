﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GCPVDMS.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EventList()
        {
            return View();
        }

        public IActionResult EventSignUp()
        {
            return View();
        }
    }
}
