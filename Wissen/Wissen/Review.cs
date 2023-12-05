/*
This code defines a UserControl 'Review' to display review details. It initializes components and applies data received as a DataRow. Key functionalities include:

- The constructor initializes the Review UserControl and invokes the 'apply' method to populate review details.
- The 'apply' method sets label text and image based on the DataRow received:
  - Sets label text for Name, Rating, and Review Message from the DataRow.
  - Converts byte array data from the DataRow into an image using the 'ConvertBytesToImage' method.
  - Handles exceptions by reporting errors using the 'report_error' method from the 'general' class.
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
    public partial class Review : UserControl
    {
        public Review(DataRow d)
        {
            InitializeComponent();
            try
            {
                apply(d);
            }
            catch (Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }
        public void apply(DataRow data)
        {
            lbl_review.AutoSize= true;
            lbl_name.Text =data["Name"].ToString();
            lbl_rating.Text =data["Rating"].ToString();
            lbl_review.Text = data["Message"].ToString();
            general g=new general();
            p_image.Image = g.ConvertBytesToImage((byte[])data["Image"]);
        }
    }
}
