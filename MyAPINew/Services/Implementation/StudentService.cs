using MyAPINew.Model;
using MyAPINew.Repository.Interface;
using MyAPINew.Services.Interface;
using System.Collections.Generic;

namespace MyAPINew.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _studentRepository;

        public StudentService(IGenericRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public void AddStudent(Student student)
        {
            _studentRepository.Add(student);
            _studentRepository.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
            _studentRepository.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student != null)
            {
                _studentRepository.Delete(student);
                _studentRepository.SaveChanges();
            }
        }
    }
}
