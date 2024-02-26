using AutoMapper;
using DotnetGenerator.Bean.Core;
using DotnetGenerator.Service.Facade;
using DotnetGenerator.Ws.Dto;
using DotnetGenerator.Zynarator.Controller;
using Lamar;
using Microsoft.AspNetCore.Mvc;
using DotnetGenerator.Zynarator.Util;
using DotnetGenerator.Dao.Criteria;
using DotnetGenerator.Zynarator.Security.Common;
using Microsoft.AspNetCore.Authorization;

namespace DotnetGenerator.WS.Facade;

[Route("api/admin/achatItem/")]
[ApiController]
[Authorize(Roles = Roles.Admin)]
public class AchatItemRest : BaseController<AchatItem, AchatItemDto, AchatItemService, AchatItemCriteria>
{
    [HttpGet("id/{id:long}")]
    public override Task<ActionResult<AchatItemDto>> FindById(long id) => base.FindById(id);

    [HttpGet]
    public override Task<ActionResult<List<AchatItemDto>>> FindAll() => base.FindAll();

    [HttpPost]
    public override Task<ActionResult<AchatItemDto>> Create(AchatItemDto dto) => base.Create(dto);

    [HttpPut]
    public override Task<ActionResult<AchatItemDto>> Update(AchatItemDto dto) => base.Update(dto);

    [HttpDelete("id/{id:long}")]
    public override Task<ActionResult<int>> DeleteById(long id) => base.DeleteById(id);

    [HttpDelete]
    public override Task<ActionResult<int>> Delete(AchatItemDto dto) => base.Delete(dto);

    [HttpPost("multiple")]
    public override Task<ActionResult<int>> Delete(List<AchatItemDto> dtos) => base.Delete(dtos);

    [HttpGet("optimized")]
    public override async Task<ActionResult<List<AchatItemDto?>>> FindOptimized()
    {
        return await base.FindOptimized();
    }

    [HttpPost("find-by-criteria")]
    public override async Task<ActionResult<List<AchatItemDto?>>> FindByCriteria(AchatItemCriteria criteria)
    {
        return await base.FindByCriteria(criteria);
    }

    [HttpPost("find-paginated-by-criteria")]
    public override async Task<ActionResult<PaginatedList<AchatItemDto?>>> FindPaginatedByCriteria(
        AchatItemCriteria criteria)
    {
        return await base.FindPaginatedByCriteria(criteria);
    }

    public AchatItemRest(IContainer container, IMapper mapper) : base(container, mapper)
    {
    }
}