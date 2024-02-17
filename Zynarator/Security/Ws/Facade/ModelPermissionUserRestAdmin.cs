using AutoMapper;
using DotnetGenerator.Zynarator.Controller;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using DotnetGenerator.Zynarator.Security.Ws.Dto;
using DotnetGenerator.Zynarator.Util;
using Lamar;
using Microsoft.AspNetCore.Mvc;

namespace DotnetGenerator.Zynarator.Security.Ws.Facade;

[Route("api/admin/modelPermissionUser/")]
[ApiController]
public class ModelPermissionUserRest : BaseController<ModelPermissionUser, ModelPermissionUserDto,
    ModelPermissionUserService, ModelPermissionUserCriteria>
{
    [HttpGet("id/{id:long}")]
    public override Task<ActionResult<ModelPermissionUserDto>> FindById(long id) => base.FindById(id);

    [HttpGet]
    public override Task<ActionResult<List<ModelPermissionUserDto>>> FindAll() => base.FindAll();

    [HttpPost]
    public override Task<ActionResult<ModelPermissionUserDto>> Create(ModelPermissionUserDto dto) => base.Create(dto);

    [HttpPut]
    public override Task<ActionResult<ModelPermissionUserDto>> Update(ModelPermissionUserDto dto) => base.Update(dto);

    [HttpDelete("id/{id:long}")]
    public override Task<ActionResult<int>> DeleteById(long id) => base.DeleteById(id);

    [HttpDelete]
    public override Task<ActionResult<int>> Delete(ModelPermissionUserDto dto) => base.Delete(dto);

    [HttpPost("multiple")]
    public override Task<ActionResult<int>> Delete(List<ModelPermissionUserDto> dtos) => base.Delete(dtos);

    [HttpGet("optimized")]
    public override async Task<ActionResult<List<ModelPermissionUserDto?>>> FindOptimized()
    {
        return await base.FindOptimized();
    }

    [HttpPost("find-by-criteria")]
    public override async Task<ActionResult<List<ModelPermissionUserDto?>>> FindByCriteria(
        ModelPermissionUserCriteria criteria)
    {
        return await base.FindByCriteria(criteria);
    }

    [HttpPost("find-paginated-by-criteria")]
    public override async Task<ActionResult<PaginatedList<ModelPermissionUserDto?>>> FindPaginatedByCriteria(
        ModelPermissionUserCriteria criteria)
    {
        return await base.FindPaginatedByCriteria(criteria);
    }

    public ModelPermissionUserRest(IContainer container, IMapper mapper) : base(container, mapper)
    {
    }
}