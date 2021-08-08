using System;
using System.Collections.Generic;
using System.Text;

namespace kursDan
{
    [Serializable]
    public class Department
    {
        /// <summary>
        /// Изменил поля и удалил методы
        /// Создал два конструктора
        /// </summary>
        int First, End = -1;
        int Count = 10;
        Project[] _projects;
        string _namedepartments;

        private Department _next;
        private Department _previous;
        public string Название { get => _namedepartments; set => _namedepartments = value; }
        public int Бюджет { get => Projectmoney(); }
        internal Project[] Projects { get => _projects; set => _projects = value; }

        public Department GetPrevious()
        {
            return _previous;
        }

        public void SetPrevious(Department value)
        {
            _previous = value;
        }

        public Department GetNext()
        {
            return _next;
        }

        public void SetNext(Department value)
        {
            _next = value;
        }

        public Department(string Name)//Если нет кол. проектов то оно по стандарту бует равно 10
        {
            Count = 10;
            _projects = new Project[Count];
            Название = Name;
            _next = this;
            _previous = this;
        }

        public Department()
        {
        }

        public Department(string namedepartments, Project[] projects)
        {
            Projects = projects;
            Название = namedepartments;
        }

        public bool Add(string Name, int Money)//Добавление данных в список
        {
            Project project = new Project(Name, Money);


            if (First == -1) First = 0;
            
           
            End = (End + 1) % Count;
            _projects[End] = project;

            return true;

        }
        public Project[] Exist(Project[] projects, int i)//Сдвиг
        {
            if (End == i)
            {
                return projects;


            }
            else
            {
                for (int s = i; s < End; s++)
                {
                    projects[s] = projects[s + 1];

                }
                projects[End] = null;
                return projects;
            }




        }
        /// <summary>
        /// уданление проекта
        /// </summary>
        /// <param name="Name"></param>
        public void Delete(string Name)//Удаление данных
        {
            for (int i = 0; i < _projects.Length; i++)
            {
                if (Comparison(Name, i))
                {
                    _projects[i] = null;
                    _projects = Exist(_projects, i);
                    break;


                }


            }



        }

        public bool Comparison(string Input, int Index)
        {
            if (_projects[Index] == null)
            { return false; }


            if (_projects[Index].Name_Project == Input)
            {
                return true;

            }

            
            return false;


        }

        public string Print()//Вывод данных
        {


            string Info = "";
            foreach (var i in _projects)
            {
                if (i != null)
                {
                    Info = Info + " " + i.Name_Project + " " + i.Money;
                
                }
            
            
            }



            return Info;

        }

        public int Search(string Input)//Поиск данных
        {
            for (int i = 0; i < Count; i++)
            {
                if (Comparison(Input, i))
                {
                    return i;
                }
            }
            return -1;

        }

        public int Projectmoney()
        {
            int OverMoney = 0;

            for (int s = First; s <= End; s++)
            {
                OverMoney = OverMoney + _projects[s].Money;


            }
            return OverMoney;

        }
        public List<Project> GetProjects()
        {
            List<Project> projects = new List<Project>();
            foreach (var i in _projects)
            {
                if (i != null)
                    projects.Add(i);
            }
            return projects;
        }
        public List<Department> ToList()
        {
            Department current = this;

            List<Department> departments = new List<Department>();
            do
            {
                departments.Add(current);
                if (current.GetNext() != null)
                    current = current.GetNext();
            } while (current != this);
            return departments;
        }
    }
}
