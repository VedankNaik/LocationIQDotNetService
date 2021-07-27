using AutoMapper;
using SwaggerService.Core.Models.V3.DBConnection;

namespace SwaggerService.Web.Models.V3.DBConnection
{
    /// <summary>
    /// Mapper Profile for DBConnection
    /// </summary>
    public class DBConnectionMapperProfile : Profile
    {
        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public DBConnectionMapperProfile()
        {
            // Automapper profiles   
            this.CreateMap<DBConnectionRequestDto, DBConnectionRequest>(); 
            // this.CreateMap<AutocompleteResponse, AutocompleteResponseDto>();      
        }

        #endregion
    }
}