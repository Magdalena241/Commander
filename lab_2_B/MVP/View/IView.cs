using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_2_B.MVP.Model;

namespace lab_2_B.MVP.View
{
    public interface IView
    {
        event Action<string> LeftSelectedDriveChanege;
        event Action<string> RightSelectedDriveChanege;
        event Action GetDriversList;
        event Action<string> ChangeRightPath;
        event Action<string> ChangeLeftPath;
        event Action LeftBackButtonClicked;
        event Action RightBackButtonClicked;
        event Action<string, string> CopyAction;
        event Action<string, string> MoveAction;
        void Run();
        void SetStartingPath(string path, string drive);
        void SetRightPath(string path, string drive);
        void SetleftPath(string path, string drive);
        void SetLeftContent(Item[] items);
        void SetRightContent(Item[] items);
        void SetDriverList(string[] drivers);
    }
}
