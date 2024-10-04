namespace Backend.DTO.Country
{
    public record Country_DTO_Return
    {
        public long CountryId { get; init; }
        public string CountryName { get;init; }

    }

    public record Country_DTO
    {
        public string CountryName { get; init; }
    }
}
