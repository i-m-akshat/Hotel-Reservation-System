namespace Backend.DTO.State
{
    public record State_DTO
    {
        public long stateid { get; init; } public string statename { get; init; }
        public long? countryid { get; set; }
    }
    public record State_DTO_GetAll
    {
        public long stateid { get; init; }
        public string statename { get; set; }
        public long? countryid { get; set; }
        public string countryname { get; set; }
    }
}
