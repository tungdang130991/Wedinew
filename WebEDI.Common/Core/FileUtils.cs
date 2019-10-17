using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebEDI.Common.Core
{
    public class FileUtils
    {

        public static byte[] ZipFolder(String folder)
        {
            DirectoryInfo from = new DirectoryInfo(folder);

            if (!from.Exists)
            {
                throw new Exception("["+ folder+"] not Exists!");
            }

            using (var memoryStream = new MemoryStream())
            {
                using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (FileInfo file in from.GetFiles().Where(o => o is FileInfo).Cast<FileInfo>())
                    {
                        var entryFile = zipArchive.CreateEntry(file.Name);
                        using (var entryStream = entryFile.Open())
                        {
                            using (FileStream fileStream = new FileStream(file.FullName, FileMode.Open))
                            {
                                fileStream.CopyTo(entryStream);
                            }
                        }
                    }
                }
                return memoryStream.ToArray();
            }                       
        }


        public static byte[] ZipMultiFolders(String[] folders, String[] zipFilename)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    for (int i = 0; i < folders.Length; i++)
                    {
                        var demoFile = zipArchive.CreateEntry(zipFilename[i]);
                        using (var entryStream = demoFile.Open())
                        {
                            byte[] data = ZipFolder(folders[i]);
                            entryStream.Write(data, 0, data.Length);
                            entryStream.Flush();
                        }
                    }                    
                }
             return memoryStream.ToArray();
            }
        }

        public static byte[] ZipMultiFiles(String[] filePaths)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    for (int i = 0; i < filePaths.Length; i++)
                    {                        
                        string fileName=Path.GetFileName(filePaths[i]);

                        var demoFile = zipArchive.CreateEntry(fileName);
                        using (var entryStream = demoFile.Open())
                        {
                            using (FileStream fileStream = new FileStream(filePaths[i], FileMode.Open))
                            {
                                fileStream.CopyTo(entryStream);
                            }                            
                            entryStream.Flush();
                        }
                    }

                }
                return memoryStream.ToArray();
            }
        }


        public static byte[] ZipFile(string filePath)
        {
            FileInfo f = new FileInfo(filePath);
            if (!f.Exists)
            {
                throw new Exception("[" + filePath + "] not Exists!");
            }

            using (var memoryStream = new MemoryStream())
            {
                using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    string fileName = Path.GetFileName(filePath);

                    var entryFile = zipArchive.CreateEntry(fileName);

                    using (var entryStream = entryFile.Open())
                    {                        
                            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                            {
                                fileStream.CopyTo(entryStream);                     
                            }                        
                    }
                }

                return memoryStream.ToArray();
            }
        }

    }
}

