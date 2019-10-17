using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using WebEDI.Common.Core;
namespace Unit_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string connectstring = "Server=172.16.19.40;Port=5432;Username=postgres;Password=123456;Database=webedidb";
            string encodeConnect = Base64.Encode(connectstring);
            Console.WriteLine(encodeConnect);
            string decodeConnect = Base64.Decode(encodeConnect);
            Console.WriteLine(decodeConnect);

        }

        [TestMethod]
        public void TestMethod2()
        {
            //   FileUtils.ZipFolders("E:\\test\\48", "E:\\test\\ok.zip");           

            //using (BinaryWriter writer = new BinaryWriter(File.OpenWrite("E:\\test\\okxx.zip")))
            //{
            //    writer.Write(FileUtils.ZipFolders("E:\\test\\48"));
            //    writer.Flush();
            //    writer.Close();
            //}
            //string[] folders = { "E:\\test\\48", "E:\\test\\49" };
            //string[] names = { "48.zip", "49.zip" };

            //using (BinaryWriter writer = new BinaryWriter(File.OpenWrite("E:\\test\\ok1xx.zip")))
            //{
            //    writer.Write(FileUtils.ZipMultiFolders(folders,names));
            //    writer.Flush();
            //    writer.Close();
            //}


        }
    }
}
