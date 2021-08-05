using System;
using System.Collections.Generic;
using System.Text;

namespace kursDan
{
    class Department
    {
        /// <summary>
        /// Изменил поля и удалил методы
        /// Создал два конструктора
        /// </summary>
        int First, End = -1;
        int Count = 10;
        Project[] projects;
        string _namedepartments;

        private Department _next;
        private Department _previous;
        public string Название { get => _namedepartments; set => _namedepartments = value; }
        public int Бюджет { get => Projectmoney(); }
        public Department Previous { get => _previous; set => _previous = value; }
        public Department Next { get => _next; set => _next = value; }
        

        


        public Department(int InputCount, string Name)//Констркутор
        {
            Count = InputCount;
            projects = new Project[Count];
            //Name = Namedepartments;
            Название = Name;
        }

        public Department(string Name)//Если нет кол. проектов то оно по стандарту бует равно 10
        {
            Count = 10;
            projects = new Project[Count];
            Название = Name;
            _next = this;
            _previous = this;
        }

        public bool Add(string Name, int Money)//Добавление данных в список
        {
            Project project = new Project(Name, Money);


            if (First == -1) First = 0;
            
           
            End = (End + 1) % Count;
            projects[End] = project;

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


        public void Delete(string Name)//Удаление данных
        {
            for (int i = 0; i < projects.Length; i++)
            {
                if (Comparison(Name, i))
                {
                    projects[i] = null;
                    projects = Exist(projects, i);
                    break;


                }


            }



        }

        public bool Comparison(string Input, int Index)
        {
            if (projects[Index] == null)
            { return false; }


            if (projects[Index].Name1 == Input)
            {
                return true;

            }

            
            return false;


        }

        public string Print()//Вывод данных
        {


            string Info = "";
            foreach (var i in projects)
            {
                if (i != null)
                {
                    Info = Info + " " + i.Name1 + " " + i.Money1;
                
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
                OverMoney = OverMoney + projects[s].Money1;


            }
            return OverMoney;

        }
        public Project[] GetProjects()
        {
            return projects;
        }

        


    }
}
