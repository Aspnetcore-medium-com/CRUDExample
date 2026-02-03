using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// Service contract for Country operations
    /// </summary>
    public interface ICountryService
    {
        /// <summary>
        /// Adds a new country using the specified request data.
        /// </summary>
        /// <param name="countryAddRequest">The request containing the details of the country to add. This parameter cannot be <see langword="null"/>.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="CountryResponse"/>
        /// with information about the added country.</returns>
        public Task<CountryResponse> AddCountry(CountryAddRequest? countryAddRequest);
    }
}
