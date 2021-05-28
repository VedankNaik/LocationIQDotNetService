using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SwaggerService.Core.Models.V2.ReverseGeocode
{

    public class ReverseGeocodeResponseObject
    {

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Search Response List
        /// </summary>
        public ReverseGeocodeResponse SearchResponse { get; set; }
    }

    /// <summary>
    /// ForwardGeocode Response List
    /// </summary>
    /// <remark></remark>
    public class ReverseGeocodeResponse
    {
        /// <summary>
        /// Distance
        /// </summary>
        /// <remark>The straight line distance (meters) between the input location and the result's location</remark>
        [DataMember(Name = "distance", EmitDefaultValue = false)]
        public decimal Distance { get; set; }

        /// <summary>
        /// PlaceId
        /// </summary>
        /// <remark>An internal identifier for this result in the LocationIQ database</remark>
        [JsonPropertyName("PlaceId")]
        [DataMember(Name = "place_id", EmitDefaultValue = false)]
        public string place_id { get; set; }

        /// <summary>
        /// Licence
        /// </summary>
        /// <remark>The Licence and attribution requirements</remark>
        [DataMember(Name = "licence", EmitDefaultValue = false)]
        public string Licence { get; set; }

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
        /// Boundingbox
        /// </summary>
        /// <remark>Array of bounding box coordinates</remark>
        [DataMember(Name = "boundingbox", EmitDefaultValue = false)]
        public List<string> Boundingbox { get; set; }

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
        /// DisplayName
        /// </summary>
        /// <remark>The display name of this result</remark>
        [JsonPropertyName("DisplayName")]
        [DataMember(Name = "display_name", EmitDefaultValue = false)]
        public string display_name { get; set; }

        /// <summary>
        /// Importance
        /// </summary>
        /// <remark>Calculated importance of this result compared to the search query the user has provided</remark>
        [DataMember(Name = "importance", EmitDefaultValue = false)]
        public decimal Importance { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        /// <remark>The address breakdown into individual components</remark>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public AddressReverse Address { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        /// <remark>Tags like website or maxspeed.</remark>
        [DataMember(Name = "extratags", EmitDefaultValue = false)]
        public ExtraTagsReverse ExtraTags { get; set; }

        /// <summary>
        /// NameDetails
        /// </summary>
        /// <remark>Full list of available names</remark>
        [DataMember(Name = "namedetails", EmitDefaultValue = false)]
        public NameDetailsReverse NameDetails { get; set; }

        /// <summary>
        /// MatchQuality
        /// </summary>
        /// <remark>Full list of available names</remark>
        [DataMember(Name = "matchquality", EmitDefaultValue = false)]
        public MatchQualityReverse MatchQuality { get; set; }
    }

    public class AddressReverse
    {
        /// <summary>
        /// HouseNumber
        /// </summary>
        [JsonPropertyName("HouseNumber")]
        [DataMember(Name = "house_number", EmitDefaultValue = false)]
        public string house_number { get; set; }

        /// <summary>
        /// Road
        /// </summary>
        [DataMember(Name = "road", EmitDefaultValue = false)]
        public string Road { get; set; }

        /// <summary>
        /// Neighbourhood
        /// </summary>
        [DataMember(Name = "neighbourhood", EmitDefaultValue = false)]
        public string Neighbourhood { get; set; }

        /// <summary>
        /// Hamlet
        /// </summary>
        [DataMember(Name = "hamlet", EmitDefaultValue = false)]
        public string Hamlet { get; set; }

        /// <summary>
        /// Suburb
        /// </summary>
        [DataMember(Name = "suburb", EmitDefaultValue = false)]
        public string Suburb { get; set; }

        /// <summary>
        /// Village
        /// </summary>
        [DataMember(Name = "village", EmitDefaultValue = false)]
        public string Village { get; set; }

        /// <summary>
        /// Town
        /// </summary>
        [DataMember(Name = "town", EmitDefaultValue = false)]
        public string Town { get; set; }

        /// <summary>
        /// CityDistrict
        /// </summary>
        [JsonPropertyName("CityDistrict")]
        [DataMember(Name = "city_district", EmitDefaultValue = false)]
        public string city_district { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        /// <summary>
        /// Region
        /// </summary>
        [DataMember(Name = "region", EmitDefaultValue = false)]
        public string region { get; set; }

        /// <summary>
        /// County
        /// </summary>
        [DataMember(Name = "county", EmitDefaultValue = false)]
        public string County { get; set; }

        /// <summary>
        /// District
        /// </summary>
        [DataMember(Name = "district", EmitDefaultValue = false)]
        public string District { get; set; }

        /// <summary>
        /// StateDistrict
        /// </summary>
        [DataMember(Name = "state_district", EmitDefaultValue = false)]
        public string StateDistrict { get; set; }

        /// <summary>
        /// State
        /// </summary>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        /// <summary>
        /// StateCode
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [JsonPropertyName("StateCode")]
        public string State_Code { get; set; }

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

    public class NameDetailsReverse
    {
        /// <summary>
        /// Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }
    }

    public class ExtraTagsReverse
    {
        /// <summary>
        /// Phone
        /// </summary>
        [DataMember(Name = "phone", EmitDefaultValue = false)]
        public string Phone { get; set; }

        /// <summary>
        /// Website
        /// </summary>
        [DataMember(Name = "website", EmitDefaultValue = false)]
        public string Website { get; set; }

        /// <summary>
        /// Wikidata
        /// </summary>
        [DataMember(Name = "wikidata", EmitDefaultValue = false)]
        public string Wikidata { get; set; }

        /// <summary>
        /// Wikipedia
        /// </summary>
        [DataMember(Name = "wikipedia", EmitDefaultValue = false)]
        public string Wikipedia { get; set; }

        /// <summary>
        /// Wheelchair
        /// </summary>
        [DataMember(Name = "wheelchair", EmitDefaultValue = false)]
        public string Wheelchair { get; set; }

        /// <summary>
        /// Opening hours
        /// </summary>
        [JsonPropertyName("OpeningHours")]
        [DataMember(Name = "opening_hours", EmitDefaultValue = false)]
        public string opening_hours { get; set; }
    }

    public class MatchQualityReverse
    {
        /// <summary>
        /// Matchcode
        /// </summary>
        [DataMember(Name = "matchcode", EmitDefaultValue = false)]
        public string Matchcode { get; set; }

        /// <summary>
        /// Matchtype
        /// </summary>
        [DataMember(Name = "matchtype", EmitDefaultValue = false)]
        public string Matchtype { get; set; }

        /// <summary>
        /// Matchlevel
        /// </summary>
        [DataMember(Name = "matchlevel", EmitDefaultValue = false)]
        public string Matchlevel { get; set; }
    }

}