// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HotelManagement.Areas.Admin.Models;
using HotelManagement.ExtendMethods;
using HotelManagement.Models;
using HotelManagement.Data;
using HotelManagement.Services;
using HotelManagement.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using X.PagedList;

namespace HotelManagement.Areas.Admin.Controllers
{

    [Authorize(Roles = Constants.ROLE_ADMIN)]
    [Area("Admin")]
    [Route("/Home/[action]")]
    public class RoomController : Controller
    {
        private readonly ILogger<RoomController> _logger;
        private readonly ApplicationDbContext _context;
        public RoomController(
            ILogger<RoomController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("/admin/room")]
        public IActionResult Index(string room = "", int status = 0, int? page = null)
        {
            var model = (from roomCus in _context.Room
                         join type in _context.RoomType on roomCus.RoomTypeID equals type.RoomTypeID
                         where roomCus.Name.Contains(room) && (status == 0 || roomCus.State == status)
                         select new RoomViews
                         {
                             RoomID = roomCus.RoomID,
                             RoomName = roomCus.Name,
                             RoomType = type.TypeName,
                             Price = type.Price,
                             State = roomCus.State
                         }).ToList();
                         var model2 = model.ToPagedList(page ?? 1, 5);
            return View(model2);
        }
    }
}