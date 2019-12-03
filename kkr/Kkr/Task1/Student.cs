namespace Task1
{
    internal sealed class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }
        public string GroupName { get; set; }

        public override string ToString()
        {
            return $"{Id}. {FirstName} {LastName}, {YearOfBirth}, {GroupName}";
        }
    }
}