using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace lab_2_B.MVP.Model
{
    public class Item
    {
        public Item(string path, Type type)
        {
            Path = path;
            Name = System.IO.Path.GetFileName(Path);
            TypeOf = type;
        }
        public enum Type { DIRECTORY, FILE }
        public Type TypeOf { get; private set; }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public override string ToString()
        {
            string text;
            if (TypeOf == Type.DIRECTORY)
                text = "[D] " + Name;
            else
                text = "[F] " + Name;
            return text;
        }
    }
}
