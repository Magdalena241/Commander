using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_2_B.MVP.View;
namespace lab_2_B.MVP
{
    public class Presenter
    {
        IView view;
        IModel model;
        public Presenter(IView view, IModel model)
        {
            this.view = view;
            this.model = model;

            view.LeftSelectedDriveChanege += ChangeLeftDrive;
            view.RightSelectedDriveChanege += ChangeRightDrive;
            view.GetDriversList += UpdateDriversList;
            model.RemoveLeftDrive += UpdateLeft;
            model.RemoveRightDrive += UpdateRight;
            UpdateLeft();
            UpdateRight();

            view.ChangeLeftPath += ChangeLeftPath;
            view.ChangeRightPath += ChangeRightPath;

            view.LeftBackButtonClicked += LeftBackCLicked;
            view.RightBackButtonClicked += RightBackClicked;

            view.CopyAction += Copy;
            view.MoveAction += Move;

            this.view.Run();
       
        }

        private void UpdateLeft()
        {
            view.SetleftPath(model.LeftCurrentPath, model.LeftCurrentDriver);
            view.SetLeftContent(model.LeftContent);
            view.SetDriverList(model.Drivers);
        }

        private void UpdateRight()
        {
            view.SetRightPath(model.RightCurrentPath, model.RightCurrentDriver);
            view.SetRightContent(model.RightContent);
            view.SetDriverList(model.Drivers);
        }

        private void UpdateDriversList()
        {
            string[] drivers = model.Drivers;
            view.SetDriverList(drivers);
        }

        private void ChangeLeftDrive(string driver)
        {
            model.LeftCurrentDriver = driver;
           // view.SetLeftContent(model.LeftContent);
            UpdateLeft();

        }

        private void ChangeRightDrive(string driver)
        {
            model.RightCurrentDriver = driver;
            // view.SetRightContent(model.RightContent);
            UpdateRight();

        }

        private void ChangeLeftPath(string path)
        {
            model.LeftCurrentPath = path;
            // view.SetLeftContent(model.LeftContent);
            UpdateLeft();

        }

        private void ChangeRightPath(string path)
        {
            model.RightCurrentPath = path;
            //view.SetRightContent(model.RightContent);
            UpdateRight();

        }
        private void RightBackClicked()
        {
            model.BackToPreviousRightPath();
            UpdateRight();
        }
        private void LeftBackCLicked()
        {
            model.BackToPreviousLeftPath();
            UpdateLeft();
        }

        private void Copy(string from, string to)
        {
            model.Copy(from, to);
            UpdateLeft();
            UpdateRight();
        }

        private void Move(string from, string to)
        {
            model.Move(from, to);
            UpdateLeft();
            UpdateRight();
        }
    }
}
