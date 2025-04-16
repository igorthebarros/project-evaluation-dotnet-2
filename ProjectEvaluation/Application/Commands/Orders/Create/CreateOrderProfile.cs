using AutoMapper;
using Domain.Entities;

namespace Application.Commands.Orders.Create
{
    /// <summary>
    /// Profile for mapping between Order entity and CreateOrderResponse
    /// </summary>
    public class CreateOrderProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreteOrder operation
        /// </summary>
        public CreateOrderProfile() 
        {
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<Order, CreateOrderResult>();
        }
    }
}
