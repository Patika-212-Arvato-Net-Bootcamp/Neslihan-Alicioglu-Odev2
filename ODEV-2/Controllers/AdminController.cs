using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODEV_2.Models;
using ODEV_2.Services.Abstract;

namespace ODEV_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IBootcampService _bootcampService;
        private readonly IUserService _userService;

        public AdminController(IBootcampService bootcampService, IUserService userService)
        {
            _bootcampService = bootcampService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Bootcamp input)//Bootcamp oluştur
        {
            input.Id = new Guid();
            input.IsDefault=(input.StartDate > DateTime.Now) ? true : false;//Eğer başlangıç tarihi geçmişse durumu pasif olacak
            var bootcamp = _bootcampService.AddAsync(input);
            return Ok(bootcamp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) //Bootcamp sil
        {
            var bootcamp = await _bootcampService.GetByIdAsync(id);
            await _bootcampService.Delete(bootcamp);

            return NoContent();//204 yanıtı dönmesini istiyorum
        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id) //Katılımcı sil
        {
            var user = await _userService.GetByIdAsync(id);
            await _userService.Delete(user);

            return NoContent();//204 yanıtı dönmesini istiyorum
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> ConfirmUser(Guid id) //Katılımcı onaylama
        {                                                     //Katılımcı nın id si gönderildiği zaman 
            var user = await _userService.GetByIdAsync(id);   //IsConfirmBootcamp değerini true yaparak katılımcı onaylanmış oluyor.
            user.IsConfirmBootcamp = true;
            await _userService.Update(user);

            return NoContent();//204 yanıtı dönmesini istiyorum
        }
    }
}
