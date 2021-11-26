using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Age_Tur.Infra.Entities
{
    [Table("tb_estado")]
    public class Estado : Entity
    {
        public Estado(string nome, string uF)
        {
            Nome = nome;
            UF = uF;
        }

        [MaxLength(200)]
        public string Nome { get; private set; }
        [MaxLength(2)]
        public string UF { get;private set; }
    }
}
