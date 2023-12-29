namespace api.S4E.Associados.Controllers
{
    using api.S4E.Associados.Controllers.Base;
    using core.S4E.Associados.Contracts;
    using domain.S4E.Associados.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : BaseController, IBaseController<Empresa>
    {
        private readonly ICoreEmpresa coreEmpresa;

        public EmpresaController(ICoreEmpresa coreEmpresa)
        {
            this.coreEmpresa = coreEmpresa;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => await ToResponseAsync(await coreEmpresa.Get(id), Request.Method);
        
        [HttpGet]
        public async Task<IActionResult> Get(int skip = 1, int take = 10)
            => await ToResponseAsync(await coreEmpresa.Get(skip, take), Request.Method);
        
        [HttpGet("{filter}/filter")]
        public async Task<IActionResult> Get(string filter, int skip = 1, int take = 10)
            => await ToResponseAsync(await coreEmpresa.Get(filter, skip, take), Request.Method);

        [HttpPost]
        public async Task<IActionResult> Post(Empresa jsonObject)
            => await ToResponseAsync(await coreEmpresa.Post(jsonObject), Request.Method);

        [HttpPut]
        public async Task<IActionResult> Put(Empresa jsonObject)
            => await ToResponseAsync(await coreEmpresa.Put(jsonObject), Request.Method);

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => await ToResponseAsync(await coreEmpresa.Delete(id), Request.Method);
    }
}
