using System;
#pragma warning disable 659

namespace Task2
{
    internal sealed class Paragraph : IEquatable<Paragraph>
    {
        public string Text { get; set; }
        
        public bool Equals(Paragraph other)
        {
            return other != null &&
                other.Text == Text;
        }

        public override bool Equals(object obj)
        {
            return obj is Paragraph p && Equals(p);
        }

        public override string ToString()
        {
            return Text;
        }
    }
}