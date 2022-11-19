using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepositoryPattern.Core.DataAccess;
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
    public class DapperStudentDal : IStudentDal
    {
        
        private readonly IConfiguration configuration;

        public DapperStudentDal(IConfiguration configuration)
        {
            this.configuration = configuration;
          
        }

        public void Add(Student entity)
        {
            var sql = "insert into Students (Name,Surname,Class) VALUES (@Name,@Surname,@Class)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnectionString")))
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
            }
        }

        public void Delete(int id)
        {
            var sql = " DELETE FROM[dbo].[Students] WHERE Id= @Id";

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnectionString")))
            {
                connection.Open();
                var result = connection.Execute(sql, new { Id = id }) ;
            }
        }

        public async Task<Student> Get(int id)
        {
            var sql = "Select * From Students WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnectionString")))
            {
                connection.Open();
                var result = connection.QuerySingleOrDefault<Student>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<List<Student>> GetList(Expression<Func<Student, bool>> filter = null)
        {
            var sql = "SELECT * FROM Students";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnectionString")))
            {
                connection.Open();
                var result = connection.Query<Student>(sql);
                return result.ToList();
            }
        }

        public void Update(Student entity)
        {
            var sql = "UPDATE Students SET Name =@Name , Surname=@Surname, Class=@Class WHERE Id =@Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnectionString")))
            {
                connection.Open();
                var result = connection.Execute(sql, entity);

            }
        }
    }
}
