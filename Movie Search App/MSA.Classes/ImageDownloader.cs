using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Movie_Search_App
{
    class ImageDownloader
    {
        public async Task<BitmapImage> DownloadImageTaskAsync(string fileUrl)
        {
            using (var client = new WebClient())
            {
                var data = await client.DownloadDataTaskAsync(fileUrl);
                return ConvertBytesToImage(data);
            }
        }
        public BitmapImage ConvertBytesToImage(byte[] data)
        {
            var stream = new MemoryStream(data);
            stream.Seek(0, SeekOrigin.Begin);
            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            image.Freeze();
            return image;
        }
       
    }
}

