using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cruz_DB
{
    public partial class frmClubRegistration : Form
    {
        private ClassRegistrationQuery clubRegistrationQuery;
        private int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;
        private long StudentId;

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var studentID = selectedRow.Cells["StudentID"].Value;
                var firstName = selectedRow.Cells["FirstName"].Value;
                var middleName = selectedRow.Cells["MiddleName"].Value;
                var lastName = selectedRow.Cells["LastName"].Value;
                var age = selectedRow.Cells["Age"].Value;
                var gender = selectedRow.Cells["Gender"].Value;
                var program = selectedRow.Cells["Program"].Value;
                frmUpdateMembers update = new frmUpdateMembers(studentID, firstName, middleName, lastName, age, gender, program);
                update.Show();
            }
        }

        public int RegistrationID()
        {
            count++;
            return count;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ID = RegistrationID();
                StudentId = Convert.ToInt64(studentIdTxt.Text);
                FirstName = firstNameTxt.Text;
                MiddleName = middleNameTxt.Text;
                LastName = lastNameTxt.Text;
                Age = Convert.ToInt32(ageTxt.Text);
                Gender = genderBox.Text;
                Program = programBox.Text;

                clubRegistrationQuery.RegisterStudent(ID, StudentId, FirstName, MiddleName, LastName, Age,
                Gender, Program);
                RefreshListOfClubMembers();
                
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }


        
        public frmClubRegistration()
        {
            InitializeComponent();
        }

        public frmClubRegistration(DataGridView dataGridView) {
            dataGridView1 = dataGridView;
        }

        public void update(long studentID, string firstName, string middleName, string lastName, int age, string gender, string program)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                selectedRow.Cells["StudentID"].Value = studentID;
                selectedRow.Cells["FirstName"].Value = firstName;
                selectedRow.Cells["MiddleName"].Value = middleName;
                selectedRow.Cells["LastName"].Value = lastName;
                selectedRow.Cells["Age"].Value = age;
                selectedRow.Cells["Gender"].Value = gender;
                selectedRow.Cells["Program"].Value = program;
            }
        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            clubRegistrationQuery = new ClassRegistrationQuery();

            RefreshListOfClubMembers();

            programBox.Items.Add("BS in Hospitality Management");
            programBox.Items.Add("BS in Computer Engineering");
            programBox.Items.Add("BS in Computer Science");
            programBox.Items.Add("BS in Information Technology");

            genderBox.Items.Add("Male");
            genderBox.Items.Add("Female");
            genderBox.Items.Add("Unspecified");
        }

        

        public void RefreshListOfClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView1.DataSource = clubRegistrationQuery.bindingSource;  
            
        }
    }
}
