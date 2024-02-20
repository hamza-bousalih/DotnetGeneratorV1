using AutoMapper;
using DotnetGenerator.Bean.Core;
using DotnetGenerator.Service.Facade;
using DotnetGenerator.Ws.Dto;
using DotnetGenerator.Zynarator.Controller;
using Lamar;
using Microsoft.AspNetCore.Mvc;
using DotnetGenerator.Zynarator.Util;
using DotnetGenerator.Dao.Criteria;
using Microsoft.AspNetCore.Authorization;

namespace DotnetGenerator.WS.Facade;

[Route("api/admin/client/")]
[ApiController]
[Authorize]
public class ClientRest : BaseController<Client, ClientDto, ClientService, ClientCriteria>
{
    [HttpGet("id/{id:long}")]
    public override Task<ActionResult<ClientDto>> FindById(long id) => base.FindById(id);

    [HttpGet]
    public override Task<ActionResult<List<ClientDto>>> FindAll() => base.FindAll();

    [HttpPost]
    public override Task<ActionResult<ClientDto>> Create(ClientDto dto) => base.Create(dto);

    [HttpPut]
    public override Task<ActionResult<ClientDto>> Update(ClientDto dto) => base.Update(dto);

    [HttpDelete("id/{id:long}")]
    public override Task<ActionResult<int>> DeleteById(long id) => base.DeleteById(id);

    [HttpDelete]
    public override Task<ActionResult<int>> Delete(ClientDto dto) => base.Delete(dto);

    [HttpPost("multiple")]
    public override Task<ActionResult<int>> Delete(List<ClientDto> dtos) => base.Delete(dtos);

    [HttpGet("optimized")]
    public override async Task<ActionResult<List<ClientDto?>>> FindOptimized()
    {
        return await base.FindOptimized();
    }

    [HttpPost("find-by-criteria")]
    public override async Task<ActionResult<List<ClientDto?>>> FindByCriteria(ClientCriteria criteria)
    {
        return await base.FindByCriteria(criteria);
    }

    [HttpPost("find-paginated-by-criteria")]
    public override async Task<ActionResult<PaginatedList<ClientDto?>>> FindPaginatedByCriteria(ClientCriteria criteria)
    {
        return await base.FindPaginatedByCriteria(criteria);
    }

    public ClientRest(IContainer container, IMapper mapper) : base(container, mapper)
    {
    }
}