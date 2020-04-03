using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reminder_App_take_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }


        Reminder NewReminder = new Reminder();
        bool TaskUpdate = false;




        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            NewReminder.ReminderText = richTextBox1.Text;
            
        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewReminder.TaskNumber++;

             if (richTextBox4.Text != string.Empty)
            {
                MessageBox.Show("You need to do some of your tasks before adding a new one!", "Too many tasks!"); // if there are 3 tasks in progress display this
                
            }

                else if (richTextBox3.Text != string.Empty)

                {
                    string temp1;                                   // if there are two tasks in progress move them down the list freeing up the top task box

                    temp1 = richTextBox3.Text;
                    richTextBox4.Text = temp1;
                    temp1 = string.Empty;

                    temp1 = richTextBox2.Text;
                    richTextBox3.Text = temp1;
                    temp1 = string.Empty;

                    
                    richTextBox2.Text = NewReminder.TaskNumber + " - " + NewReminder.ReminderText + " - " + NewReminder.dateOfReminder;
                }

                else if (richTextBox2.Text != string.Empty)
                {
                    string temp;

                    temp = richTextBox2.Text;                   //if there is a task in to top box move it to the second box freeing up the top box
                    richTextBox3.Text = temp;
                    richTextBox2.Text = string.Empty;
                    richTextBox2.Text = (NewReminder.TaskNumber + " - " + NewReminder.ReminderText + " - " + NewReminder.dateOfReminder);

                }

                else
                {
                    richTextBox2.Text = NewReminder.TaskNumber + " - " + NewReminder.ReminderText + " - " + NewReminder.dateOfReminder; // if none of the other options are met there must be no tasks in progresss so inser the task at the top
                }


            richTextBox1.Text = string.Empty;           // clear the input boxes for creating a new task
            dateTimePicker1.Text = string.Empty;              
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            NewReminder.dateOfReminder = dateTimePicker1.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


            do
            {
                if (richTextBox4.Text != string.Empty && checkBox1.Checked == true)

                {
                    string temp;

                    temp = richTextBox3.Text;
                    richTextBox2.Text = temp;
                    temp = string.Empty;


                    temp = richTextBox4.Text;
                    richTextBox3.Text = temp;
                    temp = string.Empty;
                    richTextBox4.Text = string.Empty;
                    TaskUpdate = true;


                }

                else if (richTextBox3.Text != string.Empty && checkBox1.Checked == true)

                {
                    string temp;

                    temp = richTextBox3.Text;
                    richTextBox2.Text = temp;
                    temp = string.Empty;
                    richTextBox3.Text = string.Empty;
                    TaskUpdate = true;

                }
                else if (richTextBox2.Text != string.Empty && checkBox1.Checked == true)
                {
                    richTextBox2.Text = string.Empty;
                    TaskUpdate = true;
                }
                else if (richTextBox2.Text == string.Empty && checkBox1.Checked == true)
                {
                    TaskUpdate = true;
                }
            } while (TaskUpdate == false);

            checkBox1.Checked = false;
            TaskUpdate = false;


            

        }
        
                             
               
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox3.Text = string.Empty;
            checkBox2.Checked = false;
            
            if (richTextBox4.Text != string.Empty)
            {
                string temp;

                temp = richTextBox4.Text;
                richTextBox3.Text = temp;
                temp = string.Empty;
                richTextBox4.Text = string.Empty;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox4.Text = string.Empty;
            checkBox3.Checked = false;            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
