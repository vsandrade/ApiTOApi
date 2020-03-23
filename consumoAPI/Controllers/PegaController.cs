using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using consumoAPI.model;
using Newtonsoft.Json;

namespace consumoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PegaController : ControllerBase
    {
        public string Ip = "localhost:5000/banco";
        [HttpGet]
        public ActionResult Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://{Ip}");
            request.Method = "GET";
            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded";

            HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseBody = reader.ReadToEnd();
            reader.Close();

            DetalhePagamento serverInfo = JsonConvert.DeserializeObject<DetalhePagamento>(responseBody);
            return Ok(serverInfo);
        }
    }
}
