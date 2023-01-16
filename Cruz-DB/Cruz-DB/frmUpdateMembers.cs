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
    public partial class frmUpdateMembers : Form
    {
        private ClassRegistrationQuery clubRegistrationQuery;
        private frmClubRegistration clubRegistration;
        private int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;
        private long StudentId;

        private void confirmBtn_Click(object sender, EventArgs e)
        {

            long studentID = Convert.ToInt64(idBox.Text);
            string firstName = firstNameTxt.Text;
            string middleName = middleNameTxt.Text;
            string lastName = lastNameTxt.Text;
            int age = Convert.ToInt32(ageTxt.Text);
            string gender = genderBox.Text;
            string program = programBox.Text;

            frmClubRegistration frm = new frmClubRegistration();
            frm.update(studentID, firstName, middleName, lastName, age, gender, program);

            clubRegistrationQuery = new ClassRegistrationQuery();

            clubRegistrationQuery.UpdateStudent(studentID, firstName, middleName, lastName, age, gender, program);
        }

        private void frmUpdateMembers_Load(object sender, EventArgs e)
        {
            genderBox.Items.Add("Male");
            genderBox.Items.Add("Female");
            genderBox.Items.Add("Unspecified");

            programBox.Items.Add("BS in Hospitality Management");
            programBox.Items.Add("BS in Computer Engineering");
            programBox.Items.Add("BS in Computer Science");
            programBox.Items.Add("BS in Information Technology");

        }

        

        public frmUpdateMembers()
        {
            InitializeComponent();
        }

        public frmUpdateMembers(object studentID, object firstName, object middleName, object lastName, object age, object gender, object program)
        {
            InitializeComponent();
            idBox.Text = studentID.ToString();
            firstNameTxt.Text = firstName.ToString();
            middleNameTxt.Text = middleName.ToString();
            lastNameTxt.Text = lastName.ToString();
            ageTxt.Text = age.ToString();
            genderBox.Text = gender.ToString();
            programBox.Text = program.ToString();

            idBox.Items.Add(studentID.ToString());
            
        }




    }
}
