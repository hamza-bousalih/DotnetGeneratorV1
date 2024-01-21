using DotnetGenerator.Bean.Core;
using DotnetGenerator.Service.Facade;
using Lamar;

namespace DotnetGenerator.Data;

public class DataLoader
{
    private readonly AchatService _achatService;

    public DataLoader(IContainer container)
    {
        _achatService = container.GetInstance<AchatService>();
    }

    public async Task Generate()
    {
        await GenerateAchats();
    }

    private async Task GenerateAchats()
    {
        var items = new List<Achat>();
        for (var i = 0; i < 100; i++)
        {
            var item = new Achat()
            {
                Total = i,
                TotalPaye = i + 1,
                Description = "Description" + i,
                Reference = "Reference" + i,
                DateAchat = DateTime.Now,
            };
            items.Add(item);
        }
        await _achatService.Create(items);
    }
}