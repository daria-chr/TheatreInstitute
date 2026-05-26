using Microsoft.AspNetCore.Mvc;
using TheatreApi.Data;
using TheatreApi.Models;

namespace TheatreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Application>> GetAll()
    {
        return Ok(ApplicationsStore.Applications);
    }
    [HttpPost]
    public ActionResult<Application> Create([FromBody] Application application)
    {
        if (string.IsNullOrWhiteSpace(application.Name))
        {
            return BadRequest("Имя обязательно.");
        }
        if (string.IsNullOrWhiteSpace(application.Phone))
        {
            return BadRequest("Телефон обязателен.");
        }
        application.Id = ApplicationsStore.GetNextId();
        application.CreatedAt = DateTime.UtcNow;
        application.Status = "Новая";
        ApplicationsStore.Applications.Add(application);
        return Ok(application);
    }
    [HttpPut("{id}/status")]
    public IActionResult UpdateStatus(int id, [FromBody] StatusRequest req)
    {
        var application = ApplicationsStore.Applications
            .FirstOrDefault(a => a.Id == id);

        if (application is null)
        {
            return NotFound("Заявка не найдена.");
        }
        application.Status = req.Status;
        return Ok(application);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var application = ApplicationsStore.Applications
            .FirstOrDefault(a => a.Id == id);
        if (application is null)
        {
            return NotFound("Заявка не найдена.");
        }
        ApplicationsStore.Applications.Remove(application);
        return NoContent();
    }
}

public class StatusRequest
{
    public string Status { get; set; } = string.Empty;
}