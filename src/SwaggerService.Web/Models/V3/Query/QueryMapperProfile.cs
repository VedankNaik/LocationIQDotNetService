using AutoMapper;
using SwaggerService.Core.Models.V3.DBConnection;
using SwaggerService.Core.Models.V3.Query;

namespace SwaggerService.Web.Models.V3.Query
{
    /// <summary>
    /// Mapper Profile for Query
    /// </summary>
    public class QueryMapperProfile : Profile
    {
        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public QueryMapperProfile()
        {
            // Automapper profiles   
            // this.CreateMap<DBConnectionRequestDto, DBConnectionRequest>(); 
            this.CreateMap<QueryResponse, QueryResponseDto>();      
        }

        #endregion
    }
}