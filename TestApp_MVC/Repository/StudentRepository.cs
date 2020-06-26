using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestApp_MVC.Models;
using TestApp_MVC.SiteUtility;

namespace TestApp_MVC.Repository.EmployeeRepository
{
    public class StudentRepository
    {

        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
        // SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);

        public int saveData(StudentData studentModel)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("usp_Insert_Student", connection);
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", studentModel.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", studentModel.LastName);
                    cmd.Parameters.AddWithValue("@EmailAddress", studentModel.Email);
                    cmd.Parameters.AddWithValue("@PocketMoney", studentModel.PckMoney);
                    cmd.Parameters.AddWithValue("@password", HashPassword.Encrypt(studentModel.Password));
                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result; 
        }

        public List<StudentData> StudentList()
        {
            // Get Data Here
            List<StudentData> lstStudent = new List<StudentData>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select top(1) * from (select  dense_Rank() OVER  (order by pocket_money desc  )as RankDetail,* from  student where  is_deleted=0  ) as studentFilteredData where  RankDetail=2", connectionString);
                DataSet ds = new DataSet();
                da.Fill(ds, "student");
                if (ds.Tables["student"].Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = ds.Tables[0].DefaultView;

                    foreach (DataRowView drow in dv)
                    {
                        StudentData studentData = new StudentData();

                        studentData.ID = Convert.ToInt32(drow["id"]);
                        studentData.FirstName = Convert.ToString(drow["first_name"]);
                        studentData.LastName = Convert.ToString(drow["last_name"]);
                        studentData.Email = Convert.ToString(drow["email"]);
                        studentData.PckMoney = Convert.ToString(drow["pocket_money"]);

                        lstStudent.Add(studentData);
                    }

                    return lstStudent;
                }
            }
            return lstStudent;
        }
    }
}