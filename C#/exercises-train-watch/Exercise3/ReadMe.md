# Exercise 3: Train Watch - Application Server (Back-End) Setup and Database Access via the About Page

> This is the **second** in a series of exercises where you will be building a website to manage information on trains. **Train Watch** is a community site for train lovers who want to keep up-to-date on trains across North America. They want to maintain a database of Engines and RailCars.
>
> **This set is cumulative**; future exercises in this series will build upon previous exercises.

## Overview

You are to create an additional project for the application. This project will be a class library. The library will contain Entity, DAL, and BLL classes. You will configure your web application to use the class library via dependency injection. You will  create a new page to test that the database configuration has been set up correctly.

Use the demos presented in class as a guide to implementing this exercise.
## Install Database

A new database called **TrainWatch** has been supplied to you for this exercise. This can be found at the root of this repository. It is a .dacpac file.

Use Microsoft SQL Management Studio to deploy the TrainWatch.dacpac file to the database.

## Application Library (Back-End) Set Up

In this task, you will be creating a project for the "back-end" of the application and ensuring your solution follows rudimentary Client-Server architecture.

Add a Class library that supports .Net Core or .Net Standard to your solution called TrainWatchSystem. Add 3 subfolders to this project: BLL, DAL, and Entities.

### Entity Framework

We will be using the **Microsoft.EntityFrameworkCore.SqlServer** NuGet package to connect to this database. Add this NuGet package to the class library project.

### Entities

In the "Entities" folder, create a file called `DbVersion.cs.` Add code to the class to appropriately model the database `DbVersion` table in the ***TrainWatch*** database. Include the annotations of [Table] and [Key]. You can use the following ERD to guide your coding, but you should always remember to confirm the model's structure with the actual tables in the database.

![ERD](./TrainWatch.png)

The system will add a default namespace to your entity class. Check it is the of follows:  `namespace TrainWatchSystem.Entities`. 

### DAL Context

In the "DAL" folder, create a file called `TrainWatchContext.cs` which will contain the `TrainWatchContext` class. Ensure it inherits from `DbContext`. Your class needs to include a constructor for DbContextOptions<> options injection. You will need to add appropriate namespaces to access your EntityFrameworkCore and Entities. Add a DbSet for your entity.

### BLL Services

In the "BLL" folder of your class library and add the class `TrainWatchServices`. This class must have an internal constructor that requires an instance of the `TrainWatchContext` as a parameter. Save the parameter value into a private readonly variable. 

In this class, create a public method called `GetDbVersion()` that has no parameters and returns an instance of the `DbVersion` entity. The related database table should only have one row, so you can return that first item from the database context. Your query will be `xxx.pppp.FirstOrDefault()` where xxx is your readonly variable and pppp the DbSet property.

As you code, you will need to resolve references to needed namespaces holding your context class and entity class.

Rebuild your Application Class Library. You should get a successful build

## Setup Web Application and Class Lbrary connections

You must configure the services coded in your class library for use in your webapp. This will involve creating your connection string, altering your `Program.cs` class and creating an extension method in your class library.

### Add reference in Web Application to Class Library

Add a project reference to your web application. This can be done by right clicking your Dependencies and select Add Project Reference. Select your class library project.

### Setup Connection String In `appsettings.json` 

Set up the database connection string in the `appsettings.json` file (web application), where xxxx is your sql server name.:

```csharp
"ConnectionStrings": {
    "TrainWatchLocalDB" : "Server=xxxx;Database=TrainWatch;Trusted_Connection=true;TrustServerCertificate=True;MultipleActiveResultSets=true",
    "TrainWatchRemoteVpnDmitDB" : "Server=DMIT-Capstone1.ad.sast.ca;Database=CPSC1517_1221_yourSection_yourNaitUserName;Trusted_Connection=true;TrustServerCertificate=True;MultipleActiveResultSets=true",
    "TrainWatchRemoteDmitDB" : "Server=CAPSTONE1.dmit.sast.ca;Database=CPSC1517_1221_yourSection_yourNaitUserName;Trusted_Connection=true;TrustServerCertificate=True;MultipleActiveResultSets=true",
  },
```
### Setup Extension method in the Application Library

The extension method will contain the dbcontext and transient services that will be available for dependency injection in your web application. This method will be called with the web application `Program.cs`. The extension method will add your DbContext option and a the services (methods) of your BLL class (see above).

Create a class called StartupExtension at the root of the application library. Change the class to be public static. 

Add the static method AddBackendDependencies. Check you class demo for appropriate parameters. Within the method register your DbContext and the Transient factory for your BLL class. 

## Create The `About` Page

Create an `About.cshtml`/`About.cshtml.cs` Razor Page to display the database version information. The Page Model class must declare in its constructor a dependency on the `TrainWatchServices` class. 

On this page, display the database version information from the DbVersion table of the database. Version will consist of Major.Minor.Build. Released will be the release date.

Example:   TrainWatch Verison 1.0.0  Released: 2021-10-10 12:15:45

Be sure to add a menu item so that this page can be navigated to using the main menu; use the text "About" for the link.

To ensure that your web application works, build and run your project.


## Research Notes and Credits

- [Rail Car Types](https://www.up.com/customers/track-record/tr181121_rail_car_types.htm)
- [Rail Car Types and What They Carry](https://youtu.be/ARr-LJCj2tg) **(video)**
  - Source of data for the `RailCarTypes` database table
- RR Picture Archives:
  - [Northern Alberta Railways Box Cars](http://www.rrpicturearchives.net/rsList.aspx?id=NAR&cid=2)
  - [Alberta Government Covered Hoppers](http://www.rrpicturearchives.net/rsList.aspx?id=ALNX&cid=4)
  - [Assorted Ore Cars](http://www.rrpicturearchives.net/rsList.aspx?cid=32)
  - [Canadian National Railways](http://www.rrpicturearchives.net/Railroad.aspx?id=CN) (and following links for Rolling Stock Roster)
- [Reporting Marks](https://en.wikipedia.org/wiki/List_of_reporting_marks:_C)
