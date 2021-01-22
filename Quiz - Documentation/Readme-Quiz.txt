ASP .NET Core 3.1
- Needs Visual Studio 2019 (v16.7)
- NuGet	Microsoft.VisualStudio.Web.CodeGeneration.Design v3.1.4 (TheBookLounge.Web)
	To create controlers and views.
- Dependency injection is built-in
- Has middleware components that together build up the request pipeline

MVC
- Is an arquitectural pattern - This project starts with an empty template
- Separation of concerns
- Promotes testability and maintainability
- Uses razor pages to integrate C# inside HTML

EF Core 3.1
- Open source OMR framework for ADO.Met
- Allows us to work directly with the database without writing SQL statements, in most cases.
- Allows us work with types that behind the sceens will be persistant in the database.
- Allows us to work with LINQ queries to work with data.
- Is a lightweight framework and works well with ASP.NET Core MVC web apps.
- it is cross-platform, so allows us to work with Linux, Windows and Mac.
- Supports relational and non-relational DB. (need to know which types of db supports).
- Supports Code-first approach and still you can create a model from database.
- NuGet	- Microsoft.EntityFrameworkCore.Design v3.1.4 (TheBookLounge.Web)

SQL Server - Postgres Database
-NuGet	- Microsoft.EntityFramework.SqlServer v3.1.4 (TheBookLounge.Web)
		- Microsoft.EntityFramework.Tools v3.1.4 (TheBookLounge.DataAccess)
		- Npgsql.EntityFrameworkCore.PostgreSQL v3.1.4 (TheBookLounge.DataAccess)

	

ASP .NET Identity API
- NuGet - Microsoft.AspNetCore.Identity.EntityFrameworkCore 3.1.9
		- Microsoft.AspNetCore.Identity.UI 3.1.9

TEST
- NuGet in Test project- XUnit 2.4.1
- Moq 4.15.2
- Microsoft.EntityFrameworkcore.InMemory 3.1.10
- Microsoft.AspNetCore.TestHost 3.1.10

FLUENT VALIDATION
- NuGet FluentValidation v 9.4.0
- NuGet FluentValidation.AspNetCore v 9.4.0

**Roles, Claims and Policies
4 roles:
- User
- BookKeeper
- Admin
- SuperUser
3 Policies
- ManageCheckInAndCheckOut
- ManageBookRecords
- ManageRolesAndUsers
3 Claims
- Manage Check In and Check Out
- Manage Book Records
- Manage Roles and Users
4 users
- user@mailinator.com: Role "User" - Owns a Policy with one claim - Manage check in and check out.
- bookkeeper@mailinator.com: Role "BookKeeper" - 2 Policies with one claim each - Manage check in and check out and Manage book records.
- admin@mailinator.com: Role "Admin" - Owns 2 Policies with 1 claim each - Manage check in and check out and Manage Roles and Users.
- superuser@mailinator.com: Role "SuperUser" - Owns 2 Policies with 1 claim each - Manage check in and check out, Manage Book Records and Manage Roles and Users.


