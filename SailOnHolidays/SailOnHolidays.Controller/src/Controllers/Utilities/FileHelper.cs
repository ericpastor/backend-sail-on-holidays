using Microsoft.AspNetCore.Http;

namespace SailOnHolidays.Controller.src.Utilities
{
    public class FileHelper
    {
        public static async Task<byte[]> ConvertIFormFileToByteArrayAsync(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                return ms.ToArray();
            }
        }
    }
}