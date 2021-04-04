using AutoMapper;
using Webmotors.Back9944.App.ViewModels;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.App.AutoMapper
{
    public class AdvertisingProfile : Profile
    {
        public AdvertisingProfile()
        {
            CreateMap<AdvertisingViewModel, Advertising>()
                .ForMember(_ => _.Id, _ => _.MapFrom(_ => _.Id))
                .ForMember(_ => _.Marca, _ => _.MapFrom(_ => _.Marca))
                .ForMember(_ => _.Modelo, _ => _.MapFrom(_ => _.Modelo))
                .ForMember(_ => _.Versao, _ => _.MapFrom(_ => _.Versao))
                .ForMember(_ => _.Ano, _ => _.MapFrom(_ => _.Ano))
                .ForMember(_ => _.Quilometragem, _ => _.MapFrom(_ => _.Quilometragem))
                .ForMember(_ => _.Observacao, _ => _.MapFrom(_ => _.Observacao))
                .ReverseMap();
        }
    }
}
