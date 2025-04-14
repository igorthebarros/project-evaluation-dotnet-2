using AutoMapper;
using Domain.Contracts.Services;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Commands.Orders.Create
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _service;

        public CreateOrderHandler(IMapper mapper, IOrderService service)
        {
            _mapper = mapper;
            _service = service;
        }
        
        public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken token)
        {
            var validator = new CreateOrderValidator();
            var validationResult = await validator.ValidateAsync(command, token);

            if (!validationResult.IsValid) 
                throw new ValidationException(validationResult.Errors);

            var order = _mapper.Map<Order>(command);

            var createdOrder = await _service.CreateAsync(order, token);
            var result = _mapper.Map<CreateOrderResult>(createdOrder);
            return result;
        }
    }
}
