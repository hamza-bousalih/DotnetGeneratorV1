using AutoMapper;
using DotnetGenerator.Zynarator.Bean;
using DotnetGenerator.Zynarator.Dto;
using DotnetGenerator.Zynarator.Service;
using Lamar;
using Microsoft.AspNetCore.Mvc;

namespace DotnetGenerator.Zynarator.Controller;

public abstract class BaseController<TEntity, TDto, TService> : ControllerConverter<TEntity, TDto>
    where TEntity : BusinessObject
    where TDto : BaseDto
    where TService : IService<TEntity>
{
    protected TService Service;
    
    protected BaseController(IServiceContext container, IMapper mapper) : base(mapper) =>
        Service = container.GetInstance<TService>();
    
    public virtual async Task<ActionResult<List<TDto>>> FindAll() => Ok(ToDto(await Service.FindAll()));
    
    public virtual async Task<ActionResult<int>> Create(TDto dto)
    {
        var item = ToItem(dto);
        return Ok(await Service.Create(item));
    }

    public virtual async Task<ActionResult<int>> Create(List<TDto> dtos)
    {
        var items = ToItem(dtos);
        return Ok(await Service.Create(items));
    }

    public virtual async Task<ActionResult<int>> Update(TDto dto)
    {
        var item = ToItem(dto);
        return Ok(await Service.Update(item));
    }

    public virtual async Task<ActionResult<int>> Update(List<TDto> dtos)
    {
        var items = ToItem(dtos);
        return Ok(await Service.Update(items));
    }
    
    public virtual async Task<ActionResult<TDto>> FindById(int id)
    {
        var result = await Service.FindById(id);
        return Ok(ToDto(result));
    }

    public virtual async Task<ActionResult<int>> DeleteById(int id)
    {
        var result = await Service.DeleteById(id);
        return Ok(result);
    }

    public virtual async Task<ActionResult<int>> Delete(TDto dto)
    {
        var item = ToItem(dto);
        var result = await Service.Delete(item);
        return Ok(result);
    }

    public virtual async Task<ActionResult<int>> Delete(List<TDto> dtos)
    {
        var items = ToItem(dtos);
        var result = await Service.Delete(items);
        return Ok(result);
    }
}