using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    internal class SinhVien
    {
        private int id;
        private string name;
        private int age;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public SinhVien() { }

        public SinhVien(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }

        public void Input()
        {
            Console.Write("Nhập mã số: ");
            Id = int.Parse(Console.ReadLine());
            Console.Write("Nhập họ và tên: ");
            Name = Console.ReadLine();
            Console.Write("Nhập tuổi: ");
            Age = int.Parse(Console.ReadLine());
        }

        public void Output()
        {
            Console.WriteLine($"Mã số sinh viên: {Id}, \nHọ và tên: {Name}, \nTuổi: {Age}");
        }
    }
}
