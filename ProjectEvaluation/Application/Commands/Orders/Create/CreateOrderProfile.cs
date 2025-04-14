using AutoMapper;
using Domain.Entities;

namespace Application.Commands.Orders.Create
{
    public class CreateOrderProfile : Profile
    {
        public CreateOrderProfile() 
        {
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<Order, CreateOrderResult>();
        }
    }
}
