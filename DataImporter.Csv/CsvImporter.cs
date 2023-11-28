namespace DataImporter.Csv;

public static class CsvImporter
{
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