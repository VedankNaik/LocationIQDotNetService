// using AutoMapper;
// using SwaggerService.Core.Models.Features;
// using SwaggerService.Web.Models.Shared;

// namespace SwaggerService.Web.Models.Features
// {
//     /// <summary>
//     /// Mapper Profile for Features
//     /// </summary>
//     public class FeaturesMapperProfile : Profile
//     {
//         #region Constructor
        
//         /// <summary>
//         /// Constructor
//         /// </summary>
//         public FeaturesMapperProfile()
//         {
//             // Automapper profiles
//             this.CreateMap<FeatureCreateRequestDto, FeatureCreateRequest>(); 
//             this.CreateMap<FeatureDeleteRequestDto, FeatureDeleteRequest>(); 
//             this.CreateMap<FeatureUpdateRequestDto, FeatureUpdateRequest>(); 
//             this.CreateMap<FeatureGetRequestDto, FeatureGetRequest>(); 
//             this.CreateMap<RequestBaseDto, FeatureGetRequest>(); 


//             this.CreateMap<FeatureCreateResponse, FeatureCreateResponseDto>(); 
//             this.CreateMap<FeatureDeleteResponse, FeatureDeleteResponseDto>(); 
//             this.CreateMap<FeatureUpdateResponse, FeatureUpdateResponseDto>(); 
//             this.CreateMap<FeatureGetResponse, FeatureGetResponseDto>(); 
//         }

//         #endregion
//     }
// }