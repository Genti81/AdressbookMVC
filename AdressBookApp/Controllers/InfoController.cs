using AdressBookApp.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressBookApp.Controllers
{
    public class InfoController : Controller
    {
        private readonly IStringLocalizer<InfoController> _localizer;
        private readonly IStringLocalizer<SharedResources> _sharedLocalizer;

        public InfoController(IStringLocalizer<InfoController> localizer,
                       IStringLocalizer<SharedResources> sharedLocalizer)
        {
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
        }

        public string TestLoc()
        {
            string msg = "Shared resx: " + _sharedLocalizer["Hello!"] +
                         " Info resx " + _localizer["Hello!"];
            return msg;
        }
    }
}
