using AutoMapper;
using Domain.Contracts.Services;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Commands.Orders.Create
{
    /// <summary>
    /// Handler for processing CreateOrderCommand requests
    /// </summary>
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _service;

        /// <summary>
        /// Initializes a new instance of CreateOrderHandler
        /// </summary>
        /// <param name="service">The Order service</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CreateOrderHandler(IMapper mapper, IOrderService service)
        {
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// Handles the CreateOrderCommand request
        /// </summary>
        /// <param name="command">The CreateOrder command</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>The created Order details</returns>
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
