namespace Age_Tur.Services.Modules.PrevisoesTempo
{
    public record PrevisaoClimaDto(
        string Clima,
        decimal TemperaturaMinima,
        decimal TemperaturaMaxima,
        int CidadeId
        );
}
