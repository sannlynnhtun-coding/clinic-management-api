namespace Clinic_Management.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorsService _doctorsService;

    public DoctorsController(IDoctorsService doctorsService)
    {
        _doctorsService = doctorsService;
    }

    /// <summary>
    /// الحصول على قائمة بجميع الأطباء.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllDoctors()
    {
        var result = await _doctorsService.GetAllDoctorsAsync();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    /// <summary>
    /// الحصول على طبيب معين باستخدام المعرف.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctorById(int id)
    {
        var result = await _doctorsService.GetDoctorByIdAsync(id);
        if (!result.Success)
        {
            return NotFound(result);
        }
        return Ok(result);
    }

    /// <summary>
    /// إضافة طبيب جديد.
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddDoctor([FromBody] DoctorDto doctorDto)
    {
        var doctor = doctorDto.Adapt<Doctor>();
        var result = await _doctorsService.AddDoctorAsync(doctor);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    /// <summary>
    /// تحديث التخصص لطبيب معين.
    /// </summary>
    [HttpPut("{id}/specialization")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateSpecialization(int id, [FromBody] UpdateSpecializationDto specializationDto)
    {
        var result = await _doctorsService.UpdateSpecializationAsync(id, specializationDto.Specialization);
        if (!result.Success)
        {
            return NotFound(result);
        }
        return Ok(result);
    }

    /// <summary>
    /// حذف طبيب باستخدام المعرف.
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        var result = await _doctorsService.DeleteDoctorAsync(id);
        if (!result.Success)
        {
            return NotFound(result);
        }
        return Ok(result);
    }
}