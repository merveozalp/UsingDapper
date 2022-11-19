using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Business.Abstract;
using RepositoryPattern.Domain;
using RepositoryPattern.Domain.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;
        

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
            
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var result = studentService.GetList();
            var studentDto =mapper.Map<List<StudentDto>>(result);
            return Ok(studentDto);
        }

        [HttpGet]
        public IActionResult GetById(int Id)
        {
            try
            {
                var result = studentService.GetById(Id);
                var studentDto = mapper.Map<StudentDto>(result);    
               
                return Ok(studentDto);
            }
            catch (System.Exception)
            {

                return BadRequest("Aranan Id'de kişi bulunamadı");
            }
            
           
        }

        [HttpPost]
        public IActionResult Add(StudentDto studentDto)
        {
            try
            {
                studentService.Add(mapper.Map<Student>(studentDto));
            }
            catch (System.Exception)
            {

                return BadRequest("hatalı Giriş Yapıldı.");
            }
            
            return Ok("kişi eklendi.");
        }

        [HttpPut]
        public IActionResult Update(UpdateStudentDto studentDto )
        {
            try
                
            {
                
                studentService.Update(mapper.Map<Student>(studentDto));
            }
            catch (System.Exception)
            {

                return NotFound("Aranan kişi bulunamadı.");
            }
            
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            try
            {
               
                studentService.Delete(Id);
            }
            catch (System.Exception)
            {

                return BadRequest("Hatalı Id girişi");
            }

            return Ok("Silme işlemi gerçekleşti.");
        }
    }
}

