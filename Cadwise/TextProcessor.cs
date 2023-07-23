using System.Text;

namespace Cadwise;

public class TextProcessor
{
    public async Task ProcessFilesAsync(string[] inputFiles, int wordLength, bool removePunctuation)
    {
        await Task.WhenAll(inputFiles.Select(file => ProcessFileAsync(file, wordLength, removePunctuation)));
    } 

    public async Task ProcessFileAsync(string inputFile, int wordLength, bool removePunctuation)
    {
        var outputFile = GetOutputFileName(inputFile);
        var text = await ReadTextFromFileAsync(inputFile);

        text = RemoveShortWords(text, wordLength);
        if (removePunctuation)
            text = RemovePunctuation(text);

        await WriteTextToFileAsync(outputFile, text);
    }

    private string GetOutputFileName(string inputFile) => inputFile + "_processed.txt";

    private async Task<string> ReadTextFromFileAsync(string inputFile)
    {
        using var reader = new StreamReader(inputFile);

        return await reader.ReadToEndAsync();
        //return await reader.ReadBlockAsync(;
    }

    private async Task WriteTextToFileAsync(string outputFile, string text)
    {
        using var writer = new StreamWriter(outputFile, false, Encoding.UTF8);

        await writer.WriteAsync(text);
    }

    private string RemoveShortWords(string text, int wordLength)
    {
        var words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        var filteredWords = words.Where(word => word.Length >= wordLength);
        var processedText = string.Join(" ", filteredWords);

        return processedText;
    }

    private string RemovePunctuation(string text) => 
        new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
}
