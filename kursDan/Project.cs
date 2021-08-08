using System;
using System.Collections.Generic;
using System.Text;

namespace kursDan
{
    [Serializable]
    public class Project
    {
        /// <summary>
        /// Создал консруктор 
        /// </summary>
        string _name;
        int _money;

        public Project()
        {
        }

        public Project(string InputName, int money)
        {
            Name_Project = InputName;
            Money = money;
        }





        public string Name_Project { get => _name; set => _name = value; }//Инскапсуляция
        public int Money { get => _money; set => _money = value; }
    }
}

