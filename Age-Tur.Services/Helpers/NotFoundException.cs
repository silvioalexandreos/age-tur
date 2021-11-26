using System.Net;

namespace Age_Tur.Services.Helpers
{
    public class NotFoundException : HttpStatusException
    {
        public NotFoundException(string message = "Nenhum recurso foi encontrado.")
            : base(HttpStatusCode.NotFound, message)
        {
        }
    }
}
