using AutoMapper;
using DotnetGenerator.Bean.Core;
using DotnetGenerator.Service.Facade;
using DotnetGenerator.Ws.Dto;
using DotnetGenerator.Zynarator.Controller;
using Lamar;
using Microsoft.AspNetCore.Mvc;
using DotnetGenerator.Zynarator.Util;
using DotnetGenerator.Dao.Criteria;

namespace DotnetGenerator.WS.Facade;

[Route("api/admin/produit/")]
[ApiController]
public class ProduitRest : BaseController<Produit, ProduitDto, ProduitService, ProduitCriteria>
{
    [HttpGet("id/{id:long}")]
    public override Task<ActionResult<ProduitDto>> FindById(long id) => base.FindById(id);

    [HttpGet]
    public override Task<ActionResult<List<ProduitDto>>> FindAll() => base.FindAll();

    [HttpPost]
    public override Task<ActionResult<ProduitDto>> Create(ProduitDto dto) => base.Create(dto);

    [HttpPut]
    public override Task<ActionResult<ProduitDto>> Update(ProduitDto dto) => base.Update(dto);

    [HttpDelete("id/{id:long}")]
    public override Task<ActionResult<int>> DeleteById(long id) => base.DeleteById(id);

    [HttpDelete]
    public override Task<ActionResult<int>> Delete(ProduitDto dto) => base.Delete(dto);

    [HttpPost("multiple")]
    public override Task<ActionResult<int>> Delete(List<ProduitDto> dtos) => base.Delete(dtos);

    [HttpGet("optimized")]
    public override async Task<ActionResult<List<ProduitDto?>>> FindOptimized()
    {
        return await base.FindOptimized();
    }

    [HttpPost("find-by-criteria")]
    public override async Task<ActionResult<List<ProduitDto?>>> FindByCriteria(ProduitCriteria criteria)
    {
        return await base.FindByCriteria(criteria);
    }

    [HttpPost("find-paginated-by-criteria")]
    public override async Task<ActionResult<PaginatedList<ProduitDto?>>> FindPaginatedByCriteria(
        ProduitCriteria criteria)
    {
        return await base.FindPaginatedByCriteria(criteria);
    }

    public ProduitRest(IContainer container, IMapper mapper) : base(container, mapper)
    {
    }
}