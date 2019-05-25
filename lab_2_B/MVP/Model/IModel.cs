using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_2_B.MVP.Model;

namespace lab_2_B
{
    public interface IModel
    {
        string[] Drivers { get; }
        Item[] RightContent { get; }
        Item[] LeftContent { get; }

        string LeftCurrentDriver { get; set; }
        string RightCurrentDriver { get; set; }
        string RightCurrentPath { get; set; }
        string LeftCurrentPath { get; set; }
        event Action RemoveLeftDrive;
        event Action RemoveRightDrive;
        void BackToPreviousLeftPath();
        void BackToPreviousRightPath();

        void Copy(string from, string to);
        void Move(string from, string to);
    }
}
