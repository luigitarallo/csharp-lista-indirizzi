using System.IO;
using System.Xml.Linq;

namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\file-esercizi-NET\\addresses.csv";
            string path2 = "C:\\file-esercizi-NET\\new-file.csv";
            var addresses = ReadCSV(path);
            foreach (var address in addresses)
            {
                Console.WriteLine(address.ToString());
            }
            WriteAddressesInNewCSV(addresses, path2);
        }

        public static List<Address> ReadCSV(string path)
        {
            List<Address> addresses = new List<Address>();

            var stream = File.OpenText(path);
            int i = 0;
            while(stream.EndOfStream == false)
            {
                var line = stream.ReadLine();
                i++;
                if (i <= 1)
                    continue;
                try
                {
                    var dati = line.Split(',');
                    foreach (var field in dati)
                    {
                        if (string.IsNullOrEmpty(field))
                        {
                            throw new Exception($"Error in CSV file at line {i}: One or more field are empty.");
                        }
                    }
                    string name = dati[0];
                    string surname = dati[1];
                    string street = dati[2];
                    string city = dati[3];
                    string province = dati[4];
                    int postalCode = int.Parse(dati[5]);

                    Address address = new Address(name, surname, street, city, province, postalCode);
                    addresses.Add(address); 
                    
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Error in CSV file at line {i}: The Postal Code is not a valid number. {e.Message}");
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine($"Error in CSV file at line {i}: The index is not valid. {e.Message}");
                }
                catch(Exception e)
                { 
                    Console.WriteLine($"Error in CSV file at line {i}. {e.Message}");
                }
            }
            stream.Dispose();
            return addresses;
        }

        /*------------------------------------------
         BONUS: scrittura dei dati su un altro file
        -------------------------------------------*/
        public static void WriteAddressesInNewCSV(List<Address> addresses, string path )
        {
            using StreamWriter stream = File.CreateText(path);
            foreach(var address in addresses)
            {
                stream.WriteLine(address.ToString());
            }
        }
    }
}
