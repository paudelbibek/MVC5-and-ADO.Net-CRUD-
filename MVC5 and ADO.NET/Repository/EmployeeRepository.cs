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
        public List<Employer> GetAllEmployees()
        {
            Connection();
            List<Employer> EmployeeList = new List<Employer>();
            SqlCommand cmd = new SqlCommand("dbo.GetEmployee", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach(DataRow row in dt.Rows)
            {
            
            
                EmployeeList.Add(new Employer
                {
                    EmployerID = Convert.ToInt32(row["ID"]),
                    Name = Convert.ToString(row["Name"]),
                    City = Convert.ToString(row["City"]),
                    Address = Convert.ToString(row["Address"]),

                });

                

            }
            return EmployeeList;


        }

    }
}