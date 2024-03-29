using DotnetGenerator.Data;
using Lamar;
using Microsoft.AspNetCore.Mvc;

namespace DotnetGenerator.WS.Facade;

[Route("api/[controller]")]
[ApiController]
public class LoaderController : ControllerBase
{
    private DataLoader _dataLoader;

    public LoaderController(IServiceContext container)
    {
        _dataLoader = container.GetInstance<DataLoader>();
    }

    [HttpPost("generate")]
    public async Task<ActionResult> GenerateData()
    {
        await _dataLoader.Generate();
        return Ok();
    }
}