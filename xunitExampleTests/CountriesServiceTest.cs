using AutoMapper;
using Services;
using Moq;
using ServiceContracts;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace xunitCRUDTests
{
    public class CountryServiceTest
    {
        private readonly ICountryService _countriesService;
        private readonly Mock<IMapper> _mapperMock;

        public CountryServiceTest()
        {
            _mapperMock = new Mock<IMapper>();

            _mapperMock
                .Setup(m => m.Map<Country>(It.IsAny<CountryAddRequest>()))
                .Returns((CountryAddRequest req) => new Country
                {
                    CountryName = req.CountryName
                });


            _mapperMock
                .Setup(m => m.Map<CountryResponse>(It.IsAny<Country>()))
                .Returns((Country country) => new CountryResponse
                {
                    CountryId = country.CountryId,
                    CountryName = country.CountryName
                });
            _countriesService = new CountryService(_mapperMock.Object);

        }
        [Fact]
        //when countryAddRequest is null, then AddCountry should throw ArgumentNullException
        public async Task AddCountry_NullCountryAddRequest_ThrowsArgumentNullException()
        {
            // Arrange
            CountryAddRequest? countryAddRequest = null;
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _countriesService.AddCountry(countryAddRequest);
            });
        }

        [Fact]
        //when countryname is null or empty, then AddCountry should throw ArgumentException
        public async Task AddCountry_EmptyCountryName_ThrowsArgumentException()
        {
            // Arrange
            var countryAddRequest = new CountryAddRequest
            {
                CountryName = null
            };
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await _countriesService.AddCountry(countryAddRequest);
            });
        }

        //when countryname is duplicate, then AddCountry should throw ArgumentException
        [Fact]
        public async Task AddCountry_DuplicateCountryName_ThrowsArgumentException()
        {
            // Arrange
            var countryAddRequest1 = new CountryAddRequest
            {
                CountryName = "UK"
            };
            var countryAddRequest2 = new CountryAddRequest
            {
                CountryName = "UK"
            };
            // Act
            await _countriesService.AddCountry(countryAddRequest1);
            // Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await _countriesService.AddCountry(countryAddRequest2);
            });
        }

        // when proper countryName is provided, then AddCountry should return CountryResponse with proper countryName
        [Fact]
        public async Task AddCountry_ValidCountryName_ReturnsCountryResponse()
        {
            // Arrange
            var countryAddRequest = new CountryAddRequest
            {
                CountryName = "India"
            };
            // Act
            var countryResponse = await _countriesService.AddCountry(countryAddRequest);
            // Assert
            Assert.NotNull(countryResponse);
            Assert.Equal(countryAddRequest.CountryName, countryResponse.CountryName);
            Assert.IsType<Guid>(countryResponse.CountryId);

        }
    }
}
