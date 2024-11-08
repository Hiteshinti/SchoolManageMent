//using Microsoft.EntityFrameworkCore.Migrations.Operations;
//using Moq;
//using SchoolManageMent.Controller;
//using SchoolManageMent.IRepository;
//using SchoolManageMent.Models;
//using SchoolManageMent.Repository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security;
//using System.Text;
//using System.Threading.Tasks;

//namespace SchoolManageMent_Test.Controllers
//{
//    [TestFixture]
//    public class StudentContollerTests
//    {
//        private readonly Mock<IStudentRepository> _mockRepo;
//        private readonly StudentController _studentController;

//        public StudentContollerTests()
//        {
//            _mockRepo = new Mock<IStudentRepository>();
//            _studentController = new StudentController(_mockRepo.Object);   
//        }
//         [SetUp]
//        public void SetUp() 
//        { 
            
//        }
//        [Test]
//        public void GetStudent()
//        {
//            Student s = new Student();
//            {
//                s.Id= 1;
//                s.FirstName = "hitesh";
//                s.LastName = "inti";
//                s.Address = "Madhira";
//                s.Standard = "2";
//            }
//            var actual = _mockRepo.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(s);

//            var getemployee = _studentController.GetStudent(1);

//            Assert.IsNotNull(getemployee);

            
//        }
//        public void AddStudent()
//        {
//            Student s = new Student();
//            {
               
//                s.FirstName = "hitesh";
//                s.LastName = "inti";
//                s.Address = "Madhira";
//                s.Standard = "2";
//                Marks ms = new Marks() { Subject = "English", GradeMarks = 75 };
//                s.Marks = ms;
//            }

//            var actual = _mockRepo.Setup(x => x.AddStudent(It.IsAny<Student>())).Returns(true);

//            var isAdded = _studentController.AddStudent(s);

//            Assert.IsNotNull(isAdded);
//        }


//    }
//}
