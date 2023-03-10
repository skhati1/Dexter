![Build Status](https://github.com/skhati1/Dexter/actions/workflows/dotnet.yml/badge.svg)
# Dexter 

Dexter is a small Pokedex Application that shows users information about various pokemons. It can visualize various statistics regarding Pokemons as well as let users see individual Pokemon in detail. Users can even create their own Pokemon in the UI.

# About the App

- This is a ASP.NET Core MVC and Razor cshtml pages app that requires .NET 6.
- It uses multiple LINQ queries demonstrated in `Dexter/BusinessLogic/DexterGraphData.cs` to generate various data groupings along with Google Charts JS to display them in Razor
- EntityFrameworkCore as the ORM along with the EntityFramewokCore.SQLite nuget package to maintain DB Persistence
- Dexter.Test project contains Unit Tests for the business logic in Dexter.BusinessLogic
- Validation Code for view model implemented using `FluentValidation.AspNetCore` NuGet package as demonstrated in `Dexter/Validators` 

# How to Run

1. Clone repository using `git` or Download Zip from Github
2. Open the `Dexter.sln` solution file in Visual Studio (Visual Studio 2022 Community Edition is recommended for personal use)
3. Build and Run using Visual Studio 2022

Alternatively, if using a Mac or Linux system, you can:
1. Clone repository using `git`
2. In the repo directory, run `dotnet restore` to restore nuget packages
3. Navigate to the `Dexter/` directory and run the `dotnet run` command

Dexter will now be up and running at `localhost:7106` by default

## Pages

#### Home Page 
![Home](https://github.com/skhati1/Dexter/blob/main/Dexter/Docs/home.png)

#### Stats Page
![Stats1](https://github.com/skhati1/Dexter/blob/main/Dexter/Docs/stats1.png)
![Stats2](https://github.com/skhati1/Dexter/blob/main/Dexter/Docs/stats2.png)
![Stats3](https://github.com/skhati1/Dexter/blob/main/Dexter/Docs/stats3.png)

#### Random Page
![Random](https://github.com/skhati1/Dexter/blob/main/Dexter/Docs/random.png)

#### Pokedex Page
![Pokedex](https://github.com/skhati1/Dexter/blob/main/Dexter/Docs/pokedex.png)

### Create Page
![Pokemon](https://github.com/skhati1/Dexter/blob/main/Dexter/Docs/create.png)
