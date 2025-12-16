using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OOP_Lab6
{
    internal static class ImageMirror
    {
        public static void Run()
        {
            string folder = Directory.GetCurrentDirectory();

            Regex imageExt = new Regex(
                "^((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$",
                RegexOptions.IgnoreCase
            );

            foreach (string file in Directory.GetFiles(folder))
            {
                try
                {
                    using Bitmap bmp = new Bitmap(file);

                    bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);

                    string name = Path.GetFileNameWithoutExtension(file);
                    string newFile = Path.Combine(
                        folder,
                        name + "-mirrored.gif"
                    );

                    bmp.Save(newFile, System.Drawing.Imaging.ImageFormat.Gif);
                }
                catch
                {
                    string ext = Path.GetExtension(file).TrimStart('.');

                    if (imageExt.IsMatch(ext))
                    {
                        MessageBox.Show(
                            $"Файл {Path.GetFileName(file)} має графічне розширення, але не є зображенням",
                            "Помилка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                }
            }
        }
    }
}
