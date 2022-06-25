using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODEV_2.Data;
using ODEV_2.Models;
using ODEV_2.Services.Abstract;

namespace ODEV_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampController : ControllerBase
    {
        private readonly IBootcampService _bootcampService;
        private readonly IUserService _userService;

        public BootcampController(IBootcampService bootcampService, IUserService userService)
        {
            _bootcampService = bootcampService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() //Bootcamp Listele
        {
            var bootcamps = await _bootcampService.GetAllAsync();
            return Ok(bootcamps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) //Bootcamp Getir
        {
            var bootcamp = await _bootcampService.GetByIdAsync(id);
            return Ok(bootcamp);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateAsync(Bootcamp input)//Bootcamp oluştur
        //{
        //    input.Id = new Guid();
        //    var bootcamp = _bootcampService.AddAsync(input);
        //    return Ok(bootcamp);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateAsync(User input)//Bootcamp e katıl
        {                                                       //Yeni bir kullanıcı eklendiği zaman belirttiği bootcampe katılma isteği gönderir.
            input.Id = new Guid();                              //IsConfirmBootcamp field ı burada false atanır ve admin true yaparsa kullanıcıyı onaylamış olur.
            var user = _userService.AddAsync(input);            //bu onaylama işlemi AdminControllerda olmaktadır.
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Bootcamp input)
        {
            var bootcamp = _bootcampService.Update(input);
            return Ok(bootcamp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var bootcamp = await _bootcampService.GetByIdAsync(id);
            await _bootcampService.Delete(bootcamp);

            return NoContent();//204 yanıtı dönmesini istiyorum
        }


    }
}
