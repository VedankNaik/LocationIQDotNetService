// using System.Collections.Generic;
// using System.Linq;
// using System.Net.Mime;
// using System.Threading.Tasks;
// using IAZI.Common.Core.Models.Resources;
// using SwaggerService.Core.Interfaces.Services.Features;
// using SwaggerService.Core.Models.Features;
// using SwaggerService.Web.Controllers.Shared;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using IAZI.Common.Core.Models.Web.Options;
// using Microsoft.Extensions.Options;
// using Microsoft.Extensions.Localization;
// using Microsoft.Extensions.Logging;
// using SwaggerService.Web.Models.Features;
// using AutoMapper;
// using IAZI.Common.Core.Models.Web.Exceptions;
// using SwaggerService.Web.Models.Shared;
// using SwaggerService.Core.Models.Options;
// using Microsoft.AspNetCore.Authorization;

// namespace SwaggerService.Web.Controllers.V1.Features
// {
//     /// <summary>
//     /// Controller Feature
//     /// </summary>
//     [Authorize]
//     public class FeatureController : FeatureControllerBase
//     {
//         #region Properties

//         #endregion

//         #region Constructor

//         /// <summary>
//         /// Constructor
//         /// </summary>
//         /// <param name="featureService"></param>
//         /// <param name="serviceOptions"></param>
//         /// <param name="logger"></param>
//         /// <param name="localizer"></param>
//         /// <param name="mapper"></param>
//         /// <returns></returns>
//         public FeatureController(IFeatureService featureService,
//                                  IOptions<CustomServiceOptions<MyOptions>> serviceOptions,
//                                  ILogger<FeatureController> logger,
//                                  IStringLocalizer<DefaultResource> localizer,
//                                  IMapper mapper) : base(featureService, serviceOptions, logger, localizer, mapper)
//         {            
//         }

//         #endregion

//         #region Public Methods

//         /// <summary>
//         /// Get features
//         /// </summary>
//         /// <param name="featureGetRequestDto"></param>
//         /// <param name="requestHeaderBaseDto"></param>
//         /// <returns></returns>
//         [HttpGet]
//         [Route("/v{ver:apiVersion}/features")]
//         [Produces("application/json", "application/problem+json")]
//         [ProducesResponseType(typeof(IEnumerable<FeatureGetResponseDto>), StatusCodes.Status200OK)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status401Unauthorized)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status403Forbidden)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status400BadRequest)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status404NotFound)]
//         public async Task<IActionResult> GetFeatures([FromQuery] FeatureGetRequestDto featureGetRequestDto, [FromQuery] RequestBaseDto requestHeaderBaseDto)
//         {
//             var noPermissions = CheckPermissions();
//             if (noPermissions != null)
//             {
//                 return noPermissions;
//             }

//             var model = Mapper.Map<FeatureGetRequest>(featureGetRequestDto);
//             ApplyRequestBaseHeaders(requestHeaderBaseDto, model);
//             var response = await FeatureService.GetFeatures(model);

//             var dto = Mapper.Map<IEnumerable<FeatureGetResponseDto>>(response);
//             return Ok(dto);
//         }

//         /// <summary>
//         /// Get feature by Id
//         /// </summary>
//         /// <param name="featureId"></param>
//         /// <param name="requestHeaderBaseDto"></param>
//         /// <returns></returns>
//         [HttpGet]
//         [Route("/v{ver:apiVersion}/features/{featureId:int:min(1)}")]
//         [Produces("application/json", "application/problem+json")]
//         [ProducesResponseType(typeof(FeatureGetResponseDto), StatusCodes.Status200OK)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status401Unauthorized)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status403Forbidden)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status400BadRequest)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status404NotFound)]
//         public async Task<IActionResult> GetFeature([FromRoute] int featureId, [FromQuery] RequestBaseDto requestHeaderBaseDto)
//         {
//             var noPermissions = CheckPermissions();
//             if (noPermissions != null)
//             {
//                 return noPermissions;
//             }

//             var model = Mapper.Map<FeatureGetRequest>(requestHeaderBaseDto);
//             model.FeatureId = featureId;
//             var response = await FeatureService.GetFeatures(model);

//             if (!response.Any())
//             {
//                 return NotFound();
//             }

//             var entity = response.FirstOrDefault();

//             var dto = Mapper.Map<FeatureGetResponseDto>(entity);
//             return Ok(dto);
//         }

//         /// <summary>
//         /// Create a new feature
//         /// </summary>
//         /// <param name="requestHeaderBaseDto"></param>
//         /// <param name="featureCreateRequestDto">feature input data</param>
//         /// <returns>response with feature id</returns>
//         [HttpPost]
//         [Route("/v{ver:apiVersion}/features")]
//         [Produces("application/json", "application/problem+json")]
//         [Consumes(MediaTypeNames.Application.Json)]
//         [ProducesResponseType(typeof(FeatureCreateResponseDto), StatusCodes.Status201Created)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status400BadRequest)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status401Unauthorized)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status403Forbidden)]
//         public async Task<IActionResult> CreateFeature([FromQuery] RequestBaseDto requestHeaderBaseDto, [FromBody] FeatureCreateRequestDto featureCreateRequestDto)
//         {
//             var noPermissions = CheckPermissions();
//             if (noPermissions != null)
//             {
//                 return noPermissions;
//             }

//             var model = Mapper.Map<FeatureCreateRequest>(featureCreateRequestDto);
//             ApplyRequestBaseHeaders(requestHeaderBaseDto, model);

//             var response = await FeatureService.CreateFeature(model);
//             var dto = Mapper.Map<FeatureCreateResponseDto>(response);

//             return CreatedAtAction(nameof(GetFeature), new
//             {
//                 featureId = dto.FeatureId,
//                 productId = featureCreateRequestDto.ProductId,
//                 requestCustomerId = requestHeaderBaseDto.RequestCustomerId,
//                 requestUserId = requestHeaderBaseDto.RequestUserId,
//                 culture = requestHeaderBaseDto.Culture
//             }, response);
//         }

//         /// <summary>
//         /// Delete a feature
//         /// </summary>
//         /// <param name="featureId"></param>
//         /// <param name="requestHeaderBaseDto"></param>
//         /// <param name="featureDeleteRequestDto">feature delete</param>
//         /// <returns>response with feature id</returns>
//         [HttpDelete]
//         [Route("/v{ver:apiVersion}/features/{featureId:int:min(1)}")]
//         [Produces("application/json", "application/problem+json")]
//         [Consumes(MediaTypeNames.Application.Json)]
//         [ProducesResponseType(StatusCodes.Status204NoContent)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status400BadRequest)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status401Unauthorized)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status403Forbidden)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status404NotFound)]
//         public async Task<IActionResult> DeleteFeature([FromRoute] int featureId,[FromQuery] FeatureDeleteRequestDto featureDeleteRequestDto, [FromQuery] RequestBaseDto requestHeaderBaseDto)
//         {
//             var noPermissions = CheckPermissions();
//             if (noPermissions != null)
//             {
//                 return noPermissions;
//             }

//             if (!await FeatureExistsById(featureId, requestHeaderBaseDto))
//             {
//                 return NotFound();
//             } 

//             var model = Mapper.Map<FeatureDeleteRequest>(featureDeleteRequestDto);
//             model.FeatureId = featureId;
//             ApplyRequestBaseHeaders(requestHeaderBaseDto, model);

//             await FeatureService.DeleteFeature(model);

//             return NoContent();
//         }

//         /// <summary>
//         /// Update a feature
//         /// </summary>
//         /// <param name="featureId"></param>
//         /// <param name="requestHeaderBaseDto"></param>
//         /// <param name="featureUpdateRequestDto"></param>
//         /// <returns></returns>
//         [HttpPut]
//         [Route("/v{ver:apiVersion}/features/{featureId:int:min(1)}")]
//         [Produces("application/json", "application/problem+json")]
//         [Consumes(MediaTypeNames.Application.Json)]
//         [ProducesResponseType(StatusCodes.Status204NoContent)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status400BadRequest)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status401Unauthorized)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status403Forbidden)]
//         [ProducesResponseType(typeof(ProblemDetailsDto), StatusCodes.Status404NotFound)]
//         public async Task<IActionResult> UpdateFeature([FromRoute] int featureId, [FromQuery] RequestBaseDto requestHeaderBaseDto, [FromBody] FeatureUpdateRequestDto featureUpdateRequestDto)
//         {
//             var noPermissions = CheckPermissions();
//             if (noPermissions != null)
//             {
//                 return noPermissions;
//             }

//             if (!await FeatureExistsById(featureId, requestHeaderBaseDto))
//             {
//                 return NotFound();
//             }

//             var model = Mapper.Map<FeatureUpdateRequest>(featureUpdateRequestDto);
//             model.FeatureId = featureId;
//             ApplyRequestBaseHeaders(requestHeaderBaseDto, model);

//             await FeatureService.UpdateFeature(model);

//             return NoContent();
//         }

//         #endregion
//     }
// }