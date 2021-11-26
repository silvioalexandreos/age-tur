using Age_Tur.Infra.Context;
using Age_Tur.Infra.Entities;
using Age_Tur.Services.Base;
using Age_Tur.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Age_Tur.Services.Modules.Estados
{
    public class EstadoService : Service
    {
        private readonly DbSet<Estado> _estadoSet;
        public EstadoService(SqlServerContext context) : base(context)
        {
            _estadoSet =  _context.Set<Estado>();
        }

        public async Task<IEnumerable<EstadoDto>> GetAllEstados()
        {
            if (!await _estadoSet.AnyAsync())
            {
                throw new NotFoundException("Nenhum estado cadastrado.");
            }

            var estados = await _estadoSet.OrderBy(x => x.Nome).ToListAsync();

            var listEstados = new List<EstadoDto>();
            foreach (var item in estados)
            {
                listEstados.Add(EstadoParser.ToDto(item));
            }
            return listEstados;
        }
    }
}
