using EduCare.DesignPatterns.Composite.Base;

namespace EduCare.DesignPatterns.Composite.Models
{
    public class File : IStructure
    {
        public string Name { get; set; }

        public IStructure Parent { get; set; }

        public string GetPath()
        {
            return GetParentPath(Parent, Name);
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
