using DesignPatterns.Services;
using DesignPatterns.Services.Composite;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    [HttpGet("total-size")]
    public IActionResult GetTotalSize()
    {
        IFile file = FakeFileData.GetFileData();
        var totalSize = file.GetTotalSize();
        return Ok(totalSize);
    }
}