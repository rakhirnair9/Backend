using APIApplication.DAL;
using APIApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace APIApplication.BAL
{
    public class StarWarService
    {
        public static string GetLongestOpeningCrawlMovie()
        {
            DataTable dt = new DataTable();
            string MovieName = "";
            try
            {
                dt = DBContext.GetLongestOpeningCrawlMovie();
                if(null != dt && dt.Rows.Count > 0)
                {
                    MovieName = Convert.ToString(dt.Rows[0]["title"]);
                }
                return MovieName;
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }           

        }
        
        public static List<films_characters> GetMostCharacterInFilms()
        {
            DataTable dt = new DataTable();
            List<films_characters> characterlist = new List<films_characters>();
            try
            {
                dt = DBContext.GetMostCharacterInFilms();
                int nMaxValue = 0;
                if (null != dt && dt.Rows.Count > 0)
                {
                    for(int nIndex = 0; nIndex < dt.Rows.Count; nIndex ++)
                    {
                        films_characters p = new films_characters();
                        int people_count = Convert.ToInt32(dt.Rows[nIndex]["people_count"]);
                        if (nIndex == 0)
                        {
                            nMaxValue = people_count;
                        }
                        if (nMaxValue != people_count)
                        {
                            break;
                        }
                        p.person_name = Convert.ToString(dt.Rows[nIndex]["people_name"]);
                        characterlist.Add(p);
                    }
                }
                return characterlist;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }         

        }


        public static List<films_species> GetMostSpeciesInFilms()
        {
            DataTable dt = new DataTable();
            List<films_species> characterlist = new List<films_species>();
            try
            {
                dt = DBContext.GetMostSpeciesInFilms();
                int nMaxValue = 0;
                if (null != dt && dt.Rows.Count > 0)
                {
                    for (int nIndex = 0; nIndex < dt.Rows.Count; nIndex++)
                    {
                        films_species p = new films_species();
                        int filmcount = Convert.ToInt32(dt.Rows[nIndex]["countoffilm"]);
                        if (nIndex == 0)
                        {
                            nMaxValue = filmcount;
                        }
                        if (nMaxValue != filmcount)
                        {
                            break;
                        }
                        p.species_name = Convert.ToString(dt.Rows[nIndex]["species"]);
                        p.character_count = Convert.ToInt32(dt.Rows[nIndex]["people_count"]);
                        characterlist.Add(p);
                    }
                }
                return characterlist;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }
    }
}