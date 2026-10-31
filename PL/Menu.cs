using System;
using System.Collections.Generic;
using BLL;

namespace PL;

public class Menu
{
    private readonly EntityService service = new EntityService();

    public void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("\n=== OOP LAB 3.3 / VARIANT 14 ===");
            Console.WriteLine("1. Students");
            Console.WriteLine("2. Postmen");
            Console.WriteLine("3. Mountaineers");
            Console.WriteLine("4. Draw");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        StudentsMenu();
                        break;

                    case "2":
                        PostmenMenu();
                        break;

                    case "3":
                        MountaineersMenu();
                        break;

                        case "4":
                         DrawMenu();
                         break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }
    }

    private void StudentsMenu()
    {
        Console.WriteLine("\n=== STUDENTS ===");
        Console.WriteLine("1. Add student");
        Console.WriteLine("2. Show students");
        Console.WriteLine("3. Remove student");
        Console.WriteLine("4. Find 4th-year students without scholarship");
        Console.WriteLine("5. Save students");
        Console.WriteLine("6. Load students");
        Console.Write("Choose an option: ");

        switch (Console.ReadLine())
        {
            case "1":
                Student student = new Student
                {
                    LastName = ReadText("Last name: "),
                    FirstName = ReadText("First name: "),
                    Course = ReadInt("Course: "),
                    StudentId = ReadText("Student ID: "),
                    HasScholarship = ReadBool("Has scholarship (y/n): "),
                    PassportSeries = ReadText("Passport series: "),
                    PassportNumber = ReadText("Passport number: ")
                };

                service.AddStudent(new BLL.Student
                {
                    LastName = student.LastName,
                    FirstName = student.FirstName,
                    Course = student.Course,
                    StudentId = student.StudentId,
                    HasScholarship = student.HasScholarship,
                    PassportSeries = student.PassportSeries,
                    PassportNumber = student.PassportNumber
                });

                Console.WriteLine("Student added.");
                break;

            case "2":
                foreach (BLL.Student item in service.GetStudents())
                {
                    Console.WriteLine(item.LastName + " " + item.FirstName +
                                      ", Course: " + item.Course +
                                      ", ID: " + item.StudentId);
                }
                break;

            case "3":
                string studentId = ReadText("Student ID: ");
                Console.WriteLine(
                    service.RemoveStudent(studentId)
                        ? "Student removed."
                        : "Student not found."
                );
                break;

            case "4":
                List<BLL.Student> found = service.FindStudentsWithoutScholarship();

                Console.WriteLine("Found students: " + found.Count);

                foreach (BLL.Student item in found)
                {
                    Console.WriteLine(item.LastName + " " + item.FirstName +
                                      ", ID: " + item.StudentId);
                }
                break;

            case "5":
                service.SaveStudents(ReadFilePath(), ReadFormat());
                Console.WriteLine("Students saved.");
                break;

            case "6":
                service.LoadStudents(ReadFilePath(), ReadFormat());
                Console.WriteLine("Students loaded.");
                break;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    private void PostmenMenu()
    {
        Console.WriteLine("\n=== POSTMEN ===");
        Console.WriteLine("1. Add postman");
        Console.WriteLine("2. Show postmen");
        Console.WriteLine("3. Remove postman");
        Console.WriteLine("4. Save postmen");
        Console.WriteLine("5. Load postmen");
        Console.Write("Choose an option: ");

        switch (Console.ReadLine())
        {
            case "1":
                Postman postman = new Postman
                {
                    Name = ReadText("Name: "),
                    EmployeeId = ReadText("Employee ID: "),
                    DeliveryArea = ReadText("Delivery area: "),
                    DeliveredLetters = ReadInt("Delivered letters: ")
                };

                service.AddPostman(new BLL.Postman
                {
                    Name = postman.Name,
                    EmployeeId = postman.EmployeeId,
                    DeliveryArea = postman.DeliveryArea,
                    DeliveredLetters = postman.DeliveredLetters
                });

                Console.WriteLine("Postman added.");
                break;

            case "2":
                foreach (BLL.Postman item in service.GetPostmen())
                {
                    Console.WriteLine(item);
                }
                break;

            case "3":
                Console.WriteLine(
                    service.RemovePostman(ReadText("Employee ID: "))
                        ? "Postman removed."
                        : "Postman not found."
                );
                break;

            case "4":
                service.SavePostmen(ReadFilePath(), ReadFormat());
                Console.WriteLine("Postmen saved.");
                break;

            case "5":
                service.LoadPostmen(ReadFilePath(), ReadFormat());
                Console.WriteLine("Postmen loaded.");
                break;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    private void MountaineersMenu()
    {
        Console.WriteLine("\n=== MOUNTAINEERS ===");
        Console.WriteLine("1. Add mountaineer");
        Console.WriteLine("2. Show mountaineers");
        Console.WriteLine("3. Remove mountaineer");
        Console.WriteLine("4. Save mountaineers");
        Console.WriteLine("5. Load mountaineers");
        Console.Write("Choose an option: ");

        switch (Console.ReadLine())
        {
            case "1":
                Mountaineer mountaineer = new Mountaineer
                {
                    Name = ReadText("Name: "),
                    ClimberId = ReadText("Climber ID: "),
                    Mountain = ReadText("Mountain: "),
                    ClimbsCompleted = ReadInt("Completed climbs: ")
                };

                service.AddMountaineer(new BLL.Mountaineer
                {
                    Name = mountaineer.Name,
                    ClimberId = mountaineer.ClimberId,
                    Mountain = mountaineer.Mountain,
                    ClimbsCompleted = mountaineer.ClimbsCompleted
                });

                Console.WriteLine("Mountaineer added.");
                break;

            case "2":
                foreach (BLL.Mountaineer item in service.GetMountaineers())
                {
                    Console.WriteLine(item);
                }
                break;

            case "3":
                Console.WriteLine(
                    service.RemoveMountaineer(ReadText("Climber ID: "))
                        ? "Mountaineer removed."
                        : "Mountaineer not found."
                );
                break;

            case "4":
                service.SaveMountaineers(ReadFilePath(), ReadFormat());
                Console.WriteLine("Mountaineers saved.");
                break;

            case "5":
                service.LoadMountaineers(ReadFilePath(), ReadFormat());
                Console.WriteLine("Mountaineers loaded.");
                break;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    private static string ReadText(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? "";
    }

    private static int ReadInt(string prompt)
    {
        Console.Write(prompt);

        if (!int.TryParse(Console.ReadLine(), out int value))
        {
            throw new EntityException("Invalid number.");
        }

        return value;
    }

    private static bool ReadBool(string prompt)
    {
        Console.Write(prompt);
        string? answer = Console.ReadLine()?.Trim().ToLowerInvariant();

        return answer switch
        {
            "y" => true,
            "n" => false,
            _ => throw new EntityException("Enter y or n.")
        };
    }

    private static string ReadFilePath()
    {
        return ReadText("File path: ");
    }

    private static string ReadFormat()
    {
        return ReadText("Format (json/xml/binary/custom): ");
    }
    private void DrawMenu()
{
    Console.WriteLine("\n=== DRAW ===");
    Console.WriteLine("1. Student");
    Console.WriteLine("2. Postman");
    Console.WriteLine("3. Mountaineer");
    Console.Write("Choose an option: ");

    BLL.IDrawable drawable;

    switch (Console.ReadLine())
    {
        case "1":
            drawable = new BLL.Student();
            break;

        case "2":
            drawable = new BLL.Postman();
            break;

        case "3":
            drawable = new BLL.Mountaineer();
            break;

        default:
            Console.WriteLine("Invalid option.");
            return;
    }

    Console.WriteLine(drawable.Draw());
}
}