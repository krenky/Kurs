using System;
using System.Collections.Generic;
using System.Text;

namespace kursDan
{
    class Project
    {
        /// <summary>
        /// Создал консруктор 
        /// </summary>
        string Name;
        int Money;



        public Project(string InputName, int money)
        {
            Name1 = InputName;
            Money1 = money;


        }





        public string Name1 { get => Name; set => Name = value; }//Инскапсуляция
        public int Money1 { get => Money; set => Money = value; }
    }
}

