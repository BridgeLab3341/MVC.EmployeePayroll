using CommonLayer;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RepoLayer.Service
{
    public class EmpRepo : IEmpRepo
    {
        private readonly IConfiguration configuration;
        private readonly string ConnectionString;

        public EmpRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConnectionString = configuration.GetConnectionString("MVC_Emp_Connection");
        }
        public string Create(EmployeeModel employee)
        {
            try
            {               
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand sqlCommand = new SqlCommand("InsertEmployeeData", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
                sqlCommand.Parameters.AddWithValue("@ProfileImage",employee.ProfileImage);
                sqlCommand.Parameters.AddWithValue("@Gender",employee.Gender);
                sqlCommand.Parameters.AddWithValue("@Department", employee.Department);
                sqlCommand.Parameters.AddWithValue("@Salary",employee.Salary);
                sqlCommand.Parameters.AddWithValue("@StartDate",employee.StartDate );
                sqlCommand.Parameters.AddWithValue("@Notes", employee.Notes);
                connection.Open();
                int ans = sqlCommand.ExecuteNonQuery();
                string result =ans.ToString();
                connection.Close();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                List<EmployeeModel> employees = new List<EmployeeModel>();
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("GetAllEmployees", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if(dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        EmployeeModel model = new EmployeeModel();
                        model.Name = dataReader.GetString(1);
                        model.ProfileImage = dataReader.GetString(2);
                        model.Gender = dataReader.GetString(3);
                        model.Department = dataReader.GetString(4);
                        model.Salary = dataReader.GetDecimal(5);
                        model.StartDate = dataReader.GetDateTime(6);
                        model.Notes = dataReader.GetString(7);
                        employees.Add(model);
                    }
                }
                connection.Close();
                return employees;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
