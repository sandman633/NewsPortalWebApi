using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebApi.Swagger
{
    /// <summary>
    /// Константы для указания частей API в Swagger.
    /// </summary>
    public class SwagDocParts
    {
        /// <summary>
        /// Константа для сваггер-документа 
        /// </summary>
        public const string News = nameof(News);
        /// <summary>
        /// Константа для сваггер-документа 
        /// </summary>
        public const string User = nameof(User);
        /// <summary>
        /// Константа для сваггер-документа 
        /// </summary>
        public const string Comments = nameof(Comments);
        /// <summary>
        /// Константа для сваггер-документа 
        /// </summary>
        public const string Authentificate = nameof(Authentificate);
    }
}
