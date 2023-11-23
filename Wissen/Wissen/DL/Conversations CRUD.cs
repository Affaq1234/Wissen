using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wissen.DL
{
    public class Conversations_CRUD
    {
        public void load_messages(FlowLayoutPanel flp)
        {
            add_student_message(flp, "Ali:Hi!");
            add_teacher_message(flp, "Teacher:Hi!");
            add_student_message(flp, "Ali:How are you!");
            add_teacher_message(flp, "Teacher:I am fine. So, what you wanted to ask?");
            add_student_message(flp, "Ali:I wanted to study about Theory of Automata!");
            add_teacher_message(flp, "Teacher: Ok! I am available at the given time.");
            add_student_message(flp, "Ali:Ok thanks.Bye");
            add_teacher_message(flp, "Teacher: Ok. bye!");
            add_student_message(flp, "Ali:This is a test of long message.");
        }
        private void add_teacher_message(FlowLayoutPanel flp, string message)
        {
            AddColoredTextLabel(flp, message, Color.LightSeaGreen);
        }
        private void add_student_message(FlowLayoutPanel flp, string message)
        {
            AddColoredTextLabel(flp, message, Color.Blue);
        }
        private void AddColoredTextLabel(FlowLayoutPanel flp, string text, Color backColor)
        {
            if(string.IsNullOrEmpty(text)==false)
            {
                Label label = new Label();
                label.AutoSize = true;
                label.Text = text;
                label.ForeColor = Color.White;
                label.BackColor = backColor;
                label.Padding = new Padding(6);
                label.Margin = new Padding(3);
                label.FlatStyle = FlatStyle.Popup;
                label.Font = new Font("Arial", 9, FontStyle.Bold);
                flp.Controls.Add(label);
                flp.AutoScrollPosition = new Point(0, flp.VerticalScroll.Maximum);
            }
            else
            {
                MessageBox.Show("The message box should not be empty!","Empty Message!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        public void sample_message_send(string message, FlowLayoutPanel std, string entity)
        {
            if (entity == "Student")
            {
                add_student_message(std, message);
            }
            else if (entity == "Teacher")
            {
                add_teacher_message(std, message);
            }
            else
            {

            }
        }
        public void conversation()
        {

        }
        public void change_checker()
        {

        }
        public void changes_adder()
        {

        }
    }
}
