# 
# Productivity Central
**Operator Productivity Application -- OperatorProductivity** is small project to create dashboard for the operator productivity using ASP.NET MVC and SQL Server   


### Requirement # 1
The code contains certain functionality and logical errors (both in code and database) that you have to
fix to make the report display the same results as shown in the requirements. The data in the database
is from the month March 2017, you have to convert that to May 2021.
```
Update Conversation set StartDate = dateadd(month, DATEDIFF(month, StartDate,DATEFROMPARTS (2021, 5, day(StartDate))), StartDate),
EndDate = dateadd(month, DATEDIFF(month, EndDate,DATEFROMPARTS (2021,5, day(EndDate))), EndDate)

Update Messages Set MessageDate = dateadd(month, DATEDIFF(month, MessageDate,DATEFROMPARTS (2021, 5, day(MessageDate))), MessageDate)
```


## Getting Started

You will need Visual Studio 2017 or newer to compile the Solution. Visual Studio 2019 is recommended. 
Prior versions of Visual Studio should work, but we'd recomments 2019 where possible
The [free VS 2019 Community Edition](https://visualstudio.microsoft.com/downloads/) should work fine. 
All projects target .NET Framework 4.7, with some projects.

### Opening the project
Clone the below repository on your local system and then ProductivityCentral.sln file.

https://github.com/niranjankala/ProductivityCentral

Open Solution Explorer and right click on the ProductivityCentral.Web project to set it as a startup project

### Setup the database
Open the dbscript.sql in SSMS from the deploy directory in the solution location. It will automatically create the database and the user 'chat'.


*Now switch to the Visal studio and press F5 ito run the project or click the run button in the ribbon menu.*


Demo URL - https://operatorproductivity.azurewebsites.net