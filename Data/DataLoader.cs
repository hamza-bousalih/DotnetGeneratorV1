using DotnetGenerator.Bean.Core;

namespace DotnetGenerator.Data;

public class DataLoader
{
    private readonly AppDbContext _context;

    public DataLoader(AppDbContext context)
    {
        _context = context;
    }

    public Task<int> Generate()
    {
        GenerateClients();
        var saveChangesAsync = _context.SaveChangesAsync();
        return saveChangesAsync;
    }

    private void GenerateClients()
    {
        for (var i = 0; i < 10; i++)
        {
            var item = new Client()
            {
                Cin = "cin" + i,
                Email = "Email" + i,
                Description = "Description" + i,
                Nom = "Nom" + i,
            };
            _context.Clients.Add(item);
        }
    }
}