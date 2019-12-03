using System;
using System.Collections.Generic;
using Bogus;

#pragma warning disable 659

namespace Task2
{
    internal sealed class Text : IEquatable<Text>
    {
        private readonly List<Paragraph> _paragraphs;

        public Text(int capacity, int count)
        {
            _paragraphs = new List<Paragraph>(capacity);
            
            if (count > 0)
                _paragraphs.AddRange(Faker.Generate(count));
        }

        public static readonly Faker<Paragraph> Faker = new Faker<Paragraph>()
            .RuleFor(x => x.Text, f => f.Lorem.Sentence(5));
        
        public string Title { get; set; }
        
        public bool Equals(Text other)
        {
            return other != null &&
                other.Title == Title &&
                other._paragraphs.Count == _paragraphs.Count &&
                other._paragraphs.Capacity == _paragraphs.Capacity &&
                string.Join(string.Empty, _paragraphs) == string.Join(string.Empty, other._paragraphs);
        }

        public override bool Equals(object obj)
        {
            return obj is Text t && Equals(t);
        }

        public override string ToString()
        {
            return $"Title: {Title}{Environment.NewLine}{string.Join(Environment.NewLine, _paragraphs)}";
        }

        public void AddParagraphs(IEnumerable<Paragraph> paragraphs)
        {
            _paragraphs.AddRange(paragraphs);
        }
    }
}