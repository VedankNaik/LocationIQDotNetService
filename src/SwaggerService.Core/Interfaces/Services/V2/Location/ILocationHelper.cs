using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SwaggerService.Core.Models.V1.Property;
using SwaggerService.Core.Models.V2.Autocomplete;
using SwaggerService.Core.Models.V2.Balance;
using SwaggerService.Core.Models.V2.Directions;
using SwaggerService.Core.Models.V2.ForwardGeocode;
using SwaggerService.Core.Models.V2.Nearest;
using SwaggerService.Core.Models.V2.POI;
using SwaggerService.Core.Models.V2.ReverseGeocode;

namespace SwaggerService.Core.Interfaces.Services.V2.Location
{
    /// <summary>
    /// ILocationHelper
    /// </summary>
    public interface ILocationHelper 
    {
        #region Methods

        /// <summary>
        /// ForwardGeocodeList
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ForwardGeocodeResponse ForwardGeocodeList(ForwardGeocodeRequest request);     

        /// <summary>
        /// ReverseGeocode
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
         ReverseGeocodeResponseObject ReverseGeocodeObject(ReverseGeocodeRequest request);  
            
        /// <summary>
        /// AutocompleteList
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AutocompleteResponse AutocompleteList(AutocompleteRequest request); 

        /// <summary>
        /// Balance 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BalanceResponse Balance(BalanceRequest request); 

        /// <summary>
        /// DirectionsObject 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        JObject DirectionsObject(DirectionsRequest request);      
        
        /// <summary>
        /// Nearest 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        JObject NearestObject(NearestRequest request); 

        /// <summary>
        /// POI 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        POIResponse POI(POIRequest request);

        #endregion
                                   
    }
}