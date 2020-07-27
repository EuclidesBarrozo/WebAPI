using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebAPI.Models;

namespace WebAPI.Repositorio
{
    public class UsersRepositorio
    {
        private SqlConnection _con;
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["stringConnection"].ToString();
            _con = new SqlConnection(constr);
        }

        //Insert User
        public bool InsertUser(Users u)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("InsertUser", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@uName", u.uName);
                command.Parameters.AddWithValue("@uCPF", u.uCPF);
                command.Parameters.AddWithValue("@uRG", u.uRG);
                command.Parameters.AddWithValue("@uBirthday", u.uBirthday);
                command.Parameters.AddWithValue("@uMotherName", u.uMotherName);
                command.Parameters.AddWithValue("@uFatherName", u.uFatherName);
                command.Parameters.AddWithValue("@uCheckinDate", u.uCheckinDate);

                _con.Open();

                i = command.ExecuteNonQuery();


            }

            _con.Close();

            return i >= 1;
        }

        //SearchUser
        public List<Users> SearchUser(string name)
        {
            Connection();
            List<Users> UserList = new List<Users>();

            using (SqlCommand command = new SqlCommand("SearchUser", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.AddWithValue("@uName", u.uName);
                command.Parameters.AddWithValue("@uName", name);

                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Users u = new Users()
                    {
                        userId = Convert.ToInt32(reader["userId"]),
                        uName = Convert.ToString(reader["uName"]),
                        uCPF = Convert.ToString(reader["uCPF"]),
                        uRG = Convert.ToString(reader["uRG"]),
                        uBirthday = Convert.ToDateTime(reader["uBirthday"]),
                        uMotherName = Convert.ToString(reader["uMotherName"]),
                        uFatherName = Convert.ToString(reader["uFatherName"]),
                        uCheckinDate = Convert.ToDateTime(reader["uCheckinDate"])

                    };

                    UserList.Add(u);

                }

                _con.Close();

                return UserList;
            }
        }

        //DeleteUser
        public bool DeleteUser(string CPF, string RG)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("DeleteUser", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@uCPF", CPF);
                command.Parameters.AddWithValue("@uRG", RG);

                _con.Open();

                i = command.ExecuteNonQuery();


            }

            _con.Close();

            if (i >= 1)
            {
                return true;
            }

            return false;
        }
    }
}