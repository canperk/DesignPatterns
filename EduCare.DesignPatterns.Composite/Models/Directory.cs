using EduCare.DesignPatterns.Composite.Base;
using System.Collections.Generic;

namespace EduCare.DesignPatterns.Composite.Models
{
    public class Directory : IStructure
    {
        private List<IStructure> _content;
        public Directory() : this("New Folder")
        {

        }
        public Directory(string name)
        {
            _content = new List<IStructure>();
            Name = name;
        }
        public string Name { get; set; }

        public IStructure Parent { get; set; }

        public string GetPath()
        {
            return GetParentPath(Parent, Name);
        }

        public void Add(IStructure structure)
        {
            structure.Parent = this;
            _content.Add(structure);
        }

        private string GetParentPath(IStructure str, string path)
        {
            var p = path;
            if (str != null)
            {
                p = $"{str.Name}/{p}";
                str = str.Parent;
                if (str != null)
                    p = GetParentPath(str, p);
            }
            return p;
        }
    }
}
