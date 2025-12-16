using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading.Tasks;

namespace exeption_block2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(currentDirectory);

            Regex regexExtForImage = new Regex(@"\.(bmp|gif|tiff?|jpe?g|png)$",RegexOptions.IgnoreCase);

            foreach (string fileName in files)
            {
                string ext = Path.GetExtension(fileName);

                if (!regexExtForImage.IsMatch(ext))
                    continue;
                Bitmap bitmap = null;

                try
                {
                    bitmap = new Bitmap(fileName);
                }
                catch
                {
                    Console.WriteLine($"{Path.GetFileName(fileName)} має графічне розширення, але не є зображенням.");
                    continue;
                }

                using (bitmap)
                {
                    bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    string nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
                    string outputFile = nameWithoutExt + "-mirrored.gif";
                    string outputPath = Path.Combine(currentDirectory, outputFile);
                    bitmap.Save(outputPath, ImageFormat.Gif);

                    Console.WriteLine($"Створено: {outputFile}");
                }
            }

            Console.WriteLine("Обробку завершено.");
        }
    }
        
}

