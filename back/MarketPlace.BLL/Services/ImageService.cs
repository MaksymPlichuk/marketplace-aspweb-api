using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.BLL.Services
{
    public class ImageService
    {
        public async Task<ServiceResponse> CreateImageAsync(IFormFile file, string StorePath)
        {
            try
            {
                var type = file.ContentType.Split("/");
                if (type.Length > 2 || type[0] != "image")
                {
                    return ServiceResponse.Failure("File is not Image!");
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string savePath = Path.Combine(StorePath, fileName);

                using var openFileStream = File.OpenWrite(savePath);
                await file.CopyToAsync(openFileStream);

                return ServiceResponse.Success("Image saved!", fileName);

            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure(ex.Message);
            }
        }

        public ServiceResponse DeleteImage(string filePath)
        {
            if (!File.Exists(filePath)) { return ServiceResponse.Failure("File doesn't exist"); }
            try
            {
                string[] filePathArr = filePath.Split("/"); 
                string fileName = filePathArr[filePathArr.Length - 1];

                File.Delete(filePath);
                return ServiceResponse.Success($"File {fileName} was Deleted!");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure(ex.Message);
            }
            
        }
    }
}
