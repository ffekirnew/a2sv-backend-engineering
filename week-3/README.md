# Implementing a Blog API using the Clean Architecture

## Table of Contents
- [Day 10](#day-10)
- [Day 11](#day-11)

## Reources and Tasks
### Day 10
1. Clean Architecture with ASP.NET Core 7 - .NET Conf 2022 | Brief Summary: Steve Smith talks about the Clean Architecture and his template for creating ASP.NET web applications with c#. It talks briefly about the clean architecture (how it is a domain-centric architecture, how dependence on infrastructural dependencies is minimized), and then describes his template which can be found on NuGet layer by layer.

2. 001 Introduction | Brief Summary: Trevor Williams, the creator of the course describes about what is going to be built, what the expected knowledge to be gained is, and what the course requirements are.

3. 001 Understanding Clean Architecture | Brief Summary: The course creator talks about the clean architecture. He starts by describing what he calls an all-in-one archtecture. He then talks about the Layered Architecture's pros and cons. He finally talks about the Onion Architecture (the Clean Architecture) and why it is important.

4. 002 What We Will Be Building.mp4 | Brief Summary: The course creator demos and shows the file structure of what is going to be built.

5. 004 IMPORTANT Class Library .NET Versions | Brief Summary: The code libraries were predominantly built with .NET Standard 2.1, but transitioning to .NET 5 or .NET 6 is also viable as long as version consistency is maintained across projects.

6. 003 Setting Up Solution.mp4 | Brief Summary: The creator sets up the Solution for the project, shows how to download Visual Studio Community Edition, creates a blank solution and adds to it folders Core, Api, Infrastructure to setup te Clean Architecture project

7. 005 Creating The Domain Project | Brief Summary: A new classlib project is added inside the Core project for the domain project. In this project a base entity and other entities that are used in the application are defined in C# classes.

8. 006 Creating the Application Project | Brief Summary: Another classlib project is added inside the Core folder for the application project. It references the Domain project. Then various DTOs and repository interfaces are created.

### Day 11
9. 007 Implementing AutoMapper | Brief Summary: AutoMapper is a package/library that help us convert objects of one data type to another. This comes in handy because we don't want end users of our api to know what our database entities (the ones in the domain layer) look like so we abstract it and show them data transer objects that contain data that needs to be transfered. That's where AutoMapper comes in to convert from DTOs to Entities and vice versa.

10. 008 Implementing MediatR and CQRS - Part 1 - Queries | Brief Summary: The Mediator pattern is one of the behavioral patterns found in the Gang of Four design patterns book. It deals with how different objects interact with each other. The CQRS (Command Query Request Segragation) patern on the other hand deals with separating the read and write requests from any data storage. MediatR is a package that allows us to implement these patterns.

11. 009 Implementing MediatR and CQRS - Part 2 - Queries | Brief Summary: The course creator talks about the changes he has made and how he used the different DTOs he made in the early stages of the course to write new Requests and Handlers to implement the CQRS pattern.

12. 010 Implementing MediatR and CQRS - Part 3 - Commands | Brief Summary: 
