using AutoMapper;
using DotnetGenerator.Zynarator.Controller;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Security.Payload.Request;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using DotnetGenerator.Zynarator.Security.Ws.Dto;
using DotnetGenerator.Zynarator.Util;
using Lamar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetGenerator.Zynarator.Security.Ws.Facade;

[Route("api/admin/user/")]
[Authorize]
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
    public Task<User?> FindByUsername(string username)
    {
        return Service.FindByUsername(username);
    }

    [HttpDelete("/user/{username}")]
    public Task<int> DeleteByUsername(string username)
    {
        return Service.DeleteByUsername(username);
    }
    
    [HttpPost("/changePassword")]
    public async Task<bool> ChangePassword(ChangePasswordRequest changePasswordRequest) {
        return await Service.ChangePassword(changePasswordRequest.Username, changePasswordRequest.Password);
    }

    public UserRest(IContainer container, IMapper mapper) : base(container, mapper)
    {
    }
}