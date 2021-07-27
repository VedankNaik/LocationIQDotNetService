using Newtonsoft.Json.Linq;
using SwaggerService.Core.Models.V2.Autocomplete;
using SwaggerService.Core.Models.V2.Balance;
using SwaggerService.Core.Models.V2.Directions;
using SwaggerService.Core.Models.V2.ForwardGeocode;
using SwaggerService.Core.Models.V2.Nearest;
using SwaggerService.Core.Models.V2.POI;
using SwaggerService.Core.Models.V2.ReverseGeocode;

namespace SwaggerService.Core.Interfaces.Infrastructure.Repositories.V2
{
    /// <summary>
    /// ILocationRepository interface
    /// </summary>
    public interface ILocationRepository
    {
        #region Methods

        /// <summary>
        /// Forward Geocode
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ForwardGeocodeResponse ForwardGeocode(ForwardGeocodeRequest request);  

        /// <summary>
        /// Reverse Geocode
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ReverseGeocodeResponseObject ReverseGeocode(ReverseGeocodeRequest request);  

        /// <summary>
        /// Autocomplete 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AutocompleteResponse Autocomplete(AutocompleteRequest request);  

        /// <summary>
        /// Balance 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BalanceResponse Balance(BalanceRequest request);   

        /// <summary>
        /// Directions 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        JObject Directions(DirectionsRequest request); 

        /// <summary>
        /// Nearest 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        JObject Nearest(NearestRequest request); 

        /// <summary>
        /// POI 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        POIResponse POI(POIRequest request); 

        // /// <summary>
        // /// Balance 
        // /// </summary>
        // /// <param name="request"></param>
        // /// <returns></returns>
        // BalanceResponse Balance(BalanceRequest request);      
        
        #endregion
        
    }
}