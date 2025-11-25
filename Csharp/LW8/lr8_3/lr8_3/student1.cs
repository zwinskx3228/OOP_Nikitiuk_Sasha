namespace lr8_3
{
    public partial class Student
    {
        public string Name { get; set; }
        public int Course { get; set; }

        partial void Validate();
    }
}