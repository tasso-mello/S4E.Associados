namespace api.S4E.Associados.Controllers
{
    using api.S4E.Associados.Controllers.Base;
    using core.S4E.Associados.Contracts;
    using domain.S4E.Associados.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class AssociadoController : BaseController, IBaseController<Associado>
    {
        private readonly ICoreAssociado coreAssociado;

        public AssociadoController(ICoreAssociado coreAssociado)
        {
            this.coreAssociado = coreAssociado;
        }

        public async Task<IActionResult> Get(int id)
            => await ToResponseAsync(await coreAssociado.Get(id), Request.Method);

        public async Task<IActionResult> Get(int skip = 1, int take = 10)
            => await ToResponseAsync(await coreAssociado.Get(skip, take), Request.Method);

        public async Task<IActionResult> Get(string filter, int skip = 1, int take = 10)
            => await ToResponseAsync(await coreAssociado.Get(filter, skip, take), Request.Method);

        public async Task<IActionResult> Post(Associado jsonObject)
            => await ToResponseAsync(await coreAssociado.Post(jsonObject), Request.Method);

        public async Task<IActionResult> Put(Associado jsonObject)
            => await ToResponseAsync(await coreAssociado.Put(jsonObject), Request.Method);

        public async Task<IActionResult> Delete(int id)
            => await ToResponseAsync(await coreAssociado.Delete(id), Request.Method);
    }
}