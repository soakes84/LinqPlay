using System.Runtime.InteropServices;
namespace LinqPlay
{
    internal class Person
    {
        private string name;
        private int height;
        private int weight;

        private Gender gender;

        public string Name
        {
            get
            {
                return this.name;
            }
            set 
            {
                this.name = value;
            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }



        public Gender Gender { get; set; }

        public Person(string name, int weight, int height, Gender gender)
        {
            this.Name = name;
            this.Weight = weight;
            this.Height = height;
            this.Gender = gender;
        }
    }

    internal enum Gender
    {
        Male,
        Female
    }
}