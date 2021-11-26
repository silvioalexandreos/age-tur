using Age_Tur.Infra.Context;
using Age_Tur.Infra.Entities;
using Age_Tur.Services.Base;
using Age_Tur.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Age_Tur.Services.Modules.Cidades
{
    public class CidadeService : Service
    {
        private readonly DbSet<Cidade> _cidadeSet;
        public CidadeService(SqlServerContext context) : base(context)
        {
            _cidadeSet = _context.Set<Cidade>();
        }
        public async Task<IEnumerable<CidadeDto>> GetAllCidades()
        {
            if (!await _cidadeSet.AnyAsync())
            {
                throw new NotFoundException("Nenhuma cidade cadastrada.");
            }

            var cidades = await _cidadeSet.OrderBy(x => x.Nome).ToListAsync();

            var listCidades = new List<CidadeDto>();
            foreach (var item in cidades)
            {
                listCidades.Add(CidadeParser.ToDto(item));
            }

            return listCidades;
        }
    }
}
