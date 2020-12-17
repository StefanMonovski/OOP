using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Computers
{
    public class Computer
    {
        private string name;
        private List<Part> parts;

        public Computer(string name)
        {
            Name = name;
            parts = new List<Part>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name), "Name cannot be null or empty!");
                }
                name = value;
            }
        }

        public IReadOnlyCollection<Part> Parts => parts.AsReadOnly();

        public decimal TotalPrice => Parts.Sum(x => x.Price);

        public void AddPart(Part part)
        {
            if (part == null)
            {
                throw new InvalidOperationException("Cannot add null!");
            }
            parts.Add(part);
        }

        public bool RemovePart(Part part) => parts.Remove(part);

        public Part GetPart(string partName) => Parts.FirstOrDefault(x => x.Name == partName);
    }
}
