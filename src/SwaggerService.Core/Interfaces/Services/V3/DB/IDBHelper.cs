

using System.Collections.Generic;
using SwaggerService.Core.Models.V3.DBConnection;
using SwaggerService.Core.Models.V3.Query;

namespace SwaggerService.Core.Interfaces.Services.V3.DB
{
    /// <summary>
    /// IDBHelper
    /// </summary>
    public interface IDBHelper
    {
        #region Methods

        /// <summary>
        /// DBConenction
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        bool DBConnection(DBConnectionRequest request);

        /// <summary>
        /// Execute query
        /// </summary>
        /// <param name="request"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        IEnumerable<QueryResponse> RunQuery(DBConnectionRequest request, string query);

        /// <summary>
        /// Forward validate
        /// </summary>
        /// <param name="response"></param>
        /// <param name="request"></param>
        /// <param name="InsertTable"></param>
        /// <returns></returns>
        string ForwardValidate(List<QueryResponse> response, DBConnectionRequest request, string InsertTable);

        /// <summary>
        /// Reverse validate
        /// </summary>
        /// <param name="response"></param>
        /// <param name="request"></param>
        /// <param name="InsertTable"></param>
        /// <returns></returns>
        string ReverseValidate(List<QueryResponse> response, DBConnectionRequest request, string InsertTable);

        #endregion
    }
}