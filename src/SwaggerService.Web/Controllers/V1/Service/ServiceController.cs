// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Http;
// using SwaggerService.Core.Interfaces.Services.Service;
// using AutoMapper;
// using SwaggerService.Web.Models.V1.Service;
// using System.Collections.Generic;

// // For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// namespace SwaggerService.Web.Controllers.V1.Service
// {
//     
//     public class ServiceController : ControllerBase
//     {
//         // public readonly ServiceContext _serviceContext;

//         public readonly IServiceHelper _serviceHelper;

//         protected readonly IMapper Mapper;
//         // IGetServices _getService;

//         //public ServiceController(IGetServices getService)
//         //{
//         //    _getService = getService;
//         //}
//         public ServiceController(IServiceHelper servicehelper, IMapper mapper)
//         {
//             _serviceHelper = servicehelper;
//             Mapper = mapper;
//         }

//         /// <summary>
//         /// Returns all services available 
//         /// </summary>
//         /// <returns></returns>
//         [HttpGet]
//         [Route("/v1/GetServices")]
//         [ProducesResponseType(typeof(ServiceResponseDto),StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status204NoContent)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         [ProducesResponseType(StatusCodes.Status401Unauthorized)]
//         [ProducesResponseType(StatusCodes.Status404NotFound)]
//         [ProducesResponseType(StatusCodes.Status403Forbidden)]
//         public IActionResult GetServices()
//         {
//             // var services = _serviceContext.Services;
//             var res = _serviceHelper.GetAllServices();
//             // var response = res;
//             List<ServiceResponseDto> response = new List<ServiceResponseDto>();
//             response = Mapper.Map<List<ServiceResponseDto>>(res);
//             return Ok(response);

//             // if(services.Count() == 0)
//             // {
//             //     return NoContent();
//             // }
//             // else
//             // {
//             //     return Ok(services);
//             // }          
//         }


//         // /// <summary>
//         // /// Returns service with name 
//         // /// </summary>
//         // /// <returns></returns>
//         // [HttpGet]
//         // [Route("/v1/GetService/{name}")]
//         // [ProducesResponseType(StatusCodes.Status200OK)]
//         // [ProducesResponseType(StatusCodes.Status204NoContent)]
//         // [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
//         // [ProducesResponseType(StatusCodes.Status404NotFound)]
//         // [ProducesResponseType(StatusCodes.Status403Forbidden)]
//         // public IActionResult GetService(string name)
//         // {
//         //     var service = _serviceContext.Services.SingleOrDefault(x => x.Name == name);
//         //     if(service == null)
//         //     {
//         //         return NoContent();
//         //     }
//         //     else
//         //     {
//         //         return Ok(service);
//         //     }
//         // }

//         // /// <summary>
//         // /// Add service
//         // /// </summary>
//         // /// <returns></returns>
//         // [HttpPost]
//         // [Route("/v1/AddService")]
//         // [ProducesResponseType(StatusCodes.Status200OK)]
//         // [ProducesResponseType(StatusCodes.Status204NoContent)]
//         // [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
//         // [ProducesResponseType(StatusCodes.Status404NotFound)]
//         // [ProducesResponseType(StatusCodes.Status403Forbidden)]
//         // public IActionResult AddService([FromBody] GetServiceModel service)
//         // {
//         //     var get = _serviceContext.Services.SingleOrDefault(x => x.Name == service.Name);
//         //     if (get == null)
//         //     {
//         //         _serviceContext.Services.Add(service);
//         //         _serviceContext.SaveChanges();
//         //         return Ok(service);
//         //     }
//         //     else
//         //     {
//         //         return BadRequest("Service name already exist");
//         //     }
//         // }

//         // /// <summary>
//         // /// Update service
//         // /// </summary>
//         // /// <returns></returns>
//         // [HttpPut]
//         // [Route("/v1/UpdateService")]
//         // [ProducesResponseType(StatusCodes.Status200OK)]
//         // [ProducesResponseType(StatusCodes.Status204NoContent)]
//         // [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
//         // [ProducesResponseType(StatusCodes.Status404NotFound)]
//         // [ProducesResponseType(StatusCodes.Status403Forbidden)]
//         // public IActionResult Put([FromQuery] string name, string description, string updateEmployee)
//         // {
//         //     var get = _serviceContext.Services.SingleOrDefault(x => x.Name == name);
//         //     if (get == null)
//         //     {
//         //         return NoContent();
//         //     }
//         //     else
//         //     {
//         //         if(description != null)
//         //         {
//         //             get.Description = description;
//         //         }
//         //         if (updateEmployee != null)
//         //         {
//         //             get.UpdateEmployee = updateEmployee;
//         //         }
//         //         _serviceContext.Services.Update(get);
//         //         _serviceContext.SaveChanges();
//         //         return Ok(get);
//         //     }
//         // }

//         // /// <summary>
//         // /// Delete service
//         // /// </summary>
//         // /// <returns></returns>
//         // [HttpDelete]
//         // [Route("/v1/DeleteService")]
//         // [ProducesResponseType(StatusCodes.Status200OK)]
//         // [ProducesResponseType(StatusCodes.Status204NoContent)]
//         // [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
//         // [ProducesResponseType(StatusCodes.Status404NotFound)]
//         // [ProducesResponseType(StatusCodes.Status403Forbidden)]
//         // public IActionResult Delete(string name)
//         // {
//         //     var service = _serviceContext.Services.FirstOrDefault(x => x.Name == name);
//         //     if(service == null)
//         //     {
//         //         return NoContent();
               
//         //     }
//         //     else
//         //     {
//         //         _serviceContext.Services.Remove(service);
//         //         _serviceContext.SaveChanges();
//         //         return Ok("Service deleted");
//         //     }
//         // }
//     }
// }
