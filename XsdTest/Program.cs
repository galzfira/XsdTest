using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Generated;


public class Program
{
    static void Main()
    {
        // Load the XML file
        string xmlFilePath = Path.Join("Data", "clients.xml");



        string xmlData  = File.ReadAllText(xmlFilePath);



        XmlSerializer serializer = new XmlSerializer(typeof(Clients));
        using (StringReader reader = new StringReader(xmlData))
        {
            Clients clients = (Clients)serializer.Deserialize(reader);

            // Access and use the deserialized objects
            foreach (Client client in clients.Client)
            {
                Console.WriteLine($"ID: {client.id}, Name: {client.name}");
            }
        }


        Clients clientsToSerialize = new Clients
        {
            Client = new Client[]
        {
            new Client { id = 4, name = "Alice" },
            new Client { id= 5, name = "Bob" },
            new Client { id= 6, name = "Eve" }
        }
        };

        using (StringWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, clientsToSerialize);
            string serializedXml = writer.ToString();
            Console.WriteLine(serializedXml);
        }


    }
}