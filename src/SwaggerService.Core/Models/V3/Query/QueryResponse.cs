

using Newtonsoft.Json;

namespace SwaggerService.Core.Models.V3.Query
{

    public class QueryResponse
    {
        /// <summary>
        /// EGID
        /// </summary>
        public int EGID { get; set; }

        /// <summary>
        /// Town
        /// </summary>
        public string Town { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Zip
        /// </summary>
        public int Zip { get; set; }

         /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public double latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double longitude { get; set; }
        

    }
}
