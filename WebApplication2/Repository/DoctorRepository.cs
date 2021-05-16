using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication2.Models;


namespace WebApplication2.Repository
{
    public class DoctorRepository
    {
        #region Get all List of Doctors
        public List<DoctorViewModel> GetAllDoctorList()
        {
            try
            {
                List<DoctorViewModel> list = new List<DoctorViewModel>();
                using (SqlConnection con = new SqlConnection(DBConnection.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllDoctors", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    con.Open();
                    da.Fill(dt);
                    con.Close();

                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(new DoctorViewModel
                        {
                            DoctorID = Convert.ToInt32(dr["DoctorID"]),
                            FullName = Convert.ToString(dr["FullName"]),
                            FirstName = Convert.ToString(dr["FirstName"]),
                            LastName = Convert.ToString(dr["LastName"]),
                            EmailID = Convert.ToString(dr["EmailID"]),
                            PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                            Address = Convert.ToString(dr["Address"]),
                            DepartmentID = Convert.ToInt32(dr["DepartmentID"]),
                            Qualification = Convert.ToString(dr["Qualification"])
                        });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insert Doctors
        public bool SetDoctor(DoctorViewModel model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBConnection.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_Insert_Update_Doctor", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FullName", model.FullName);
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@EmailID", model.EmailID);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@DepartmentID", model.DepartmentID);
                    cmd.Parameters.AddWithValue("@Qualification", model.Qualification);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();

                    if (i >= 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Updating Doctors
        public bool UpdateDoctor(DoctorViewModel model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBConnection.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_Insert_Update_Doctor", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DoctorID", model.DoctorID);
                    cmd.Parameters.AddWithValue("@FullName", model.FullName);
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@DepartmentID", model.DepartmentID);
                    cmd.Parameters.AddWithValue("@EmailID", model.EmailID);
                
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();

                    if (i >= 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Deleting Doctors
        public bool DeleteDoctor(int DoctorID)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_Delete_Doctor", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DoctorID", DoctorID);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if(i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion
    }
}