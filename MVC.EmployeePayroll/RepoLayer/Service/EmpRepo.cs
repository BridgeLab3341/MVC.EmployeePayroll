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
                        model.EmployeeId = dataReader.GetInt32(0);
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
        public EmployeeModel Update(EmployeeModel employee)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand sqlCommand = new SqlCommand("SPUpdateEmployeeDeatils", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
                sqlCommand.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
                sqlCommand.Parameters.AddWithValue("@Department", employee.Department);
                sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
                sqlCommand.Parameters.AddWithValue("@StartDate", employee.StartDate);
                sqlCommand.Parameters.AddWithValue("@Notes", employee.Notes);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public EmployeeModel GetEmployeeData(int? employeeid)
        //{
        //    try
        //    {
        //        string query= "SELECT * FROM EmployeeManagement WHERE EmployeeID= " + employeeid;
        //        EmployeeModel employee = new EmployeeModel();
        //        SqlConnection connection = new SqlConnection(ConnectionString);
        //        SqlCommand sqlCommand = new SqlCommand(query, connection);
        //        connection.Open();
        //        SqlDataReader reader = sqlCommand.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            employee.EmployeeId = Convert.ToInt32(reader["EmployeeID"]);
        //            employee.Name = reader["Name"].ToString();
        //            employee.ProfileImage = reader["ProfileImage"].ToString();
        //            employee.Gender = reader["Gender"].ToString();
        //            employee.Department = reader["Department"].ToString();
        //            employee.Salary = Convert.ToDecimal(reader["Salary"].ToString());
        //            employee.StartDate = DateTime.Parse(reader["DateTime"].ToString());
        //            employee.Notes = reader["Notes"].ToString();
        //        }
        //        return employee;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public void DeleteEmployee(int? id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand sqlCommand = new SqlCommand("SPDeleteEmployee", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmployeeId", id);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
