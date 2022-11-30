using dima_pozarnik.Models;
using dima_pozarnik.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dima_pozarnik.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private List<Department> department_list = new List<Department>();
        private List<Equipment> equipment_list = new List<Equipment>();

        public List<Department> Departments
        {
            get => department_list;
            set => Set(ref department_list, value, nameof(Departments));
        }
        public List<Equipment> Equipment
        {
            get => equipment_list;
            set => Set(ref equipment_list, value, nameof(Equipment));
        }

        public MainWindowViewModel()
        {
            Departments = new ApplicationDbContext().Departments.ToList();
            Equipment = new ApplicationDbContext().Equipment.ToList();
        }

        public void OpenSecondWindow()
        {
            SecondWindow window = new SecondWindow();
            window.ShowDialog();
        }
    }
}
