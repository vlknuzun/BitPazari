using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BitPazari.WebUI.Helpers
{
    public class ImageUploadHelper
    {
        public static string UploadSingleImage(string serverPath,HttpPostedFileBase file)
        {
            if (file!=null)
            {
                var uniqname = Guid.NewGuid();
                serverPath = serverPath.Replace("~", string.Empty);
                var fileArray = file.FileName.Split('.');
                string extension = fileArray[fileArray.Length - 1].ToLower();
                string filename = uniqname + "." + extension;

                if (extension=="jpg"||extension=="png"||extension=="jpeg"||extension=="gif")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath+filename)))
                    {
                        return "1";//bu isimde resin daha önce eklenmiş.
                    }
                    else
                    {
                        var filePath = HttpContext.Current.Server.MapPath(serverPath + filename);
                        file.SaveAs(filePath);
                        return serverPath + filename;
                    }
                }
                else
                {
                    return "2";//doğru formatta dosya gelmedi.
                }
            }
            else
            {
                return "0";//dosya gelmedi.
            }
        }
    }
}