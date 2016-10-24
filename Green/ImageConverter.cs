using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
//Jack is useless hahahah




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
            Image img = Image.FromFile(fname);
            byte[] byteArray = imageToByteArray(img);
           
            //this is a test.
            int totalPix = byteArray.Length;
            int divBy = 0;
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

            String totalString =  "";
            String tempString;

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