using Microsoft.EntityFrameworkCore;
using SwaggerService.Core.Interfaces.Infrastructure.Repositories.V1;
using Microsoft.Data.SqlClient;
using System;
using AutoMapper;
using System.Data;
using System.Collections.Generic;
using Dapper;
using SwaggerService.Core.Models.V1.Property;
using Microsoft.AspNetCore.Mvc;
using SwaggerService.Core.Interfaces.Infrastructure.Repositories.V2;
using SwaggerService.Core.Models.V2.ForwardGeocode;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SwaggerService.Core.Models.V2.ReverseGeocode;
using SwaggerService.Core.Models.V2.Autocomplete;
using SwaggerService.Core.Models.V2.Balance;
using SwaggerService.Core.Models.V2.Directions;
using SwaggerService.Core.Models.V2.Nearest;
using SwaggerService.Core.Models.V2.POI;

namespace SwaggerService.Infrastructure.Repositories.V1
{
    /// <summary>
    /// Location Repository class
    /// </summary>
    public class LocationRepository : ILocationRepository
    {
        #region Constants

        protected readonly IMapper Mapper;


        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public LocationRepository(IMapper mapper)
        {
            Mapper = mapper;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// ForwardGeocode
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ForwardGeocodeResponse ForwardGeocode(ForwardGeocodeRequest request)
        {
            var client = new RestSharp.RestClient(request.clientUrl);
            var req = new RestSharp.RestRequest(request.request);
            req.AddParameter("key", "pk.884091cb1c1f30ec8b84d4531540940e");
            if (request.q != null) req.AddParameter("q", request.q);
            if (request.format != null) req.AddParameter("format", request.format);
            if (request.normalizecity) req.AddParameter("normalizecity", Convert.ToInt32(true));
            if (request.addressdetails) req.AddParameter("addressdetails", Convert.ToInt32(true));
            if (request.viewbox != null) req.AddParameter("viewbox", request.viewbox);
            if (request.bounded) req.AddParameter("bounded", Convert.ToInt32(false));
            if (request.limit != 0) req.AddParameter("limit", request.limit);
            if (request.acceptLanguage != null) req.AddParameter("accept-language", request.acceptLanguage);
            if (request.countrycodes != null) req.AddParameter("countrycodes", request.countrycodes);
            if (request.namedetails) req.AddParameter("namedetails", Convert.ToInt32(true));
            if (request.extratags) req.AddParameter("extratags", Convert.ToInt32(true));
            if (request.statecode) req.AddParameter("statecode", Convert.ToInt32(true));
            if (request.matchquality) req.AddParameter("matchquality", Convert.ToInt32(true));
            if (request.postaladdress) req.AddParameter("postaladdress", Convert.ToInt32(true));

            var res = client.Execute(req);
            var content = res.Content;
            ForwardGeocodeResponse response = new ForwardGeocodeResponse();
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                response.SearchResponseLists = JsonConvert.DeserializeObject<List<ForwardGeocodeResponseList>>(content);
                response.Status = res.StatusCode.ToString();
            }
            else
            {
                var message = JObject.Parse(content);
                response.Status = res.StatusCode.ToString() + " : " + message["error"].ToString();
            }

            return response;
        }

        /// <summary>
        /// ReverseGeocode
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ReverseGeocodeResponseObject ReverseGeocode(ReverseGeocodeRequest request)
        {
            var client = new RestSharp.RestClient(request.clientUrl);
            var req = new RestSharp.RestRequest(request.request);
            req.AddParameter("key", "pk.884091cb1c1f30ec8b84d4531540940e");
            if (request.lat != 0) req.AddParameter("lat", request.lat);
            if (request.lon != 0) req.AddParameter("lon", request.lon);
            if (request.format != null) req.AddParameter("format", request.format);
            if (request.zoom > 0 && request.zoom <= 18) req.AddParameter("zoom", request.zoom);
            if (request.normalizecity) req.AddParameter("normalizecity", Convert.ToInt32(true));
            if (request.addressdetails) req.AddParameter("addressdetails", Convert.ToInt32(true));
            if (request.acceptLanguage != null) req.AddParameter("accept-language", request.acceptLanguage);
            if (request.namedetails) req.AddParameter("namedetails", Convert.ToInt32(true));
            if (request.extratags) req.AddParameter("extratags", Convert.ToInt32(true));
            if (request.statecode) req.AddParameter("statecode", Convert.ToInt32(true));
            if (request.showdistance) req.AddParameter("showdistance", Convert.ToInt32(true));
            if (request.postaladdress) req.AddParameter("postaladdress", Convert.ToInt32(true));


            var res = client.Execute(req);
            var content = res.Content;
            ReverseGeocodeResponseObject response = new ReverseGeocodeResponseObject();
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                response.SearchResponse = JsonConvert.DeserializeObject<ReverseGeocodeResponse>(content);
                response.Status = res.StatusCode.ToString();
            }
            else
            {
                var message = JObject.Parse(content);
                response.Status = res.StatusCode.ToString() + " : " + message["error"].ToString();
            }

            return response;
        }

        /// <summary>
        /// Autocomplete
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AutocompleteResponse Autocomplete(AutocompleteRequest request)
        {
            var client = new RestSharp.RestClient(request.clientUrl);
            var req = new RestSharp.RestRequest(request.request);
            req.AddParameter("key", "pk.884091cb1c1f30ec8b84d4531540940e");
            if (request.q != null) req.AddParameter("q", request.q);
            if (request.format != null) req.AddParameter("format", request.format);
            if (request.normalizecity) req.AddParameter("normalizecity", Convert.ToInt32(true));
            if (request.addressdetails) req.AddParameter("addressdetails", Convert.ToInt32(true));
            if (request.viewbox != null) req.AddParameter("viewbox", request.viewbox);
            if (request.bounded) req.AddParameter("bounded", Convert.ToInt32(true));
            if (request.limit != 0) req.AddParameter("limit", request.limit);
            if (request.acceptLanguage != null) req.AddParameter("accept-language", request.acceptLanguage);
            if (request.countrycodes != null) req.AddParameter("countrycodes", request.countrycodes);
            if (request.tag != null) req.AddParameter("tag", request.tag);

            var res = client.Execute(req);
            var content = res.Content;
            AutocompleteResponse response = new AutocompleteResponse();
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                response.SearchResponseList = JsonConvert.DeserializeObject<List<AutocompleteResponseList>>(content);
                response.Status = res.StatusCode.ToString();
            }
            else
            {
                var message = JObject.Parse(content);
                response.Status = res.StatusCode.ToString() + " : " + message["error"].ToString();
            }

            return response;
        }

        /// <summary>
        /// Balance
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public BalanceResponse Balance(BalanceRequest request)
        {
            var client = new RestSharp.RestClient(request.clientUrl);
            var req = new RestSharp.RestRequest(request.request);
            req.AddParameter("key", "pk.884091cb1c1f30ec8b84d4531540940e");

            var res = client.Execute(req);
            var content = res.Content;
            BalanceResponse response = new BalanceResponse();
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                response = JsonConvert.DeserializeObject<BalanceResponse>(content);
            }
            else
            {
                var message = JObject.Parse(content);
                response.Status = res.StatusCode.ToString() + " : " + message["error"].ToString();
            }

            return response;
        }

        /// <summary>
        /// Directions
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JObject Directions(DirectionsRequest request)
        {
            var client = new RestSharp.RestClient(request.clientUrl);
            var req = new RestSharp.RestRequest(request.request + "/" + request.coordinates);
            req.AddParameter("key", "pk.884091cb1c1f30ec8b84d4531540940e");
            if (request.bearings != null) req.AddParameter("bearings", request.bearings);
            if (request.radiuses != null) req.AddParameter("radiuses", request.radiuses);
            if (request.generateHints) req.AddParameter("generate_hints", request.generateHints.ToString().ToLower());
            if (request.exclude != null) req.AddParameter("exclude", request.exclude);
            if (request.alternatives != 0) req.AddParameter("alternatives", request.alternatives);
            if (request.steps) req.AddParameter("steps", request.steps.ToString().ToLower());
            if (request.geometries != null) req.AddParameter("geometries", request.geometries);
            if (request.overview != null) req.AddParameter("overview", request.overview);
            if (request.continue_straight != null) req.AddParameter("continue_straight", request.continue_straight);

            var res = client.Execute(req);
            var content = res.Content;
            JObject ob = JObject.Parse(content);
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return ob;
            }
            else
            {
                return JObject.Parse(content);
            }

        }

        /// <summary>
        /// Nearest
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JObject Nearest(NearestRequest request)
        {
            var client = new RestSharp.RestClient(request.clientUrl);
            var req = new RestSharp.RestRequest(request.request + "/" + request.coordinates);
            req.AddParameter("key", "pk.884091cb1c1f30ec8b84d4531540940e");
            if (request.bearings != null) req.AddParameter("bearings", request.bearings);
            if (request.radiuses != null) req.AddParameter("radiuses", request.radiuses);
            if (request.generateHints) req.AddParameter("generate_hints", request.generateHints.ToString().ToLower());
            if (request.number != 0) req.AddParameter("number", request.number);
        
            var res = client.Execute(req);
            var content = res.Content;
            JObject ob = JObject.Parse(content);
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return ob;
            }
            else
            {
                return JObject.Parse(content);
            }
        }

        /// <summary>
        /// POI
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public POIResponse POI(POIRequest request)
        {
            var client = new RestSharp.RestClient(request.clientUrl);
            var req = new RestSharp.RestRequest(request.request);
            req.AddParameter("key", "pk.884091cb1c1f30ec8b84d4531540940e");
            if (request.lat != 0) req.AddParameter("lat", request.lat);
            if (request.lon != 0) req.AddParameter("lon", request.lon);
            if (request.radius > 0) req.AddParameter("radius", request.radius);
            if (request.tag != null) req.AddParameter("tag", request.tag);
            if (request.limit > 0) req.AddParameter("limit", request.limit);
            if (request.format != null) req.AddParameter("format", request.format);

            var res = client.Execute(req);
            var content = res.Content;
            POIResponse response = new POIResponse();
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                response.SearchResponseList = JsonConvert.DeserializeObject<List<POIResponseList>>(content);
                response.Status = res.StatusCode.ToString();
            }
            else
            {
                var message = JObject.Parse(content);
                response.Status = res.StatusCode.ToString() + " : " + message["error"].ToString();
            }

            return response;
        }

        #endregion
    }
}