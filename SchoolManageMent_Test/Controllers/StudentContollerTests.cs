using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

using Moq;
using SchoolManageMent.Controller;
using SchoolManageMent.IRepository;
using SchoolManageMent.Models;
using SchoolManageMent.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SchoolManageMent_Test.Controllers
{
    //[TestFixture]
    public class StudentContollerTests
    {
        private readonly Mock<IStudentRepository> _mockRepo;
        //private readonly Mock<UserManager<AppUser>> _mockUserManager;   
        //private readonly Mock<RoleManager<IdentityRole>> _mockRoleManager;
        //private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly StudentController _studentController;
       // private readonly LoginController _loginController;
        public StudentContollerTests()
        {
            _mockRepo = new Mock<IStudentRepository>();
            //_mockUserManager = new Mock<UserManager<AppUser>>();
            //_mockRoleManager = new Mock<RoleManager<IdentityRole>>();
            //_mockConfiguration = new Mock<IConfiguration>();
            _studentController = new StudentController(_mockRepo.Object);
            //_loginController = new LoginController(_mockUserManager.Object, _mockRoleManager.Object, _mockConfiguration.Object);


        }
        Student s;
        [SetUp]
        public void SetUp()
        {
           s = new Student();
            {
                s.Id = 1;
                s.FirstName = "hitesh";
                s.LastName = "inti";
                s.Address = "Madhira";
                s.Standard = "2";
            }
        }
        [Test]
        public void GetStudent()
        {
            
            var actual = _mockRepo.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(s);

            var getemployee = _studentController.GetStudent(1);

            Assert.IsNotNull(getemployee);


        }
        //public void AddStudent()
        //{
        //    Student s = new Student();
        //    {

        //        s.FirstName = "hitesh";
        //        s.LastName = "inti";
        //        s.Address = "Madhira";
        //        s.Standard = "2";
        //        Marks ms = new Marks() { Subject = "English", GradeMarks = 75 };
        //        s.Marks = ms;
        //    }

        //    var actual = _mockRepo.Setup(x => x.AddStudent(It.IsAny<Student>())).Returns(true);

        //    var isAdded = _studentController.AddStudent(s);

        //    Assert.IsNotNull(isAdded);
        //}
        //[Test]
        //public void test_login()
        //{
        //    Login login = new Login()
        //    {
        //        Username = "hiteshinti@gmail.com",
        //        Password = "Pass@123"
        //    };

        //    var actual = _loginController.Login(login);

         
        //}
    }
}
