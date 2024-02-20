using AutoMapper;
using DotnetGenerator.Zynarator.Controller;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Common;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using DotnetGenerator.Zynarator.Security.Ws.Dto;
using DotnetGenerator.Zynarator.Util;
using Lamar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetGenerator.Zynarator.Security.Ws.Facade;

[Route("api/admin/modelPermission/")]
[Authorize(Roles = AuthoritiesConstants.Admin)]
[ApiController]
public class ModelPermissionRest : BaseController<ModelPermission, ModelPermissionDto, ModelPermissionService,
    ModelPermissionCriteria>
{
    [HttpGet("id/{id:long}")]
    public override Task<ActionResult<ModelPermissionDto>> FindById(long id) => base.FindById(id);

    [HttpGet]
    public override Task<ActionResult<List<ModelPermissionDto>>> FindAll() => base.FindAll();

    [HttpPost]
    public override Task<ActionResult<ModelPermissionDto>> Create(ModelPermissionDto dto) => base.Create(dto);

    [HttpPut]
    public override Task<ActionResult<ModelPermissionDto>> Update(ModelPermissionDto dto) => base.Update(dto);

    [HttpDelete("id/{id:long}")]
    public override Task<ActionResult<int>> DeleteById(long id) => base.DeleteById(id);

    [HttpDelete]
    public override Task<ActionResult<int>> Delete(ModelPermissionDto dto) => base.Delete(dto);

    [HttpPost("multiple")]
    public override Task<ActionResult<int>> Delete(List<ModelPermissionDto> dtos) => base.Delete(dtos);

    [HttpGet("optimized")]
    public override async Task<ActionResult<List<ModelPermissionDto?>>> FindOptimized()
    {
        return await base.FindOptimized();
    }

    [HttpPost("find-by-criteria")]
    public override async Task<ActionResult<List<ModelPermissionDto?>>> FindByCriteria(ModelPermissionCriteria criteria)
    {
        return await base.FindByCriteria(criteria);
    }

    [HttpPost("find-paginated-by-criteria")]
    public override async Task<ActionResult<PaginatedList<ModelPermissionDto?>>> FindPaginatedByCriteria(
        ModelPermissionCriteria criteria)
    {
        return await base.FindPaginatedByCriteria(criteria);
    }

    public ModelPermissionRest(IContainer container, IMapper mapper) : base(container, mapper)
    {
    }
}