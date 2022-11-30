using dima_pozarnik.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using System.Windows.Shapes;

namespace dima_pozarnik.Views
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        List<Department> Departments = new List<Department>();

        public SecondWindow()
        {
            InitializeComponent();

            List<string> CBSort_list = new List<string>()
            {
                "without",
                "biggest",
                "less"
            };
            List<string> CBFilter_list = new List<string>()
            {
                "without",
                "big 10",
                "less 10"
            };

            CBSort.ItemsSource = CBSort_list;
            CBFilter.ItemsSource = CBFilter_list;

            Departments = new ApplicationDbContext().Departments.ToList();
            Display();
        }

        private List<Department> Filter(List<Department> departments)
        {
            switch (CBFilter.SelectedIndex)
            {
                case 0:
                    return new ApplicationDbContext().Departments.ToList();
                case 1:
                    return departments.Where(d => d.EmployeeCount > 10).ToList();
                case 2:
                    return departments.Where(d => d.EmployeeCount < 10).ToList();
                default:
                    return departments;
            }
        }

        private List<Department> Search(List<Department> departments)
        {
            if (TextBoxSearch.Text == "")
                return departments;
            else
                return departments.Where(d => d.DepartmentName.ToLower().Contains(TextBoxSearch.Text.ToLower())).ToList();
        }

        private List<Department> Sort(List<Department> departments)
        {
            switch (CBSort.SelectedIndex)
            {
                case 1:
                    return departments.OrderBy(d => d.DepartmentName).ToList();
                case 2:
                    return departments.OrderByDescending(d => d.DepartmentName).ToList();
                default:
                    return departments;
            }
        }

        private void Display()
        {
            LW1.ItemsSource = Sort(Search(Filter(Departments)));
        }

        private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Display();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Display();
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Display();
        }
    }
}
