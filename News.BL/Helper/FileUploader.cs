using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL.Helper
{
 public static   class FileUploader
    {
        public static string UploadFile(string Folder, IFormFile File)
        {
            try
            {
                var FilePath = Directory.GetCurrentDirectory() + "/wwwroot/" + Folder;
                var FileName = Guid.NewGuid() + Path.GetFileName(File.FileName);
                var FinalPath = Path.Combine(FilePath + FileName);

                using (var stream = new FileStream(FinalPath, FileMode.Create))
                {
                    File.CopyTo(stream);
                }
                return FileName;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
            public static string RemoveFile(string Folder, string FileName)
            {
                try
                {

                    if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/" + Folder + FileName))
                    {
                        System.IO.File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/" + Folder + FileName);
                    }

                    return "File Deleted";

                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

        }
    }

