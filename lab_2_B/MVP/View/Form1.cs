using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab_2_B.MVP.Model;
namespace lab_2_B
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mInTCPanel1.Drives = System.IO.Directory.GetLogicalDrives();
            mInTCPanel1.SelectedDriveChanege += MInTCPanel1_SelectedDriveChanege;
            mInTCPanel2.SelectedDriveChanege += MInTCPanel2_SelectedDriveChanege;
            mInTCPanel1.ComboBoxClicked += getDriversList;
            mInTCPanel2.ComboBoxClicked += getDriversList;
            mInTCPanel1.MoveToNextDirectory += MoveLeftToNextDirectory;
            mInTCPanel2.MoveToNextDirectory += MoveRightToNextDirectory;
            mInTCPanel1.BackButtonClicked += LeftBackButtonClicked;
            mInTCPanel2.BackButtonClicked += RightBackButtonClicked;
        }

        public event Action<string> LeftSelectedDriveChanege;
        public event Action<string> RightSelectedDriveChanege;
        public event Action GetDriversList;
        public event Action<string, string> CopyAction;
        public event Action<string, string> MoveAction;
        public event Action<string> ChangeLeftPath;
        public event Action<string> ChangeRightPath;
        public event Action LeftBackClicked;
        public event Action RightBackClicked;

        private void MInTCPanel1_SelectedDriveChanege(string driver)
        {
            if (LeftSelectedDriveChanege != null)
                LeftSelectedDriveChanege(driver);
        }

        private void MInTCPanel2_SelectedDriveChanege(string driver)
        {
            if (RightSelectedDriveChanege != null)
                RightSelectedDriveChanege(driver);
        }

        public void SetStartingPath(string path, string drive)
        {
            SetLeftPath(path, drive);
            SetRightPath(path, drive);
        }

        public void SetLeftPath(string path, string drive)
        {
            mInTCPanel1.SetPath(path, drive);
        }

        public void SetRightPath(string path, string drive)
        {
            mInTCPanel2.SetPath(path, drive);
        }

        public void SetLeftContent(Item[] items)
        {
            mInTCPanel1.SetContent(items);
        }

        public void SetRightContent(Item[] items)
        {
            mInTCPanel2.SetContent(items);
        }

        public void SetDriverList(string[] items)
        {
            mInTCPanel1.Drives = items;
            mInTCPanel2.Drives = items;
        }

        private void getDriversList()
        {
            if (GetDriversList != null)
                GetDriversList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void moveToLeft_Click(object sender, EventArgs e)
        {
            string from = mInTCPanel2.SelectedPath();
            string to = mInTCPanel1.CurrentPath;
            if (!isPathsCorrect(from, to))
            {
                MessageBox.Show("Błąd, nie można przenosić folderu do samego siebie");
                return;
            }
            if (MoveAction != null)
                MoveAction(from, to);
        }

        private void moveToRight_Click(object sender, EventArgs e)
        {
            string to = mInTCPanel2.CurrentPath;
            string from = mInTCPanel1.SelectedPath();
            if (!isPathsCorrect(from, to))
            {
                MessageBox.Show("Błąd, nie można przenosić folderu do samego siebie");
                return;
            }
            if (MoveAction != null)
                MoveAction(from, to);
        }

        private void copyToRight_Click(object sender, EventArgs e)
        {
            string from = mInTCPanel1.SelectedPath();
            string to = mInTCPanel2.CurrentPath;
            if (!isPathsCorrect(from, to))
            {
                MessageBox.Show("Błąd, nie można kopiować folderu do samego siebie");
                return;
            }
            if (CopyAction != null)
                CopyAction(from, to);
        }

        private void copyToLeft_Click(object sender, EventArgs e)
        {
            string to = mInTCPanel1.CurrentPath;
            string from = mInTCPanel2.SelectedPath();
            if (!isPathsCorrect(from, to))
            {
                MessageBox.Show("Błąd, nie można kopiować folderu do samego siebie");
                return;
            }
            if (CopyAction != null)
                CopyAction(from, to);
        }

        private bool isPathsCorrect(string from, string to)
        {
            return !to.Contains(from);
        }

        private void errorPaths()
        {
            
        }

        private void MoveLeftToNextDirectory(string path)
        {
            if (ChangeLeftPath != null)
                ChangeLeftPath(path);
        }

        private void MoveRightToNextDirectory(string path)
        {
            if (ChangeRightPath != null)
                ChangeRightPath(path);
        }

        private void RightBackButtonClicked()
        {
            if (RightBackClicked != null)
                RightBackClicked();
        }

        private void LeftBackButtonClicked()
        {
            if (LeftBackClicked != null)
                LeftBackClicked();
        }
    }
}
