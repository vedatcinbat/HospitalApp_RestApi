This is a Demo Hospital Website that built with ASP.NET Core MVC (6.0.100) and ASP.NET Core - Web Api (REST)

** There are 2 project called : HospitalWebApi and HospitalAppMvc

x HospitalWebApi has a HospitalsController.cs where we define our apis.
x There are 5 api in HospitalsController

* GET - localhost:..../api/hospitals : It returns all patients info from db
* GET - localhost:..../api/hospitals/{id} : It returns one patient from db where p=> p.Id == id
* POST - localhost:.../api/hospitals : It adds one patient to _context.Patients
* DELETE - localhost:..../api/hospitals/{id} : It finds that patient and remove from table
* GET - localhost:..../api/hospitals/{country} : It collects the patients where patientFrom value is equals to that {country value} 



x HospitalAppMvc has 1 controller : HomeController


* Action 1 : Index() : It shows all patients info from our db

> var response = await _httpClient.GetAsync("https://localhost:..../api/hospitals");

> var patients = await response.Content.ReadFromJsonAsync<List<Patient>>();

> return View(patients);

* Action 2 : PostNewPatient(Patient patient) : It adds new patient to Patients table

> var response = await _httpClient.PostAsJsonAsync("https://localhost:..../api/hospitals", patient);
  
> return RedirectToAction("Index");

* Action 3 : GetPatient(int id) : It returns one patient from Patients table

> var patient = await _httpClient.GetAsync($"https://localhost:..../api/hospitals/{id}");

> var patientInfo = await patient.Content.ReadFromJsonAsync<Patient>();
  
> return View(patientInfo);  

* Action 4 : DeleteOnePatient(int id) : It removes patient from Patients table
  
> var patient = await _httpClient.GetAsync($"https://localhost:..../api/hospitals/{id}");

> var patientInfo = await patient.Content.ReadFromJsonAsync<Patient>();

> await _httpClient.DeleteAsync($"https://localhost:7169/api/hospitals/{id}");

> return View(patientInfo)  

* Action 5 : GetWithCountry(string country) : It shows all patients where their "patientFrom" value is equals to country that we catch FromRoute
  
> var patients = await _httpClient.GetAsync($"https://localhost:7169/api/hospitals/{country}");

> var patientsList = await patients.Content.ReadFromJsonAsync<List<Patient>>();

> return View(patientsList);  
  
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
  
  




