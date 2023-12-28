using Microsoft.AspNetCore.Mvc;

namespace api.S4E.Associados.Controllers.Base
{
    public interface IBaseController<T>
    {
        Task<IActionResult> Get(int id);
        Task<IActionResult> Get(int skip = 1, int take = 10);
        Task<IActionResult> Get(string filter, int skip = 1, int take = 10);
        Task<IActionResult> Put(T jsonObject);
        Task<IActionResult> Post(T jsonObject);
        Task<IActionResult> Delete(int id);
    }

    public class BaseController : ControllerBase
    {
        protected IActionResult ToResponse(string result, string method, string url = null)
            => result.Contains("error") ? HttpErrorStatusCodeResult(result, method) : HttpSuccessStatusCodeResult(result, method, url);
        protected async Task<IActionResult> ToResponseAsync(string result, string method, string url = null)
            => result.Contains("error") ? HttpErrorStatusCodeResult(result, method) : HttpSuccessStatusCodeResult(result, method, url);
        protected byte[] GetBytesFromFile(IFormFile file)
        {
            using (var memory = new MemoryStream())
            {
                file.CopyTo(memory);
                return memory.ToArray();
            }
        }
        private IActionResult HttpErrorStatusCodeResult(string result, string method)
        {
            switch (method.ToUpper())
            {
                case "GET":
                    return BadRequest(result);
                case "POST":
                    {
                        if (result.Contains("Invalid crerdentials"))
                            return Unauthorized(result);
                        else
                            return BadRequest(result);
                    }
                default:
                    return Forbid();
            }
        }
        private IActionResult HttpSuccessStatusCodeResult(string result, string method, string url = null)
        {
            switch (method.ToUpper())
            {
                case "POST":
                    return Created(url ?? string.Empty, result);
                default:
                    return Ok(result);
            }
        }
    }
}
