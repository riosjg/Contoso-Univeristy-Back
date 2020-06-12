using Contoso_Univeristy.DAL;
using Contoso_Univeristy.DTO;
using Contoso_Univeristy.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Web.Http.Cors;

namespace Contoso_Univeristy.Controllers
{
    public class RequestsController : ApiController
    {
        private ContosoDbContext db = new ContosoDbContext();

        // --------------- STUDENTS SERVICES ---------------- //

        [HttpGet]
        [Route("~/api/students")]
        public IHttpActionResult GetStudent()
        {
            return Ok(db.Students);
        }

        [HttpGet]
        [Route("~/api/students/{id}")]
        public IHttpActionResult GetStudent(int id)
        {
            return Ok(db.Students.First(item => item.Id == id));
        }

        [HttpPost]
        [Route("~/api/addStudent")]
        public IHttpActionResult PostStudent([FromBody]Student student)
        {
            try
            {
                var Students = db.Students.ToList();
                if (Students == null) //in case that there aren't any students on the db yet
                {
                     Students = new List<Student>();
                }
                if (Students.Exists(s => s.Id == student.Id)) //validates if the id written it's already on the db
                {
                    return NotFound(); //return response id it's incorrect
                }
                else
                {
                    db.Students.Add(student);
                }
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return InternalServerError(); //return response when there is an error adding an student
            }
        }

        [HttpPut]
        [Route("~/api/editStudent/{id}")]
        public IHttpActionResult PutStudent(int id, [FromBody]Student student)
        {
            try
            {
                var foundStudent = db.Students.FirstOrDefault(s => s.Id == id);
                if( foundStudent == null)
                {
                    return NotFound();
                }
                else
                {
                    foundStudent.Name = student.Name;
                    foundStudent.LastName = student.LastName;
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("~/api/deleteStudent/{id}")]

        public IHttpActionResult DeleteStudent(int id)
        {
            db.Students.Remove(db.Students.First(p => p.Id == id));
            db.SaveChanges();
            return Ok();
        }

        // --------------- STUDENTS SERVICES ---------------- //

        // --------------- DEPARTMENTS SERVICES ---------------- //

        [HttpGet]
        [Route("~/api/departments")]
        public IHttpActionResult GetDepartment()
        {
            return Ok(db.Departments);
        }

        [HttpGet]
        [Route("~/api/departments/{id}")]
        public IHttpActionResult GetDepartment(int id)
        {
            return Ok(db.Departments.First(item => item.Id == id));
        }

        [HttpPost]
        [Route("~/api/addDepartment")]
        public IHttpActionResult PostDepartment([FromBody]Department department)
        {
            try
            {
                var Departments = db.Departments.ToList();
                if (Departments == null) //in case that there aren't any students on the db yet
                {
                    Departments = new List<Department>();
                }
                if (Departments.Exists(d => d.Id == department.Id)) //validates if the id written it's already on the db
                {
                    return NotFound(); //return response id it's incorrect
                }
                else
                {
                    db.Departments.Add(department);
                }
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return InternalServerError(); //return response when there is an error adding an student
            }
        }

        [HttpPut]
        [Route("~/api/editDepartment/{id}")]
        public IHttpActionResult PutDepartment(int id, [FromBody]Department department)
        {
            try
            {
                var foundDepartment = db.Departments.FirstOrDefault(d => d.Id == id);
                if (foundDepartment == null)
                {
                    return NotFound();
                }
                else
                {
                    foundDepartment.Description = department.Description;
                    foundDepartment.Title = department.Title;
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("~/api/deleteDepartment/{id}")]

        public IHttpActionResult DeleteDepartment(int id)
        {
            //deletes every course that has this department as parent
            var course = db.Courses.Where(c => c.Department.Id == id);
            db.Courses.RemoveRange(course);

            db.Departments.Remove(db.Departments.First(d => d.Id == id));
            db.SaveChanges();
            return Ok();
        }

        // --------------- DEPARTMENTS SERVICES ---------------- //

        // --------------- INSTRUCTORS SERVICES ---------------- //

        [HttpGet]
        [Route("~/api/instructors")]
        public IHttpActionResult GetInstructor()
        {
            return Ok(db.Instructors);
        }

        [HttpGet]
        [Route("~/api/instructors/{id}")]
        public IHttpActionResult GetInstructor(int id)
        {
            return Ok(db.Instructors.First(item => item.Id == id));
        }

        [HttpPost]
        [Route("~/api/addInstructor")]
        public IHttpActionResult PostInstructor([FromBody]Instructor instructor)
        {
            try
            {
                var Instructor = db.Instructors.ToList();
                if (Instructor == null) //in case that there aren't any students on the db yet
                {
                    Instructor = new List<Instructor>();
                }
                if (Instructor.Exists(i => i.Id == instructor.Id)) //validates if the id written it's already on the db
                {
                    return NotFound(); //return response id it's incorrect
                }
                else
                {
                    db.Instructors.Add(instructor);
                }
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return InternalServerError(); //return response when there is an error adding an student
            }
        }

        [HttpPut]
        [Route("~/api/editInstructor/{id}")]
        public IHttpActionResult PutInstructor(int id, [FromBody]Instructor instructor)
        {
            try
            {
                var foundInstructor = db.Instructors.FirstOrDefault(i => i.Id == id);
                if (foundInstructor == null)
                {
                    return NotFound();
                }
                else
                {
                    foundInstructor.Name = instructor.Name;
                    foundInstructor.LastName = instructor.LastName;
                    foundInstructor.HireDate = instructor.HireDate;
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("~/api/deleteInstructor/{id}")]

        public IHttpActionResult DeleteInstructor(int id)
        {
            db.Instructors.Remove(db.Instructors.First(i => i.Id == id));
            db.SaveChanges();
            return Ok();
        }

        // --------------- INSTRUCTORS SERVICES ---------------- //

        // --------------- COURSES SERVICES ---------------- //

        [HttpGet]
        [Route("~/api/courses")]
        public IHttpActionResult GetCourses()
        {
            var query = db.Courses.Include( u => u.Department).Include( i => i.Instructor).Select(m => new CourseDTO
            {
                CourseId = m.Id,
                CourseTitle = m.Title,
                CourseCapacity = m.Capacity,
                DepartmentId = m.Department.Id,
                DepartmentTitle = m.Department.Title,
                InstructorId = m.Instructor.Id,
                InstructorFullName = m.Instructor.LastName + " " + m.Instructor.Name
            });
            return Ok(query.ToList());
        }

        [HttpGet]
        [Route("~/api/courses/{id}")]
        public IHttpActionResult GetCourses(int id)
        {
            var query = db.Courses.Include(u => u.Department).Include(i => i.Instructor).FirstOrDefault(c => c.Id == id);
            var res = new CourseDTO
            {
                CourseId = query.Id,
                CourseTitle = query.Title,
                CourseCapacity = query.Capacity,
                DepartmentTitle = query.Department.Title,
                InstructorFullName = query.Instructor.LastName
            };
            return Ok(res);
        }

        [HttpPost]
        [Route("~/api/addCourse")]
        public IHttpActionResult PostCourse([FromBody]Course course)
        {
            try
            {
                course.Department = db.Departments.FirstOrDefault(d => d.Id == course.DepartmentId);
                course.Instructor = db.Instructors.FirstOrDefault(d => d.Id == course.InstructorId);
                var Course = db.Courses.ToList();
                if (Course == null) //in case that there aren't any courses on the db yet
                {
                    Course = new List<Course>();
                }
                if (Course.Exists(c => c.Id == course.Id)) //validates if the id written it's already on the db
                {
                    return NotFound(); //return response id it's incorrect
                }
                else
                {
                    db.Courses.Add(course);
                }
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return InternalServerError(); //return response when there is an error adding an student
            }
        }

        [HttpPut]
        [Route("~/api/editCourse/{id}")]
        public IHttpActionResult PutCourse(int id, [FromBody]Course course)
        {
            try
            {
                course.Instructor = db.Instructors.FirstOrDefault(d => d.Id == course.InstructorId);
                var foundCourse = db.Courses.FirstOrDefault(i => i.Id == id);
                if (foundCourse == null)
                {
                    return NotFound();
                }
                else
                {
                    //VALIDATE IF INSTRUCTOR ID EXISTS IN THE INSTRUCTORS DB?
               //     foundCourse.Title = course.Title;
                    foundCourse.Instructor = course.Instructor;
                    foundCourse.Capacity = course.Capacity;
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("~/api/deleteCourse/{id}")]

        public IHttpActionResult DeleteCourse(int id)
        {
            db.Courses.Remove(db.Courses.First(c => c.Id == id));
            db.SaveChanges();
            return Ok();
        }

        // --------------- COURSES SERVICES ---------------- //
        // --------------- STUDENT ENROLLMENT SERVICES ---------------- //

        [HttpGet]
        [Route("~/api/enrollments/{id}")]
        public IHttpActionResult GetEnrollment(int id)
        {
            var query = db.Courses.Where(c => c.Id == id).SelectMany(
                c => c.Students.Select(
                s => new CourseStudentDTO
                {
                    CourseId = c.Id,
                    CourseTitle = c.Title,
                    StudentId = s.Id,
                    StudentFullName = s.LastName + " " + s.Name
                }));
            var list = query.ToList();
            return Ok(list);
        }

        [HttpGet]
        [Route("~/api/studentEnrollments/{id}")]
        public IHttpActionResult GetStudentEnrollments(int id)
        {
            var query = db.Students.Where(s => s.Id == id).SelectMany(
                s => s.Courses.Select(
                c => new CourseStudentDTO
                {
                    CourseId = c.Id,
                    CourseTitle = c.Title,
                    StudentId = s.Id,
                    StudentFullName = s.LastName + " " + s.Name
                }));
            var list = query.ToList();
            return Ok(list);
        }

        [HttpPost]
        [Route("~/api/addEnrollment/{id}")]
        public IHttpActionResult PostEnrollment (int id, [FromBody]Student student)
        {
            try
            {
                var enrollingStudent = db.Students.FirstOrDefault(s => s.Id == student.Id);
                var course = db.Courses.FirstOrDefault(c => c.Id == id);
                course.Students.Add(enrollingStudent);
                enrollingStudent.Courses.Add(course);
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("~/api/deleteEnrollment/{cid}/{sid}")]

        public IHttpActionResult DeleteEnrollment(int cid, int sid)
        {
            try
            {
                var enrollingStudent = db.Students.FirstOrDefault(s => s.Id == sid);
                var enrollingCourse = db.Courses.FirstOrDefault(c => c.Id == cid);
                enrollingCourse.Students.Remove(enrollingCourse.Students.FirstOrDefault(
                    s => s.Id == sid)
                    );
                enrollingStudent.Courses.Remove(enrollingStudent.Courses.FirstOrDefault(
                    c => c.Id == cid)
                    );
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }
        // --------------- STUDENT ENROLLMENT SERVICES ---------------- //
        // --------------- USERS SERVICES ---------------- //
        [HttpPost]
        [Route("~/api/authenticate")]
        public IHttpActionResult AuthorizeUser([FromBody]User logInfo)
        {
            try
            {
                var selectedUser = db.Users.FirstOrDefault(u => u.Mail.Equals(logInfo.Mail));
                if (selectedUser != null && Equals( selectedUser.Password, Encryptor.MD5Hash(logInfo.Password) ))
                {
                    var userInfo = new UserDTO
                    {
                        StudentId = selectedUser.StudentId,
                        Role = selectedUser.Role
                    };
                    return Ok(userInfo);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("~/api/createUser")]
        public IHttpActionResult CreateUser([FromBody]UserStudentDTO studentAcc)
        {
            try
            {
                //checks that the DNI has been uploaded by the admin 
                Student student = db.Students.FirstOrDefault(s => s.Dni.Equals(studentAcc.Dni));
                if(student != null)
                {
                    db.Users.Add(new User
                    {
                        Mail = studentAcc.Mail,
                        Password = Encryptor.MD5Hash(studentAcc.Password),
                        Role = Constants.RoleStudent,
                        StudentId = student.Id
                    });
                    db.SaveChanges();
                    return Ok();
                }
                else
                {
                    //The admin hasn't uploaded the registered DNI, therefore the user is not allowed to create the account
                    return Unauthorized();
                }
            }
            catch
            {
                return InternalServerError();
            }
        }
        // --------------- USERS SERVICES ---------------- //
    }
}