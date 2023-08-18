using Microsoft.AspNetCore.Mvc;
using Teste_Pratico_DTI.Models;
using System.Collections.Generic;
using System.Buffers.Text;
using System.Runtime.InteropServices;
using System.Threading;
using Project.Service;

namespace Project.Controllers
{
    [ApiController]
    [Route("/procura_petshops")]
   
    
    public class PetShopController : ControllerBase
    {
    

        [HttpPost()]
        public IActionResult procuraPetshop([FromBody] PetshopRequestModel request)
        {

            var cachorrosGrandes = request.CachorrosGrandes;
            var cachorrosPequenos = request.CachorrosPequenos;
            var data = request.Data;



            PetshopService petshopService = new ProcuraPetshopServiceImpl();

            var result = petshopService.procuraPetshop(request, cachorrosGrandes, cachorrosPequenos, data);

            return Ok(result);
        }
    }
}