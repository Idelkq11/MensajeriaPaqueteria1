using AutoMapper;
using MensajeriaPaqueteria.Domain.Entities;  
using MensajeriaPaqueteria.Api.Models; 

namespace MensajeriaPaqueteria.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Aquí defines cómo se mapean las entidades con los ViewModels
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Empleado, EmpleadoViewModel>().ReverseMap();
            CreateMap<Paquete, PaqueteViewModel>().ReverseMap();
            CreateMap<Envio, EnvioViewModel>().ReverseMap();
            CreateMap<Ruta, RutaViewModel>().ReverseMap();
            // Agrega más mapeos según lo que necesites
        }
    }
}
