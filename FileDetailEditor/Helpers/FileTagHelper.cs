using System.IO;
using System.Text;

namespace FileDetailEditor.Helpers
{
    internal static class FileTagHelper
    {

        private static List<string> importantProperties = new List<string>
        {
            "Title",
            "Artists",
            "Genres",
            "Album",
            "Performers",
            "Year",
            "Track"

        };

        public static Dictionary<string, object?> GetTagsFromFile(FileInfo fileInfo) => GetTagsFromFile(fileInfo.FullName);

        public static Dictionary<string, object?> GetTagsFromFile(string pathFile)
        {
            var tags = new Dictionary<string, object?>();

            TagLib.File? file;

            try
            {
                file = TagLib.File.Create(pathFile);
            }
            catch
            {
                return tags;
            }

            if (file == null) return tags;

            var properties = file.Tag.GetType().GetProperties();

            foreach (var prop in properties.Where(p => importantProperties.Contains(p.Name)))
            {

                if (prop.PropertyType == typeof(string))
                    tags.Add(prop.Name, prop.GetValue(file.Tag, null));
                if (prop.PropertyType == typeof(string[]))
                {
                    var values = (string[]?)prop.GetValue(file.Tag, null);
                    if (values != null && values.Length > 0)
                    {
                        var valuesBuilder = new StringBuilder();
                        foreach (var value in values)
                        {
                            valuesBuilder.AppendLine(value);
                        }

                        tags.Add(prop.Name, valuesBuilder.ToString());
                    }
                }
            }




            return tags;
        }




    }
}
