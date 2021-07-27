using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using SwaggerService.Core.Interfaces.Infrastructure.Repositories.V3;
using SwaggerService.Core.Interfaces.Services.V3.DB;
using SwaggerService.Core.Models.V3.DBConnection;
using SwaggerService.Core.Models.V3.Query;

namespace SwaggerService.Core.Services.V2.Location
{
    /// <summary>
    /// Implementation of IDBHelper
    /// </summary>
    public class DBHelper : IDBHelper
    {
        #region Properties

        private readonly IDBRepository _dbRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbRepository"></param>
        public DBHelper(IDBRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// DBConnection
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool DBConnection(DBConnectionRequest request)
        {
            var response = _dbRepository.DBConnection(request);
            return response;
        }

        /// <summary>
        /// Execute query
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IEnumerable<QueryResponse> RunQuery(DBConnectionRequest request, string query)
        {
            var response = _dbRepository.RunQuery(request, query);
            return response;
        }

        /// <summary>
        /// Forward Validate
        /// </summary>
        /// <param name="response"></param>>
        /// <returns></returns>
        public string ForwardValidate(List<QueryResponse> response, DBConnectionRequest request, string query)
        {
            var res = _dbRepository.ForwardValidate(response, request, query);
            return res;
        }

        /// <summary>
        /// Reverse Validate
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public string ReverseValidate(List<QueryResponse> response, DBConnectionRequest request, string query)
        {
            var res = _dbRepository.ReverseValidate(response, request, query);
            return res;
        }
        

        #endregion
    }
}