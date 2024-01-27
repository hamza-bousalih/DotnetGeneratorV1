using AutoMapper;
using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Criteria;
using DotnetGenerator.Service.Facade;
using DotnetGenerator.WS.Dto;
using DotnetGenerator.Zynarator.Controller;
using Lamar;
using Microsoft.AspNetCore.Mvc;

namespace DotnetGenerator.WS.Facade;

[Route("api/admin/achat/")]
[ApiController]
public class AcahtRest : BaseController<Achat, AchatDto, AchatService, AchatCriteria>
{
    public AcahtRest(IContainer container, IMapper mapper) :
        base(container, mapper)
    {
    }

    [HttpGet("id/{id:int}")]
    public override Task<ActionResult<AchatDto>> FindById(long id)
    {
        return base.FindById(id);
    }

    [HttpGet]
    public override Task<ActionResult<List<AchatDto>>> FindAll()
    {
        return base.FindAll();
    }

    [HttpGet("find-paginated/page={page:int}/size={size:int}")]
    public override Task<ActionResult<List<AchatDto>>> FindPaginated(int page, int size)
    {
        return base.FindPaginated(page, size);
    }

    [HttpPost]
    public override Task<ActionResult<AchatDto>> Create(AchatDto dto)
    {
        return base.Create(dto);
    }

    [HttpPost("all")]
    public override Task<ActionResult<List<AchatDto>>> Create(List<AchatDto> dtos)
    {
        return base.Create(dtos);
    }

    [HttpPut]
    public override Task<ActionResult<AchatDto>> Update(AchatDto dto)
    {
        return base.Update(dto);
    }

    [HttpPut("all")]
    public override Task<ActionResult<List<AchatDto>>> Update(List<AchatDto> dtos)
    {
        return base.Update(dtos);
    }

    [HttpDelete("id/{id:int}")]
    public override Task<ActionResult<int>> DeleteById(long id)
    {
        return base.DeleteById(id);
    }

    [HttpDelete]
    public override Task<ActionResult<int>> Delete(AchatDto dto)
    {
        return base.Delete(dto);
    }

    [HttpDelete("multiple")]
    public override Task<ActionResult<int>> Delete(List<AchatDto> dtos)
    {
        return base.Delete(dtos);
    }

    [HttpPost("find-by-criteria")]
    public override async Task<ActionResult<List<AchatDto?>>> FindByCriteria(AchatCriteria criteria)
    {
        return await base.FindByCriteria(criteria);
    }

    [HttpPost("find-paginated-by-criteria")]
    public override async Task<ActionResult<List<AchatDto?>>> FindPaginatedByCriteria(AchatCriteria criteria)
    {
        return await base.FindPaginatedByCriteria(criteria);
    }

    //---------------------------------------------------------------------------------------
    [HttpDelete("/client/{id:long}")]
    public async Task<ActionResult<int>> DeleteByClientId(long id)
    {
        return Ok(await Service.DeleteByClientId(id));
    }

    [HttpGet("/client/{id:long}")]
    public async Task<ActionResult<List<AchatDto>>> FindByClientId(int id)
    {
        var found = await Service.FindByClientId(id);
        if (found is null) return new NotFoundObjectResult("There is no achats with this client!");
        return Ok(ToDto(found));
    }
}