using System.Xml.Serialization;

namespace Accounts.Data.Xml
{
    public static class Serializer
    {


        public static void Save( this Organization organization, string filename )
        {
            var formater = new XmlSerializer(typeof(Organization));
            using (var stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            { 
                formater.Serialize(stream, organization);
            }
        }

        public static Organization Load( string filename )
        {
            var formater = new XmlSerializer(typeof(Organization));
            using ( var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                return formater.Deserialize(stream) as Organization;
            }
        }
    }
}
