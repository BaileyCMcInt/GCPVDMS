using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GCPVDMS.Models;

namespace GCPVDMS.Controllers
{
    public class DriveController : Controller
    {
        private IDriveRepository repository;
        public DriveController(IDriveRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Drives);
    }
}
