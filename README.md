# Dexter

Dexter is a small Pokedex Application that shows users information about various pokemons. It can visualize various statistics regarding Pokemons as well as let users see individual Pokemon in detail.

# About the App

- This is a ASP.NET Core MVC and Razor cshtml pages app that requires .NET 6.
- It uses multiple LINQ queries demonstrated in `/BusinessLogic/DexterGraphData.cs' to generate various data groupings along with Google Charts JS to display them in Razor
- EntityFrameworkCore as the ORM along with the EntityFramewokCore.SQLite nuget package to maintain DB Persistence
- Dexter.Test project contains Unit Tests for the business logic in Dexter.BusinessLogic
- Validation Code also provided as part of the repo code

# How to Run

1. Clone repository using `git` or Download Zip from Github
2. Open the `Dexter.sln` solution file in Visual Studio (Visual Studio 2022 Community Edition is recommended for personal use)
3. Build and Run using Visual Studio 2022

Alternatively, if using a Mac or Linux system, you can:
1. Clone repository using `git`
2. In the repo directory, run `dotnet restore` to restore nuget packages
3. Finally, run the `dotnet run` command

Dexter will now be up and running at `localhost:7106` by default

## Pages

#### Home Page
![Home](./Docs/home.jpg)

#### Stats Page
![Stats1](./Docs/stats1.jpg)
![Stats2](./Docs/stats2.jpg)
![Stats3](./Docs/stats3.jpg)

#### Random Page
![Random](./Docs/random.jpg)

#### Pokedex Page
![Pokedex](./Docs/pokedex.jpg)

## TODO

Validation Test