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
    }
}
