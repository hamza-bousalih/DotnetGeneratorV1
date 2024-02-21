using Lamar;
using Microsoft.AspNetCore.Mvc;

namespace DotnetGenerator.Data;

[Route("/loader")]
[ApiController]
public class Loader : ControllerBase
{
    private DataLoader _loader;

    public Loader(IContainer container)
    {
        _loader = container.GetInstance<DataLoader>();
    }

    [HttpGet]
    public async Task Load()
    {
        await _loader.Load();
    }
}