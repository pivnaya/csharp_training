using System;

namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public string Name { get; set; }

        public ProjectData(string name)
        {
            Name = name;
        }

        public int CompareTo(ProjectData other)
        {
            return Name.CompareTo(other.Name);
        }

        public bool Equals(ProjectData other)
        {
            return Name.Equals(other.Name);
        }
    }
}
