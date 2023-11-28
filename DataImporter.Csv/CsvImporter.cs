namespace DataImporter.Csv;

public static class CsvImporter
{
    
    // Note: This is unnecessarily complicated, and most of the functionality can be achieved with string.Split method
    public static List<string> LoadFromFile(string filePath, char? delimitingCharacter='\u002C')
    {
        var result = new List<string>();
        var delimiter = Convert.ToInt32(delimitingCharacter);
        
        using (var reader = new StreamReader(filePath))
        {
            var endOfFile = false;

            while (!endOfFile)
            {
                var word = string.Empty;
                var next = -1;

                while (next != delimiter)
                {
                    next = reader.Read();

                    if (next < 0)
                    {
                        endOfFile = true;
                        break;
                    }

                    if (next == delimiter)
                    {
                        break;
                    }

                    var c = Convert.ToChar(next);
                    word += c;
                }
                
                result.Add(word);
            }
        }
        
        return result;
    }


    public static CsvImportResult ReadCsvFile(string filePath)
    {
        string[] columns;
        var values = new List<string[]>();
        

        using (var reader = new StreamReader(filePath))
        {
            var header = reader.ReadLine();
            const string separator = ",";
            
            if (string.IsNullOrEmpty(header))
            {
                throw new InvalidDataException("No line found in the csv");
            }
            
            columns = header.Split(separator);
            
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var lineValues = line?.Split(separator);
                
                if (lineValues != null)
                {
                    values.Add(lineValues);
                }
            }
        }

        return new CsvImportResult(columns, values);
    }
}