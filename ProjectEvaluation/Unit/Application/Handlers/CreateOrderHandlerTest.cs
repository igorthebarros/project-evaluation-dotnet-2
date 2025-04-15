using Application.Commands.Orders.Create;
using AutoMapper;
using Domain.Contracts.Services;
using Domain.Entities;
using FluentValidation;
using NSubstitute;
using Unit.TestData;

namespace Unit.Application.Handlers
{
    public class CreateOrderHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _service;
        private readonly CreateOrderHandler _handler;

        public CreateOrderHandlerTest()
        {
            _mapper = Substitute.For<IMapper>();
            _service = Substitute.For<IOrderService>();
            _handler = new CreateOrderHandler(_mapper, _service);
        }

        [Fact]
        public async Task Given_ValidCommand_When_HandleIsCalled_Then_OrderIsCreatedAndResultReturned()
        {
            // Arrange (Given)
            var command = OrderTestData.GenerateValidCommand();
            var order = new Order();
            var createdOrder = new Order();
            var expectedResult = new CreateOrderResult();

            _mapper.Map<Order>(command).Returns(order);
            _service.CreateAsync(order, Arg.Any<CancellationToken>()).Returns(createdOrder);
            _mapper.Map<CreateOrderResult>(createdOrder).Returns(expectedResult);

            // Act (When)
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert (Then)
            Assert.Equal(expectedResult, result);
            await _service.Received(1).CreateAsync(order, Arg.Any<CancellationToken>());
            _mapper.Received(1).Map<Order>(command);
            _mapper.Received(1).Map<CreateOrderResult>(createdOrder);
        }

        [Fact]
        public async Task Given_InvalidCNPJ_When_HandleIsCalled_Then_ReturnExceptionFormatIsInvalid()
        {
            // Arrange (Given)
            var command = OrderTestData.GenerateValidCommand();
            command.Company.CNPJ = "000000120-2";

            // Act (When)
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));

            // Assert (Then)
            Assert.NotNull(exception);
            Assert.Contains(exception.Errors, e =>
                e.PropertyName == "Company.CNPJ" &&
                e.ErrorMessage.Contains("CNPJ format is invalid."));

        }

        [Fact]
        public async Task Given_InvalidCNPJ_When_HandleIsCalled_Then_ReturnExceptionMustBeNumericCharactersOnly()
        {
            // Arrange (Given)
            var command = OrderTestData.GenerateValidCommand();
            command.Company.CNPJ = "InvalidCNPJ";

            // Act (When)
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));

            // Assert (Then)
            Assert.NotNull(exception);
            Assert.Contains(exception.Errors, e =>
                e.PropertyName == "Company.CNPJ" &&
                e.ErrorMessage.Contains("CNPJ must be numeric characters only."));

        }

        [Fact]
        public async Task Given_InvalidCNPJ_When_HandleIsCalled_Then_ReturnExceptionCNPJMustHave14Digits()
        {
            // Arrange (Given)
            var command = OrderTestData.GenerateValidCommand();
            command.Company.CNPJ = "123";

            // Act (When)
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));

            // Assert (Then)
            Assert.NotNull(exception);
            Assert.Contains(exception.Errors, e =>
                e.PropertyName == "Company.CNPJ" &&
                e.ErrorMessage.Contains("CNPJ must have 14 digits."));

        }
    }
}
