using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Management;
namespace lab_2_B.MVP.Model
{
    public class Model : IModel
    {
     
        public Model()
        {
            setLeftDefault();
            setRightDefault();

            //USB - wkładanie i wyjmowanie dysku (pendriva)
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2 or EventType = 3");
            watcher.EventArrived += (s, e) =>
            {
                string driveName = e.NewEvent.Properties["DriveName"].Value.ToString()+"\\";
                if (leftCurrentDriver == driveName && RemoveLeftDrive != null)
                {
                    setLeftDefault();
                    RemoveLeftDrive();
                }
                if (rightCurrentDriver == driveName && RemoveRightDrive != null)
                {
                    setRightDefault();
                    RemoveRightDrive();
                }
            };
            watcher.Query = query;
            watcher.Start();
        }

        private ManagementEventWatcher watcher = new ManagementEventWatcher();
        

        private string leftCurrentDriver;
        private string rightCurrentDriver;
        public string LeftCurrentDriver { get => leftCurrentDriver; set
            {
                leftCurrentDriver = value;
                LeftCurrentPath = value;
            }
        }
        public string RightCurrentDriver { get=> rightCurrentDriver; set
            {
                rightCurrentDriver = value;
                RightCurrentPath = value;
            }
        }
        public string RightCurrentPath { get; set; }
        public string LeftCurrentPath { get; set; }


        

        public string[] Drivers { get {
                List<string> drivers = new List<string>();
                foreach (var drive in DriveInfo.GetDrives())
                    if (drive.DriveType == DriveType.CDRom && drive.IsReady == false)
                        continue;
                    else
                        drivers.Add(drive.Name);
                return drivers.ToArray();
            } }

        public Item[] LeftContent
        {
            get
            {
                return PathContent(LeftCurrentPath);
            }
        }

        public Item[] RightContent
        {
            get
            {
                return PathContent(RightCurrentPath);
            }
        }

        

        private Item[] PathContent(string path)
        {
            string[] files = Directory.GetFiles(path);
            string[] directories = Directory.GetDirectories(path);
            Item[] items = new Item[files.Length + directories.Length];
            int i = 0;
            for (int j = 0; j < files.Length; j++, i++)
                items[i] = new Item(files[j], Item.Type.FILE);
            for (int j = 0; j < directories.Length; i++, j++)
                items[i] = new Item(directories[j], Item.Type.DIRECTORY);
            return items;
        }
        private void setLeftDefault()
        {
            LeftCurrentPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            LeftCurrentDriver = Path.GetPathRoot(LeftCurrentPath);
            LeftCurrentPath = LeftCurrentDriver;
        }

        private void setRightDefault()
        {
            RightCurrentPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            RightCurrentDriver = Path.GetPathRoot(RightCurrentPath);
            RightCurrentPath = RightCurrentDriver;
        }


        public event Action RemoveLeftDrive;
        public event Action RemoveRightDrive;

        public void setLeftPath(string path)
        {
            LeftCurrentPath = path;
        }

        public void BackToPreviousLeftPath()
        {
            if(LeftCurrentPath.Length >3)
            LeftCurrentPath = Directory.GetParent(LeftCurrentPath).ToString();

        }

        public void BackToPreviousRightPath()
        {
            if (RightCurrentPath.Length > 3)
                RightCurrentPath =  Directory.GetParent(RightCurrentPath).ToString();

        }

        public void Copy(string from, string to)
        {
            if (isDirectory(from))
            {
                DirectoryInfo dir = new DirectoryInfo(from);
                CopyDirectory(from, to+"\\" + dir.Name);
            }
            else
            {
                FileInfo file = new FileInfo(from);
                File.Copy(from, to + "\\" + file.Name);
            }
        }

        public void Move(string from, string to)
        {
            if (isDirectory(from))
            {
                DirectoryInfo dir = new DirectoryInfo(from);
                Directory.Move(from, to+"\\"+dir.Name);
            }
            else
            {
                FileInfo file = new FileInfo(from);
                File.Move(from, to+"\\"+file.Name);
            }
        }

        private bool isDirectory(string path)
        {
            FileAttributes attr = File.GetAttributes(path);

            //detect whether its a directory or file
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                return true;
            else
                return false;
        }
        private void CopyDirectory(string source, string target)
        {
            var diSource = new DirectoryInfo(source);
            var diTarget = new DirectoryInfo(target);

            CopyAll(diSource, diTarget);
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}
