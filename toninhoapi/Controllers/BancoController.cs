using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using toninhoapi.model;

namespace toninhoapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BancoController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var listaPagamentos = new DetalhePagamento() { 
                        listaPagamentos = new List<Pagamento>() 
                        {
                            new Pagamento {
                                token = "1",
                                formaPagar = "Debito"
                            }, 
                            new Pagamento {
                                token = "2",
                                formaPagar = "Credito"
                            }
                    }
                };
                return Ok(listaPagamentos);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
