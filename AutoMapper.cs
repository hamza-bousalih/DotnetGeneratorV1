using AutoMapper;
using DotnetGenerator.Bean.Core;
using DotnetGenerator.Ws.Dto;

namespace DotnetGenerator;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        
        // client mapper
        CreateMap<ClientDto, Client>();
        CreateMap<Client, ClientDto>();
        // achat mapper
        CreateMap<AchatDto, Achat>()
            .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
            .ForMember(dest => dest.AchatItems, opt => opt.MapFrom(src => src.AchatItems))
                ;
        CreateMap<Achat, AchatDto>()
            .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
            .ForMember(dest => dest.AchatItems, opt => opt.MapFrom(src => src.AchatItems))
        ;

        // achatItem mapper
        CreateMap<AchatItemDto, AchatItem>();
        CreateMap<AchatItem, AchatItemDto>();

        // produit mapper
        CreateMap<ProduitDto, Produit>();
        CreateMap<Produit, ProduitDto>();
    }
}

