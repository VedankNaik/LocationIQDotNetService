using SwaggerService.Core.Models.Service;
using SwaggerService.Core.Interfaces.Infrastructure.Repositories.V1;
using Microsoft.Data.SqlClient;
using System;
using AutoMapper;
using System.Data;
using System.Collections.Generic;
using Dapper;

namespace SwaggerService.Infrastructure.Repositories.V1
{
    /// <summary>
    /// Features Repository class
    /// </summary>
    public class ServiceRepository : IServiceRepository
    {
        #region Constants

        protected readonly IMapper Mapper;

        private string connectionString;

        SqlConnection _con;


        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ServiceRepository(IMapper mapper)
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

        public SqlConnection GetConnection()
        {
            try
            {
                SqlConnection _con = new SqlConnection("Data Source=DESKTOP-TSP81E7\\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=True");
                _con.Open();
                return _con;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<ServiceResponse> GetServices()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "select * from services";
                dbConnection.Open();
                return dbConnection.Query<ServiceResponse>(query);
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