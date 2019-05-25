using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab_2_B.MVP.Model;

namespace lab_2_B.MVP.View
{
    public class FormView: IView
    {
        private Form1 form;
        public FormView()
        {
            form = new Form1();
            form.LeftSelectedDriveChanege += leftSelectedDriveChanege;
            form.RightSelectedDriveChanege += rightSelectedDriveChanege;
            form.ChangeLeftPath += changeLeftPath;
            form.ChangeRightPath += changeRightPath;
            form.LeftBackClicked += leftBackButtonClicked;
            form.RightBackClicked += rightBackButtonClicked;
            form.MoveAction += moveAction;
            form.CopyAction += copyAction;
        }

        public event Action<string> LeftSelectedDriveChanege;
        public event Action<string> RightSelectedDriveChanege;
        public event Action GetDriversList;
        public event Action<string> ChangeRightPath;
        public event Action<string> ChangeLeftPath;
        public event Action<string, string> CopyAction;
        public event Action<string, string> MoveAction;
        public event Action LeftBackButtonClicked;
        public event Action RightBackButtonClicked;


        public void Run()
        {
            Application.Run(form);
        }

        public void SetLeftContent(Item[] items)
        {
            form.SetLeftContent(items);
        }

        public void SetleftPath(string path, string drive)
        {
            form.SetLeftPath(path, drive);
        }

        public void SetRightContent(Item[] items)
        {
            form.SetRightContent(items);
        }

        public void SetRightPath(string path, string drive)
        {
            form.SetRightPath(path, drive);
        }

        public void SetStartingPath(string path, string drive)
        {
            form.SetStartingPath(path, drive);
        }

        private void leftSelectedDriveChanege(string driver)
        {
            if (LeftSelectedDriveChanege != null)
                LeftSelectedDriveChanege(driver);
        }

        private void rightSelectedDriveChanege(string driver)
        {
            if (RightSelectedDriveChanege != null)
                RightSelectedDriveChanege(driver);
        }

        void getDriversList()
        {
            if (GetDriversList != null)
                GetDriversList();
        }

        public void SetDriverList(string[] drivers)
        {
            form.SetDriverList(drivers);
        }

        private void changeRightPath(string path)
        {
            if (ChangeRightPath != null)
                ChangeRightPath(path);
        }
        private void changeLeftPath(string path)
        {
            if (ChangeLeftPath != null)
                ChangeLeftPath(path);
        }

        private void leftBackButtonClicked()
        {
            if (LeftBackButtonClicked != null)
                LeftBackButtonClicked();
        }
        private void rightBackButtonClicked()
        {
            if (RightBackButtonClicked != null)
                RightBackButtonClicked();
        }

        private void moveAction(string from, string to)
        {
            if (MoveAction != null)
                MoveAction(from, to);
        }

        private void copyAction(string from, string to)
        {
            if (CopyAction != null)
                CopyAction(from, to);
        }
    }
}
