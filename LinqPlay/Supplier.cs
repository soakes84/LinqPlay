using System;
namespace LinqPlay
{
    internal class Supplier
    {
        private string name;
        private string district;
        private int age;

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

        public string District
        {
            get
            {
                return this.district;
            }
            set
            {
                this.district = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public Supplier(string name, string district, int age)
        {
            this.Name = name;
            this.District = district;
            this.Age = age;
        }
       
    }
}
