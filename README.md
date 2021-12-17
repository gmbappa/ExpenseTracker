# ExpenseTracker
## Description
Develop an Expense Tracker system that can record daily expenditure in
different categories. 

## Setup To Run Project
1. Need To Change DB Server Name at appsettings.json
2. Need To migration and Update database
    * Add-Migration init
    * Update-Database
3. Run The Application In visual studio 2019 
4. Login by using Default User Id and  Password Any of Them

 User Id  : "pulak"
 Password : 123
*******************
 User Id  : "aninda"
 Password : 123
*******************
 User Id  : "Mostafa"
 Password : 123


### DB Server

* MSSQL


### Development Environment 

* Visual Studio 2019 


## Requirements 

Expense Category:
User should be able to create their different expense categories. Example of expense categories
are “House Rent”, “Water Bill”, “Electric Bill”, “Groceries”, “Uber”, “Medications” etc. Each
expense category must be unique, and system must prevent user to create a duplicate category.
User should be able to see all expense categories and able to edit or delete any specific category.

Expenses:
Through this function user will record their daily expenses. To record an expense user will select
the expense category, date of the expense, and type the expense amount. In expense amount
field user will only be able to type integer or decimal numbers. System will prevent user to record
any expenditure in future date. User should be able to see expenses between two dates and able
to edit or delete a particular expense entry.

