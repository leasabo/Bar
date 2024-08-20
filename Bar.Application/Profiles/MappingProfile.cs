using AutoMapper;
using Bar.Domain.Entities;
using Bar.Application.Commands;

namespace Bar.Application.Profiles
{ 
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Configura el mapeo entre CreateWaiterCommand y Waiter
            CreateMap<CreateWaiterCommand, Waiter>();
            // Configura el mapeo entre CreateTableCommand y Table
            CreateMap<CreateTableCommand, Table>();
            // Configura el mapeo entre CreateReceiptCommand y Receipt
            CreateMap<CreateReceiptCommand, Receipt>();
            // Agrega más configuraciones de mapeo según sea necesario
        }
    }
}
