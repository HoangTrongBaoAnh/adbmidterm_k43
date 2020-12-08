using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db4objects.Db4o;
using MidTerm2019;
using Db4objects.Db4o.Linq;


namespace midterm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_company_Click(object sender, EventArgs e)
        {
            IObjectContainer db = Db4oEmbedded.OpenFile("EmployeeManager3.yap");
            if(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Lỗi nhập liệu", "Lỗi");
            }
            else
            {
                Company c1 = new Company(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                db.Store(c1);
            }
            
            db.Close();
            
            getdata();
        }

        public void getdata()
        {
            IObjectContainer db = Db4oEmbedded.OpenFile("EmployeeManager3.yap");
            /*
            var company = new List<Company>();
            var companyHaveEmployees = new List<Company>();

            var employee1 = new Employee();
            IObjectSet result = db.QueryByExample(employee1);
            List<Employee> data = new List<Employee>();
            for (int i = 0; i < result.Count; i++)
            {
                var em = (Employee)result[i];
                data.Add(em);
            }
            var employee = data;
            employee.ToList().ForEach(item =>
            {
                if (!company.Any(x => x.CompanyName == item.HomeBase.CompanyName))
                {
                    company.Add(item.HomeBase);
                }
                else
                {
                    if (!companyHaveEmployees.Any(x => x == item.HomeBase) && item.Salary > 1000)
                    {
                        companyHaveEmployees.Add(item.HomeBase);
                    }
                }
            });
            */
            var r = from Employee e in db
                    where e.Salary > 1000
                    group e by e.HomeBase into grp
                    where grp.Count() >= 2
                    select (grp.Key) ;
           
            dataGridView1.DataSource = r.ToList();
            db.Close();
            //dataGridView1.DataSource = companyHaveEmployees.ToList();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            getdata();
        }
    }
}
