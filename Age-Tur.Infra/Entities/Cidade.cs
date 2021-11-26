using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Age_Tur.Infra.Entities
{
    [Table("tb_cidade")]
    public class Cidade : Entity
    {
        public Cidade(string nome, int estadoId)
        {
            Nome = nome;
            EstadoId = estadoId;

        }

        [MaxLength(200)]
        public string Nome { get; private set; }
        public int EstadoId { get; private set; }
    }
}
