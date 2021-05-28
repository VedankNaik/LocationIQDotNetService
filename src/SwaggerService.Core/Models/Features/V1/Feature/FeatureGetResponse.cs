using System;

namespace SwaggerService.Core.Models.Features
{
    /// <summary>
    /// output class for FeatureGet
    /// </summary>
    public class FeatureGetResponse
    {
        #region Properties
            
        /// <summary>
        /// FeatureCommitId
        /// </summary>
        /// <value></value>
        public int? FeatureCommitId { get; set; }
        
        /// <summary>
        /// FeatureId
        /// </summary>
        /// <value></value>
        public int FeatureId { get; set; }
        
        /// <summary>
        /// FeatureExternalId
        /// </summary>
        /// <value></value>
        public string FeatureExternalId { get; set; }
        
        /// <summary>
        /// FeatureCreateDatetime
        /// </summary>
        /// <value></value>
        public DateTime? FeatureCreateDatetime { get; set; }
        
        /// <summary>
        /// FeatureCreateEmployeeId
        /// </summary>
        /// <value></value>
        public int? FeatureCreateEmployeeId { get; set; }
        
        /// <summary>
        /// FeatureLastUpdateDatetime
        /// </summary>
        /// <value></value>
        public DateTime? FeatureLastUpdateDatetime { get; set; }
        
        /// <summary>
        /// FeatureLastUpdateEmployeeId
        /// </summary>
        /// <value></value>
        public int? FeatureLastUpdateEmployeeId { get; set; }
        
        /// <summary>
        /// FeatureName
        /// </summary>
        /// <value></value>
        public string FeatureName { get; set; }

        /// <summary>
        /// Feature Description
        /// </summary>
        /// <value></value>
        public string FeatureDescription { get; set; }
        
        #endregion               
    }
}