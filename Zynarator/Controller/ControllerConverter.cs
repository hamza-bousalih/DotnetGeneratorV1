using AutoMapper;
using DotnetGenerator.Zynarator.Bean;
using DotnetGenerator.Zynarator.Dto;
using DotnetGenerator.Zynarator.Util;
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
    
    protected List<TEntity> ToItem(List<TDto> dtos)
    {
        var items = new List<TEntity>();
        dtos.ForEach(dto =>
        {
            var converted = ToItem(dto);
            if (converted is not null) items.Add(converted);
        });
        return items;
    }

    protected List<TDto?> ToDto(List<TEntity> items) => items.Select(ToDto).ToList(); 
    
    protected PaginatedList<TDto?> ToDto(PaginatedList<TEntity> paginatedList)
    {
        return new PaginatedList<TDto?>
        {
            List = ToDto(paginatedList.List),
            DataSize = paginatedList.DataSize
        };
    }
}