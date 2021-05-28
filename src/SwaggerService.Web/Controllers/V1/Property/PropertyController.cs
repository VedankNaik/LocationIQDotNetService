using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SwaggerService.Core.Interfaces.Services.Service;
using AutoMapper;
using SwaggerService.Web.Models.V1.Service;
using System.Collections.Generic;
using SwaggerService.Core.Interfaces.Services.V1.Property;
using SwaggerService.Web.Models.V1.Property;
using System.Net.Http;
using System.Net;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SwaggerService.Web.Controllers.V1.Property
{
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "V1")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        // public readonly ServiceContext _serviceContext;

        public readonly IPropertyHelper _propertyHelper;

        protected readonly IMapper Mapper;
        // IGetServices _getService;

        //public ServiceController(IGetServices getService)
        //{
        //    _getService = getService;
        //}
        public PropertyController(IPropertyHelper propertyHelper, IMapper mapper)
        {
            _propertyHelper = propertyHelper;
            Mapper = mapper;
        }

        /// <summary>
        /// Returns all properties available 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/v1/GetProperties")]
        [ProducesResponseType(typeof(PropertyResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetProperites()
        {
            var res = _propertyHelper.GetAllProperties();
            List<PropertyResponseDto> response = new List<PropertyResponseDto>();
            response = Mapper.Map<List<PropertyResponseDto>>(res);
            if(response==null)
            {
                return NoContent();
            }
            else
            {
                return Ok(response);
            }
            
        }

        /// <summary>
        /// Returns service with name 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/v1/GetProperty/{address}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetProperty(string address)
        {
            var res = _propertyHelper.GetOneProperty(address);
            PropertyResponseDto response = new PropertyResponseDto();
            response = Mapper.Map<PropertyResponseDto>(res);
            if(response==null)
            {
               return Ok("No reponse found");
            }
            else
            {
                return Ok(response);
            }
        }

        /// <summary>
        /// Add property
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/v1/AddProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult AddProperty([FromBody] PropertyRequestDto property)
        {
            var response = _propertyHelper.AddNewProperty(property);
            return Ok(response);
        }

        /// <summary>
        /// Update property
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("/v1/UpdateProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdateProperty([FromBody] PropertyRequestDto property)
        {
            var response = _propertyHelper.UpdateOldProperty(property);
            // PropertyResponseDto response = new PropertyResponseDto();
            // response = Mapper.Map<PropertyResponseDto>(res);
            return Ok(response);
        }

        /// <summary>
        /// Delete property
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("/v1/DeleteProperty/{address}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult DeleteProperty(string address)
        {
            var response = _propertyHelper.DeleteOldProperty(address);
            // PropertyResponseDto response = new PropertyResponseDto();
            // response = Mapper.Map<PropertyResponseDto>(res);
            return Ok(response);
        }
    }
}
