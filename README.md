# ProductivityCentral
Operator Productivity Application -- OperatorProductivity

#### Requirement # 1
The code contains certain functionality and logical errors (both in code and database) that you have to
fix to make the report display the same results as shown in the requirements. The data in the database
is from the month March 2017, you have to convert that to May 2021.
```
Update Conversation set StartDate = dateadd(month, DATEDIFF(month, StartDate,DATEFROMPARTS (2021, 5, day(StartDate))), StartDate),
EndDate = dateadd(month, DATEDIFF(month, EndDate,DATEFROMPARTS (2021,5, day(EndDate))), EndDate)

Update Messages Set MessageDate = dateadd(month, DATEDIFF(month, MessageDate,DATEFROMPARTS (2021, 5, day(MessageDate))), MessageDate)
```