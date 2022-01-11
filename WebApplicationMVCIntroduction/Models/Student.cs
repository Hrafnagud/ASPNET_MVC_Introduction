using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationMVCIntroduction.Models
{
    public class Student : IEquatable<Student>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name field can't be empty")]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Name field must have amount of characters between 2-20")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname field can't be empty")]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Surname field must have amount of characters between 2-20")]
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }

        public static List<Student> StudentList { get; set; } = new List<Student>();

        public static List<Student> BringStudents()
        {
            if (StudentList.Count == 0)
            {
                StudentList = new List<Student>()
                {
                    new Student()
                    {
                        Id = 1, Name = "Jonathan", Surname = "Colber", BirthDate = new DateTime(1992, 10, 15) },
                    new Student(){
                        Id = 2, Name = "Terry", Surname = "Boulder", BirthDate = new DateTime(1992, 10, 11) },
                    new Student(){
                        Id = 3, Name = "Bill", Surname = "Tarded", BirthDate = new DateTime(1992, 10, 12)}
                };
            }
            return StudentList;
        }

        public bool Equals(Student other)
        {
            return Id == other.Id;
        }
    }
}