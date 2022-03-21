using System;
using System.Collections.Generic;
using System.Text;

namespace T01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        private void Validate(string name, double value)
        {
            if (value <= 0d)
            {
                throw new ArgumentException($"{name} cannot be zero or negative.");
            }
        }

        public override string ToString()
        {
            string result = $"Surface Area - {(2 * Length * Width + 2 * Width * Height + 2 * Height * Length):F2}\n"
                +$"Lateral Surface Area - {(2 * Height) * (Width + Length):F2}\n"
                + $"Volume - {(Length*Width*Height):F2}";
            return result;
        }

        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                Validate("Length", value);
                length = value;
            }
        }
        public double Height 
        {
            get
            {
                return height;
            }
            set
            {
                Validate("Height", value);
                height = value;
            }
        }
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                Validate("Width", value);
                width = value;
            }
        }

    }
}
