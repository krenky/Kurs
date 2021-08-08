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
    [Serializable]
    public class Enterprises
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

                curent = curent.GetNext();

                if (curent == Head)
                { return false; }

            }
            while (curent != Head);

            Department Name = new Department(NewNameDepartmens);

            Name.SetPrevious(curent);
            Name.SetNext(curent.GetNext());
            curent.GetNext().SetPrevious(Name);
            curent.SetNext(Name);

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
                curent = curent.GetNext();
                if (curent == Head)
                { return false; }
            }
            while (curent != Head);
            Department Name = new Department(NewNameDepartmens);
            Name.SetNext(curent);
            Name.SetPrevious(curent.GetPrevious());
            curent.GetPrevious().SetNext(Name);
            curent.SetPrevious(Name);
            return true;
        }

        public bool AddDepartment(string data)//Добавление отделов
        {
            Department Name = new Department(data);

            if (Head == null)
            {
                Head = Name;
                Head.SetNext(Name);
                Head.SetPrevious(Name);
            }
            else
            {
                Name.SetPrevious(Head.GetPrevious());
                Name.SetNext(Head);
                Head.GetPrevious().SetNext(Name);
                Head.SetPrevious(Name);
            }

            Count++;

            return true;

        }
        public bool AddDepartment(Department data)//Добавление отделов
        {

            if (Head == null)
            {
                Head = data;
                Head.SetNext(data);
                Head.SetPrevious(data);
            }
            else
            {
                data.SetPrevious(Head.GetPrevious());
                data.SetNext(Head);
                Head.GetPrevious().SetNext(data);
                Head.SetPrevious(data);
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
                    current = current.GetNext();

                
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

                curent = curent.GetNext();

                if (curent == Head)
                { return false; }

            }
            while (curent != Head);

            curent.Delete(NameProject);

            return true;

        }

        /// <summary>
        /// Del Department
        /// </summary>
        /// <param name="Name">Name department</param>
        /// <returns></returns>
        public bool Delete(string Name)//Удаление отдела
        {
            Department current = Head;

            Department removedItem = null;
            if (Count == 0) return false;
            // поиск удаляемого узла
            do
            {
                if (current.Название.Equals(Name))
                {
                    removedItem = current;
                    break;
                }
                current = current.GetNext();
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
                        Head = Head.GetNext();
                    }
                    removedItem.GetPrevious().SetNext(removedItem.GetNext());///?
                    removedItem.GetNext().SetPrevious(removedItem.GetPrevious());///?
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

                    current = current.GetNext();

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


            while (department != Head.GetPrevious())
            {
                moneydepartmens = moneydepartmens + department.Projectmoney();

            }
            return moneydepartmens;

        }
        //public List<Department> GetList()
        //{
        //    List<Department> departments = new List<Department>();
        //    Department department = _head;
        //    do
        //    {
        //        departments.Add(department);
        //        department = department.GetNext();
        //    } while (department != _head);
        //    return departments;
        //}
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
                        head = head.GetNext();

                } while (head != _head);
            }
            else return null;
            return null;
        }
        
    }
    }
