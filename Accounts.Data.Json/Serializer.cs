
using System.Text.Json;

namespace Accounts.Data.Json
{
    public static class Serializer
    {
        public static void Save(Organization organization, string filename)
        {
            var options = new JsonSerializerOptions { IncludeFields = true, WriteIndented = true };
            File.WriteAllText( filename, JsonSerializer.Serialize(organization, options) );
        }

        public static Organization Load(string filename)
        {
            return JsonSerializer.Deserialize<Organization>(File.ReadAllText(filename));
        }

    }
}