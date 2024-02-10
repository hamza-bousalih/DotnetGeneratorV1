using AutoMapper;
using DotnetGenerator.Zynarator.Bean;
using DotnetGenerator.Zynarator.Criteria;
using DotnetGenerator.Zynarator.Dto;
using DotnetGenerator.Zynarator.Service;
using DotnetGenerator.Zynarator.Util;
using Lamar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DotnetGenerator.Zynarator.Controller;

public abstract class BaseController<TEntity, TDto, TService, TCriteria> : ControllerConverter<TEntity, TDto>
    where TEntity : BusinessObject
    where TDto : BaseDto
    where TCriteria : BaseCriteria
    where TService : IService<TEntity, TCriteria>
{
    protected TService Service;

    protected BaseController(IServiceContext container, IMapper mapper) : base(mapper) =>
        Service = container.GetInstance<TService>();

    public virtual async Task<ActionResult<List<TDto>>> FindAll()
    {
        var found = await Service.FindAll();
        if (found.IsNullOrEmpty()) NotFound("No Data Found!");
        return Ok(ToDto(found));
    }

    public virtual async Task<ActionResult<TDto>> Create(TDto dto)
    {
        var item = ToItem(dto);
        if (item == null) return BadRequest("No Entity Was Provided!");
        return Created("New Item Was Created Successfully!", await Service.Create(item));
    }

    public virtual async Task<ActionResult<TDto>> Update(TDto dto)
    {
        var item = ToItem(dto);
        if (item == null) return BadRequest("No Entity Was Provided!");
        return Ok(await Service.Update(item));
    }

    public virtual async Task<ActionResult<TDto>> FindById(long id)
    {
        var found = await Service.FindById(id);
        return Ok(ToDto(found));
    }

    public virtual async Task<ActionResult<int>> DeleteById(long id)
    {
        var result = await Service.DeleteById(id);
        return Ok(result);
    }

    public virtual async Task<ActionResult<int>> Delete(TDto dto)
    {
        var item = ToItem(dto);
        if (item is null) return BadRequest("no data was provide to be deleted!");
        var result = await Service.Delete(item);
        return Ok(result);
    }

    public virtual async Task<ActionResult<int>> Delete(List<TDto> dtos)
    {
        if (dtos.IsNullOrEmpty()) return BadRequest("no data was provide to be deleted!");
        var items = ToItem(dtos);
        var result = await Service.Delete(items);
        return Ok(result);
    }

    public virtual async Task<ActionResult<List<TDto?>>> FindByCriteria(TCriteria criteria)
    {
        var found = await Service.FindByCriteria(criteria);
        return ToDto(found);
    }

    public virtual async Task<ActionResult<PaginatedList<TDto?>>> FindPaginatedByCriteria(TCriteria criteria)
    {
        var found = await Service.FindPaginatedByCriteria(criteria);
        return ToDto(found);
    }

    public virtual async Task<ActionResult<List<TDto?>>> FindOptimized()
    {
        var found = await Service.FindOptimized();
        return ToDto(found);
    }
}
