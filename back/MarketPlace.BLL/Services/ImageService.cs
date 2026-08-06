using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace MarketPlace.BLL.Services
{
    public class ImageService
    {
        public async Task<ServiceResponse> CreateImageAsync(IFormFile file, string basePath, string subPath)
        {
            try
            {
                var type = file.ContentType.Split("/");
                if (type.Length > 2 || type[0] != "image")
                {
                    return ServiceResponse.Failure("File is not Image!");
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string savePath = Path.Combine(basePath, subPath, fileName);

                using var openFileStream = File.OpenWrite(savePath);
                await file.CopyToAsync(openFileStream);

                
                //string[] PathArr = StorePath.Split("\\");
                ////string ImgDir = PathArr[PathArr.Length - 2].ToLower();
                //string CatDir = PathArr[PathArr.Length - 1].ToLower();
                //string savePathforWeb = CatDir + "/" + fileName;

                string savePathWithSub = subPath.ToLower() + "/" + fileName; //для універсального запису у БД такий `/` замість `\` і при Deploy

                return ServiceResponse.Success("Image saved!", savePathWithSub);

            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure(ex.Message);
            }
        }

        public ServiceResponse DeleteImage(string basePath, string fileName)//Images/guid -- треба продумати capitalize todo
        {
            //string[] filePathArr = filePath.Split("/");
            //[0] - C:\Users\Admin\source\repos\MarketPlace_ASPWEBAPI\back\MarketPlace.API\Media
            //[1] - Images\Categories\categories
            //[2] - 2fc7f179 - 4b70 - 4518 - 937c - 64428052d9d8.webp

            //string ImageType = filePathArr[1];
            string capitalizedForPath = char.ToUpper(fileName[0]) + fileName.Substring(1);
            string fullFilePath = Path.Combine(basePath, capitalizedForPath);

            if (!File.Exists(fullFilePath)) { return ServiceResponse.Failure("File doesn't exist"); }
            try
            {
                //Console.WriteLine(fullFilePath);
                File.Delete(fullFilePath);
                return ServiceResponse.Success($"File '{fileName}' was Deleted!");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure(ex.Message);
            }

        }
    }
}
