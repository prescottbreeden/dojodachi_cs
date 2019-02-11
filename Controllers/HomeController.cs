using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dojodachi.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace dojodachi.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("")]
    public IActionResult Index()
    {
      Dojodachi dojo = DojodachiHelper.Get(HttpContext);
      return View(dojo);
    }

    [HttpGet("/feed")]
    public IActionResult Feed()
    {
      Dojodachi dojo = DojodachiHelper.Get(HttpContext);
      dojo.Feed();
      DojodachiHelper.Save(HttpContext, dojo);
      return RedirectToAction("Index");
    }

    [HttpGet("/play")]
    public IActionResult Play()
    {
      Dojodachi dojo = DojodachiHelper.Get(HttpContext);
      dojo.Play();
      DojodachiHelper.Save(HttpContext, dojo);
      return RedirectToAction("Index");
    }

    [HttpGet("/work")]
    public IActionResult Work()
    {
      Dojodachi dojo = DojodachiHelper.Get(HttpContext);
      dojo.Work();
      DojodachiHelper.Save(HttpContext, dojo);
      return RedirectToAction("Index");
    }

    [HttpGet("/sleep")]
    public IActionResult Sleep()
    {
      Dojodachi dojo = DojodachiHelper.Get(HttpContext);
      dojo.Sleep();
      DojodachiHelper.Save(HttpContext, dojo);
      return RedirectToAction("Index");
    }

    [HttpGet("/reset")]
    public IActionResult Reset()
    {
      Dojodachi dojo = new Dojodachi();
      DojodachiHelper.Save(HttpContext, dojo);
      return RedirectToAction("Index");
    }

  }
}
