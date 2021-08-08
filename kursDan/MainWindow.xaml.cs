using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Microsoft.Win32;
using System.Text.Json;
using System.IO;


/*
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⣴⣤⣤⣤⣤⣤⡄⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⠟⢋⣵⣿⣿⣿⡿⠛⣩⣤⣿⣿⣿⣿⣿⣿⣿⣬⣙⠻⣿⣿⣿⣷⡍⠛⢿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⠟⢹⠃⣠⣾⣿⣿⡿⢋⣴⣿⣿⣿⣿⠿⠿⠈⠿⢿⣿⣿⣿⣷⣤⡙⣿⣿⣿⢦⡀⢣⠙⣿⣿⣿⣿
⣿⣿⡿⡿⠀⡯⠊⣡⣿⣿⠏⣴⣿⣿⣿⠟⠁⣀⣤⣤⠀⣤⣤⡀⠙⠻⣿⣿⣿⣌⢻⣿⣧⡉⠺⡄⢸⠹⣿⣿
⣿⣿⠃⢷⠀⡠⢺⣿⣿⡏⣰⣿⣿⡟⠁⣠⣾⣿⣿⠿⠀⠿⣿⣿⣷⡄⠘⣿⣿⣿⡄⣿⣿⣯⠢⡀⢸⠀⢹⣿
⣿⣿⠀⢸⠊⣠⣿⣿⣿⢀⣿⣿⣿⠁⣰⣿⣿⣿⣿⣆⢀⣼⣿⣿⣿⣿⡄⢸⣿⣿⣿⣹⣿⣿⣦⠈⢺⠀⢸⣿
⣿⠹⡆⠀⣴⢻⣿⣿⣿⢸⣿⣿⣿⠀⣿⣿⡿⠿⠿⢿⣿⠿⠿⠿⣿⣿⡇⢈⣿⣿⣿⠀⣿⣿⣿⠳⡀⢀⡇⢸
⣿⡀⠹⣸⠉⣿⣿⡿⢋⣠⣿⣿⣿⡀⠸⠟⢋⣀⢠⣾⣿⣷⡀⣀⡙⠻⠁⢸⣿⣿⣿⣈⠻⣿⣿⡄⠹⡜⠀⣸
⣿⢧⠀⠇⢠⣿⣿⣷⡘⣿⣿⣿⣟⣁⡀⠘⢿⣿⣿⣿⣿⣿⣿⣿⠿⠀⣠⣉⣿⣿⣿⡿⢠⣿⡿⢧⠀⠁⣰⢿
⣿⡌⢷⡄⣾⠀⣿⣿⣷⡜⢿⣿⣿⣿⣿⣦⣄⠈⠉⠛⠛⠛⠉⢁⣠⣾⣿⣿⣿⣿⡟⣰⣿⣿⡇⢸⢀⡴⠃⣼
⣿⣷⣄⠙⢿⠀⣿⢿⣿⣿⣌⠿⠟⡻⣿⣿⣿⣿⣷⣶⣶⣶⣿⣿⣿⣿⡿⠛⠿⠟⣼⣿⡿⢫⠃⢸⠋⢀⣼⣿
⣿⣿⣟⣶⣄⡀⢸⡀⢻⣿⣿⣾⣿⣿⣶⣍⣙⠛⠿⠿⠿⠿⠿⠛⣋⣥⣶⣿⣿⣾⣿⣿⠁⣸⢀⣴⣶⣯⣿⣿
⣿⣿⣿⣿⣿⣿⠾⣧⠀⢯⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⡿⢫⠃⢠⢷⣛⣉⣽⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣄⣁⡈⢧⠈⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⣠⢋⣀⣠⣴⣾⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣯⣉⠉⠉⠉⣀⣀⡭⠟⠛⢛⣛⠛⠛⠛⣛⠛⠛⠩⣥⣀⣈⢁⢀⣀⣴⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⣝⡛⢉⣁⣀⣤⠖⣫⣴⣿⣿⣷⣬⡙⣦⣤⣀⡈⣉⣩⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣼⣿⣿⣿⣿⣿⣿⣿⣧⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
 */
namespace kursDan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Enterprises _Enterprises;
        List<LDepartment> lDepartments = new List<LDepartment>();

        private void AddDepartment_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_Enterprises == null) 
                _Enterprises = new Enterprises(NameDepartment.Text);
            else 
                _Enterprises.AddDepartment(NameDepartment.Text);
            DepartmentsData.ItemsSource = _Enterprises.Head.ToList();
        }

        private void DeleteDepartment_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_Enterprises.Delete(NameDepartment.Text))
            {
                MessageBox.Show($"Отдел {NameDepartment.Text} удален");
                DepartmentsData.ItemsSource = _Enterprises.Head.ToList();
            }
            else
                MessageBox.Show($"Отдел {NameDepartment.Text} не найден");
        }

        private void AddProject_Button_Click(object sender, RoutedEventArgs e)
        {
            Department department = DepartmentsData.SelectedItem as Department ?? 
                _Enterprises.GetDepartment(
                    new Department(NameDepartment.Text));
            department = _Enterprises.GetDepartment(department);
            if (department != null)
            {
                department.Add(NameProject.Text, int.Parse(BudgetProject.Text));
                ProjectData.ItemsSource = department.GetProjects();
            }
        }

        private void DeleteProject_Button_Click(object sender, RoutedEventArgs e)
        {
            Department department = DepartmentsData.SelectedItem as Department ??
                _Enterprises.GetDepartment(
                    new Department(NameDepartment.Text));
            department = _Enterprises.GetDepartment(department);
            Project project = ProjectData.SelectedItem as Project ?? new Project(NameProject.Text, 0);
            department.Delete(project.Name_Project);
            ProjectData.ItemsSource = department.GetProjects();
        }

        private void DepartmentsData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Department department = DepartmentsData.SelectedItem as Department;
            if (department != null)
            {
                ProjectData.ItemsSource = department.GetProjects();
            }
        }

        private void ProjectData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            ConvertToLDepartment();
            if ((bool)saveFileDialog.ShowDialog())
                using (FileStream fs = (FileStream)saveFileDialog.OpenFile())
                {
                    JsonSerializer.Serialize<List<LDepartment>>(new Utf8JsonWriter(fs), lDepartments);
                }
        }

        private async void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if ((bool)openFileDialog.ShowDialog())
                using (FileStream fs = (FileStream)openFileDialog.OpenFile())
                {
                    //_Enterprises
                    lDepartments = await JsonSerializer.DeserializeAsync<List<LDepartment>>(fs);
                }
            _Enterprises = ConvertToEnter();
            DepartmentsData.ItemsSource = _Enterprises.Head.ToList();
        }
        public void ConvertToLDepartment()
        {
            foreach(var i in _Enterprises.Head.ToList())
            {
                lDepartments.Add(new LDepartment(i.Название, i.Projects.ToList<Project>()));
            }
        }
        public Enterprises ConvertToEnter()
        {
            Enterprises enterprises = new Enterprises();
            foreach (var i in lDepartments) 
            {
                enterprises.AddDepartment(new Department(i.Name, i.projects.ToArray()));
            }
            return enterprises;
        }

    }
    class LDepartment
    {
        public string Name { get; set; }
        public List<Project> projects { get; set; }

        public LDepartment(string name, List<Project> projects)
        {
            Name = name;
            this.projects = projects;
        }

        public LDepartment()
        {
        }
    }
}
