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
    public override Task <ActionResult<AchatDto>> FindById(int id) => base.FindById(id);

    [HttpGet]
    public override Task <ActionResult<List<AchatDto>>> FindAll() => base.FindAll();

    [HttpPost]
    public override Task<ActionResult<int>> Create(AchatDto dto) => base.Create(dto);

    [HttpPost("all")]
    public override Task<ActionResult<int>> Create(List<AchatDto> dtos) => base.Create(dtos);

    [HttpPut]
    public override Task<ActionResult<int>> Update(AchatDto dto) => base.Update(dto);

    [HttpPut("all")]
    public override Task<ActionResult<int>> Update(List<AchatDto> dtos) => base.Update(dtos);

    [HttpDelete("id/{id:int}")]
    public override Task<ActionResult<int>> DeleteById(int id) => base.DeleteById(id);

    [HttpDelete]
    public override Task<ActionResult<int>> Delete(AchatDto dto) => base.Delete(dto);

    [HttpDelete("multiple")]
    public override Task<ActionResult<int>> Delete(List<AchatDto> dtos) => base.Delete(dtos);
}