# CRUD-SQL
This repository is to test a CRUD using SQL server in an API of .NET C#.


## STEPS

### 1
First of all, i've created a Person Model with the following attributes:
- ID;
- Name;
- Birthday;
- Marital Status;
- E-mail;
- Phone Number; 
- Address.

### 2 
As a second step, MyContext was created to create the Pessoas DB. 

### 3
For the third step, the Pessoas Controller was created to include the HTTP Get, GetName, GetById, Post, Put and Delete.

### 4 
This step was used to create de database using SQL-Server using add-migration and update-database;

### 5
To become more easier to give maintenance, i moved the connection string to appsettings.json.

### 6 
Finally, the CRUD for Person was created.
