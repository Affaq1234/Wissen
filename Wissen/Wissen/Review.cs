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
            apply(d);
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
