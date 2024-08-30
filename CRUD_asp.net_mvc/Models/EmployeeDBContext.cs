using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CRUD_asp.net_mvc.Models
{
    public class EmployeeDBContext
    {
                                                                        //get connection string
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public List<Employee>GetEmployees()                             //method for returning all employee from emoloyee_tbl of Employee_db
        {
            List<Employee> EmployeeList = new List<Employee>();         //saving employees in a list
            SqlConnection con=new SqlConnection(cs);                    //maintaining connection with dbase
            SqlCommand cmd = new SqlCommand("spGetEmployees", con);     //exexute query
            cmd.CommandType=CommandType.StoredProcedure;                //telling it is a stored procedure
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Employee emp=new Employee();                            //single data
                emp.id = Convert.ToInt32(dr.GetValue(0).ToString());    //int to string format
                emp.name=dr.GetValue(1).ToString();
                emp.gender=dr.GetValue(2).ToString();
                emp.age = Convert.ToInt32(dr.GetValue(3).ToString());
                emp.salary = Convert.ToInt32(dr.GetValue(4).ToString());
                emp.city=dr.GetValue(5).ToString();

                EmployeeList.Add(emp);                                  //adding each employee in a list
            }
            con.Close();
            return EmployeeList;
        }
        //method for inserting new employee in emoloyee_tbl of Employee_db
        public bool AddEmployee(Employee emp)
        {
            SqlConnection con=new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spAddEmployees",con);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name",emp.name);
            cmd.Parameters.AddWithValue("@gender",emp.gender);
            cmd.Parameters.AddWithValue("@age",emp.age);
            cmd.Parameters.AddWithValue("@salary",emp.salary);
            cmd.Parameters.AddWithValue("@city",emp.city);
            con.Open();
            int i=cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else {
                return false;
            }
        }
        //method for updating/renaming an employee in emoloyee_tbl of Employee_db
        public bool UpdateEmployee(Employee emp) {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spUpdateEmployees",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",emp.id);
            cmd.Parameters.AddWithValue("@name",emp.name);
            cmd.Parameters.AddWithValue("@gender",emp.gender);
            cmd.Parameters.AddWithValue("@age",emp.age);
            cmd.Parameters.AddWithValue("@salary",emp.salary);
            cmd.Parameters.AddWithValue("@city",emp.city);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete of employee details
        public bool DeleteEmployee(int id)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spDeleteEmployees",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}