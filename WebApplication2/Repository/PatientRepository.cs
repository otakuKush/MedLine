using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class PatientRepository
    {
        #region Get All Patient 
        public List<PatientViewModel> GetAllPatient()
        {
            try
            {
                List<PatientViewModel> list = new List<PatientViewModel>();
                using (SqlConnection con = new SqlConnection(DBConnection.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllPatients", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    con.Open();
                    da.Fill(dt);
                    con.Close();

                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(new PatientViewModel
                        {
                            PatientID = Convert.ToInt32(dr["PatientID"]),
                            FirstName = Convert.ToString(dr["FirstName"]),
                            LastName = Convert.ToString(dr["LastName"]),
                            PhoneNumber = Convert.ToInt32(dr["PhoneNumber"]),
                            Address = Convert.ToString(dr["Address"]),
                            EmailID = Convert.ToString(dr["EmailID"]),
                            DateOfBirth = Convert.ToString(dr["D.O.B"]),
                            Age = Convert.ToInt32(dr["Age"]),
                            Gender = Convert.ToString(dr["Gender"]),
                            BloodGroup = Convert.ToString(dr["BloodGroup"]),
                            MartialStatus = Convert.ToString(dr["MartialStatus"]),
                            ArrivalDate = Convert.ToDateTime(dr["ArrivalDate"]),
                            DischargeDate = Convert.ToDateTime(dr["DischargeDate"])
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

        #region Inserting Patient Data
        public bool AddPatient(PatientViewModel model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBConnection.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_Insert_Upate_Patient", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@EmailID", model.EmailID);
                    cmd.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Age", model.Age);
                    cmd.Parameters.AddWithValue("@Gender", model.Gender);
                    cmd.Parameters.AddWithValue("@BloodGroup", model.BloodGroup);
                    cmd.Parameters.AddWithValue("@MartialStatus", model.MartialStatus);
                    cmd.Parameters.AddWithValue("@ArrivalDate", model.ArrivalDate);
                    cmd.Parameters.AddWithValue("@DischargeDate", model.DischargeDate);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();

                    if (i <= 1)
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

        #region Updating Patient Data
        public bool UpdatePatient(PatientViewModel model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBConnection.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_Insert_Upate_Patient", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PatientID", model.PatientID);
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@EmailID", model.EmailID);
                    cmd.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Age", model.Age);
                    cmd.Parameters.AddWithValue("@Gender", model.Gender);
                    cmd.Parameters.AddWithValue("@BloodGroup", model.BloodGroup);
                    cmd.Parameters.AddWithValue("@MartialStatus", model.MartialStatus);
                    cmd.Parameters.AddWithValue("@ArrivalDate", model.ArrivalDate);
                    cmd.Parameters.AddWithValue("@DischargeDate", model.DischargeDate);

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

        #region Deleting Patient Data
        public bool DeletePatient(int PatientID)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_Delete_Patient", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Patient", PatientID);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
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