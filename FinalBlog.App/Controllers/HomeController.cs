﻿using Microsoft.AspNetCore.Mvc;
using FinalBlog.Services.ViewModels;
using System.Diagnostics;

namespace FinalBlog.App.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        /// <summary>
        /// Домашняя страница
        /// </summary>
        public IActionResult Index(string? returnUrl)
        {
            if (User.Identity!.IsAuthenticated)
            {
                if (returnUrl != null && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                return View();
            }
            return View();
        }

        /// <summary>
        /// Страница политики конфиденциальности
        /// </summary>
        public IActionResult Privacy() => View();

        /// <summary>
        /// Страница отчёта об ошибке для разработчиков
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}