using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    public class Address
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street {  get; set; }
        public string City { get; set; }
        public string Province {  get; set; }
        public int PostalCode { get; set; }

        public Address(string name, string surname, string street, string city, string province, int postalCode)
        {
            this.Name = name;
            this.Surname = surname;
            this.Street = street;
            this.City = city;
            this.Province = province;
            this.PostalCode = postalCode;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, Street: {Street}, City: {City}, Province: ({Province}), Postal Code: {PostalCode}";
        }
    }
}
