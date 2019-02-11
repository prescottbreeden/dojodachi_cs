using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace dojodachi.Models
{
  public static class DojodachiHelper
  {
    public static Dojodachi Get(HttpContext context)
    {
      string dd = context.Session.GetString("dachi");
      if (dd is null)
      {
        Dojodachi dojo = new Dojodachi();
        context.Session.SetString("dachi", JsonConvert.SerializeObject(dojo));
        return dojo;
      }
      else
      {
        Dojodachi dojo = JsonConvert.DeserializeObject<Dojodachi>(dd);
        return dojo;
      }
    }
    public static void Save(HttpContext context, Dojodachi dojo)
    {
      context.Session.SetString("dachi", JsonConvert.SerializeObject(dojo));
    }

  }
}