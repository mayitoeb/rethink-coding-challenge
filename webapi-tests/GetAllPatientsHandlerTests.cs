using MediatR;
using Moq;
using webapi.Core.Domain;
using webapi.Core.Handlers;
using webapi.Core.Interfaces;
using webapi.Core.Queries;

namespace webapi_tests
{
    public class GetAllPatientsHandlerTests
    {
        [Fact]
        public async Task GettAllPatientsHandler_SuccessAsync()
        {
            IEnumerable<Patient> patientsList = new List<Patient>() {
                new Patient
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Birthday = DateTime.Now,
                    Gender = "m"
                }
            };

            //Arrange
            var mediator = new Mock<IMediator>();

            var repository = new Mock<IPatientRepository>();
            repository
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(patientsList);

            var request = new GetAllPatientsQuery();
            var handler = new GetAllPatientsHandler(repository.Object);

            //Act
            var patients = await handler.Handle(request, new CancellationToken());

            //Assert
            Assert.NotNull(patients);
            Assert.Single(patients);
        }
    }
}