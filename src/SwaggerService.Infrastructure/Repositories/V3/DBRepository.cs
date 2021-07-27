
using System;
using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SqlDataReaderMapper;
using SwaggerService.Core.Interfaces.Infrastructure.Repositories.V3;
using SwaggerService.Core.Models.V2.ForwardGeocode;
using SwaggerService.Core.Models.V2.ReverseGeocode;
using SwaggerService.Core.Models.V3.DBConnection;
using SwaggerService.Core.Models.V3.Query;

namespace SwaggerService.Infrastructure.Repositories.V1
{
    /// <summary>
    /// DB Repository class
    /// </summary>
    public class DBRepository : IDBRepository
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
        public DBRepository(IMapper mapper)
        {
            Mapper = mapper;
        }

        #endregion

        #region Public methods

        public bool DBConnection(DBConnectionRequest request)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = request.Server,
                    UserID = request.UserName,
                    Password = request.Password,
                    InitialCatalog = request.Database,
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    return true;
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static SqlConnection GetConnection(DBConnectionRequest request)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = request.Server,
                    UserID = request.UserName,
                    Password = request.Password,
                    InitialCatalog = request.Database,
                };

                SqlConnection connection = new SqlConnection(builder.ConnectionString);

                return connection;


            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }

        }

        public IEnumerable<QueryResponse> RunQuery(DBConnectionRequest request, string query)
        {
            try
            {
                SqlConnection connection = GetConnection(request);
            if (connection != null)
            {
                using (SqlConnection dbConnection = connection)
                {
                    dbConnection.Open();
                    // query = "select town from addresses";
                    return dbConnection.Query<QueryResponse>(query);
                }
            }
            else
            {
                return null;
            }
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public string ForwardValidate(List<QueryResponse> queryResponse, DBConnectionRequest request, string insertTable)
        {
            try
            {
                SqlConnection connection = GetConnection(request);
                if (connection != null)
                {
                    using (SqlConnection dbConnection = connection)
                    {
                        dbConnection.Open();

                        for (var i = 0; i < 2; i++)
                        {
                            var req = queryResponse[i].Street + " " + queryResponse[i].Zip + " " + queryResponse[i].Town;
                            var client = new RestSharp.RestClient("https://eu1.locationiq.com/");
                            var restRequest = new RestSharp.RestRequest("v1/search.php");
                            restRequest.AddParameter("key", "pk.884091cb1c1f30ec8b84d4531540940e");
                            restRequest.AddParameter("q", req);
                            restRequest.AddParameter("format", "json");
                            restRequest.AddParameter("limit", 1);
                            var restResponse = client.Execute(restRequest);
                            var content = restResponse.Content;
                            Thread.Sleep(1000);

                            ForwardGeocodeResponse geoResponse = new ForwardGeocodeResponse();

                            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                geoResponse.SearchResponseLists = JsonConvert.DeserializeObject<List<ForwardGeocodeResponseList>>(content);
                                geoResponse.Status = restResponse.StatusCode.ToString();
                                var result = geoResponse.SearchResponseLists[0];

                                string insertQuery = string.Format("INSERT INTO {0}([EGID], [Street], [Zip], [Town], [PlaceID], [Latitide] ,[Longitude], [DisplayName], [Class], [Type], [Importance]) VALUES (@EGID, @Street, @Zip, @Town, @place_id, @Lat, @Lon, @display_name, @Class, @Type, @Importance)", insertTable);
                                var execute = dbConnection.Execute(insertQuery, new
                                {
                                    queryResponse[i].EGID,
                                    queryResponse[i].Street,
                                    queryResponse[i].Zip,
                                    queryResponse[i].Town,
                                    result.place_id,
                                    result.Lat,
                                    result.Lon,
                                    result.display_name,
                                    result.Class,
                                    result.Type,
                                    result.Importance
                                });

                                if (execute == 1)
                                {
                                    string updateQuery = string.Format("update addresses set validate = 1 where EGID = {0}", queryResponse[i].EGID);
                                    dbConnection.Execute(updateQuery);
                                }
                            }
                            else
                            {
                                i++;
                            }
                        }
                    }
                }
                else
                {
                    return "Connection Error";
                }

                return "Ok";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public string ReverseValidate(List<QueryResponse> queryResponse, DBConnectionRequest request, string insertTable)
        {
            try
            {
                SqlConnection connection = GetConnection(request);
                if (connection != null)
                {
                    using (SqlConnection dbConnection = connection)
                    {
                        dbConnection.Open();

                        for (var i = 0; i < 2; i++)
                        {
                            var client = new RestSharp.RestClient("https://eu1.locationiq.com/");
                            var restRequest = new RestSharp.RestRequest("v1/reverse.php");
                            restRequest.AddParameter("key", "pk.884091cb1c1f30ec8b84d4531540940e");
                            restRequest.AddParameter("lat", queryResponse[i].latitude);
                            restRequest.AddParameter("lon", queryResponse[i].longitude);
                            restRequest.AddParameter("zoom", "18");
                            restRequest.AddParameter("format", "json");
                            var restResponse = client.Execute(restRequest);
                            var content = restResponse.Content;
                            Thread.Sleep(1000);

                            ReverseGeocodeResponseObject geoResponse = new ReverseGeocodeResponseObject();

                            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                geoResponse.SearchResponse = JsonConvert.DeserializeObject<ReverseGeocodeResponse>(content);
                                geoResponse.Status = restResponse.StatusCode.ToString();
                                var result = geoResponse.SearchResponse;

                                string insertQuery = string.Format("INSERT INTO {0}([RefID], [City], [OldLatitude], [OldLongitude], [PlaceID], [NewLatitude] ,[NewLongitude], [DisplayName], [Importance]) VALUES (@ID, @city, @latitude, @longitude, @place_id, @Lat, @Lon, @display_name, @Importance)", insertTable);
                                var execute = dbConnection.Execute(insertQuery, new
                                {
                                    queryResponse[i].ID,
                                    queryResponse[i].city,
                                    queryResponse[i].latitude,
                                    queryResponse[i].longitude,
                                    result.place_id,
                                    result.Lat,
                                    result.Lon,
                                    result.display_name,
                                    // result.Importance
                                });

                                if (execute == 1)
                                {
                                    string updateQuery = string.Format("update latlon set validate = 1 where ID = {0}", queryResponse[i].ID);
                                    dbConnection.Execute(updateQuery);
                                }
                            }
                            else
                            {
                                i++;
                            }
                        }
                    }
                }
                else
                {
                    return "Connection Error";
                }

                return "Ok";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        
        #endregion

    }
}

