using AutoMapper;
using SwaggerService.Core.Models.V2.Nearest;

namespace SwaggerService.Web.Models.V2.Nearest
{
    /// <summary>
    /// Mapper Profile for Nearest
    /// </summary>
    public class NearestMapperProfile : Profile
    {
        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public NearestMapperProfile()
        {
            // Automapper profiles   
            this.CreateMap<NearestRequestDto, NearestRequest>();    
        }

        #endregion
    }
}