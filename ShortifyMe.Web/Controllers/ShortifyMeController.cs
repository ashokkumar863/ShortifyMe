using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UrlShortner;

namespace ShortifyMe.Web.Controllers
{
    public class ShortifyMeController : ApiController
    {

      [HttpGet]
      [Route( "{shortCode}" )]
      public HttpResponseMessage RedirectToMainUrl(string shortCode) {
        var urlResponse=new DbOperations().Retrive(shortCode);
        var response = Request.CreateResponse( HttpStatusCode.Moved );
        response.Headers.Location = new Uri(urlResponse.MainUrl );
        return response;
      }

    [HttpPost]
      [Route("api/shortifyme/getShortUrl")]
      public ShortenResponse GetShortUrl([FromBody]ShortenRequest request)
      {
        return new ShortCodeGenerator().GetShortUrl(request);
      }

  }
}
