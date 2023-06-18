using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HospitalWebApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace HospitalAppMvc.Controllers
{
    public class HomeController : Controller
    {

        private readonly HttpClient _httpClient;

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7169/api/hospitals");

            var patients = await response.Content.ReadFromJsonAsync<List<Patient>>(); 


            return View(patients);
        }

        [HttpGet]

        public IActionResult PostNewPatient()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostNewPatient(Patient patient)
        {
            

            var response = await _httpClient.PostAsJsonAsync("https://localhost:7169/api/hospitals", patient);

            return RedirectToAction("Index");
        }


        /*
         [HttpGet]
        public IActionResult GetOnePatient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetOnePatient(int id)
        {
            var patient = await _httpClient.GetAsync($"https://localhost:7169/api/hospitals/{id}");

            var patientInfo = await patient.Content.ReadFromJsonAsync<Patient>();

            return View("PatientInfo",patientInfo);
        }

        public IActionResult PatientInfo(Patient patient)
        {
            return View(patient);
        }*/

        [HttpGet]
        public IActionResult GetOnePatient()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _httpClient.GetAsync($"https://localhost:7169/api/hospitals/{id}");

            var patientInfo = await patient.Content.ReadFromJsonAsync<Patient>();

            return View(patientInfo);
        }

        [HttpGet]

        public async Task<IActionResult> DeletePatient() {

            var patients = await _httpClient.GetAsync("https://localhost:7169/api/hospitals");

            var jsonPatients = await patients.Content.ReadFromJsonAsync<List<Patient>>();

            return View(jsonPatients);

        }

        [HttpGet]
        public async Task<IActionResult> DeleteOnePatient(int id) {

            var patient = await _httpClient.GetAsync($"https://localhost:7169/api/hospitals/{id}");

            var patientInfo = await patient.Content.ReadFromJsonAsync<Patient>();

            await _httpClient.DeleteAsync($"https://localhost:7169/api/hospitals/{id}");

            

            return View(patientInfo);


        }


        [HttpGet]
        public IActionResult SearchWithCountry() {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetWithCountry(string country) {

            var patients = await _httpClient.GetAsync($"https://localhost:7169/api/hospitals/{country}");

            var patientsList = await patients.Content.ReadFromJsonAsync<List<Patient>>();
            
            @ViewBag.countryName = country;



            return View(patientsList);

                
        }

        


    }
}