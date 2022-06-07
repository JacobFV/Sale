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
    public partial class addElement : Form
    {
        Dictionary dictionary;

        public addElement(Dictionary dictionary)
        {
            InitializeComponent();
            this.dictionary = dictionary;
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (englishSingular.Text == "")
            {
                englishSingular.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            }
            if (englishPlural.Text == "")
            {
                englishPlural.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            }
            if (spanishSingular.Text == "")
            {
                spanishSingular.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            }
            if (spanishPlural.Text == "")
            {
                spanishPlural.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            }

            Person singularPerson = Person.firstSing;
            Person pluralPerson = Person.firstPlural;
            Gender gender = masculine.Checked == true ? Gender.masculine : Gender.feminine;
            if(firstPerson.Checked == true){
                singularPerson = Person.firstSing;
                pluralPerson = Person.firstPlural;
            }
            else if (secondPerson.Checked == true)
            {
                singularPerson = Person.secondSing;
                pluralPerson = Person.secondPlural;
            }
            else if (thirdPerson.Checked == true)
            {
                singularPerson = Person.thirdSing;
                pluralPerson = Person.thirdPlural;
            }
            if (checkBoxSP.CheckState == CheckState.Checked)
            {
                dictionary.subjects.addSubject(englishSingular.Text, singularPerson, Language.english, gender);
                dictionary.subjects.addSubject(englishPlural.Text, pluralPerson, Language.english, gender);
                dictionary.subjects.addSubject(spanishSingular.Text, singularPerson, Language.spanish, gender);
                dictionary.subjects.addSubject(spanishPlural.Text, pluralPerson, Language.spanish, gender);
            }
            if (checkBoxDOP.CheckState == CheckState.Checked)
            {
                dictionary.directObjects.addDirectObject(englishSingular.Text, singularPerson, Language.english);
                dictionary.directObjects.addDirectObject(englishPlural.Text, pluralPerson, Language.english);
                dictionary.directObjects.addDirectObject(spanishSingular.Text, singularPerson, Language.spanish);
                dictionary.directObjects.addDirectObject(spanishPlural.Text, pluralPerson, Language.spanish);
            }
            if (checkBoxIOP.CheckState == CheckState.Checked)
            {
                dictionary.indirectObjects.addIndirectObject(englishSingular.Text, singularPerson, Language.english);
                dictionary.indirectObjects.addIndirectObject(englishPlural.Text, pluralPerson, Language.english);
                dictionary.indirectObjects.addIndirectObject(spanishSingular.Text, singularPerson, Language.spanish);
                dictionary.indirectObjects.addIndirectObject(spanishPlural.Text, pluralPerson, Language.spanish);
            }
            this.Close();
        }

        private void englishSingular_TextChanged(object sender, EventArgs e)
        {
            englishPlural.Text = englishSingular.Text + "s";
            stuffChanged(sender, e);
        }

        private void spanishSingular_TextChanged(object sender, EventArgs e)
        {
            spanishPlural.Text = spanishSingular.Text + "s";
            stuffChanged(sender, e);
        }

        private void stuffChanged(object sender, EventArgs e)
        {
            if (checkBoxSP.Checked == true)
            {
                groupBoxGender.Enabled = true;
            }
            else
            {
                groupBoxGender.Enabled = false;
            }

            if (((spanishPlural.Text != "" && spanishSingular.Text != "") ||
                (englishPlural.Text != "" && englishSingular.Text != "" )) &&
                (checkBoxSP.Checked == true || checkBoxIOP.Checked == true||
                 checkBoxDOP.Checked == true))
            {
                add.Enabled = true;
            }
            else
            {
                add.Enabled = false;
            }
        }

        private void englishPlural_TextChanged(object sender, EventArgs e)
        {
            stuffChanged(sender, e);
        }

        private void spanishPlural_TextChanged(object sender, EventArgs e)
        {
            stuffChanged(sender, e);
        }

        private void checkBoxSP_CheckedChanged(object sender, EventArgs e)
        {
            stuffChanged(sender, e);
        }

        private void checkBoxDOP_CheckedChanged(object sender, EventArgs e)
        {
            stuffChanged(sender, e);
        }

        private void checkBoxIOP_CheckedChanged(object sender, EventArgs e)
        {
            stuffChanged(sender, e);
        }
    }
}
