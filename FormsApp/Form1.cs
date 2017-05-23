using LSI_Theme_Finder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class Form1 : Form
    {
        private List<string> _pageText = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void findThemesSubmit_Click(object sender, EventArgs e)
        {
            var worker = new Worker();
            var themes = worker.GetThemeElements(_pageText);
            _pageText = new List<string>();

            var phrases = themes.Skip(1).SelectMany(x => x).OrderByDescending(a => a.Rank).Select(y => y.Phrase + " | " + y.Rank);
            var resultWindow = new Form2(themes[0].OrderByDescending(x => x.Rank).Select(x =>x.Phrase + " | " + x.Rank), phrases);
            resultWindow.Visible = true;
        }


        private void submitPageText_Click(object sender, EventArgs e)
        {
            var text = pageText.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {
                var cleanedText = pageText.Text.Trim().ToLowerInvariant();
                _pageText.Add(cleanedText);

                pageText.Text = string.Empty;
            }
        }
    }
}
