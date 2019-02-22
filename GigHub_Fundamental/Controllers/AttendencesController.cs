using GigHub_Fundamental.Dto;
using GigHub_Fundamental.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub_Fundamental.Controllers
{

    [Authorize]
    public class AttendencesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendencesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();
            var exists = _context.Attendances
                .Any(a => a.AttendeeId == userId && a.GigId == dto.GigId);

            if (exists)
            {
                return BadRequest("The Attendence Already Exists");
            }
            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();


        }
    }
}
