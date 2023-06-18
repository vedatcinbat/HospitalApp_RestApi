This is a Demo Hospital Website that built with ASP.NET Core MVC (6.0.100) and ASP.NET Core - Web Api (REST)

** There are 2 project called : HospitalWebApi and HospitalAppMvc

x HospitalWebApi has a HospitalsController.cs where we define our apis.
x There are 5 api in HospitalsController

1. GET - localhost:..../api/hospitals : It returns all patients info from db
2. GET - localhost:..../api/hospitals/{id} : It returns one patient from db where p=> p.Id == id
3. POST - localhost:.../api/hospitals : It adds one patient to _context.Patients
4. DELETE - localhost:..../api/hospitals/{id} : It finds that patient and remove from table
5. GET - localhost:..../api/hospitals/{country} : It collects the patients where patientFrom value is equals to that {country value}

   
* Install Microsoft.EntityFrameworkCore 
* Install Microsoft.EntityFrameworkCore.Design
* Install Microsoft.EntityFrameworkCore.Tools
* Install Microsoft.EntityFrameworkCore.SqlServer
* Reference "HospitalWebApi" to HospitalAppMvc for using requests
* For MsSql Database Connection, you have to write your sqlConnection : HospitalWebApi>appsettings.json
"ConnectionString": {
  "sqlConnection": "Data Source = ....; Initial Catalog = ....; Integrated Security = true; TrustServerCertificate = true"
}
* For creating database and updating database
* In HospitalWebApi project
PMC
  > Add-Migration initial -o Migrations
  > Update-Database
CLI
  > dotnet ef migrations add initial
  > dotnet ef database update
  
  




