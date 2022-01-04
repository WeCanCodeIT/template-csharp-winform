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
    // A delegate declaration is similar to an Interface declaration which means they are definitions of methods
    public delegate void SaveEmployeeHandler(Employee employee);
    public partial class EmployeeForm : Form
    {
        // This creates a public event on the Employee Form object that is a variable referencing a delegate method stub
        public event SaveEmployeeHandler SaveEmployee;
        public EmployeeForm()
        {
            InitializeComponent();
        }

        // The event handler for when the save button is clicked
        private void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            // Create a new employee and populate their attributes via the TextBox fields
            Employee newEmployee = new Employee();
            newEmployee.Name = this.txtFullName.Text;
            newEmployee.DOB = this.dtDOB.Value;
            newEmployee.Department = this.cbDepartment.SelectedItem.ToString();

            // Access the event handler by using the definition of the delegate - the saving 
            this.SaveEmployee(newEmployee);
        }
    }
}
