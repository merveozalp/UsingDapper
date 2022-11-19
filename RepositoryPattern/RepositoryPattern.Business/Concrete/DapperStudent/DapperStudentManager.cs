using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepositoryPattern.Business.Abstract;
using RepositoryPattern.Data.Abstract;
using RepositoryPattern.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Business.Concrete.DapperStudent
{
    public class DapperStudentManager : IStudentService
    {

        private readonly IStudentDal studentDal;

        public DapperStudentManager(IStudentDal studentDal)
        {
            this.studentDal = studentDal;
        }

        public void Add(Student student)
        {
            studentDal.Add(student);
        }

        public void Delete(int id)
        {
            studentDal.Delete(id);


        }

        public Student GetById(int StudentId)
        {
            return studentDal.Get(StudentId).Result;
        }

      

        public List<Student> GetList()
        {
           return  studentDal.GetList().Result.ToList();

        }

        public void Update(Student student)
        {
            studentDal.Update(student);


        }
    }
}
