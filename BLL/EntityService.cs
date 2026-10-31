using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BLL;

public class EntityService
{
    private readonly EntityContext context = new EntityContext();

    private List<Student> students = new List<Student>();
    private List<Postman> postmen = new List<Postman>();
    private List<Mountaineer> mountaineers = new List<Mountaineer>();

    public void AddStudent(Student student)
    {
        if (string.IsNullOrWhiteSpace(student.LastName) ||
            string.IsNullOrWhiteSpace(student.FirstName) ||
            string.IsNullOrWhiteSpace(student.StudentId))
        {
            throw new EntityException("Student data cannot be empty.");
        }

        if (student.Course < 1 || student.Course > 6)
        {
            throw new EntityException("Invalid student course.");
        }

        if (students.Any(s => s.StudentId == student.StudentId))
        {
            throw new EntityException("Student with this ID already exists.");
        }

        students.Add(student);
    }

    public List<Student> GetStudents()
    {
        return new List<Student>(students);
    }

    public bool RemoveStudent(string studentId)
    {
        return students.RemoveAll(s => s.StudentId == studentId) > 0;
    }

    public List<Student> FindStudentsWithoutScholarship()
    {
        return students
            .Where(s => s.Course == 4 && !s.HasScholarship)
            .ToList();
    }

    public void AddPostman(Postman postman)
    {
        if (string.IsNullOrWhiteSpace(postman.Name) ||
            string.IsNullOrWhiteSpace(postman.EmployeeId))
        {
            throw new EntityException("Invalid postman data.");
        }

        if (postmen.Any(p => p.EmployeeId == postman.EmployeeId))
        {
            throw new EntityException("Postman with this ID already exists.");
        }

        postmen.Add(postman);
    }

    public List<Postman> GetPostmen()
    {
        return new List<Postman>(postmen);
    }

    public bool RemovePostman(string employeeId)
    {
        return postmen.RemoveAll(p => p.EmployeeId == employeeId) > 0;
    }

    public void AddMountaineer(Mountaineer mountaineer)
    {
        if (string.IsNullOrWhiteSpace(mountaineer.Name) ||
            string.IsNullOrWhiteSpace(mountaineer.ClimberId))
        {
            throw new EntityException("Invalid mountaineer data.");
        }

        if (mountaineers.Any(m => m.ClimberId == mountaineer.ClimberId))
        {
            throw new EntityException("Mountaineer with this ID already exists.");
        }

        mountaineers.Add(mountaineer);
    }

    public List<Mountaineer> GetMountaineers()
    {
        return new List<Mountaineer>(mountaineers);
    }

    public bool RemoveMountaineer(string climberId)
    {
        return mountaineers.RemoveAll(m => m.ClimberId == climberId) > 0;
    }

    public void SaveStudents(string filePath, string format)
    {
        List<DAL.Student> data = students.Select(s => new DAL.Student
        {
            LastName = s.LastName,
            FirstName = s.FirstName,
            Course = s.Course,
            StudentId = s.StudentId,
            HasScholarship = s.HasScholarship,
            PassportSeries = s.PassportSeries,
            PassportNumber = s.PassportNumber
        }).ToList();

        context.Save(data, filePath, format);
    }

    public void LoadStudents(string filePath, string format)
    {
        List<DAL.Student> data = context.Load<DAL.Student>(filePath, format);

        students = data.Select(s => new Student
        {
            LastName = s.LastName,
            FirstName = s.FirstName,
            Course = s.Course,
            StudentId = s.StudentId,
            HasScholarship = s.HasScholarship,
            PassportSeries = s.PassportSeries,
            PassportNumber = s.PassportNumber
        }).ToList();
    }

    public void SavePostmen(string filePath, string format)
    {
        List<DAL.Postman> data = postmen.Select(p => new DAL.Postman
        {
            Name = p.Name,
            EmployeeId = p.EmployeeId,
            DeliveryArea = p.DeliveryArea,
            DeliveredLetters = p.DeliveredLetters
        }).ToList();

        context.Save(data, filePath, format);
    }

    public void LoadPostmen(string filePath, string format)
    {
        List<DAL.Postman> data = context.Load<DAL.Postman>(filePath, format);

        postmen = data.Select(p => new Postman
        {
            Name = p.Name,
            EmployeeId = p.EmployeeId,
            DeliveryArea = p.DeliveryArea,
            DeliveredLetters = p.DeliveredLetters
        }).ToList();
    }

    public void SaveMountaineers(string filePath, string format)
    {
        List<DAL.Mountaineer> data = mountaineers.Select(m => new DAL.Mountaineer
        {
            Name = m.Name,
            ClimberId = m.ClimberId,
            Mountain = m.Mountain,
            ClimbsCompleted = m.ClimbsCompleted
        }).ToList();

        context.Save(data, filePath, format);
    }

    public void LoadMountaineers(string filePath, string format)
    {
        List<DAL.Mountaineer> data =
            context.Load<DAL.Mountaineer>(filePath, format);

        mountaineers = data.Select(m => new Mountaineer
        {
            Name = m.Name,
            ClimberId = m.ClimberId,
            Mountain = m.Mountain,
            ClimbsCompleted = m.ClimbsCompleted
        }).ToList();
    }
}