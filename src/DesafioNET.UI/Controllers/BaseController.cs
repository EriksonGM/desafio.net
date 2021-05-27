using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace DesafioNET.UI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
