
using MVC5_and_ADO.NET.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace MVC5_and_ADO.NET.Repository
{
    public class EmployeeRepository
    {
        private SqlConnection con;

        private void Connection()
        {
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-I3T5H70;Initial Catalog=ADO.NET;Integrated Security=SSPI");
              
            }
            catch(Exception ex)
            {
                
            }
        }
        public List<Employee> GetAllEmployees()
        {
            Connection();
            List<Employee> EmployeeList = new List<Employee>();
            SqlCommand cmd = new SqlCommand("dbo.GetEmployee", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach(DataRow row in dt.Rows)
            {
            
            
                EmployeeList.Add(new Employee
                {
                    EmployerID = Convert.ToInt32(row["ID"]),
                    Name = Convert.ToString(row["Name"]),
                    City = Convert.ToString(row["City"]),
                    Address = Convert.ToString(row["Address"]),

                });

                

            }
            return EmployeeList;


        }
        public bool AddEmployee(Employee employee)
        {
            Connection();
            SqlCommand sqlCommand = new SqlCommand("dbo.AddNewEmployeeDetail", con);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
            sqlCommand.Parameters.AddWithValue("@Address", employee.Address);
            sqlCommand.Parameters.AddWithValue("@City", employee.City);

            con.Open();
            int i = sqlCommand.ExecuteNonQuery();
            con.Close();
            if (i > 1)
                return true;
            else
                return false;

        }

        public bool UpdateEmployee(Employee emp)
        {
            Connection();
            SqlCommand sqlCommand = new SqlCommand("dbo.UpdateEmployeeDetails", con);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@EmpId", emp.EmployerID);
            sqlCommand.Parameters.AddWithValue("@Name", emp.Name);
            sqlCommand.Parameters.AddWithValue("@City", emp.City);
            sqlCommand.Parameters.AddWithValue("@Address", emp.Address);
            con.Open();
            int i = sqlCommand.ExecuteNonQuery();
            con.Close();
            if (i > 1)
                return true;
            else
                return false;
        }

        public bool DeleteEmployee(int id)
        {
            Connection();
            SqlCommand sqlCommand = new SqlCommand("dbo.DeleteEmployee", con);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ID", id);
            con.Open();
            int i = sqlCommand.ExecuteNonQuery();
            con.Close();
            if (i > 1)
                return true;
            else
                return false;
        }



    }
}