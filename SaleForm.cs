using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaleLib;

namespace Sale
{
    public partial class SaleForm : Form
    {
        English english = new English();
        Spanish spanish = new Spanish();
        Dictionary dictionary = new Dictionary();

        public SaleForm()
        {
            InitializeComponent();
        }

        private void translateGoButton_Click(object sender, EventArgs e)
        {
            outputText.Text = "";
            string scentence = textInput.Text;
            textInput.SelectAll();
            List<string> possibleEnglishTranslations = new List<string>();
            List<string> possibleSpanishTranslations = new List<string>();
            Exception error = new Exception();
            try
            {
                //from english to spanish
                Idea enI = english.understand(scentence, dictionary);
                enI.translate(Language.spanish, dictionary);
                possibleSpanishTranslations.AddRange(spanish.render(enI, dictionary));
            }
            catch (Exception exception)
            {
                error = exception;
            }
            try
            {
                //from spanish to english
                Idea spI = spanish.understand(scentence, dictionary);
                spI.translate(Language.english, dictionary);
                possibleEnglishTranslations.AddRange(english.render(spI, dictionary));
            }
            catch (Exception exception)
            {
                error = exception;
            }
            if (possibleEnglishTranslations.Count == 0 && possibleSpanishTranslations.Count == 0)
            {
                MessageBox.Show(error.Message, "Oh no! An error occurred");
            }
            else
            {
                if (possibleEnglishTranslations.Count > 0)
                {
                    outputText.AppendText("Possible English Translations:" + Environment.NewLine);
                    foreach (string possibleTranslation in possibleEnglishTranslations)
                    {
                        outputText.AppendText(possibleTranslation + Environment.NewLine);
                    }
                }
                if (possibleSpanishTranslations.Count > 0)
                {
                    outputText.AppendText("Possible Spanish Translations:" + Environment.NewLine);
                    foreach (string possibleTranslation in possibleSpanishTranslations)
                    {
                        outputText.AppendText(possibleTranslation + Environment.NewLine);
                    }
                }
            }
        }

        private void addVerbButton_Click(object sender, EventArgs e)
        {
            Form verbLibForm = new addVerb(this.dictionary, this);
            verbLibForm.ShowDialog();
        }

        private void textInput_Enter(object sender, EventArgs e)
        {
            aLabel.Visible = true;
            eLabel.Visible = true;
            iLabel.Visible = true;
            oLabel.Visible = true;
            uLabel.Visible = true;
            nLabel.Visible = true;
        }

        private void textInput_Leave(object sender, EventArgs e)
        {
            aLabel.Visible = false;
            eLabel.Visible = false;
            iLabel.Visible = false;
            oLabel.Visible = false;
            uLabel.Visible = false;
            nLabel.Visible = false;
        }

        private void accentLabel_Click(object sender, EventArgs e)
        {
            textInput.Text += ((Label)sender).Text;
            textInput.SelectionStart = textInput.Text.Length;
        }
        public void updateDictionary(Dictionary dictionary)
        {
            this.dictionary = dictionary;
        }

        private void properNouns_Click(object sender, EventArgs e)
        {
            addElement adder = new addElement(dictionary);
            adder.ShowDialog();
        }
    }
}
