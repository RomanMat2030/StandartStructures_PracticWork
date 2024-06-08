

using System.Collections;

namespace _12_Standart_Interface
{


    class Director : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public object Clone()
        {
            Director director = this.MemberwiseClone() as Director;
            return director;
        }

        public override string ToString()
        {
            return $"Name : {FirstName}\nSurname : {LastName}\n";
        }
    }
    enum Genre
    {
        Drama, Action, Horror, Adventure
    }
    class Movie : ICloneable, IComparable<Movie>
    {
        public string Title { set; get; }
        public string Description { set; get; }
        public string Country { set; get; }
        public Genre Genre { set; get; }
        public Director Director { set; get; }
        public DateTime year { set; get; }
        public short rating { set; get; }

        public object Clone()
        {
            Movie copy = this.MemberwiseClone() as Movie;
            copy.Director = this.Director.Clone() as Director;
            return copy;
        }

        public int CompareTo(Movie? other)
        {
            return this.Title.CompareTo(other.Title);
        }

        public override string ToString()
        {
            return $"Title : {Title}\nDescription : {Description}\nCountry : {Country}\nYear : {year}\n";
        }
    }
    class Cinema : IEnumerable
    {
        //public string {get; set;}
        Movie[] movies;
        public Cinema()
        {
            this.movies = new Movie[]
            {
                new Movie
                {
                    Title = "Test",
                    Description = "The best film around the world",
                    Country = "Ukraine",
                    Genre = Genre.Action,
                    year = new DateTime(2047,02,24), Director= new Director() { FirstName = "Tom", LastName="Angelo"},
                     rating=5
                },
                 new Movie
                {
                    Title = "Test",
                    Description = "The best film around the world",
                    Country = "Ukraine",
                    Genre = Genre.Action,
                    year = new DateTime(2055,09,09), Director= new Director() { FirstName = "Tom", LastName="Angelo"},
                     rating=5
                },
                  new Movie
                {
                    Title = "Test",
                    Description = "The best film around the world",
                    Country = "Ukraine",
                    Genre = Genre.Action,
                    year = new DateTime(2033,03,14), Director= new Director() { FirstName = "Tom", LastName="Angelo"},
                     rating=5
                }

        };
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return movies.GetEnumerator();
        }

        public void Print()
        {
            foreach (Movie movie in movies)
            {
                Console.WriteLine(movie);
            }
        }
        public void Sort()
        {
            Array.Sort(movies);
        }
        public void Sort(IComparer<Movie> comparer)
        { Array.Sort(movies, comparer); }

    }

    class ComapareByRating : IComparer<Movie>
    {
        public int Compare(Movie? x, Movie? y)
        {
            return x.rating.CompareTo(y.rating);
        }
    }
    class ComapareByYear : IComparer<Movie>
    {
        public int Compare(Movie? x, Movie? y)
        {
            return x.year.CompareTo(y.year);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Cinema cinema = new Cinema();
            cinema.Print();
            Console.WriteLine("----------- Year sort -------");
            cinema.Sort(new ComapareByYear());

            foreach (var st in cinema)
            {
                Console.WriteLine(st);
            }
            //Movie original = new Movie
            //{
            //    Title = "Test",
            //    Description = "The best film around the world",
            //    Country = "Ukraine",
            //    Genre = Genre.Action,
            //    year = new DateTime(2022, 02, 24),
            //    Director = new Director() { FirstName = "Tom", LastName = "Angelo" },
            //    rating = 5
            //};
            //Console.WriteLine(original);
            //Movie copy = (Movie)original.Clone();
            //Console.WriteLine("-----------Copy------------");
            //Console.WriteLine(copy);
            //copy.Cinema
            //}
        }
    }
}