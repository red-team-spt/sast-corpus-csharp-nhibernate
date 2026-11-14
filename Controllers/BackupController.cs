using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OrdersApi.Controllers;

[ApiController]
[Route("api/backup")]
public class BackupController : ControllerBase
{
    [HttpPost("archive")]
    public IActionResult Archive([FromQuery] string folder)
    {
        var psi = new ProcessStartInfo("/bin/sh", $"-c \"tar -czf /backups/orders.tgz {folder}\"")
        {
            RedirectStandardOutput = true,
            UseShellExecute = false
        };
        using var proc = Process.Start(psi)!;
        proc.WaitForExit();
        return Ok(new { exit = proc.ExitCode });
    }
}
