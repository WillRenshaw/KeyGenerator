using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
//Jack is useless
namespace MakeKey
{
    class ImageConverter
    {
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        static void Main(string[] args)
        {
            String fname = "E:\\Desktop\\Green\\green.png";
            Bitmap img = new Bitmap(fname);
            Image imger = Image.FromFile(fname);
            int Height,Width, totalPix;
            int divBy = 0;
            Height = img.Height;
            Width = img.Width;
            totalPix = Height * Width;
            if (totalPix <= 1000)
            {
                divBy = 1;
            }
            else if (totalPix <=5000)
            {
                divBy = 2;
            }
            else if (totalPix <= 10000)
            {
                divBy = 5;
            }
            else if (totalPix <= 50000)
            {
                divBy = 10;
            }
            else if (totalPix <= 100000)
            {
                divBy = 15;
            }
            else if (totalPix <= 500000)
            {
                divBy = 100;
            }
            else if (totalPix <= 1000000)
            {
                divBy = 500;
            }
            else if (totalPix <= 10000000)
            {
                divBy = 10000;
            }

            Color[,] imgArray = new Color[Width,Height];
            String totalString =  "";
            String tempString;


            /*for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    if (i % divBy == 0)
                    {
                        Color pixel = img.GetPixel(i, j);
                        imgArray[i, j] = pixel;
                        String tempString = ((pixel.R) + (pixel.G) + (pixel.B)).ToString("X");
                        totalString += tempString;
                    }
                }
            }*/
            byte[] byteArray = imageToByteArray(imger);
            Console.WriteLine("*");
            for (int i = 0; i < byteArray.Length; i++)
            {
                if (i % divBy == 0)
                {
                    tempString = byteArray[i].ToString("X");
                    totalString += tempString;
                }
            }

            Console.WriteLine(totalString);
            File.WriteAllText(@"E:\\Desktop\\Green\\text.txt", totalString);
            Console.ReadLine();
        }
        
    }
}