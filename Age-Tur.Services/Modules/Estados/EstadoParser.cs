using Age_Tur.Infra.Entities;

namespace Age_Tur.Services.Modules.Estados
{
    public class EstadoParser
    {
        public static EstadoDto ToDto(Estado estado)
        {
            return new EstadoDto(estado.Nome, estado.UF);
        }

        public static Estado ToEntity(EstadoDto dto)
        {
            return new Estado(dto.Nome, dto.UF);
        }
    }
}
