﻿namespace MVCCore_5_Uygulama.Utilities
{
    public class FileOperations
    {
        public static string UploadImage(IFormFile imageName, string folderPath = "wwwroot/images/")
        {
            string guid = Guid.NewGuid().ToString();
            string fileName = guid + "_" + imageName.FileName;
            string filePath = folderPath + fileName;
            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            imageName.CopyTo(fileStream);
            fileStream.Close();
            return fileName;

        }
    }
}
