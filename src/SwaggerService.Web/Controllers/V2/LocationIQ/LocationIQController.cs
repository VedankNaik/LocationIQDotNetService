﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using SwaggerService.Core.Interfaces.Services.V2.Location;
using SwaggerService.Web.Models.V2.ForwardGeocode;
using SwaggerService.Web.Models.V2.ReverseGeocode;
using SwaggerService.Web.Models.V2.Autocomplete;
using SwaggerService.Web.Models.V2.Balance;
using SwaggerService.Web.Models.V2.Directions;
using SwaggerService.Web.Models.V2.Nearest;
using SwaggerService.Web.Models.V2.POI;

namespace SwaggerService.Web.Controllers.V2.LocationIQ
{
    // [Route("api/v{version:apiversion}/[controller]")]
    [ApiVersion("2")]
    [ApiExplorerSettings(GroupName = "V2")]
    [ApiController]
    public class LocationIQController : ControllerBase
    {
        public readonly ILocationHelper _locationHelper;
        protected readonly IMapper Mapper;
        public LocationIQController(ILocationHelper locationHelper, IMapper mapper)
        {
            _locationHelper = locationHelper;
            Mapper = mapper;
        }

        /// <summary>
        /// Convert addresses into geographic coordinates
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v{version:apiversion}/ForwardGeocode")]
        [ProducesResponseType(typeof(ForwardGeocodeResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult ForwardGeocoding([FromQuery] ForwardGeocodeRequestDto search)
        {
            var res = _locationHelper.ForwardGeocodeList(search);
            var response = Mapper.Map<ForwardGeocodeResponseDto>(res);
            if(response != null)
            {
                return Ok(response);   
            }
            else
            {
                return NoContent();
            }
                
        } 

        /// <summary>
        /// Convert coordinates to a readable address or place name
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v{version:apiversion}/ReverseGeocode")]
        [ProducesResponseType(typeof(ReverseGeocodeResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult ReverseGeocoding([FromQuery] ReverseGeocodeRequestDto search)
        {
            var res = _locationHelper.ReverseGeocodeObject(search);
            var response = Mapper.Map<ReverseGeocodeResponseDto>(res);
            if(response != null)
            {
                return Ok(response);   
            }
            else
            {
                return NoContent();
            }
                
        } 

        /// <summary>
        /// Returns place predictions in response to request
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v{version:apiversion}/Autocomplete")]
        [ProducesResponseType(typeof(AutocompleteResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Autocomplete([FromQuery] AutocompleteRequestDto search)
        {
            var res = _locationHelper.AutocompleteList(search);
            var response = Mapper.Map<AutocompleteResponseDto>(res);
            if(response != null)
            {
                return Ok(response);   
            }
            else
            {
                return NoContent();
            }
                
        }

        /// <summary>
        /// Provides a count of request credits left in the user's account for the day
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v{version:apiversion}/Balance")]
        [ProducesResponseType(typeof(BalanceResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Balance()
        {
            var search = new BalanceRequestDto();
            var res = _locationHelper.Balance(search);
            var response = Mapper.Map<BalanceResponseDto>(res);
            if(response != null)
            {
                return Ok(response);   
            }
            else
            {
                return NoContent();
            }
                
        }

        /// <summary>
        /// Finds the fastest route between coordinates
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v{version:apiversion}/Directions")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Directions([FromQuery] DirectionsRequestDto search)
        {
            var res = _locationHelper.DirectionsObject(search);
            if(res != null)
            {
                return Ok(res.ToString());   
            }
            else
            {
                return NoContent();
            }
                
        }

        /// <summary>
        /// Returns nearest Service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v{version:apiversion}/Nearest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Nearest([FromQuery] NearestRequestDto search)
        {
            var res = _locationHelper.NearestObject(search);
            if(res != null)
            {
                return Ok(res.ToString());   
            }
            else
            {
                return NoContent();
            }
                
        }

        /// <summary>
        /// Points of interest
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v{version:apiversion}/Nearby")]
        [ProducesResponseType(typeof(POIResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Nearby([FromQuery] POIRequestDto search)
        {
            var res = _locationHelper.POI(search);
            var response = Mapper.Map<POIResponseDto>(res);
            if(response != null)
            {
                return Ok(response);   
            }
            else
            {
                return NoContent();
            }
                
        }
        
        
    }
}
