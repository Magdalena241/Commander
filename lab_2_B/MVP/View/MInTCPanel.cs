using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab_2_B.MVP.Model;

namespace lab_2_B
{
    public partial class MInTCPanel : UserControl
    {
        #region Prop
        public string CurrentPath
        {
            get {
                return textBox1.Text;
            }
            set {
                ///
                textBox1.Text = value;
            }
        }
        public string[] Drives
        {
            set
            {
                if (InvokeRequired)
                    Invoke(new MethodInvoker(delegate ()
                    {
                        comboBox1.Items.Clear();
                        foreach (var d in value)
                        {
                            comboBox1.Items.Add(d);
                        }
                    }));
                else
                {
                    comboBox1.Items.Clear();
                    foreach (var d in value)
                    {
                        comboBox1.Items.Add(d);
                    }
                }
                

               // comboBox1.Items.AddRange(value);
            }
        }

        #endregion

        #region Events
        public event Action<string> SelectedDriveChanege;
        public event Action ComboBoxClicked;
        public event Action<string> MoveToNextDirectory;
        public event Action BackButtonClicked;
        #endregion

        public MInTCPanel()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SelectedDriveChanege!=null)
                SelectedDriveChanege(comboBox1.SelectedItem.ToString());
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (ComboBoxClicked != null)
                ComboBoxClicked();
        }

        public void SetPath(string path, string drive)
        {
            textBox1.Text = path;
        }

        public void SetContent(Item[] items)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate ()
                {
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(items);
                }));
            else
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(items);
            }
        }

        public void SetDrivers(string[] drivers)
        {
            Drives = drivers;
        }

        private void MInTCPanel_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Item item = (Item)listBox1.SelectedItem;
            if (item.TypeOf != Item.Type.DIRECTORY)
                return;
            if(MoveToNextDirectory != null)
                MoveToNextDirectory(item.Path);
            textBox1.Text = item.Path;
        }

        public string SelectedPath() 
        {
            Item item = (Item)listBox1.SelectedItem;
            return item.Path;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if(BackButtonClicked != null)
                BackButtonClicked();
        }
    }
}
