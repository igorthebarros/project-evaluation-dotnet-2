using Application.Commands.Companies.Create;
using AutoMapper;
using Domain.Contracts.Services;
using Domain.Entities;
using FluentValidation;
using NSubstitute;
using Unit.TestData;

namespace Unit.Application.Handlers
{
    public class CreateCompanyHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _service;
        private readonly CreateCompanyHandler _handler;

        public CreateCompanyHandlerTest()
        {
            _mapper = Substitute.For<IMapper>();
            _service = Substitute.For<ICompanyService>();
            _handler = new CreateCompanyHandler(_mapper, _service);
        }

        [Fact]
        public async Task Given_ValidCommand_When_HandleIsCalled_Then_CompanyIsCreatedAndResultReturned()
        {
            // Arrange (Given)
            var command = CompanyTestData.GenerateValidCommand();
            var company = new Company();
            var createdCompany = new Company();
            var expectedResult = new CreateCompanyResult();

            _mapper.Map<Company>(command).Returns(company);
            _service.CreateAsync(company, Arg.Any<CancellationToken>()).Returns(createdCompany);
            _mapper.Map<CreateCompanyResult>(createdCompany).Returns(expectedResult);

            // Act (When)
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert (Then)
            Assert.Equal(expectedResult, result);
            await _service.Received(1).CreateAsync(company, Arg.Any<CancellationToken>());
            _mapper.Received(1).Map<Company>(command);
            _mapper.Received(1).Map<CreateCompanyResult>(createdCompany);
        }

        [Fact]
        public async Task Given_InvalidCNPJ_When_HandleIsCalled_Then_ReturnExceptionFormatIsInvalid()
        {
            // Arrange (Given)
            var command = CompanyTestData.GenerateValidCommand();
            command.CNPJ = "000000120-2";

            // Act (When)
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));

            // Assert (Then)
            Assert.NotNull(exception);
            Assert.Contains(exception.Errors, e =>
                e.PropertyName == "CNPJ" &&
                e.ErrorMessage.Contains("CNPJ format is invalid."));

        }

        [Fact]
        public async Task Given_InvalidCNPJ_When_HandleIsCalled_Then_ReturnExceptionMustBeNumericCharactersOnly()
        {
            // Arrange (Given)
            var command = CompanyTestData.GenerateValidCommand();
            command.CNPJ = "InvalidCNPJ";

            // Act (When)
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));

            // Assert (Then)
            Assert.NotNull(exception);
            Assert.Contains(exception.Errors, e =>
                e.PropertyName == "CNPJ" &&
                e.ErrorMessage.Contains("CNPJ must be numeric characters only."));

        }

        [Fact]
        public async Task Given_InvalidCNPJ_When_HandleIsCalled_Then_ReturnExceptionCNPJMustHave14Digits()
        {
            // Arrange (Given)
            var command = CompanyTestData.GenerateValidCommand();
            command.CNPJ = "123";

            // Act (When)
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));

            // Assert (Then)
            Assert.NotNull(exception);
            Assert.Contains(exception.Errors, e =>
                e.PropertyName == "CNPJ" &&
                e.ErrorMessage.Contains("CNPJ must have 14 digits."));

        }
    }
}
