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
            int n = 0;
            Console.WriteLine("Nhập số lượng sinh viên: ");
            n = Console.Read();
            for(int i = 0; i < n; i++)
            {
                SinhVien student = new SinhVien();
                student.input();
                students.Add(student);
            }
            while (!exit) 
            {
                Console.WriteLine("1. In danh sách toàn bộ học sinh");
                Console.WriteLine("2. In ra danh sách học sinh có tuổi từ 15 đến 18");
                Console.WriteLine("3. In ra danh sách học sinh có tên bắt đầu bằng chữ 'A'");
                Console.WriteLine("4. In tổng số tuổi của học sinh");
                Console.WriteLine("5. In học sinh có số tuổi lớn nhất");
                Console.WriteLine("6. In danh sách sắp xếp học sinh theo tuổi tăng dần");
                Console.WriteLine("0. Thoát");
                Console.WriteLine("Lựa chọn của bạn: ");
                int slc = Console.Read();
                switch (slc) {
                    case 1:
                        Console.WriteLine("Danh sách học sinh: ");
                        foreach (var sinhVien in students)
                        {
                            sinhVien.output();
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
                        break ; 
                    case 5:
                        printTheOldestStudent(students);
                        break ;
                    case 6: 
                        printListbyAge(students);   
                        break ;
                    case 0:
                        exit = true;
                        break ;
                    default:
                        Console.WriteLine("Vui lòng chọn lại");
                        break ;

                }
            }
        }
        static void PrintListStudentAgeFrom15to18(List<SinhVien> students)
        {
            var listStudentsAgeFrom15to18 = students.Where(s => s.Age >= 15 && s.Age <= 18);
            Console.WriteLine("Danh sách sinh viên có độ tuổi từ 15 đến 18: ");
            foreach(var student in listStudentsAgeFrom15to18) { student.output(); }
        }
        static void PrintListStudentStartingWithA(List<SinhVien> students)
        {
            var filterStudents = students.Where(s => s.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Danh sách học sinh có tên bắt đầu bằng chữ 'A': ");
            foreach (var student in filterStudents)
            {
                student.output();
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
            if(oldestStudent != null)
            {
                Console.WriteLine("Học sinh lớn tuổi nhất là: ");
                oldestStudent.output();
            }
        }
        static void printListbyAge(List<SinhVien> students)
        {
            var listByAge = students.OrderBy(s => s.Age).ToList();
            Console.WriteLine("Danh sách học sinh theo số tuổi tăng dần: ");
            foreach(var student in listByAge)
            {
                student.output();
            }
        }
    }
}