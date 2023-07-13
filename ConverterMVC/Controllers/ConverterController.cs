using ConverterMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConverterMVC.Controllers;

public class ConverterController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(ConverterViewModel cvm)
    {
        double f = ConvertFtoC(double.Parse(cvm.Celsius));
        ViewBag.F = f;
        return View();
    }

    public double ConvertFtoC(double f)
    {
        return (f - 32) * 5 / 9;
    }
}