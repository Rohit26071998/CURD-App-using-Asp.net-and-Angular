using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class StudentsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select SNo,Name,Branch,
                    convert(varchar(10),DOB,120) as DOB,
                    MobileNo, Address, State, Pincode
                    from
                    dbo.tblStudents
                    ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["StudentsAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);


        }

        public string Post(Students stu)
        {
            try
            {
                string query = @"
                    insert into dbo.tblStudents values
                    (
                    '" + stu.Name + @"'
                    ,'" + stu.Branch + @"'
                    ,'" + stu.DOB + @"'
                    ,'" + stu.MobileNo + @"'
                    ,'" + stu.Address + @"'
                    ,'" + stu.State + @"'
                    ,'" + stu.Pincode + @"'
                    )
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["StudentsAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Add!!";
            }
        }


        public string Put(Students stu)
        {
            try
            {
                string query = @"
                    update dbo.tblStudents set 
                     Name='" + stu.Name + @"'
                    ,Branch='" + stu.Branch + @"'
                    ,DOB='" + stu.DOB + @"'
                    ,MobileNo='" + stu.MobileNo + @"'
                    ,Address='" + stu.Address + @"'
                    ,State='" + stu.State + @"'
                    ,Pincode='" + stu.Pincode + @"'
                    where SNo=" + stu.SNo + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["StudentsAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Update!!";
            }
        }


        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.tblStudents 
                    where SNo=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["StudentsAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Delete!!";
            }
        }
    }
}
