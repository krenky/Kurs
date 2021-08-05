using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace kursDan
{
    /*
     *what time is it? 

            12
        11  ^    1 
      10    |      2          time for u 
     9      ⊙————>     to stop       
      8            4         using this
        7        5             copypasta
            6
     */
    class Enterprises
    {
        /// <summary>
        /// Класс Enterprises для управления списком
        /// Исправил поля класса 
        /// </summary>

        Department _head;

        int _count;

        public Department Head { get => _head; set => _head = value; }
        public int Count { get => _count; set => _count = value; }

        public Enterprises(string data)//Конструктор 
        {
            if (data != null)
            {
                Head = new Department(data);//Создание кокмпании и отдела с одним и тем же названием
                Count++;
            }
        }

        public Enterprises()
        {
        }

        public bool AddAfter(string Namedepartments, string NewNameDepartmens)
        {
            var curent = Head;

            if (Head == null)
            {
                AddDepartment(Namedepartments);

                return true;
            }

            do

            {
                if (curent.Название == Namedepartments)
                {
                    break;

                }

                curent = curent.Next;

                if (curent == Head)
                { return false; }

            }
            while (curent != Head);

            Department Name = new Department(NewNameDepartmens);

            Name.Previous = curent;
            Name.Next = curent.Next;
            curent.Next.Previous = Name;
            curent.Next = Name;

            return true;






        }

        public bool AddPrev(string Namedepartments, string NewNameDepartmens)
        {
            var curent = Head;
            if (Head == null)
            {
                AddDepartment(Namedepartments);
                return true;
            }
            do
            {
                if (curent.Название == Namedepartments)
                {
                    break;
                }
                curent = curent.Next;
                if (curent == Head)
                { return false; }
            }
            while (curent != Head);
            Department Name = new Department(NewNameDepartmens);
            Name.Next = curent;
            Name.Previous = curent.Previous;
            curent.Previous.Next = Name;
            curent.Previous = Name;
            return true;
        }

        public bool AddDepartment(string data)//Добавление отделов
        {
            Department Name = new Department(data);

            if (Head == null)
            {
                Head = Name;
                Head.Next = Name;
                Head.Previous = Name;
            }
            else
            {
                Name.Previous = Head.Previous;
                Name.Next = Head;
                Head.Previous.Next = Name;
                Head.Previous = Name;
            }

            Count++;

            return true;

        }

        public bool AddProject(string NameProject, string Name, int Money)//Добавление проектов
        {
            Department current = Head;

            do
            {
                if (current.Название.Equals(Name))
                {
                    current.Add(NameProject, Money);
                    return true;
                }
                else 
                {
                    current = current.Next;

                
                }

            }
            while (current != Head);

            return false;

        
        }

        public bool DeleteProject(string NameDepartmens, string NameProject)
        {
            var curent = Head;

            do

            {
                if (curent.Название == NameDepartmens)
                {
                    break;

                }

                curent = curent.Next;

                if (curent == Head)
                { return false; }

            }
            while (curent != Head);

            curent.Delete(NameProject);

            return true;

        }


        public bool Delete(string data)//Удаление отдела
        {
            Department current = Head;

            Department removedItem = null;
            if (Count == 0) return false;
            // поиск удаляемого узла
            do
            {
                if (current.Название.Equals(data))
                {
                    removedItem = current;
                    break;
                }
                current = current.Next;
            }
            while (current != Head);

            if (removedItem != null)
            {
                // если удаляется единственный элемент списка
                if (Count == 1)
                    Head = null;
                else
                {
                    // если удаляется первый элемент
                    if (removedItem == Head)
                    {
                        Head = Head.Next;
                    }
                    removedItem.Previous.Next = removedItem.Next;///?
                    removedItem.Next.Previous = removedItem.Previous;///?
                }
                Count--;

                return true;
            }
            return false;




        }

        public String Print(string data)//Вывод
        {
            if (Head != null)
            {
                string Sim = "";
                Department current = Head;
                
                do

                {
                    Sim = Sim + "Компания: " + current.Название +" "+ current.Print() + "\n";

                    current = current.Next;

                }
                while (current != Head);


                return Sim;
            }
            else return "Нет";



        }

        public int DepartmensMoney()
        {
            int moneydepartmens = 0;
            Department department = Head;


            while (department != Head.Previous)
            {
                moneydepartmens = moneydepartmens + department.Projectmoney();

            }
            return moneydepartmens;

        }
        public List<Department> GetList()
        {
            List<Department> departments = new List<Department>();
            Department department = _head;
            do
            {
                departments.Add(department);
                department = department.Next;
            } while (department != _head);
            return departments;
        }
        public Department GetDepartment(Department department)
        {
            Department head = _head;
            if (department != null)
            {
                do
                {
                    if (head.Название.Equals(department.Название))////////////////////////////////////////////////////////////////////////////////
                    {
                        return head;
                    }
                    else
                        head = head.Next;

                } while (head != _head);
            }
            else return null;
            return null;
        }
        
    }
    }
