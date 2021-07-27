using Newtonsoft.Json.Linq;
using SwaggerService.Core.Interfaces.Infrastructure.Repositories.V2;
using SwaggerService.Core.Interfaces.Services.V2.Location;
using SwaggerService.Core.Models.V2.Autocomplete;
using SwaggerService.Core.Models.V2.Balance;
using SwaggerService.Core.Models.V2.Directions;
using SwaggerService.Core.Models.V2.ForwardGeocode;
using SwaggerService.Core.Models.V2.Nearest;
using SwaggerService.Core.Models.V2.POI;
using SwaggerService.Core.Models.V2.ReverseGeocode;

namespace SwaggerService.Core.Services.V2.Location
{
    /// <summary>
    /// Implementation of ILocationHelper
    /// </summary>
    public class LocationHelper : ILocationHelper
    {
        #region Properties

        private readonly ILocationRepository _locationRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="locationRepository"></param>
        public LocationHelper(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// ForwardGeocodeList
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ForwardGeocodeResponse ForwardGeocodeList(ForwardGeocodeRequest request)
        {
            var response = _locationRepository.ForwardGeocode(request);
            return response;
        }

        /// <summary>
        /// ForwardGeocodeList
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ReverseGeocodeResponseObject ReverseGeocodeObject(ReverseGeocodeRequest request)
        {
            var response = _locationRepository.ReverseGeocode(request);
            return response;
        }

        /// <summary>
        /// AutocompleteList
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AutocompleteResponse AutocompleteList(AutocompleteRequest request)
        {
            var response = _locationRepository.Autocomplete(request);
            return response;
        }

        /// <summary>
        /// Balance
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public BalanceResponse Balance(BalanceRequest request)
        {
            var response = _locationRepository.Balance(request);
            return response;
        }

        /// <summary>
        /// DirectionsObject
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JObject DirectionsObject(DirectionsRequest request)
        {
            var response = _locationRepository.Directions(request);
            return response;
        }

        /// <summary>
        /// NearestObject
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JObject NearestObject(NearestRequest request)
        {
            var response = _locationRepository.Nearest(request);
            return response;
        }

        /// <summary>
        /// POI
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public POIResponse POI(POIRequest request)
        {
            var response = _locationRepository.POI(request);
            return response;
        }

        #endregion
    }
}