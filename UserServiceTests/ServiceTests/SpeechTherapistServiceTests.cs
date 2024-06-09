using System.Threading.Tasks;
using Moq;
using User_Service.Models;
using User_Service.Repository.Interfaces;
using User_Service.Service;
using Xunit;
using Assert = Xunit.Assert;

namespace UserServiceTests.Service
{
    public class SpeechTherapistServiceTests
    {
        [Fact]
        public async Task GetInformation_ValidId_ReturnsSpeechTherapist()
        {
            // Arrange
            var expectedSpeechTherapist = new SpeechTherapist { Id = 1, FirstName = "Maike", LastName="Meek",  Email="maikemeek2002@gmail.com"};
            var mockRepository = new Mock<ISpeechTherapistRepository>();
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(expectedSpeechTherapist);
            var service = new SpeechTherapistService(mockRepository.Object);

            // Act
            var result = await service.GetInformation(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedSpeechTherapist.Id, result.Id);
            Assert.Equal(expectedSpeechTherapist.FirstName, result.FirstName);
            Assert.Equal(expectedSpeechTherapist.LastName, result.LastName);
            Assert.Equal(expectedSpeechTherapist.Email, result.Email);
        }

        [Fact]
        public async Task AddSpeechTherapist_ValidSpeechTherapist_ReturnsAddedSpeechTherapist()
        {
            // Arrange
            var speechTherapistToAdd = new SpeechTherapist { Id = 1, FirstName = "Maike", LastName = "Meek", Email = "maikemeek2002@gmail.com" };
            var mockRepository = new Mock<ISpeechTherapistRepository>();
            mockRepository.Setup(repo => repo.AddAsync(speechTherapistToAdd)).ReturnsAsync(speechTherapistToAdd);
            var service = new SpeechTherapistService(mockRepository.Object);

            // Act
            var result = await service.AddSpeechTherapist(speechTherapistToAdd);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(speechTherapistToAdd.Id, result.Id);
            Assert.Equal(speechTherapistToAdd.FirstName, result.FirstName);
            Assert.Equal(speechTherapistToAdd.LastName, result.LastName);
            Assert.Equal(speechTherapistToAdd.Email, result.Email);
        }

    }
}
