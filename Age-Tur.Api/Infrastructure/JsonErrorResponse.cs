using System.Collections.Generic;

namespace Age_Tur.Api.Infrastructure
{
    public class JsonErrorResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonErrorResponse()
        {
            Messages = new Dictionary<string, IEnumerable<string>>();
        }

        /// <summary>
        /// Error messages
        /// </summary>
        public IDictionary<string, IEnumerable<string>> Messages { get; set; }

        /// <summary>
        /// Message for developers, expect to be shown only in Development Environments
        /// </summary>
        public object DeveloperMeesage { get; set; }
    }
}
