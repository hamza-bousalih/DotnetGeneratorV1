using AutoMapper;
using DotnetGenerator.Bean.Core;
using DotnetGenerator.WS.Dto;

namespace DotnetGenerator;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // achat mapper
        CreateMap<AchatDto, Achat>()
            .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
            .ForMember(dest => dest.AchatItems, opt => opt.MapFrom(src => src.AchatItems));
        CreateMap<Achat, AchatDto>()
            .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client));

        // Client mapper
        CreateMap<ClientDto, Client>()
            .ForMember(dest => dest.Achats, opt => opt.MapFrom(src => src.Achats));
        CreateMap<Client, ClientDto>()
            .ForMember(dest => dest.Achats, opt => opt.MapFrom(src => src.Achats));
        
        // Produit mapper
        CreateMap<ProduitDto, Produit>()
            .ForMember(dest => dest.AchatItems, opt => opt.MapFrom(src => src.AchatItems));
        CreateMap<Produit, ProduitDto>()
            .ForMember(dest => dest.AchatItems, opt => opt.MapFrom(src => src.AchatItems));
        
        // AchatItem mapper
        CreateMap<AchatItemDto, AchatItem>()
            .ForMember(dest => dest.Achat, opt => opt.MapFrom(src => src.Achat))
            .ForMember(dest => dest.Produit, opt => opt.MapFrom(src => src.Produit));
        CreateMap<AchatItem, AchatItemDto>()
            .ForMember(dest => dest.Achat, opt => opt.MapFrom(src => src.Achat))
            .ForMember(dest => dest.Produit, opt => opt.MapFrom(src => src.Produit));
    }
}

