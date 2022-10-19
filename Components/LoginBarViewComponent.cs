using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MM.Areas.Identity.ViewModels;

namespace MM.Components
{
    public class LoginBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new LoginViewModel());
        }
    }
}
