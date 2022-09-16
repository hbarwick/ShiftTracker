# ShiftTracker

Console based CRUD application for recording worker shifts and pay.
SQLServer server database constructed using EF Code First approach, ASP.net API handles the database operations.

# Requirements
- [x] This is an application where you should record a worker's shifts
- [x] You need to create two applications: the API and the UI that will call it
- [x] All validation and user input should happen in the UI app
- [x] Your API's controller should be lean. Any logic should be handled in a separate "service"
- [x] You should use SQL Server, not SQLite

# Features
* SQL Server database connection
    - Database constructed using Entity Framework with "Code First" approach
* ASP.net API to handle CRUD operations into databse
* Data validation in console app to ensure valid data passed to API
    
# Lessons learned
* Creating API with ASP.net
* Entity Framework Code First database creation
* Serializing and deserializing JSON to pass data between DTO and API
