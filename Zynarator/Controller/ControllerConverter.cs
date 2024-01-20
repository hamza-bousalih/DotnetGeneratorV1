using System.Collections;
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

    private TDto ConvertToDto(TEntity item) => _mapper.Map<TDto>(item);
    private TEntity ConvertToItem(TDto dto) => _mapper.Map<TEntity>(dto);

    protected TDto? ToDto(TEntity? item) => item == null ? null: ConvertToDto(item);
    protected TEntity? ToItem(TDto? dto) => dto == null ? null: ConvertToItem(dto);
    
    protected List<TEntity?> ToItem(List<TDto>? dtos) => dtos is null ? new List<TEntity?>() : dtos.Select(ToItem).ToList();
    protected List<TDto?> ToDto(List<TEntity?>? items) => items is null ? new List<TDto?>() : items.Select(ToDto).ToList(); 
}