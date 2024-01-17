using AutoMapper;
using DotnetGenerator.Zynarator.Bean;
using DotnetGenerator.Zynarator.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DotnetGenerator.Zynarator.Controller;

public abstract class ControllerConverter<TEntity, TDto> : ControllerBase
    where TEntity : BusinessObject 
    where TDto : BaseDto
{
    private readonly IMapper _mapper;
    
    protected ControllerConverter(IMapper mapper) => _mapper = mapper;

    protected virtual TDto ConvertToDto(TEntity item) => _mapper.Map<TDto>(item);

    protected virtual TEntity ConvertToItem(TDto dto) => _mapper.Map<TEntity>(dto);

    protected TDto ToDto(TEntity item) => ConvertToDto(item);
    protected TEntity ToItem(TDto dto) => ConvertToItem(dto);
    
    protected List<TEntity> ToItem(List<TDto> dtos) => dtos.Select(ToItem).ToList();
    protected List<TDto> ToDto(List<TEntity> items) => items.Select(ToDto).ToList(); 
}