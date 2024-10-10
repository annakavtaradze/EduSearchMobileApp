using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Drawing;
using System.ComponentModel;

namespace mobileApp
{
    internal class SQLProcedures
    {
        public static string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;
        public static SqlConnection conn = new SqlConnection(connstr);
        public static SqlCommand cmd;
        public static SqlDataAdapter dataAdapter;


        public static DataTable SelectEvent()
        {
            cmd = new SqlCommand("SelectEvent", conn);
            dataAdapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            return table;
        }

        public static void CreateEvent(int organizationid, DateTime date, Bitmap backgroundImage, int minAge, int maxAge, string location, string details, string tags, string name)
        {
            // there should be Insert instead of Create
            cmd = new SqlCommand("CreateEvent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[9];

            paramss[0] = new SqlParameter("@organizationid", SqlDbType.Int);
            paramss[0].Value = Convert.ToInt32(organizationid);

            paramss[1] = new SqlParameter("@date", SqlDbType.SmallDateTime);
            paramss[1].Value = date;

            paramss[2] = new SqlParameter("@location", SqlDbType.VarChar, (200));
            paramss[2].Value = location;

            paramss[3] = new SqlParameter("@details", SqlDbType.VarChar, (2500));
            paramss[3].Value = details;

            paramss[4] = new SqlParameter("@backgroundImage", SqlDbType.Image);
            paramss[4].Value = backgroundImage;

            paramss[5] = new SqlParameter("@minAge", SqlDbType.Int);
            paramss[5].Value = Convert.ToInt32(minAge);

            paramss[6] = new SqlParameter("@maxAge", SqlDbType.Int);
            paramss[6].Value = Convert.ToInt32(maxAge);

            paramss[7] = new SqlParameter("@tags", SqlDbType.VarChar, (500));
            paramss[7].Value = tags;

            paramss[8] = new SqlParameter("@name", SqlDbType.VarChar, (100));
            paramss[8].Value = name;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteEvent(int ID)
        {
            cmd = new SqlCommand("DeleteEvent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[1];

            paramss[0] = new SqlParameter("@eventid", SqlDbType.Int);
            paramss[0].Value = Convert.ToInt32(ID);

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateEvent(int organizationid, int eventid, DateTime date, Bitmap backgroundImage, int minAge, int maxAge, string location, string details, string tags, string name)
        {
            cmd = new SqlCommand("UpdateEvent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[10];


            paramss[0] = new SqlParameter("@organizationid", SqlDbType.Int);
            paramss[0].Value = Convert.ToInt32(organizationid);

            paramss[1] = new SqlParameter("@date", SqlDbType.SmallDateTime);
            paramss[1].Value = date;

            paramss[2] = new SqlParameter("@location", SqlDbType.VarChar, (200));
            paramss[2].Value = location;

            paramss[3] = new SqlParameter("@details", SqlDbType.VarChar, (2500));
            paramss[3].Value = details;

            paramss[4] = new SqlParameter("@backgroundImage", SqlDbType.Image);
            paramss[4].Value = backgroundImage;

            paramss[5] = new SqlParameter("@minAge", SqlDbType.Int);
            paramss[5].Value = Convert.ToInt32(minAge);

            paramss[6] = new SqlParameter("@maxAge", SqlDbType.Int);
            paramss[6].Value = Convert.ToInt32(maxAge);

            paramss[7] = new SqlParameter("@tags", SqlDbType.VarChar, (500));
            paramss[7].Value = tags;

            paramss[8] = new SqlParameter("@name", SqlDbType.VarChar, (100));
            paramss[8].Value = name;

            paramss[9] = new SqlParameter("@eventid", SqlDbType.Int);
            paramss[9].Value = Convert.ToInt32(eventid);

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }




        public static DataTable SelectAdmin()
        {
            cmd = new SqlCommand("SelectAdmin", conn);
            dataAdapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            return table;
        }

        public static void CreateAdmin(string username, string password)
        {
            // there should be Insert instead of Create
            cmd = new SqlCommand("CreateAdmin", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[2];

            paramss[0] = new SqlParameter("@username", SqlDbType.VarChar, (50));
            paramss[0].Value = username;

            paramss[1] = new SqlParameter("@password", SqlDbType.VarChar, (50));
            paramss[1].Value = password;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteAdmin(int ID)
        {
            cmd = new SqlCommand("DeleteAdmin", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[1];

            paramss[0] = new SqlParameter("@adminid", SqlDbType.Int);
            paramss[0].Value = Convert.ToInt32(ID);

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateAdmin(int adminid, string username, string password)
        {
            cmd = new SqlCommand("UpdateAdmin", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[5];

            paramss[0] = new SqlParameter("@username", SqlDbType.VarChar, (50));
            paramss[0].Value = username;

            paramss[1] = new SqlParameter("@password", SqlDbType.VarChar, (50));
            paramss[1].Value = password;

            paramss[3] = new SqlParameter("@adminid", SqlDbType.Int);
            paramss[3].Value = Convert.ToInt32(adminid);

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }




        public static DataTable SelectUser()
        {
            cmd = new SqlCommand("SelectUser", conn);
            dataAdapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            return table;
        }

        public static void CreateUser(int age, string name, string surname, string email, string password, string username, Bitmap picture)
        {
            // there should be Insert instead of Create
            cmd = new SqlCommand("CreateUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[7];

            paramss[0] = new SqlParameter("@name", SqlDbType.VarChar, (50));
            paramss[0].Value = name;

            paramss[1] = new SqlParameter("@surname", SqlDbType.VarChar, (50));
            paramss[1].Value = surname;

            paramss[2] = new SqlParameter("@email", SqlDbType.VarChar, (50));
            paramss[2].Value = email;

            paramss[3] = new SqlParameter("@picture", SqlDbType.Image);
            paramss[3].Value = picture;

            paramss[4] = new SqlParameter("@username", SqlDbType.VarChar, (50));
            paramss[4].Value = username;

            paramss[5] = new SqlParameter("@age", SqlDbType.Int);
            paramss[5].Value = Convert.ToInt32(age);

            paramss[6] = new SqlParameter("@password", SqlDbType.VarChar, (50));
            paramss[6].Value = password;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteUser(int ID)
        {
            cmd = new SqlCommand("DeleteUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[2];

            paramss[0] = new SqlParameter("@userid", SqlDbType.Int);
            paramss[0].Value = Convert.ToInt32(ID);

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateUser(int userid, int age, string name, string surname, string email, string password, string username, Bitmap picture)
        {
            cmd = new SqlCommand("UpdateUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[8];

            paramss[0] = new SqlParameter("@name", SqlDbType.VarChar, (50));
            paramss[0].Value = name;

            paramss[1] = new SqlParameter("@surname", SqlDbType.VarChar, (50));
            paramss[1].Value = surname;

            paramss[2] = new SqlParameter("@email", SqlDbType.VarChar, (50));
            paramss[2].Value = email;

            paramss[3] = new SqlParameter("@picture", SqlDbType.Image);
            paramss[3].Value = picture;

            paramss[4] = new SqlParameter("@username", SqlDbType.VarChar, (50));
            paramss[4].Value = username;

            paramss[5] = new SqlParameter("@age", SqlDbType.Int);
            paramss[5].Value = Convert.ToInt32(age);

            paramss[6] = new SqlParameter("@password", SqlDbType.VarChar, (50));
            paramss[6].Value = password;

            paramss[7] = new SqlParameter("@userid", SqlDbType.Int);
            paramss[7].Value = Convert.ToInt32(userid);

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }




        public static DataTable SelectOrganization()
        {
            cmd = new SqlCommand("SelectOrganization", conn);
            dataAdapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            return table;
        }

        public static void CreateOrganization(char registered, string adress, string description, Bitmap profilePicture, Bitmap backgroundPicture, string phoneNumber, string email, string password, string username, string name)
        {
            // there should be Insert instead of Create
            cmd = new SqlCommand("CreateOrganization", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[10];

            paramss[0] = new SqlParameter("@registered", SqlDbType.Bit);
            paramss[0].Value = registered;

            paramss[1] = new SqlParameter("@adress", SqlDbType.VarChar, (200));
            paramss[1].Value = adress;

            paramss[2] = new SqlParameter("@description", SqlDbType.VarChar, (2500));
            paramss[2].Value = description;

            paramss[3] = new SqlParameter("@profilePicture", SqlDbType.Image);
            paramss[3].Value = profilePicture;

            paramss[4] = new SqlParameter("@backgroundPicture", SqlDbType.Image);
            paramss[4].Value = backgroundPicture;

            paramss[5] = new SqlParameter("@phoneNumber", SqlDbType.VarChar, (50));
            paramss[5].Value = phoneNumber;

            paramss[6] = new SqlParameter("@email", SqlDbType.VarChar, (50));
            paramss[6].Value = email;

            paramss[7] = new SqlParameter("@name", SqlDbType.VarChar, (500));
            paramss[7].Value = name;

            paramss[8] = new SqlParameter("@username", SqlDbType.VarChar, (50));
            paramss[8].Value = username;

            paramss[9] = new SqlParameter("@password", SqlDbType.VarChar, (50));
            paramss[9].Value = password;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteOrganization(int ID)
        {
            cmd = new SqlCommand("DeleteOrganization", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[1];

            paramss[0] = new SqlParameter("@organizationid", SqlDbType.Int);
            paramss[0].Value = Convert.ToInt32(ID);

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateOrganization(int organizationid, char registered, string adress, string description, Bitmap profilePicture, Bitmap backgroundPicture, string phoneNumber, string email, string password, string username, string name)
        {
            cmd = new SqlCommand("CreateOrganization", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[11];

            paramss[0] = new SqlParameter("@registered", SqlDbType.Bit);
            paramss[0].Value = registered;

            paramss[1] = new SqlParameter("@adress", SqlDbType.VarChar, (200));
            paramss[1].Value = adress;

            paramss[2] = new SqlParameter("@description", SqlDbType.VarChar, (2500));
            paramss[2].Value = description;

            paramss[3] = new SqlParameter("@profilePicture", SqlDbType.Image);
            paramss[3].Value = profilePicture;

            paramss[4] = new SqlParameter("@backgroundPicture", SqlDbType.Image);
            paramss[4].Value = backgroundPicture;

            paramss[5] = new SqlParameter("@phoneNumber", SqlDbType.VarChar, (50));
            paramss[5].Value = phoneNumber;

            paramss[6] = new SqlParameter("@email", SqlDbType.VarChar, (50));
            paramss[6].Value = email;

            paramss[7] = new SqlParameter("@name", SqlDbType.VarChar, (500));
            paramss[7].Value = name;

            paramss[8] = new SqlParameter("@username", SqlDbType.VarChar, (50));
            paramss[8].Value = username;

            paramss[9] = new SqlParameter("@password", SqlDbType.VarChar, (50));
            paramss[9].Value = password;

            paramss[10] = new SqlParameter("organizationid", SqlDbType.Int);
            paramss[10].Value = Convert.ToInt32(organizationid);

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }




        public static DataTable SelectUserEvent()
        {
            cmd = new SqlCommand("SelectUserEvent", conn);
            dataAdapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            return table;
        }

        public static void CreateUserEvent(int eventid, int userid)
        {
            // there should be Insert instead of Create
            cmd = new SqlCommand("CreateUserEvent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[2];

            paramss[0] = new SqlParameter("@eventid", SqlDbType.Int);
            paramss[0].Value = eventid;

            paramss[1] = new SqlParameter("@userid", SqlDbType.Int);
            paramss[1].Value = userid;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteUserEvent(int eventid, int userid)
        {
            cmd = new SqlCommand("DeleteUserEvent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[2];

            paramss[0] = new SqlParameter("@eventid", SqlDbType.Int);
            paramss[0].Value = Convert.ToInt32(eventid);

            paramss[1] = new SqlParameter("@userid", SqlDbType.Int);
            paramss[1].Value = Convert.ToInt32(userid);

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
