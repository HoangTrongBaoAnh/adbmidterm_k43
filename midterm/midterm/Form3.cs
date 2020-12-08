using Db4objects.Db4o;
using MidTerm2019;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db4objects.Db4o.Linq;

namespace midterm
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            
            InitializeComponent();
        }



        public void add_combobox()
        {
            var company = new Company();
            IObjectContainer db = Db4oEmbedded.OpenFile("EmployeeManager3.yap");
            List<Company> data = new List<Company>();
            IObjectSet result = db.QueryByExample(company);
            /* var r = from Employee e in db
                    
                    group e by e.HomeBase into grp
                    
                    select (grp.Key); */

            for(int i = 0; i < result.Count; ++i)
            {
                var c1 = (Company)result[i];
                data.Add(c1);
            }

            //data = r.ToList();

            data.Select(x => x.CompanyName).Distinct();

            foreach (Company value in data)
            {
                comboBox1.Items.Add(value);
            }
            db.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IObjectContainer db = Db4oEmbedded.OpenFile("EmployeeManager3.yap");
            if (double.Parse(textBox4.Text) < 300 )
            {
                MessageBox.Show("Lỗi nhập liệu", "Lỗi");
            }
            
            else
            {
                var employee = new Employee(textBox1.Text, textBox2.Text, (Company)this.comboBox1.SelectedItem, double.Parse(textBox4.Text));
                db.Store(employee);

                var pilot1 = new Company
                {
                    CompanyName = comboBox1.Text,

                };
                IObjectSet result = db.QueryByExample(pilot1);
                int a = result.Count;
                Company p2 = (Company)result[0];
                Company p = (Company)result[1];
                

                var pilot2 = new Employee
                {
                    FullName = textBox1.Text,

                };
                IObjectSet result1 = db.QueryByExample(pilot2);
                Employee p1 = (Employee)result1[0];
                
                p1.HomeBase = p2;
                db.Store(p1);
                db.Delete(p);
                db.Close();
                getdata();
            }
           
        }

        public void getdata()
        {
            IObjectContainer db = Db4oEmbedded.OpenFile("EmployeeManager3.yap");
            var employee = new Employee();
            IObjectSet result = db.QueryByExample(employee);
            List<Employee> data = new List<Employee>();
            for(int i = 0; i < result.Count; i++)
            {
                var em = (Employee)result[i];
                data.Add(em);
            }
            db.Close();
            dataGridView1.DataSource = data;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            add_combobox();
            getdata();
        }
    }
}
