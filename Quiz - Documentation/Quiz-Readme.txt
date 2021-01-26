RUN THE APPLICATION FOR THE FIRST TIME

>> Add own postgres database id and password to the conection string to in the appsettings.json file:
"AppConnection": "User ID=USERID;Password=PASSWORD;Host=localhost;Port=5432;Database=quizzing;"

When the application detects that the database does not exist,
it runs the migrations and create the database that will be built with the respective tables and sample data.
There will be 3 quizes as an example with their own questions and answers.

>>--------------------------

HOW TO ACCESS TO THE APPLICATION

An admin user assigned to the admin role will be created the first time the application runs
and has to be used to access the application as an administrator:

>> Go to Login and use the following credentials.
Email: admin@mailinator.com
Pasword: Abcd123456@

A Read-only role (ro) will also be generated at the start of the application.
When registering a new user, this will be assigned a Read-only role automatically;
if this user needs to be assigned to another role, an admin user with an admin role can
assign a new role in the users and roles managment side of the application.

>> Go to Management > Roles > Create new role (if a new role needs to be created).
>> Go to Management > Users > Edit user > Manage Roles > select the new user and assign a new role to it.

>>--------------------------

DIFFERENT USER Roles

Users with admin role will be able to access to the whole application.
Users with readonly role will be able to login, access to the index page,
the list of quizzes and the Details page where they can see the questions and answers for a quiz.
Users unregistered or unlogged can access to the login, resgister and Index page.
They can also access to the List of quizzes; when accessing to the Details page
they can see the questions for a quizz but not the answers.
