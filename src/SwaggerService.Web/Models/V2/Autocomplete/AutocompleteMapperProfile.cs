using AutoMapper;
using SwaggerService.Core.Models.V2.Autocomplete;

namespace SwaggerService.Web.Models.V2.Autocomplete
{
    /// <summary>
    /// Mapper Profile for Autocomplete
    /// </summary>
    public class AutocompleteMapperProfile : Profile
    {
        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public AutocompleteMapperProfile()
        {
            // Automapper profiles   
            this.CreateMap<AutocompleteRequestDto, AutocompleteRequest>(); 
            this.CreateMap<AutocompleteResponse, AutocompleteResponseDto>();      
        }

        #endregion
    }
}