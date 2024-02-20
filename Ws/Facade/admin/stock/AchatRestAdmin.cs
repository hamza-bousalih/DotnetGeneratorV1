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

[Route("api/admin/achat/")]
[ApiController]
public class AchatRest : BaseController<Achat, AchatDto, AchatService, AchatCriteria>
{
    [HttpGet("id/{id:long}")]
    public override Task<ActionResult<AchatDto>> FindById(long id) => base.FindById(id);

    [HttpGet]
    public override Task<ActionResult<List<AchatDto>>> FindAll() => base.FindAll();

    [HttpPost]
    public override Task<ActionResult<AchatDto>> Create(AchatDto dto) => base.Create(dto);

    [HttpPut]
    public override Task<ActionResult<AchatDto>> Update(AchatDto dto) => base.Update(dto);

    [HttpDelete("id/{id:long}")]
    public override Task<ActionResult<int>> DeleteById(long id) => base.DeleteById(id);

    [HttpDelete]
    public override Task<ActionResult<int>> Delete(AchatDto dto) => base.Delete(dto);

    [HttpPost("multiple")]
    public override Task<ActionResult<int>> Delete(List<AchatDto> dtos) => base.Delete(dtos);

    [HttpGet("optimized")]
    public override async Task<ActionResult<List<AchatDto?>>> FindOptimized()
    {
        return await base.FindOptimized();
    }

    [HttpPost("find-by-criteria")]
    public override async Task<ActionResult<List<AchatDto?>>> FindByCriteria(AchatCriteria criteria)
    {
        return await base.FindByCriteria(criteria);
    }

    [HttpPost("find-paginated-by-criteria")]
    public override async Task<ActionResult<PaginatedList<AchatDto?>>> FindPaginatedByCriteria(AchatCriteria criteria)
    {
        return await base.FindPaginatedByCriteria(criteria);
    }

    public AchatRest(IContainer container, IMapper mapper) : base(container, mapper)
    {
    }
}