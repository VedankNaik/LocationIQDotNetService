using AutoMapper;
using SwaggerService.Core.Models.V2.Balance;

namespace SwaggerService.Web.Models.V2.Balance
{
    /// <summary>
    /// Mapper Profile for Balance
    /// </summary>
    public class BalanceMapperProfile : Profile
    {
        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public BalanceMapperProfile()
        {
            // Automapper profiles   
            this.CreateMap<BalanceRequestDto, BalanceRequest>(); 
            this.CreateMap<BalanceResponse, BalanceResponseDto>();      
        }

        #endregion
    }
}