using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SwaggerService.Core.Models.V2.Directions
{

    public class DirectionsResponse
    {
        /// <summary>
        /// Code
        /// </summary>
        [DataMember(Name="code", EmitDefaultValue=false)]
        public string Code { get; set; }

        /// <summary>
        /// Waypoints
        /// </summary>
        [DataMember(Name="waypoints", EmitDefaultValue=false)]
        public List<DirectionWaypoints> Waypoints { get; set; }

        /// <summary>
        /// Routes
        /// </summary>
        [DataMember(Name="routes", EmitDefaultValue=false)]
        public List<DirectionsRoutes> Routes { get; set; }
      
    }

    /// <summary>
    /// Directions Routes
    /// </summary>
    /// <remark></remark>
    public class DirectionsRoutes
    {
        /// <summary>
        /// Legs
        /// </summary>
        [DataMember(Name="legs", EmitDefaultValue=false)]
        public List<DirectionLegs> Legs { get; set; }

        /// <summary>
        /// WeightName
        /// </summary>
        [DataMember(Name="weight_name", EmitDefaultValue=false)]
        public string Weight_Name { get; set; }

        /// <summary>
        /// Geometry
        /// </summary>
        [DataMember(Name="geometry", EmitDefaultValue=false)]
        public string Geometry { get; set; }

        /// <summary>
        /// Weight
        /// </summary>
        [DataMember(Name="weight", EmitDefaultValue=false)]
        public decimal Weight { get; set; }

        /// <summary>
        /// Distance
        /// </summary>
        [DataMember(Name="distance", EmitDefaultValue=false)]
        public decimal Distance { get; set; }

        /// <summary>
        /// Duration
        /// </summary>
        [DataMember(Name="duration", EmitDefaultValue=false)]
        public decimal Duration { get; set; }
    }

    public class DirectionWaypoints
    {
        /// <summary>
        /// hint
        /// </summary>
        [DataMember(Name="hint", EmitDefaultValue=false)]
        public string hint { get; set; }

        /// <summary>
        /// distance
        /// </summary>
        [DataMember(Name="distance", EmitDefaultValue=false)]
        public decimal distance { get; set; }

        /// <summary>
        /// name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string name { get; set; }

        /// <summary>
        /// location
        /// </summary>
        [DataMember(Name="location", EmitDefaultValue=false)]
        public List<decimal> location { get; set; }
    }

    public class DirectionLegs
    {
        /// <summary>
        /// steps
        /// </summary>
        [DataMember(Name="steps", EmitDefaultValue=false)]
        public List<string> steps { get; set; }

        /// <summary>
        /// distance
        /// </summary>
        [DataMember(Name="distance", EmitDefaultValue=false)]
        public decimal distance { get; set; }

        /// <summary>
        /// duration
        /// </summary>
        [DataMember(Name="duration", EmitDefaultValue=false)]
        public decimal duration { get; set; }

        /// <summary>
        /// summary
        /// </summary>
        [DataMember(Name="summary", EmitDefaultValue=false)]
        public string summary { get; set; }

        /// <summary>
        /// weight
        /// </summary>
        [DataMember(Name="weight", EmitDefaultValue=false)]
        public decimal weight { get; set; }
    }

}