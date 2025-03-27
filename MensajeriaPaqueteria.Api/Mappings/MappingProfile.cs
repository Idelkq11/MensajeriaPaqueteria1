using AutoMapper;
using MensajeriaPaqueteria.Domain.Entities;  
using MensajeriaPaqueteria.Api.Models;
using MensajeriaPaqueteria.Application.ViewModels;


namespace MensajeriaPaqueteria.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Mensajero, MensajeroViewModel>().ReverseMap();
            CreateMap<Paquete, PaqueteViewModel>().ReverseMap();
            CreateMap<Envio, EnvioViewModel>().ReverseMap();
            CreateMap<Ruta, RutaViewModel>().ReverseMap();
           
        }
    }
}
