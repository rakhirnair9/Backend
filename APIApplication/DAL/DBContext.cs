using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIApplication.DAL
{
    public class DBContext
    {
        public const string connectionstring = @"data source=candidate-test.caqylurhpyhw.eu-west-1.rds.amazonaws.com;initial catalog=star-wars;user id=candidate;password=candidate;";
        public static DataTable GetLongestOpeningCrawlMovie()
        {
            DataTable dt = new DataTable();
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            SqlCommand sqlCmd = new SqlCommand();
            try
            { 
                myConnection.ConnectionString = connectionstring;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select top 1 LEN(opening_crawl), title from  [star-wars].[dbo].[films] order by LEN(opening_crawl) desc";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
                dt.Load(reader);
                myConnection.Close();
                return dt;
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                if(dt != null)
                {
                    dt.Dispose();
                    dt = null;
                }
                if (reader != null)
                {
                    reader.Dispose();
                    reader = null;
                }
                if (myConnection != null)
                {
                    myConnection.Close();
                    myConnection.Dispose();
                    myConnection = null;
                }
                if (sqlCmd != null)
                {
                    sqlCmd.Dispose();
                    sqlCmd = null;
                }
            }
            

        }

        public static DataTable GetMostCharacterInFilms()
        {
            DataTable dt = new DataTable();
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                myConnection.ConnectionString = connectionstring;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "SELECT (select name from [star-wars].[dbo].people where people_id = people.id) as people_name, COUNT(people_id) as people_count FROM [star-wars].[dbo].[films_characters] GROUP BY people_id ORDER BY COUNT(people_id) DESC";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
                dt.Load(reader);
                myConnection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                if (dt != null)
                {
                    dt.Dispose();
                    dt = null;
                }
                if (reader != null)
                {
                    reader.Dispose();
                    reader = null;
                }
                if (myConnection != null)
                {
                    myConnection.Close();
                    myConnection.Dispose();
                    myConnection = null;
                }
                if (sqlCmd != null)
                {
                    sqlCmd.Dispose();
                    sqlCmd = null;
                }
            }

         

        }

        public static DataTable GetMostSpeciesInFilms()
        {
            DataTable dt = new DataTable();
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                myConnection.ConnectionString = connectionstring;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "SELECT COUNT(film_id) as countoffilm,(select name from[star-wars].[dbo].[species] where id = species_id)  as species,(select count(*) from[star-wars].[dbo].[species_people]   where species_id = films_species.species_id) as people_count   FROM[star-wars].[dbo].[films_species]  GROUP BY species_id";
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
                dt.Load(reader);
                myConnection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                if (dt != null)
                {
                    dt.Dispose();
                    dt = null;
                }
                if (reader != null)
                {
                    reader.Dispose();
                    reader = null;
                }
                if (myConnection != null)
                {
                    myConnection.Close();
                    myConnection.Dispose();
                    myConnection = null;
                }
                if (sqlCmd != null)
                {
                    sqlCmd.Dispose();
                    sqlCmd = null;
                }
            }



        }
    }
}