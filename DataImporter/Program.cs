using DataImporter.Csv;

Console.WriteLine("Program started");

var importDirectory = Directory.GetCurrentDirectory() + "\\ImportFiLes";
var fileNames = Directory.GetFiles(importDirectory);


var result = CsvImporter.ReadCsvFile(fileNames[0]); 




// Print in console in a slightly fancy way
var separator = " | ";

var header = separator;
foreach (var c in result.Columns)
{
    header += c + separator;
}
Console.WriteLine(header);

foreach (var vals in result.Values)
{
    var line = separator;
    foreach (var v in vals)
    {
        line += v + separator;
    }
    Console.WriteLine(line);
}



// Keep console open until user input
Console.ReadLine();
