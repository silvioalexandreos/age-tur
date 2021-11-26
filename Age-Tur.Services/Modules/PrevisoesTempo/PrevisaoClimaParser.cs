using Age_Tur.Infra.Entities;

namespace Age_Tur.Services.Modules.PrevisoesTempo
{
    public class PrevisaoClimaParser
    {
        public static PrevisaoClimaDto ToDto(PrevisaoClima tempo)
        {
            return new PrevisaoClimaDto(tempo.Clima, tempo.TemperaturaMinima, tempo.TemperaturaMaxima, tempo.CidadeId);
        }

        public static PrevisaoClima ToEntity(PrevisaoClimaDto dto)
        {
            return new PrevisaoClima(dto.Clima, dto.TemperaturaMinima, dto.TemperaturaMaxima, dto.CidadeId);
        }
    }
}
