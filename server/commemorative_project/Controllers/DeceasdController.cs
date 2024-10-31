using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;
using static System.Net.WebRequestMethods;


namespace commemorative_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeceasdController: ControllerBase
    {
        private readonly IService<DeceasdDetailesDto> service;
        public DeceasdController (IService<DeceasdDetailesDto> service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<List<DeceasdDetailesDto>> Get()
        {
            var decead=await service.getAllAsync();
            foreach (var dec in decead)
            {
               foreach (var item in dec.Images)
               {
                    string img= GetImage(item);
                    dec.ImagesUrl.Add(img);
               }
            }
            return decead;
        }
        [HttpGet("{id}")]
        public async Task<DeceasdDetailesDto> Get(int id)
        {
            return await service.getAsync(id);
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Post([FromForm] DeceasdDetailesDto Deceasd)
        {

            Deceasd.Images = new List<string>();
            if (Deceasd.Files != null)
            {
                foreach (var imageFile in Deceasd.Files)
                {

                    var myPath = Path.Combine(Environment.CurrentDirectory + "/images/"/*+Deceasd.Name+"/"*/ + imageFile.FileName);
                    Console.WriteLine("myPath: " + myPath);

                    using (FileStream fs = new FileStream(myPath, FileMode.Create))
                    {
                        imageFile.CopyTo(fs);
                        fs.Close();
                        Deceasd.Images.Add(imageFile.FileName);
                    }
                }
            }
            return Ok(await service.AddAsync(Deceasd));

        }




       
        [HttpPut("{id}")]
        public async Task Put(int id, [FromForm] DeceasdDetailesDto deceasd)
        {
            DeceasdDetailesDto temp = await service.getAsync(id);
            deceasd.Images = temp.Images;

            if (deceasd.Files != null)
            {
                foreach (var imageFile in deceasd.Files)
                {

                    var myPath = Path.Combine(Environment.CurrentDirectory + "/images/"/*+Deceasd.Name+"/"*/ + imageFile.FileName);
                    Console.WriteLine("myPath: " + myPath);

                    using (FileStream fs = new FileStream(myPath, FileMode.Create))
                    {
                        imageFile.CopyTo(fs);
                        fs.Close();
                        deceasd.Images.Add(imageFile.FileName);
                    }
                }
            }
            
            await service.updateAsync(id, deceasd);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.deleteAsync(id);
        }


        [HttpGet("getImage/{ImageUrl}")]
        public string GetImage(string ImageUrl)
        {
            var path = Path.Combine(Environment.CurrentDirectory + "/images/", ImageUrl);
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            string imageBase64 = Convert.ToBase64String(bytes);
            string image = string.Format("data:image/jpeg;base64,{0}", imageBase64);
            return image;
        }

      
    }
}
