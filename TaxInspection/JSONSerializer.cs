
namespace TaxInspection
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.Json;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization.Json;
    using Database_elements;

    public class JSONSerializer
    {
        public static readonly string TaxesFileName = "Taxes.json";
        public static readonly string NaturalPersonsFileName = "NaturalPersons.json";
        public static readonly string JuridicalPersonsFileName = "JuridicalPersons.json";
        public static readonly string TaxesPayedByNaturalPersonFileName = "TaxesPayedByNaturalPersons.json";
        public static readonly string TaxesPayedByJuridicalPersonFileName = "TaxesPayedByJuridicalPersons.json";

        public List<T> LoadDataFromJson<T>(string fileName)
        {
            Stream file = new FileStream(fileName, FileMode.Open);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<T>));

            var elements = (List<T>)serializer.ReadObject(file);
            return elements;
        }

        public void StoreDataToJson<T>(string fileName, IList<T> elements)
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All) };

            string jsonString = JsonSerializer.Serialize(elements, typeof(IList<T>), options);

            File.WriteAllText(fileName, jsonString);
        }
    }
}
