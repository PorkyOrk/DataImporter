using DataImporter.Csv;

Console.WriteLine("Program started");

var importDirectory = Directory.GetCurrentDirectory() + "\\ImportFiLes";
var fileNames = Directory.GetFiles(importDirectory);

var imported = new List<List<string>>();


// foreach (var fileName in fileNames)
// {
//     Console.WriteLine($"Importing from file: {fileName}");
//
//     var importedCsv = CsvImporter.LoadFromFile(fileName);
//     imported.Add(importedCsv);
// }


var result = CsvImporter.ReadCsvFile(fileNames[3]);


Console.ReadLine();
