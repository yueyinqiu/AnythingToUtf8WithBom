using System.Text;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

Console.Write("Directory (e.g. C:/Users/yueyi/Documents): ");
var directoryInput = Console.ReadLine() ?? "";
Console.Write("Pattern (e.g. *.txt): ");
var patternInput = Console.ReadLine() ?? "";
Console.Write("Input Encoding (e.g. GB2312): ");
var inputEncodingInput = Console.ReadLine() ?? "";

var inputEncoding = Encoding.GetEncoding(inputEncodingInput);
var outputEncoding = new UTF8Encoding(true);
var files = Directory.GetFiles(directoryInput, patternInput, SearchOption.AllDirectories);

Console.WriteLine();
Console.WriteLine($"Encoding: ");
Console.WriteLine($"    {inputEncoding.EncodingName} -> {outputEncoding.EncodingName}");
Console.WriteLine($"Files: ");
foreach (var file in files)
    Console.WriteLine($"    {file}");
Console.Write($"Enter anything to continue: ");
_ = Console.ReadLine();

foreach (var file in files)
{
    Console.WriteLine($"Dealing with {file} ...");
    var text = await File.ReadAllTextAsync(file, inputEncoding);
    await File.WriteAllTextAsync(file, text, outputEncoding);
}
