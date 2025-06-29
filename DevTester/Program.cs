﻿using CoreApp;
using DataAccess.CRUD;
using DataAccess.DAO;
using DTOs;
using Newtonsoft.Json;
using System.Data.SqlTypes;

public class Program
{
    public static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("---- MAIN MENU ----");
            Console.WriteLine("1. User Menu");
            Console.WriteLine("2. Movie Menu");
            Console.WriteLine("3. Exit");
            Console.WriteLine("-------------------");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    UserMenu();
                    break;
                case "2":
                    MovieMenu();
                    break;
                case "3":
                    exit = true;
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void UserMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("---- USER MENU ----");
            Console.WriteLine("1. Insert User");
            Console.WriteLine("2. Show Users");
            Console.WriteLine("3. Show User By ID");
            Console.WriteLine("4. Delete User");
            Console.WriteLine("5. Back");
            Console.WriteLine("-------------------");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    InsertUser();
                    break;
                case "2":
                    PrintUsers();
                    break;
                case "3":
                    PrintUserByID();
                    break;
                case "4":
                    Console.WriteLine("Delete User logic here...");
                    Console.ReadKey();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void MovieMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("---- MOVIE MENU ----");
            Console.WriteLine("1. Insert Movie");
            Console.WriteLine("2. Show Movies");
            Console.WriteLine("3. Delete Movie");
            Console.WriteLine("4. Back");
            Console.WriteLine("---------------------");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    InsertMovie();
                    break;
                case "2":
                    PrintMovies();
                    break;
                case "3":
                    Console.WriteLine("Delete Movie logic here...");
                    Console.ReadKey();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void InsertUser()
    {
        Console.Clear();
        Console.WriteLine("---- INSERT USER ----");

        Console.Write("User Code: ");
        string userCode = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        Console.Write("Birthdate (YYYY-MM-DD): ");
        DateTime birthDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Status (e.g., AC): ");
        string status = Console.ReadLine();

        var sqlOperation = new SqlOperation
        {
            ProcedureName = "CRE_USER_PR"
        };
        sqlOperation.AddStringParameter("P_UserCode", userCode);
        sqlOperation.AddStringParameter("P_Name", name);
        sqlOperation.AddStringParameter("P_Email", email);
        sqlOperation.AddStringParameter("P_Password", password);
        sqlOperation.AddDateTimeParam("P_BirthDate", birthDate);
        sqlOperation.AddStringParameter("P_Status", status);

        var user = new User()
        {
            UserCode = userCode,
            Name = name,
            Email = email,
            Password = password,
            BirthDate = birthDate,
            Status = status
        };

        /*var uCrud = new UserCrudFactory();
        uCrud.Create(user);*/

        //SqlDAO.GetInstance().ExecuteProcedure(sqlOperation);

        var userManager = new UserManager();
        userManager.Create(user);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void InsertMovie()
    {
        Console.Clear();
        Console.WriteLine("---- INSERT MOVIE ----");

        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Genre: ");
        string genre = Console.ReadLine();

        Console.Write("Director: ");
        string director = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Release Date (YYYY-MM-DD): ");
        DateTime releaseDate = DateTime.Parse(Console.ReadLine());

        var sqlOperation = new SqlOperation
        {
            ProcedureName = "CRE_MOVIE_PR"
        };
        sqlOperation.AddStringParameter("P_Title", title);
        sqlOperation.AddStringParameter("P_Genre", genre);
        sqlOperation.AddStringParameter("P_Director", director);
        sqlOperation.AddStringParameter("P_Description", description);
        sqlOperation.AddDateTimeParam("P_ReleaseDate", releaseDate);

        var movie = new Movie()
        {
            Title = title,
            Genre = genre,
            Director = director,
            Description = description,
            ReleaseDate = releaseDate
        };

        //var mCrud = new MovieCrudFactory();
        //mCrud.Create(movie);

        //SqlDAO.GetInstance().ExecuteProcedure(sqlOperation);

        var movieManager = new MovieManager();
        movieManager.Create(movie);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void PrintUsers()
    {
        Console.Clear();
        var uCrud = new UserCrudFactory();
        var listUsers = uCrud.RetrieveAll<User>();
        foreach (var u in listUsers)
        {
            Console.WriteLine(JsonConvert.SerializeObject(u, Formatting.Indented));
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void PrintMovies()
    {
        Console.Clear();
        var mCrud = new MovieCrudFactory();
        var listMovies = mCrud.RetrieveAll<Movie>();
        foreach (var m in listMovies)
        {
            Console.WriteLine(JsonConvert.SerializeObject(m, Formatting.Indented));
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void PrintUserByID()
    {
        Console.Clear();
        Console.Write("Enter User ID: ");
        string id = Console.ReadLine();
        int userId = int.Parse(id);

        var uCrud = new UserCrudFactory();
        var user = uCrud.RetrieveById<User>(userId);
        if (user != null)
        {
            Console.WriteLine(JsonConvert.SerializeObject(user, Formatting.Indented));
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
