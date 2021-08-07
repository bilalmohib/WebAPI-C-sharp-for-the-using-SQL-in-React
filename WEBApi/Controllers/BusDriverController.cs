using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Models;

namespace WEBApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusDriverController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public BusDriverController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //GET API Method to get all the department details
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from BusDriver";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BTMSAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand mysqlCommand = new SqlCommand(query, myCon))
                {
                    myReader = mysqlCommand.ExecuteReader();
                    table.Load(myReader);

                    //Closing the reader
                    myReader.Close();
                    //Closing the Connection
                    myCon.Close();
                }
            }
            //Now Returning the data table as a Result
            return new JsonResult(table);
        }

        //POST Method to Insert the data into the sql database
        [HttpPost]
        public JsonResult Post(BusDriver busDriver)
        {
            string query = @"INSERT INTO BusDriver(CNIC ,BusNo) VALUES 
            (
               '" + busDriver.CNIC + @"',
               '" + busDriver.BusNo + @"'
            )
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BTMSAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand mysqlCommand = new SqlCommand(query, myCon))
                {
                    myReader = mysqlCommand.ExecuteReader();
                    table.Load(myReader);

                    //Closing the reader
                    myReader.Close();
                    //Closing the Connection
                    myCon.Close();
                }
            }
            //Now Returning the response when the data is returned that is a message "Added Successfully"
            return new JsonResult("Added Successfully");
        }


        //PUT Method to Update the data into the sql database table
        [HttpPut]
        public JsonResult Put(BusDriver busDriver)
        {
            string query = @"
                UPDATE Bus SET DriverID = '" + busDriver.DriverID + "CNIC = " + busDriver.CNIC + "BusNo = " + busDriver.BusNo +
                @"'
                WHERE DriverID = " + busDriver.DriverID + @"";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BTMSAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand mysqlCommand = new SqlCommand(query, myCon))
                {
                    myReader = mysqlCommand.ExecuteReader();
                    table.Load(myReader);

                    //Closing the reader
                    myReader.Close();
                    //Closing the Connection
                    myCon.Close();
                }
            }
            //Now Returning the response when the data is returned that is a message "Added Successfully"
            return new JsonResult("Updated Successfully");
        }

        //Delete Method to Delete the data into the sql database table
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                DELETE FROM BUSDRIVER WHERE DriverID = '" + id + @"'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BTMSAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand mysqlCommand = new SqlCommand(query, myCon))
                {
                    myReader = mysqlCommand.ExecuteReader();
                    table.Load(myReader);

                    //Closing the reader
                    myReader.Close();
                    //Closing the Connection
                    myCon.Close();
                }
            }
            //Now Returning the response when the data is returned that is a message "Added Successfully"
            return new JsonResult("Deleted Successfully");
        }
    }
}
