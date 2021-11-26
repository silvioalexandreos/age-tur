using Age_Tur.Infra.Context;
using Age_Tur.Infra.Entities;
using Age_Tur.Services.Base;
using Age_Tur.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Age_Tur.Services.Modules.PrevisoesTempo
{
    public class PrevisaoClimaService : Service
    {
        private readonly DbSet<PrevisaoClima> _previsaoClimaSet;
        public PrevisaoClimaService(SqlServerContext context) : base(context)
        {
            _previsaoClimaSet = _context.Set<PrevisaoClima>();
        }

        public async Task<IEnumerable<PrevisaoClimaDto>> GetAllPrevisoesClima()
        {
            if (!await _previsaoClimaSet.AnyAsync())
            {
                throw new NotFoundException("Nenhuma previsão do clima cadastrada.");
            }

            var previsoesClima = await _previsaoClimaSet.OrderBy(x => x.TemperaturaMinima).ToListAsync();

            var listPrevisaoClima = new List<PrevisaoClimaDto>();
            foreach (var item in previsoesClima)
            {
                listPrevisaoClima.Add(PrevisaoClimaParser.ToDto(item));
            }
            return listPrevisaoClima;
        }
    }
}
