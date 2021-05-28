using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SwaggerService.Core.Models.V2.POI
{
    public class POIResponse
    {

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Search Response List
        /// </summary>
        public List<POIResponseList> SearchResponseList { get; set; }
    } 

    public class POIResponseList
    {
        /// <summary>
        /// PlaceId
        /// </summary>
        /// <remark>An internal identifier for this result in the LocationIQ database</remark>
        [JsonPropertyName("PlaceId")]
        [DataMember(Name = "place_id", EmitDefaultValue = false)]
        public string place_id { get; set; }

        /// <summary>
        /// OsmType
        /// </summary>
        /// <remark>The type of this result.</remark>
        [JsonPropertyName("OsmType")]
        [DataMember(Name = "osm_type", EmitDefaultValue = false)]
        public string osm_type { get; set; }

        /// <summary>
        /// OsmId
        /// </summary>
        /// <remark>The corresponding OSM ID of this result</remark>
        [JsonPropertyName("OsmId")]
        [DataMember(Name = "osm_id", EmitDefaultValue = false)]
        public string osm_id { get; set; }

        /// <summary>
        /// Lat
        /// </summary>
        /// <remark>The Latitude of this result</remark>
        [DataMember(EmitDefaultValue = false)]
        [JsonPropertyName("Latitude")]
        public string Lat { get; set; }

        /// <summary>
        /// Lon
        /// </summary>
        /// <remark>The Longitude of this result</remark>
        [DataMember(EmitDefaultValue = false)]
        [JsonPropertyName("Longitude")]

        public string Lon { get; set; }

        /// <summary>
        /// Class
        /// </summary>
        /// <remark>The category of this result</remark>
        [DataMember(EmitDefaultValue = false)]
        [JsonPropertyName("Class")]

        public string Class { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        /// <remark>The type of the result</remark>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Tag_Type
        /// </summary>
        /// <remark>The Tag_Type of the result</remark>
        [DataMember(Name = "Tag_Type", EmitDefaultValue = false)]
        public string Tag_Type { get; set; }
        
        /// <summary>
        /// Name
        /// </summary>
        /// <remark>Name of location</remark>
        [DataMember(Name = "Name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// DisplayName
        /// </summary>
        /// <remark>The display name of this result</remark>
        [JsonPropertyName("DisplayName")]
        [DataMember(Name = "display_name", EmitDefaultValue = false)]
        public string display_name { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        /// <remark>The address breakdown into individual components</remark>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public AddressPOI Address { get; set; }

        /// <summary>
        /// Boundingbox
        /// </summary>
        /// <remark>Array of bounding box coordinates</remark>
        [DataMember(Name = "boundingbox", EmitDefaultValue = false)]
        public List<string> Boundingbox { get; set; }

        /// <summary>
        /// Distance
        /// </summary>
        /// <remark>Distance from location</remark>
        [JsonPropertyName("Distance")]
        [DataMember(Name = "Distance", EmitDefaultValue = false)]
        public string Distance { get; set; }

    }

    public class AddressPOI
    {
        /// <summary>
        /// Name
        /// </summary>
        /// <remark>Name of location</remark>
        [DataMember(Name = "Name", EmitDefaultValue = false)]
        public string Name { get; set; }
        
        /// <summary>
        /// Road
        /// </summary>
        [DataMember(Name = "road", EmitDefaultValue = false)]
        public string Road { get; set; }

        /// <summary>
        /// Suburb
        /// </summary>
        [DataMember(Name = "suburb", EmitDefaultValue = false)]
        public string Suburb { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        /// <summary>
        /// State
        /// </summary>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        /// <summary>
        /// Postcode
        /// </summary>
        [DataMember(Name = "postcode", EmitDefaultValue = false)]
        public string Postcode { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; }

        /// <summary>
        /// CountryCode
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [JsonPropertyName("CountryCode")]
        public string country_code { get; set; }

    }

}