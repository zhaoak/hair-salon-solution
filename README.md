# _Claire's Salon_

#### By Allie Zhao

## Description

Simple C#/ASP.NET web application built for use with a MySQL (or otherwise 
compatible) database. Allows user to add, edit, and track a list of stylists 
and clients of those stylists to the database through a web frontend. Users may 
also add and remove stylists and clients from the system.

## Technologies Used

- C#/ASP.NET
- MySQL (or other compatible RMDBS)

## Setup/Installation Requirements

### Web application setup

- clone repository to location of your choice
- ensure .NET 6 SDK is installed and correctly configured
- ensure proper .NET dependencies are retrieved
    - this should happen automatically with `dotnet run`
- navigate to `HairSalon` directory
- in your terminal, enter `dotnet run`
- in your browser, open `http://localhost:5001`

### Database setup

- set up a MySQL (or otherwise client protocol compatible) database instance
- create a new database `[your_db_name]`, using a name of your choice
    - to do this, enter `CREATE DATABASE [your_db_name];` in your DB shell
    - you may also use a GUI database tool like MySQL Workbench
- import the included schema file `allie_zhao.sql` to your new database
    - in bash (not your database shell interface), the command for this is
    `mysql -u [your_database_login] -p [your_db_name] < allie_zhao.sql`
    - or import using a GUI database tool
- in the `HairSalon` directory, create the file `appsettings.json`, containing the following
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=[your_database_address];Port=3306;database=[your_db_name];uid=[your_db_login];pwd=[your_db_password];"
      }
    }
- substitute fields in brackets with your own database information
- also switch port if your database is not configured to use 3306

## License

MIT

Copyright (c) 2023 Allie Zhao
