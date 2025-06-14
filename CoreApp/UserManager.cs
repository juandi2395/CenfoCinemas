
using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class UserManager : BaseManager
    {
        public void Create(User user) 
        {
            try 
            {
                if (isOver18(user)) 
                { 
                    var uCrud = new UserCrudFactory();

                    // Consultamos en BD si existe un usario con ese codigo
                    var uExist = uCrud.RetrieveByUserCode<User>(user);

                    if (uExist == null) 
                    {
                        uExist = uCrud.RetrieveByEmail<User>(user);

                        if (uExist == null)
                        {
                            uCrud.Create(user);
                            // Envio de correo
                        }
                        else 
                        { 
                            throw new Exception("User with this email already exists.");
                        }
                    }
                    else 
                    {
                        throw new Exception("User with this code already exists.");
                    }
                   
                }
                else 
                {
                    throw new Exception("User must be at least 18 years old.");
                }
            }
            catch (Exception ex) 
            {
                ManageException (ex);
            }
        }
        private bool isOver18(User user) { 

            var currentDate = DateTime.Now;
            int age = currentDate.Year - user.BirthDate.Year;

            if(user.BirthDate > currentDate.AddYears(-age)) 
            {
                age--;
            }
            return age >= 18;
        }
    }


}
