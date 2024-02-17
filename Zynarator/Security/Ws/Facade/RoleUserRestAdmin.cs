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

[Route("api/admin/roleUser/")]
[ApiController]
public class RoleUserRest : BaseController<RoleUser, RoleUserDto, RoleUserService, RoleUserCriteria>
{
    [HttpGet("id/{id:long}")]
    public override Task<ActionResult<RoleUserDto>> FindById(long id) => base.FindById(id);

    [HttpGet]
    public override Task<ActionResult<List<RoleUserDto>>> FindAll() => base.FindAll();

    [HttpPost]
    public override Task<ActionResult<RoleUserDto>> Create(RoleUserDto dto) => base.Create(dto);

    [HttpPut]
    public override Task<ActionResult<RoleUserDto>> Update(RoleUserDto dto) => base.Update(dto);

    [HttpDelete("id/{id:long}")]
    public override Task<ActionResult<int>> DeleteById(long id) => base.DeleteById(id);

    [HttpDelete]
    public override Task<ActionResult<int>> Delete(RoleUserDto dto) => base.Delete(dto);

    [HttpPost("multiple")]
    public override Task<ActionResult<int>> Delete(List<RoleUserDto> dtos) => base.Delete(dtos);

    [HttpGet("optimized")]
    public override async Task<ActionResult<List<RoleUserDto?>>> FindOptimized()
    {
        return await base.FindOptimized();
    }

    [HttpPost("find-by-criteria")]
    public override async Task<ActionResult<List<RoleUserDto?>>> FindByCriteria(RoleUserCriteria criteria)
    {
        return await base.FindByCriteria(criteria);
    }

    [HttpPost("find-paginated-by-criteria")]
    public override async Task<ActionResult<PaginatedList<RoleUserDto?>>> FindPaginatedByCriteria(
        RoleUserCriteria criteria)
    {
        return await base.FindPaginatedByCriteria(criteria);
    }

    public RoleUserRest(IContainer container, IMapper mapper) : base(container, mapper)
    {
    }
}