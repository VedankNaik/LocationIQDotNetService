using SwaggerService.Core.Interfaces.Infrastructure.Repositories.V1;
using Microsoft.Data.SqlClient;
using AutoMapper;
using System.Data;
using System.Collections.Generic;
using Dapper;
using SwaggerService.Core.Models.V1.Property;

namespace SwaggerService.Infrastructure.Repositories.V1
{
    /// <summary>
    /// Features Repository class
    /// </summary>
    public class PropertyRepository : IPropertyRepository
    {
        #region Constants

        protected readonly IMapper Mapper;

        private readonly string connectionString;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public PropertyRepository(IMapper mapper)
        {
            //this.GetConnection(); 
            connectionString = "Data Source=DESKTOP-TSP81E7\\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=True";
            Mapper = mapper;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        #endregion

        #region Public methods

        public IEnumerable<PropertyResponse> GetProperties()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "select * from property";
                dbConnection.Open();
                return dbConnection.Query<PropertyResponse>(query);
            }
        }

        public PropertyResponse GetProperty(string address)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "select * from property where address=@address";
                dbConnection.Open();
                PropertyResponse res = dbConnection.QueryFirstOrDefault<PropertyResponse>(query, new { address = address });
                return res;
            }
        }

        public string AddProperty(PropertyRequest property)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string check = "select * from property where address=@address";
                dbConnection.Open();
                PropertyResponse res = dbConnection.QueryFirstOrDefault<PropertyResponse>(check, new { address = property.address });
                if(res==null)
                {
                    string query = "insert into property(address, ownerName, price) values(@address, @ownerName, @price)";           
                    dbConnection.Execute(query, property);
                    return "Property added";
                }
                else 
                {
                     return "Property address already added";
                }          
            }
        }

        public string UpdateProperty(PropertyRequest property)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string check = "select * from property where address=@address";
                dbConnection.Open();
                PropertyResponse res = dbConnection.QueryFirstOrDefault<PropertyResponse>(check, new { address = property.address });
                if(res==null)
                {
                    return "Property address does not exist";
                }
                else 
                {
                    string query = "update property set ownerName=@ownerName, price=@price where address=@address";
                    dbConnection.Execute(query, property);
                    return "Property updated";
                } 
            }
        }

        public string DeleteProperty(string address)
        {
            using (IDbConnection dbConnection = Connection)
            {   
                string check = "select * from property where address=@address";
                dbConnection.Open();
                PropertyResponse res = dbConnection.QueryFirstOrDefault<PropertyResponse>(check, new { address = address });
                if(res==null)
                {
                    return "Property address does not exist";
                }
                else 
                {
                    string query = "delete from property where address=@address";
                    dbConnection.Execute(query,new { address = address });
                    return "Property deleted";
                } 
            }
        }



        // /// <summary>
        // /// GetService
        // /// </summary>
        // /// <param name=""></param>
        // /// <returns></returns>
        // public List<ServiceResponse> GetServices()
        // {
        //     //throw new NotImplementedException();
        //     SqlConnection con = this.GetConnection();
        //     SqlCommand command = new SqlCommand("select * from services", con);
        //     SqlDataReader reader = command.ExecuteReader();
        //     List<ServiceResponse> response = new List<ServiceResponse>();
        //     var dataTable = new DataTable();
        //     dataTable.Load(reader);
        //     if (dataTable.Rows.Count > 0)
        //     {
        //         var serializedMySevices = JsonConvert.SerializeObject(dataTable);
        //         // response = (List<ServiceResponse>)JsonConvert.DeserializeObject(serializedMySevices, typeof(List<ServiceResponse>));
        //         response = JsonConvert.DeserializeObject<List<ServiceResponse>>(serializedMySevices);
        //     }
        //     // while(reader.Read())
        //     // {
        //     //     ServiceResponse res = new ServiceResponse();
        //     //     res.ServiceId = (int)reader[0];
        //     //     res.Name = reader[1].ToString();

        //     //     response.Add(res);
        //     // }
        //     con.Close();
        //     return response;
        // }

        #endregion
    }
}