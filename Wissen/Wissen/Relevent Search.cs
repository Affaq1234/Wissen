/*
Relevent_Search Form Summary:

- This form is responsible for displaying search results based on a given category.
- It receives a category string and a DataRow object upon initialization.
- Upon loading, it populates a FlowLayoutPanel (flp_relevant_teachers) with teachers matching the provided category.
- It triggers the search functionality within the Relevent_Search_Load method when the form is loaded.
- In case of any errors during the search or population of results, it reports the error using the general class.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wissen.DL;

namespace Wissen
{
    public partial class Relevent_Search : Form
    {
        DataRow data;
        string cat;
        Find_Teachers f=new Find_Teachers();
        public Relevent_Search(string category,DataRow d)
        {
            InitializeComponent();
            this.data = d;
            cat = category;
        }

        private void Relevent_Search_Load(object sender, EventArgs e)
        {
            try
            {
                TextBox t = new TextBox();
                t.Text = cat;
                f.find_teachers(t, flp_relevent_teachers, data);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
