using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class MovieManager : BaseManager
    {
        public void Create(Movie movie)
        {
            try
            {
                var mCrud = new MovieCrudFactory();

                // Consultamos en BD si existe una pelicula con ese titulo
                var mExist = mCrud.RetrieveMovieByTitle<Movie>(movie);

                if (mExist == null)
                {
                    mCrud.Create(movie);
                    // Envio de correo a usuarios, nuevo titulo
                }
                else
                {
                    throw new Exception("Movie with this title already exists.");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public List<Movie> RetrieveAll()
        {
            var mCrud = new MovieCrudFactory();

            try
            {
                if (mCrud.RetrieveAll<Movie>().Count > 0)
                {
                    return mCrud.RetrieveAll<Movie>();
                }
                else
                {
                    throw new Exception("No movies found.");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
            return null;
        }

        public void Delete(Movie movie)
        {
            var mCrud = new MovieCrudFactory();
            try
            {
                var movieTemp = mCrud.RetrieveById<Movie>(movie.ID);
                if (movieTemp != null)
                {
                    mCrud.Delete(movie);
                }
                else
                {
                    throw new Exception("Movie not found.");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }
        public Movie RetrieveById(int id)
        {
            var mCrud = new MovieCrudFactory();
            try
            {
                var movie = mCrud.RetrieveById<Movie>(id);
                if (movie != null)
                {
                    return movie;
                }
                else
                {
                    throw new Exception("Movie not found.");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
            return null;
        }

        public void Update(Movie movie)
        {
            var mCrud = new MovieCrudFactory();
            try
            {
                if (mCrud.RetrieveById<Movie>(movie.ID) != null)
                {
                    mCrud.Update(movie);
                }
                else
                {
                    throw new Exception("Movie not found.");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

            

    }


}
