using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;

namespace Gemeenschap
{
    public class Videomanager
    {
        public ObservableCollection<Film> GetFilms()
        {
            ObservableCollection<Film> films = new ObservableCollection<Film>();
            var manager = new VideoDbManager();
            using(var conVideoAdo = manager.GetConnection())
            {
                using(var comRead = conVideoAdo.CreateCommand())
                {
                    comRead.CommandType = CommandType.Text;
                    comRead.CommandText = "SELECT * from Films";

                    conVideoAdo.Open();

                    using(var rdrFilms = comRead.ExecuteReader())
                    {
                        Int32 vidBandNrPos = rdrFilms.GetOrdinal("BandNr");
                        Int32 vidTitelPos = rdrFilms.GetOrdinal("Titel");
                        Int32 vidGenrePos = rdrFilms.GetOrdinal("GenreNr");
                        Int32 vidInPos = rdrFilms.GetOrdinal("InVoorraad");
                        Int32 vidUitPos = rdrFilms.GetOrdinal("UitVoorraad");
                        Int32 vidPrijsPos = rdrFilms.GetOrdinal("Prijs");
                        Int32 vidTotverhPos = rdrFilms.GetOrdinal("TotaalVerhuurd");

                        while (rdrFilms.Read())
                        {
                            films.Add(new Film(rdrFilms.GetInt32(vidBandNrPos), rdrFilms.GetString(vidTitelPos),
                                rdrFilms.GetInt32(vidGenrePos), rdrFilms.GetInt32(vidInPos), rdrFilms.GetInt32(vidUitPos),
                                rdrFilms.GetDecimal(vidPrijsPos), rdrFilms.GetInt32(vidTotverhPos)));
                        }
                    }
                }
            }
            return films;
        }
        public  List<Genre> GetGenre()
        {
            List<Genre> genres = new List<Genre>();
            var manager = new VideoDbManager();
            using (var conGenres = manager.GetConnection())
            {
                using (var comGenresZoeken = conGenres.CreateCommand())
                {
                    comGenresZoeken.CommandType = CommandType.Text;
                    comGenresZoeken.CommandText = "select GenreNr,Genre from Genres order by Genre";
                    conGenres.Open();
                    using (var rdrGenres = comGenresZoeken.ExecuteReader())
                    {
                        Int32 genreNumPos = rdrGenres.GetOrdinal("GenreNr");
                        Int32 genreNaamPos = rdrGenres.GetOrdinal("Genre");
                        while (rdrGenres.Read())
                        {
                            genres.Add(new Genre(rdrGenres.GetInt32(genreNumPos), rdrGenres.GetString(genreNaamPos)));
                        }

                    }
                }
            }
            return genres;
        }
    }
}
