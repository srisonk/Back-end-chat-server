﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
namespace A2UserCRUD.Controller
{
    [Produces("application/json")]
    [Route("api/Image")]
    public class ImageController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;
        public ImageController(IHostingEnvironment environment)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }




        // POST: api/Image
        [HttpPost]
        public async Task<string> Post(IFormFile file)
        {
            try
            {
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        return "/api/Gallery/" + file.FileName;
                    }
                }
                else
                {
                    return "Failed! Something went wrong!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }


    }
}