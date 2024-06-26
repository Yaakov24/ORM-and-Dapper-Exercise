﻿using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using ORM_Dapper;
using System.Transactions;
//^^^^MUST HAVE USING DIRECTIVES^^^^
namespace ORM_Dapper {
    
    public class Program {

    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();
        string connString = config.GetConnectionString("DefaultConnection");
        IDbConnection conn = new MySqlConnection(connString);
        var repo = new DapperDepartmentRepository(conn);

        Console.WriteLine("Type a new Department name");
        var newDepartment = Console.ReadLine();
        repo.InsertDepartment(newDepartment);
        var departments = repo.GetAllDepartments();
        foreach (var department in departments)
        {
            Console.WriteLine(department.Name);
        }
    }
}
    }
