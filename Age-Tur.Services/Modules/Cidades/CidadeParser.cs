using Age_Tur.Infra.Entities;

namespace Age_Tur.Services.Modules.Cidades
{
    public class CidadeParser
    {
        public static CidadeDto ToDto(Cidade cidade)
        {
            return new CidadeDto(cidade.Nome, cidade.EstadoId);
        }

        public static Cidade ToEntity(CidadeDto dto)
        {
            return new Cidade(dto.Nome, dto.EstadoId);
        }
    }
}
