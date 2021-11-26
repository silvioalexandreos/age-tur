using Age_Tur.Infra.Context;
using System;
using System.Threading.Tasks;

namespace Age_Tur.Services.Base
{
    public abstract class Service
    {
        protected readonly SqlServerContext _context;

        protected Service(SqlServerContext context)
        {
            _context = context;
        }

        protected virtual async Task CommitChanges()
        {
            var changes = 0;
            try
            {
                changes = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            if (changes <= 0)
            {
                throw new Exception("Erro ao salvar as alterações no banco de dados.");
            }
        }
    }
}
