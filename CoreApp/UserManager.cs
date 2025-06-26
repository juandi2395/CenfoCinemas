
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
        private bool isOver18(User user) 
        { 

            var currentDate = DateTime.Now;
            int age = currentDate.Year - user.BirthDate.Year;

            if(user.BirthDate > currentDate.AddYears(-age)) 
            {
                age--;
            }
            return age >= 18;
        }

        public List<User> RetrieveAll()
        {
            var uCrud = new UserCrudFactory();

            try
            { 
                if(uCrud.RetrieveAll<User>().Count > 0)
                {
                    return uCrud.RetrieveAll<User>();
                }
                else
                {
                    throw new Exception("No users found.");
                }
            }
            catch (Exception ex)
            { 
                ManageException(ex);
            }
            return null;
        }

        public void Delete(int id)
        {
            var uCrud = new UserCrudFactory();
            try
            {
                var user = uCrud.RetrieveById<User>(id);
                if (user != null)
                {
                    uCrud.Delete(id);
                }
                else
                {
                    throw new Exception("User not found.");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public User RetrieveByUserCode(string userCode)
        {
            var uCrud = new UserCrudFactory();
            try
            {
                var user = uCrud.RetrieveByUserCode<User>(userCode);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new Exception("User not found.");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
            return null;
        }

        public User RetrieveByEmail(string email)
        {
            var uCrud = new UserCrudFactory();
            try
            {
                var user = uCrud.RetrieveByEmail<User>(email);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new Exception("User not found.");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
            return null;
        }
        public User RetrieveById(int id)
        {
            var uCrud = new UserCrudFactory();
            try
            {
                var user = uCrud.RetrieveById<User>(id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new Exception("User not found.");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
            return null;
        }

        public void Update(User user)
        {
            var uCrud = new UserCrudFactory();
            try
            {
                if (uCrud.RetrieveById<User>(user.ID) != null)
                {
                    uCrud.Update(user);
                }
                else
                {
                    throw new Exception("User not found.");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        }


}
