using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LSI_Theme_Finder.Models;

namespace FormsApp
{
    public partial class Form2 : Form
    {
        public Form2(IEnumerable<string> words, IEnumerable<string> phrases)
        {
            InitializeComponent();
            this.DisplayThemePhrases(words, true);
            this.DisplayThemePhrases(phrases, false);
        }

        private void DisplayThemePhrases(IEnumerable<string> words, bool isSingleWords)
        {
            if(isSingleWords)
                themeWords.Text = string.Join(Environment.NewLine, words); 
            else
                textBox2.Text = string.Join(Environment.NewLine, words);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void themeWords_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
