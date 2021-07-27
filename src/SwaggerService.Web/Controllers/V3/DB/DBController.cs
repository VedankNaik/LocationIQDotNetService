using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using System;
using SwaggerService.Core.Interfaces.Services.V3.DB;
using SwaggerService.Web.Models.V3.DBConnection;
using System.Collections.Generic;
using SwaggerService.Web.Models.V3.Query;
using Newtonsoft.Json;
using SwaggerService.Core.Models.V2.ForwardGeocode;
using Newtonsoft.Json.Linq;
using System.Threading;
using SwaggerService.Core.Models.V3.Query;

namespace SwaggerService.Web.Controllers.V3.DB
{
    [ApiVersion("3")]
    [ApiExplorerSettings(GroupName = "V3")]
    [ApiController]
    public class DBController : ControllerBase
    {
        public readonly IDBHelper _dbHelper;
        protected readonly IMapper Mapper;

        public DBController(IDBHelper dbHelper, IMapper mapper)
        {
            _dbHelper = dbHelper;
            Mapper = mapper;
        }

        /// <summary>
        /// Test Database connection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v{version:apiversion}/DBConnection")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult DBConnection([FromQuery] DBConnectionRequestDto details)
        {
            var response = _dbHelper.DBConnection(details);
            if (response)
            {
                return Ok("Connection successful");
            }
            else
            {
                return BadRequest("Connection error");
            }

        }

        /// <summary>
        /// Execute query
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v{version:apiversion}/Query")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Query([FromQuery] DBConnectionRequestDto request, string query)
        {
            var res = _dbHelper.RunQuery(request, query);
            var response = Mapper.Map<List<QueryResponseDto>>(res);
            // for (var i = 0; i < response.Count; i++) {
            //     Console.WriteLine("Amount is {0} and type is {1}", response[i].Town, response[i].type);
            // }
            if (response == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(response);
            }

        }

        /// <summary>
        /// Forward Geocode Validation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v{version:apiversion}/ForwardGeocodeValidation")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult ForwardGeocodeValidate([FromQuery] DBConnectionRequestDto request, string query, string insertTable)
        {
            var queryRes = _dbHelper.RunQuery(request, query);
            var queryResponse = Mapper.Map<List<QueryResponse>>(queryRes);

            if(queryResponse == null || queryResponse.Count == 0 || queryResponse[0].Street == null || queryResponse[0].Zip.ToString() == null || queryResponse[0].Town == null)
            {
                return BadRequest("Invalid input");
            }

            var validateRes = _dbHelper.ForwardValidate(queryResponse, request, insertTable);       

            if (validateRes == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(validateRes);
            }

        }

        /// <summary>
        /// Reverse Geocode Validation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v{version:apiversion}/ReverseGeocodeValidation")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult ReverseGeocodeValidate([FromQuery] DBConnectionRequestDto request, string query, string insertTable)
        {
            var queryRes = _dbHelper.RunQuery(request, query);
            var queryResponse = Mapper.Map<List<QueryResponse>>(queryRes);

            if(queryResponse == null || queryResponse.Count == 0 || queryResponse[0].latitude.ToString() == null || queryResponse[0].longitude.ToString() == null)
            {
                return BadRequest("Invalid input");
            }

            var validateRes = _dbHelper.ReverseValidate(queryResponse, request, insertTable);       

            if (validateRes == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(validateRes);
            }

        }


    }

}