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
    public class PersonController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PersonController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //GET API Method to get all the department details
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from Person";
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
        public JsonResult Post(Person person)
        {
            string query = @"INSERT INTO Person(CNIC,FName ,LName,Age,Sex,Contact) VALUES 
            (
               '" + person.CNIC + @"',
               '" + person.FName + @"',
               '" + person.LName + @"',
               '" + person.Age + @"',
               '" + person.Sex + @"',
               '" + person.Contact + @"'
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
        public JsonResult Put(Person person)
        {
            string query = @"
                UPDATE PERSON SET FName = '" + person.FName + "LName = " + person.LName + "Age = " + person.Age +
                "Sex = " + person.Sex +"Contact = " + person.Contact +
                @"'
                WHERE CNIC = " + person.CNIC + @"";
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
        public JsonResult Delete(string id)
        {
            string query = @"
                DELETE FROM PERSON WHERE CNIC = '" + id + @"'";
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
