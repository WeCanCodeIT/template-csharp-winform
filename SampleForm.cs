using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using template_csharp_winform.Models;

namespace template_csharp_winform
{
    public partial class SampleForm : Form
    {
        private Company myCompany;
        public SampleForm()
        {
            InitializeComponent();
            myCompany = new Company("WCCI");
        }


        // The Load Event for this WinForm
        private void SampleForm_Load(object sender, EventArgs e)
        {
            this.LoadEmployees();
        }

        private void LoadEmployees()
        {
            cbEmployees.Items.Clear();
            foreach (var employee in myCompany.Employees)
            {
                cbEmployees.Items.Add(employee.Name);
            }
        }

        private void FilterEmployees(string term)
        {
            cbEmployees.Items.Clear();

            // Using LINQ: SELECT * from Employees WHERE lower(Name) LIKE '%term%';
            var filteredEmployees = myCompany.Employees.Where(employee => employee.Name.ToLower().Contains(term.ToLower())).ToList();
            foreach (var employee in filteredEmployees)
            {
                cbEmployees.Items.Add(employee.Name);
            }
        }

        // Performs the actual save to the database and adds it dynamically to the employee list
        // This is the method that gets assigned to the SaveEmployee event handler from the Employee Form
        private void SF_SaveEmployee(Employee employee)
        {
            myCompany.Employees.Add(employee);
            this.LoadEmployees();
        }

        private void createEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new employee form for each click of the Create Employee menu option
            EmployeeForm newEmployee = new EmployeeForm();

            // The Employee Form has an event handler called SaveEmployee that is a SaveEmployeeHandler object
            newEmployee.SaveEmployee += SF_SaveEmployee;
            newEmployee.Show();
        }

        // ShowDialog is a method of Form and therefore inherited by any WinForm file
        private void companyInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyInfoForm info = new CompanyInfoForm();
            info.ShowDialog();
        }

        // To determine which key event to use ask yourself the following:
        // KeyDown - takes place when the key has been pushed in, useful for 'any key' scenarios
        // KeyPress - similar to the KeyDown event but occurs between the KeyDown and KeyUp event but does not include non-characters
        // KeyUp - takes place after the key has been lifted which is after the action of the key itself
        private void txtSearchEmployee_KeyUp(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtSearchEmployee.Text))
            {
                this.LoadEmployees();
            }
            else
            {
                this.FilterEmployees(this.txtSearchEmployee.Text);
            }
        }

    }
}
