namespace DataImporter.Csv;

public class CsvImportResult
{
    public string[] Columns { get; init; }
    public IEnumerable<string[]> Values { get; init; }

    public CsvImportResult(string[] columns, IEnumerable<string[]> values)
    {
        Columns = columns;
        Values = values;
    }
}