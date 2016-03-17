using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Movie_Search_App
{
   
        class ImageDownloader
        {
        public BitmapImage ConvertBytesToImage(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            stream.Seek(0, SeekOrigin.Begin);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            image.Freeze();
            return image;
        }
            public async Task<BitmapImage> DownloadImageTaskAsync(string fileUrl)
            {
                using (WebClient client = new WebClient())
                {
                    byte[] data = await client.DownloadDataTaskAsync(fileUrl);
                    return ConvertBytesToImage(data);
                }
            }
        }
    }

