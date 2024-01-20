using AutoMapper;
using DotnetGenerator.Bean.Core;
using DotnetGenerator.Service.Facade;
using DotnetGenerator.WS.Dto;
using DotnetGenerator.Zynarator.Controller;
using Lamar;
using Microsoft.AspNetCore.Mvc;

namespace DotnetGenerator.WS.Facade;

[Route("api/admin/achat/")]
[ApiController]
public class AcahtRest :  BaseController<Achat, AchatDto, AchatService>
{
    public AcahtRest(IContainer container, IMapper mapper):
        base(container, mapper)
    {
    }

    [HttpGet("id/{id:int}")]
    public override Task <ActionResult<AchatDto>> FindById(long id) => base.FindById(id);

    [HttpGet]
    public override Task <ActionResult<List<AchatDto>>> FindAll() => base.FindAll();

    [HttpPost]
    public override Task<ActionResult<AchatDto>> Create(AchatDto dto) => base.Create(dto);

    [HttpPost("all")]
    public override Task<ActionResult<List<AchatDto>>> Create(List<AchatDto> dtos) => base.Create(dtos);

    [HttpPut]
    public override Task<ActionResult<AchatDto>> Update(AchatDto dto) => base.Update(dto);

    [HttpPut("all")]
    public override Task<ActionResult<List<AchatDto>>> Update(List<AchatDto> dtos) => base.Update(dtos);

    [HttpDelete("id/{id:int}")]
    public override Task<ActionResult<int>> DeleteById(long id) => base.DeleteById(id);

    [HttpDelete]
    public override Task<ActionResult<int>> Delete(AchatDto dto) => base.Delete(dto);

    [HttpDelete("multiple")]
    public override Task<ActionResult<int>> Delete(List<AchatDto> dtos) => base.Delete(dtos);
    
    //---------------------------------------------------------------------------------------
    public async Task<ActionResult<int>> DeleteByClientId(int id) => Ok(await Service.DeleteByClientId(id));

    public async Task<ActionResult<List<AchatDto>>> FindByClientId(int id)
    {
        var found = await Service.FindByClientId(id);
        if (found is null) return new NotFoundObjectResult("There is no achats with this client!");
        return Ok(ToDto(found));
    }
}