using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<SinhVien> students = new List<SinhVien>();
            bool exit = false;

            Console.Write("Nhập số lượng học sinh: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Vui lòng nhập một số nguyên dương: ");
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhập học sinh thứ {i + 1}:");
                SinhVien sv = new SinhVien();
                sv.Input();
                students.Add(sv);
            }

            while (!exit)
            {
                Console.WriteLine("\n1. In danh sách toàn bộ học sinh");
                Console.WriteLine("2. In ra danh sách học sinh có tuổi từ 15 đến 18");
                Console.WriteLine("3. In ra danh sách học sinh có tên bắt đầu bằng chữ 'A'");
                Console.WriteLine("4. In tổng số tuổi của học sinh");
                Console.WriteLine("5. In học sinh có số tuổi lớn nhất");
                Console.WriteLine("6. In danh sách sắp xếp học sinh theo tuổi tăng dần");
                Console.WriteLine("0. Thoát");
                Console.Write("Lựa chọn của bạn: ");

                int slc;
                while (!int.TryParse(Console.ReadLine(), out slc))
                {
                    Console.Write("Vui lòng chọn một số hợp lệ: ");
                }

                switch (slc)
                {
                    case 1:
                        Console.WriteLine("Danh sách học sinh: ");
                        foreach (var sv in students)
                        {
                            sv.Output();
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        PrintListStudentAgeFrom15to18(students);
                        break;
                    case 3:
                        PrintListStudentStartingWithA(students);
                        break;
                    case 4:
                        TotalAge(students);
                        break;
                    case 5:
                        printTheOldestStudent(students);
                        break;
                    case 6:
                        printListbyAge(students);
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Vui lòng chọn lại");
                        break;
                }
            }
            Console.ReadKey();  
        }

        static void PrintListStudentAgeFrom15to18(List<SinhVien> students)
        {
            var listStudentsAgeFrom15to18 = students.Where(s => s.Age >= 15 && s.Age <= 18);
            Console.WriteLine("Danh sách sinh viên có độ tuổi từ 15 đến 18: ");
            foreach (var student in listStudentsAgeFrom15to18)
            {
                student.Output();
            }
        }

        static void PrintListStudentStartingWithA(List<SinhVien> students)
        {
            var filterStudents = students.Where(s => s.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Danh sách học sinh có tên bắt đầu bằng chữ 'A': ");
            foreach (var student in filterStudents)
            {
                student.Output();
            }
        }

        static void TotalAge(List<SinhVien> students)
        {
            var totalAge = students.Sum(s => s.Age);
            Console.WriteLine($"Tổng số tuổi học sinh trong danh sách: {totalAge}");
        }

        static void printTheOldestStudent(List<SinhVien> students)
        {
            var oldestStudent = students.OrderByDescending(s => s.Age).FirstOrDefault();
            if (oldestStudent != null)
            {
                Console.WriteLine("Học sinh lớn tuổi nhất là: ");
                oldestStudent.Output();
            }
        }

        static void printListbyAge(List<SinhVien> students)
        {
            var listByAge = students.OrderBy(s => s.Age).ToList();
            Console.WriteLine("Danh sách học sinh theo số tuổi tăng dần: ");
            foreach (var student in listByAge)
            {
                student.Output();
            }
        }
    }
}
