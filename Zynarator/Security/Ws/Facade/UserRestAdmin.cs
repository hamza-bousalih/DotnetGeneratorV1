using AutoMapper;
using DotnetGenerator.Zynarator.Controller;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Common;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Security.Payload.Request;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using DotnetGenerator.Zynarator.Security.Ws.Dto;
using DotnetGenerator.Zynarator.Util;
using Lamar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetGenerator.Zynarator.Security.Ws.Facade;

[Route("api/user/")]
[Authorize(Roles = Roles.Admin)]
[ApiController]
public class UserRest : BaseController<User, UserDto, UserService, UserCriteria>
{
    [HttpGet("id/{id:long}")]
    public override Task<ActionResult<UserDto>> FindById(long id) => base.FindById(id);

    [HttpGet]
    public override Task<ActionResult<List<UserDto>>> FindAll() => base.FindAll();

    [HttpPost]
    public override Task<ActionResult<UserDto>> Create(UserDto dto) => base.Create(dto);

    [HttpPut]
    public override Task<ActionResult<UserDto>> Update(UserDto dto) => base.Update(dto);

    [HttpDelete("id/{id:long}")]
    public override Task<ActionResult<int>> DeleteById(long id) => base.DeleteById(id);

    [HttpDelete]
    public override Task<ActionResult<int>> Delete(UserDto dto) => base.Delete(dto);

    [HttpPost("multiple")]
    public override Task<ActionResult<int>> Delete(List<UserDto> dtos) => base.Delete(dtos);

    [HttpGet("optimized")]
    public override async Task<ActionResult<List<UserDto?>>> FindOptimized()
    {
        return await base.FindOptimized();
    }

    [HttpPost("find-by-criteria")]
    public override async Task<ActionResult<List<UserDto?>>> FindByCriteria(UserCriteria criteria)
    {
        return await base.FindByCriteria(criteria);
    }

    [HttpPost("find-paginated-by-criteria")]
    public override async Task<ActionResult<PaginatedList<UserDto?>>> FindPaginatedByCriteria(UserCriteria criteria)
    {
        return await base.FindPaginatedByCriteria(criteria);
    }

    [HttpGet("/user/{username}")]
    public async Task<ActionResult<UserDto?>> FindByUsername(string username)
    {
        var result = await Service.FindByUsername(username);
        return ToDto(result);
    }

    [HttpDelete("/user/{username}")]
    public async Task<ActionResult<int>> DeleteByUsername(string username)
    {
        return await Service.DeleteByUsername(username);
    }
    
    [HttpPost("/changePassword")]
    public async Task<ActionResult<bool>> ChangePassword(ChangePasswordRequest changePasswordRequest) {
        return await Service.ChangePassword(changePasswordRequest.Username, changePasswordRequest.Password);
    }
    
    
    [HttpGet("/username/{username}")]
    public async Task<ActionResult<UserDto?>> FindByUsernameWithRoles(string username)
    {
        var result = await Service.FindByUsernameWithRoles(username);
        return Ok(ToDto(result));
    }

    public UserRest(IContainer container, IMapper mapper) : base(container, mapper)
    {
    }
}