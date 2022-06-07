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
    public partial class addVerb : Form
    {
        DateTime currentrandomtag = DateTime.MinValue; // minvalue means invalid because it's not january 1st, 1900
        Dictionary dictionary;
        Verb selectedVerb;
        SaleForm oldForm;
        int i = 0;
        bool autoMode = false;

        public addVerb(Dictionary dictionary, SaleForm oldForm)
        {
            InitializeComponent();
            this.dictionary = dictionary;
            selectedVerb = this.dictionary.verbs[0];
            for (; 0 > verbListBox.Items.Count; verbListBox.Items.RemoveAt(0)) { }
            foreach (Verb verb in dictionary.verbs)
            {
                verbListBox.Items.Add(verb.englishInfinitive + " — " + verb.spanishInfinitive);
            }
            verbListBox.SelectedItem = verbListBox.Items[0];
            verbListBox_Click(null, null);
        }

        private void englishInfinitive_TextChanged(object sender, EventArgs e)
        {
            if (autoMode == false)
            {
                autoMode = true;
                string verb = englishInfinitive.Text;
                if (verb.StartsWith("to "))
                {
                    verb = verb.Substring(2);
                }
                englishParticiple.Text = verb + "ing";
                en1st.Text = verb;
                en2nd.Text = verb;
                if (verb.EndsWith("a") ||
                    verb.EndsWith("i") ||
                    verb.EndsWith("o") ||
                    verb.EndsWith("u") ||
                    verb.EndsWith("x") ||
                    verb.EndsWith("h"))
                {
                    en3rd.Text = verb + "es";
                }
                else if (verb.EndsWith("s"))
                {
                    en3rd.Text = verb + "ses";
                }
                else
                {
                    en3rd.Text = verb + "s";
                }
                en4th.Text = verb;
                en5th.Text = verb;
                en6th.Text = verb;
                editMade(sender, e);
                autoMode = false;
            }
        }

        private void spanishInfinitive_TextChanged(object sender, EventArgs e)
        {
            if (autoMode == false)
            {
                autoMode = true;
                if (spanishInfinitive.Text.Length >= 2)
                {
                    //add support for -arse, erse, irse
                    string verb;
                    if (spanishInfinitive.Text.EndsWith("se"))
                    {
                        verb = spanishInfinitive.Text.Substring(0, spanishInfinitive.Text.Length - 2);
                    }
                    else
                    {
                        verb = spanishInfinitive.Text;
                    }
                    string root;
                    if (verb.EndsWith("ar"))
                    {
                        root = verb.Substring(0, verb.Length - 2);
                        spanishParticiple.Text = root + "ando";
                        es1st.Text = root + "o";
                        es2nd.Text = root + "as";
                        es3rd.Text = root + "a";
                        es4th.Text = root + "amos";
                        es5th.Text = root + "an";
                        es6th.Text = root + "an";

                        affTu.Text = es3rd.Text;
                        negTu.Text = "no " + root + "es";
                        affUd.Text = root + "e";
                        negUd.Text = "no " + root + "e";
                        affNos.Text = root + "emos";
                        negNos.Text = "no " + root + "emos";
                        affUds.Text = root + "en";
                        negUds.Text = "no " + root + "en";
                    }
                    else if (verb.EndsWith("er"))
                    {
                        root = verb.Substring(0, verb.Length - 2);
                        if (root.EndsWith("a") ||
                            root.EndsWith("e") ||
                            root.EndsWith("i") ||
                            root.EndsWith("o") ||
                            root.EndsWith("u"))
                        {
                            spanishParticiple.Text = root + "yendo";
                        }
                        else
                        {
                            spanishParticiple.Text = root + "iendo";
                        }
                        es1st.Text = root + "o";
                        es2nd.Text = root + "es";
                        es3rd.Text = root + "e";
                        es4th.Text = root + "emos";
                        es5th.Text = root + "en";
                        es6th.Text = root + "en";

                        affTu.Text = es3rd.Text;
                        negTu.Text = "no " + root + "as";
                        affUd.Text = root + "a";
                        negUd.Text = "no " + root + "a";
                        affNos.Text = root + "amos";
                        negNos.Text = "no " + root + "amos";
                        affUds.Text = root + "an";
                        negUds.Text = "no " + root + "an";
                    }
                    else if (verb.EndsWith("ir"))
                    {
                        root = verb.Substring(0, verb.Length - 2);
                        if (root.EndsWith("a") ||
                            root.EndsWith("e") ||
                            root.EndsWith("i") ||
                            root.EndsWith("o") ||
                            root.EndsWith("u"))
                        {
                            spanishParticiple.Text = root + "yendo";
                        }
                        else
                        {
                            spanishParticiple.Text = root + "iendo";
                        }
                        es1st.Text = root + "o";
                        es2nd.Text = root + "es";
                        es3rd.Text = root + "e";
                        es4th.Text = root + "imos";
                        es5th.Text = root + "en";
                        es6th.Text = root + "en";

                        affTu.Text = es3rd.Text;
                        negTu.Text = "no " + root + "as";
                        affUd.Text = root + "a";
                        negUd.Text = "no " + root + "a";
                        affNos.Text = root + "amos";
                        negNos.Text = "no " + root + "amos";
                        affUds.Text = root + "an";
                        negUds.Text = "no " + root + "an";
                    }
                    else
                    {
                        root = verb;
                        spanishParticiple.Text = spanishInfinitive.Text;
                        es1st.Text = root;
                        es2nd.Text = root;
                        es3rd.Text = root;
                        es4th.Text = root;
                        es5th.Text = root;
                        es6th.Text = root;
                        affTu.Text = root;
                        negTu.Text = "no " + root;
                        affUd.Text = root;
                        negUd.Text = "no " + root;
                        affNos.Text = root;
                        negNos.Text = "no " + root;
                        affUds.Text = root;
                        negUds.Text = "no " + root;
                    }
                }
                else
                {
                    spanishParticiple.Text = spanishInfinitive.Text;
                    es1st.Text = spanishInfinitive.Text;
                    es2nd.Text = spanishInfinitive.Text;
                    es3rd.Text = spanishInfinitive.Text;
                    es4th.Text = spanishInfinitive.Text;
                    es5th.Text = spanishInfinitive.Text;
                    es6th.Text = spanishInfinitive.Text;

                    affTu.Text = spanishInfinitive.Text;
                    negTu.Text = "no " + spanishInfinitive.Text;
                    affUd.Text = spanishInfinitive.Text;
                    negUd.Text = "no " + spanishInfinitive.Text;
                    affNos.Text = spanishInfinitive.Text;
                    negNos.Text = "no " + spanishInfinitive.Text;
                    affUds.Text = spanishInfinitive.Text;
                    negUds.Text = "no " + spanishInfinitive.Text;
                }
                editMade(sender, e);
                autoMode = false;
            }
        }

        private void verbListBox_Click(object sender, EventArgs e)
        {
            //nothing
        }

        private void editMade(object sender, EventArgs e)
        {
            if (autoMode == false)
            {
                autoMode = true;
                Transitivity transitivity = Transitivity.ditransitive;
                if (DOcheck.Checked == true)
                {
                    if (IOcheck.Checked == true)
                    {
                        transitivity = Transitivity.ditransitive;
                    }
                    else
                    {
                        transitivity = Transitivity.transitiveDirect;
                    }
                }
                else
                {
                    if (IOcheck.Checked == true)
                    {
                        transitivity = Transitivity.transitiveIndirect;
                    }
                    else
                    {
                        transitivity = Transitivity.intransitive;
                    }
                }
                int removeIndex = dictionary.verbs.FindLastIndex(
                    (otherverb)=>{
                        if (otherverb.randomtag == currentrandomtag)
                            return true;

                        return false;
                    }
                );
                dictionary.verbs.RemoveAt(removeIndex);
                string oldEnglishInfinitive = selectedVerb.englishInfinitive;
                string oldSpanishInfinitive = selectedVerb.spanishInfinitive;
                selectedVerb = new Verb(new TenseArray(en1st.Text, en2nd.Text, en3rd.Text,
                                                       en4th.Text, en5th.Text, en6th.Text),
                                        ((englishInfinitive.Text.StartsWith("to ")) ? englishInfinitive.Text.Substring(3) : englishInfinitive.Text),
                                        englishParticiple.Text,
                                        new TenseArray(es1st.Text, es2nd.Text, es3rd.Text,
                                                       es4th.Text, es5th.Text, es6th.Text),
                                        (spanishInfinitive.Text.EndsWith("se") ? spanishInfinitive.Text.Substring(0, spanishInfinitive.Text.Length - 2) : spanishInfinitive.Text),
                                        spanishParticiple.Text,
                                        new CommandForms(affTu.Text, affUd.Text, affNos.Text, affUds.Text,
                                                         negTu.Text, negUd.Text, negNos.Text, negUds.Text),
                                        transitivity);
                currentrandomtag = selectedVerb.randomtag = DateTime.Now;
                dictionary.verbs.Insert(removeIndex, selectedVerb);
                int index = verbListBox.Items.IndexOf((string)(oldEnglishInfinitive + " — " + oldSpanishInfinitive));
                verbListBox.Items[index] = (selectedVerb.englishInfinitive + " — " + selectedVerb.spanishInfinitive);
            }
            autoMode = false;
        }
        private void removeVerbButton_Click(object sender, EventArgs e)
        {
            for (int itemNum = 0; itemNum < dictionary.verbs.Count; itemNum++)
            {
                if (dictionary.verbs[itemNum].englishInfinitive + " — " + dictionary.verbs[itemNum].spanishInfinitive == (string)verbListBox.SelectedItem)
                {
                    dictionary.verbs.RemoveAt(itemNum);
                    //verbListBox.Items.Remove(dictionary.verbs[itemNum].englishInfinitive + " — " + dictionary.verbs[itemNum].spanishInfinitive == (string)verbListBox.SelectedItem);
                }
            }
            selectedVerb = this.dictionary.verbs[0];
            verbListBox.SelectedItem = verbListBox.Items[0];
        }

        private void addVerbButton_Click(object sender, EventArgs e)
        {
            /*List<string> oldItems = new List<string>(verbListBox.Items.Count);
            foreach (object item in verbListBox.Items)
            {
                oldItems.Add((string)item);
            }
            oldItems.Add(selectedVerb.englishInfinitive + " — " + selectedVerb.spanishInfinitive);
            Verb newVerb = new Verb(dictionary.verbs.Count);
            selectedVerb = new Verb(newVerb);
            dictionary.verbs.Add(selectedVerb);
            List<Verb> verbs = dictionary.verbs;*/
            autoMode = false;
            Verb newVerb = new Verb(dictionary.verbs.Count);

            autoMode = true;
            englishInfinitive.Text = newVerb.englishInfinitive;
            //dictionary.verbs = verbs;
            spanishInfinitive.Text = newVerb.spanishInfinitive;
            //dictionary.verbs = verbs;
            selectedVerb = newVerb;
            currentrandomtag = newVerb.randomtag;
            autoMode = false;
            verbListBox.Items.Add(newVerb.englishInfinitive + " — " + newVerb.spanishInfinitive);
            /*foreach (string item in oldItems)
            {
                verbListBox.Items.Add(item);
            }
            i++;
            if (i > 2)
            {
                MessageBox.Show("");
            }*/
            dictionary.verbs.Add(newVerb);
            verbListBox.SelectedItem = (string)selectedVerb.englishInfinitive + " — " + selectedVerb.spanishInfinitive;
            autoMode = false;
        }

        private void verbListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            verbSelected();
        }

        void verbSelected()
        {
            bool foundVerb = false;
            foreach (Verb verb in dictionary.verbs)
            {
                if (verb.englishInfinitive + " — " + verb.spanishInfinitive == (string)verbListBox.SelectedItem)
                {
                    selectedVerb = verb;
                    currentrandomtag = verb.randomtag = DateTime.Now;
                    foundVerb = true;
                }
            }
            if (foundVerb == true)
            {
                if (selectedVerb.spanishInfinitive == "ser" ||
                   selectedVerb.spanishInfinitive == "estar" ||
                   selectedVerb.spanishInfinitive == "ir" ||
                   selectedVerb.spanishInfinitive == "permitir")
                {
                    removeVerbButton.Enabled = false;
                }
                else
                {
                    removeVerbButton.Enabled = true;
                }
                autoMode = true;
                Verb tempVerb = new Verb(selectedVerb);
                englishInfinitive.Text = tempVerb.englishInfinitive;
                englishParticiple.Text = tempVerb.englishParticiple;
                en1st.Text = tempVerb.englishForms.allForms()[0];
                en2nd.Text = tempVerb.englishForms.allForms()[1];
                en3rd.Text = tempVerb.englishForms.allForms()[2];
                en4th.Text = tempVerb.englishForms.allForms()[3];
                en5th.Text = tempVerb.englishForms.allForms()[4];
                en6th.Text = tempVerb.englishForms.allForms()[5];

                spanishInfinitive.Text = tempVerb.spanishInfinitive;
                spanishParticiple.Text = tempVerb.spanishParticiple;
                es1st.Text = tempVerb.spanishForms.allForms()[0];
                es2nd.Text = tempVerb.spanishForms.allForms()[1];
                es3rd.Text = tempVerb.spanishForms.allForms()[2];
                es4th.Text = tempVerb.spanishForms.allForms()[3];
                es5th.Text = tempVerb.spanishForms.allForms()[4];
                es6th.Text = tempVerb.spanishForms.allForms()[5];

                if (tempVerb.spanishInfinitive != "ser")
                {
                    affTu.Text = tempVerb.spanishCommandForms.affirmativeTu;
                    affUd.Text = tempVerb.spanishCommandForms.affirmativeUd;
                    affNos.Text = tempVerb.spanishCommandForms.affirmativeNos;
                    affUds.Text = tempVerb.spanishCommandForms.affirmativeUds;
                    negTu.Text = tempVerb.spanishCommandForms.negitiveTu;
                    negUd.Text = tempVerb.spanishCommandForms.negitiveUd;
                    negNos.Text = tempVerb.spanishCommandForms.negitiveNos;
                    negUds.Text = tempVerb.spanishCommandForms.negitiveUds;

                    affTu.Enabled = true;
                    affUd.Enabled = true;
                    affNos.Enabled = true;
                    affUds.Enabled = true;
                    negTu.Enabled = true;
                    negUd.Enabled = true;
                    negNos.Enabled = true;
                    negUds.Enabled = true;
                }
                else
                {
                    affTu.Text = "no puedo editir";
                    affUd.Text = "no puedo editir";
                    affNos.Text = "no puedo editir";
                    affUds.Text = "no puedo editir";
                    negTu.Text = "no puedo editir";
                    negUd.Text = "no puedo editir";
                    negNos.Text = "no puedo editir";
                    negUds.Text = "no puedo editir";

                    affTu.Enabled = false;
                    affUd.Enabled = false;
                    affNos.Enabled = false;
                    affUds.Enabled = false;
                    negTu.Enabled = false;
                    negUd.Enabled = false;
                    negNos.Enabled = false;
                    negUds.Enabled = false;
                }

                switch (tempVerb.transitivity)
                {
                    case Transitivity.intransitive:
                        IOcheck.Checked = false;
                        DOcheck.Checked = false;
                        break;
                    case Transitivity.transitiveDirect:
                        IOcheck.Checked = false;
                        DOcheck.Checked = true;
                        break;
                    case Transitivity.transitiveIndirect:
                        IOcheck.Checked = true;
                        DOcheck.Checked = false;
                        break;
                    case Transitivity.ditransitive:
                        IOcheck.Checked = true;
                        DOcheck.Checked = true;
                        break;
                }
                autoMode = false;
                selectedVerb = tempVerb;
            }
        }
    }
}
