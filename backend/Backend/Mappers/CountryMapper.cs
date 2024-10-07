using Backend.DTO.Country;
using Backend.Models.Country_Domain;

namespace Backend.Mappers
{
    public static class CountryMapper
    {
        public static Country ToCountryFromDTO(this Country_DTO dto)
        {
            return new Country
            {
                CountryName = dto.CountryName
            };
        }
        public static Country_DTO_Return ToCountryDTO_Return(this Country _country)
        {
            return new Country_DTO_Return
            {
                CountryName = _country.CountryName,
                CountryId=_country.CountryId
            };
        }
    }
}
