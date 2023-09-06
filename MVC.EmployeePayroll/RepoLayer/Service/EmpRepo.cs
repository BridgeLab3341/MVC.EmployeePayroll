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
        public EmployeeModel GetEmployeeData(int? employeeId)
        {
            try
            {
                string query = "SELECT * FROM EmployeeManagement WHERE EmployeeID= " + employeeId;
                EmployeeModel employee = new EmployeeModel();
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    employee.EmployeeId = Convert.ToInt32(reader["EmployeeID"]);
                    employee.Name = reader["Name"].ToString();
                    employee.ProfileImage = reader["ProfileImage"].ToString();
                    employee.Gender = reader["Gender"].ToString();
                    employee.Department = reader["Department"].ToString();
                    employee.Salary = Convert.ToDecimal(reader["Salary"].ToString());
                    employee.StartDate = reader.GetDateTime(6);
                    employee.Notes = reader["Notes"].ToString();
                }
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteEmployee(int? employeeId)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand sqlCommand = new SqlCommand("SPDeleteEmployee", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public EmployeeModel LoginEmployee(EmployeeLoginModel loginModel)
        //{
        //    try
        //    {
        //        EmployeeModel employeeModel = new EmployeeModel();
        //        SqlConnection connection = new SqlConnection(ConnectionString);
        //        SqlCommand sqlCommand = new SqlCommand("SPEmployeeLogin", connection);
        //        sqlCommand.CommandType = CommandType.StoredProcedure;
        //        connection.Open();
        //        sqlCommand.Parameters.AddWithValue("@EmployeeId", loginModel.EmployeeId);
        //        sqlCommand.Parameters.AddWithValue("@Name", loginModel.EmployeeId);
        //        var returnparameter = sqlCommand.Parameters.Add("@Result", SqlDbType.Int);
        //        returnparameter.Direction = ParameterDirection.ReturnValue;
        //        using (SqlDataReader reader = sqlCommand.ExecuteReader())
        //        {
        //            var result = returnparameter.Value;
        //            if (reader.HasRows && reader.Read())
        //            {
        //                employeeModel = new EmployeeModel();
        //                employeeModel.EmployeeId =Convert.ToInt32(reader["EmployeeId"]);
        //                employeeModel.Name = reader["Name"].ToString();
        //                employeeModel.ProfileImage = reader["ProfileImage"].ToString();
        //                employeeModel.Gender = reader["Gender"].ToString();
        //                employeeModel.Department = reader["Department"].ToString();
        //                employeeModel.Salary = Convert.ToDecimal(reader["Salary"].ToString());
        //                employeeModel.StartDate = reader.GetDateTime(6);
        //                employeeModel.Notes = reader["Notes"].ToString();
        //            }
        //            else
        //            {
        //                return null;
        //            }
        //        }
        //        return employeeModel;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
