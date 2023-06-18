using HospitalWebApi.Models;
using HospitalWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebApi.Controllers
{
    [Route("api/hospitals")]   //   https://localhost:7169/api/hospitals
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly HospitalRepositoryContext _context;
        public HospitalsController(HospitalRepositoryContext context)
        {
            _context = context;
        }

        [HttpGet] // [GET] api/hospitals
        public ActionResult<IEnumerable<Patient>> GetAllPatients() {
            var patiens = _context.Patients.ToList(); 
            return Ok(patiens);
        }

        [HttpGet("{id:int}")] // [GET] api/hospitals/1
        public IActionResult GetOnePatient([FromRoute(Name = "id")]int id)
        {
            var patient = _context.Patients.Where(p => p.Id == id).SingleOrDefault();
            return Ok(patient);
        }

        [HttpPost] // [POST] api/hospitals
        public async Task<IActionResult> AddOnePatient([FromBody] Patient patient)
        {
             await _context.Patients.AddAsync(patient);
             await _context.SaveChangesAsync();
             return Ok(_context.Patients);
        }

        [HttpDelete("{id:int}")] // [DELETE] api/hospitals/1
        public IActionResult DeleteOnePatient([FromRoute(Name = "id")]int id)
        {
            var entity = _context.Patients.Where(p => p.Id == id).SingleOrDefault();

            _context.Patients.Remove(entity);
            _context.SaveChanges();
            return NoContent();
        }

        
        [HttpGet("{country}")] // [GET] api/hospitals/Turkey || api/hospitals/UK
        public IActionResult GetPatientWithCountry([FromRoute(Name = "country")]string country) {
            
            var patients = _context.Patients.Where(patient => patient.patientFrom == country).ToList();
            
            return Ok(patients);


        }

        



    }
}
