﻿using Microsoft.AspNetCore.Http;
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
    public class SeatController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SeatController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //GET API Method to get all the department details
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from Seat";
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
        public JsonResult Post(Seat seat)
        {
            //string query = @"INSERT INTO Seat(BUS_SEATID,SeatID ,SEATNO,Availability_of_seat) VALUES 
            //(
            //   '" + seat. + @"',
            //   '" + seat.BusNo + @"',
            //   '" + seat.departureDate + @"',
            //   '" + seat.departureTime + @"',
            //   '" + seat.ArrivalTime + @"'
            //)
            //";
            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("BTMSAppCon");
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            //    myCon.Open();
            //    using (SqlCommand mysqlCommand = new SqlCommand(query, myCon))
            //    {
            //        myReader = mysqlCommand.ExecuteReader();
            //        table.Load(myReader);

            //        //Closing the reader
            //        myReader.Close();
            //        //Closing the Connection
            //        myCon.Close();
            //    }
            //}
            //Now Returning the response when the data is returned that is a message "Added Successfully"
            return new JsonResult("Added Successfully");
        }


        //PUT Method to Update the data into the sql database table
        [HttpPut]
        public JsonResult Put(Schedule schedule)
        {
            string query = @"
                UPDATE SCHEDULE SET ListNo = '" + schedule.ListNo + "BusNo = " + schedule.BusNo + "departureDate = " + schedule.departureDate +
                "departureTime = " + schedule.departureTime +
                @"'
                WHERE ListNo = " + schedule.ListNo + @"";
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
                DELETE FROM SCHEDULE WHERE ListNo = '" + id + @"'";
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
