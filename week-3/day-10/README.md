# Day 10

## Resources
1. [Clean Architecture with ASP.NET Core 7 | .NET Conf 2022](https://www.youtube.com/watch?v=j6u7Pw6dyUw) | Brief Summary: Steve Smith talks about the Clean Architecture and his template for creating ASP.NET web applications with c#. It talks briefly about the clean architecture (how it is a domain-centric architecture, how dependence on infrastructural dependencies is minimized), and then describes his template which can be found on NuGet layer by layer.

2. [001 Introduction.mp4](https://drive.google.com/file/d/10SP5xneVESe43IcNxWcorKPqFqxKViXO/view?usp=sharing) | Brief Summary: Trevor Williams, the creator of the course describes about what is going to be built, what the expected knowledge to be gained is, and what the course requirements are.

3. [001 Understanding Clean Architecture.mp4](https://drive.google.com/file/d/1K_0ugcIBgEcHcxlTH-GHGFccLqvxemGs/view?usp=sharing) | Brief Summary: The course creator talks about the clean architecture. He starts by describing what he calls an all-in-one archtecture. He then talks about the Layered Architecture's pros and cons. He finally talks about the Onion Architecture (the Clean Architecture) and why it is important.

4. [002 What We Will Be Building.mp4](https://drive.google.com/file/d/1SNS1QlvFLAMNgptXSs4HYtD5hD5UzyXN/view?usp=sharing) | Brief Summary: The course creator demos and shows the file structure of what is going to be built.

5. [004 IMPORTANT Class Library .NET Versions.html](https://drive.google.com/file/d/1F5NbSTAc75RU-XmnJ1X8f3OQG3GItZUS/view?usp=sharing) | Brief Summary: The code libraries were predominantly built with .NET Standard 2.1, but transitioning to .NET 5 or .NET 6 is also viable as long as version consistency is maintained across projects.

6. [003 Setting Up Solution.mp4](https://drive.google.com/file/d/1FrOVM1AQw8YuDuRrQrD13ctWmDAo-k8L/view?usp=sharing) | Brief Summary: The creator sets up the Solution for the project, shows how to download Visual Studio Community Edition, creates a blank solution and adds to it folders Core, Api, Infrastructure to setup te Clean Architecture project

7. [005 Creating The Domain Project.mp4](https://drive.google.com/file/d/19ufDUz7nESVfu-2LdFYnvgO044wesfvG/view?usp=sharing) | Brief Summary: A new classlib project is added inside the Core project for the domain project. In this project a base entity and other entities that are used in the application are defined in C# classes.

8. [006 Creating the Application Project.mp4](https://drive.google.com/file/d/1LI1IbP7g1F2XdEP4zww7A8xtRjoxvg5m/view?usp=sharing)
 Brief Summary: Another classlib project is added inside the Core folder for the application project. It references the Domain project. Then various DTOs and repository interfaces are created.
