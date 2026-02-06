using Microsoft.Maui.Media;

namespace ContagemConsignados.Utilities
{
    public static class ImageHelper
    {
        public static async Task<string> ToPngBase64Async(IScreenshotResult  screenshot)
        {
            using var stream = await screenshot.OpenReadAsync();
            using var ms = new MemoryStream();

            await stream.CopyToAsync(ms);

            var bytes = ms.ToArray();
            return Convert.ToBase64String(bytes);
        }
    }
}
