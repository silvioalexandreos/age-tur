using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Age_Tur.Infra.Entities
{
    [Table("tb_previsaclima")]
    public class PrevisaoClima : Entity
    {
        public PrevisaoClima(string clima, decimal temperaturaMinima, decimal temperaturaMaxima, int cidadeId)
        {
            Clima = clima;
            TemperaturaMinima = temperaturaMinima;
            TemperaturaMaxima = temperaturaMaxima;
            CidadeId = cidadeId;
        }

        [MaxLength(15)]
        public string Clima { get; private set; }
        public decimal TemperaturaMinima { get; private set; }
        public decimal TemperaturaMaxima { get; private set; }
        public int CidadeId { get; private set; }
    }
}
