using System.Threading.Tasks;
using gadgets.Application.gadgets.Queries.GetGadgetList;
using gadgets.Application.gadgets.Queries.GetGadgetDetails;
using Microsoft.AspNetCore.Mvc;
using gadgets.Application.gadgets.Commands.CreateGadget;
using gadgets.Application.gadgets.Commands.UpdateGadget;
using gadgets.Application.gadgets.Commands.DeleteGadget;
using gadgets.WebAPI.Models;
using AutoMapper;
using System.Data;
using System.Data.SqlClient;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using MediatR;
using Microsoft.AspNetCore.Authorization;
namespace gadgets.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class gadgetsController : BaseController
    {
        private readonly IMapper _mapper;
        /*private readonly IConfiguration _config;*/
        /*public gadgetsController(IMapper mapper) => _mapper = mapper;*/
        private readonly IConfiguration _configuration;
        public gadgetsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Authorize]
        /* public async Task<ActionResult<GadgetListVm>> GetAll()*/
        public JsonResult GetAll()
        {
            string query = @"
                select gadgetId as ""gadgetId"",
                       Title as ""Title"",
                       Details as ""Details""
                from gadgetsDb
            ";
            DataTable table = new DataTable();
             string sqlDataSource = _configuration.GetConnectionString("PostgreSQL");
            NpgsqlDataReader reader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    connection.Close();
                }  
            }
            return new JsonResult(table);
        }
        [HttpGet("{id}")]
        [Authorize]
        /*public async Task<ActionResult<GadgetListVm>> GetAll()*/
        public JsonResult Get(int id)
        {
            string query = @"
                select gadgetId as ""gadgetId"",
                       Title as ""Title"",
                       Details as ""Details""
                from gadgetsDb
                where gadgetId = @gadgetId
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PostgreSQL");
            NpgsqlDataReader reader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@gadgetId", id);
                    command.Parameters.AddWithValue("@Title", id);
                    command.Parameters.AddWithValue("@Details", id);
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        [Authorize]
        public JsonResult Post(CreateGadgetDto dep)
        {
            string query = @"
                insert into gadgetsDb(Title, Details)
                values             (@Title, @Details)
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PostgreSQL");
            NpgsqlDataReader reader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", dep.Title);
                    command.Parameters.AddWithValue("@Details", dep.Details);
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult("Added Succesfully");
        }
        [HttpPut]
        [Authorize]
        public JsonResult Put(UpdateGadgetDto dep)
        {
            string query = @"
                update gadgetsDb
                set Title = @Title,
                    Details = @Details
                where gadgetId=@gadgetId 
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PostgreSQL");
            NpgsqlDataReader reader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@gadgetId", dep.gadgetId);
                    command.Parameters.AddWithValue("@Title", dep.Title);
                    command.Parameters.AddWithValue("@Details", dep.Details);                    
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult("Updated Succesfully");
        }
        [HttpDelete("{id}")]
        [Authorize]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from gadgetsDb
                where gadgetId = @gadgetId
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PostgreSQL");
            NpgsqlDataReader reader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@gadgetId", id);
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult("Deleted Succesfully");
        }
    }
}