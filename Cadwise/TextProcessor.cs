using System.Text;

namespace Cadwise;

public class TextProcessor
{
    public async Task ProcessFilesAsync(string[] inputFiles, int wordLength, bool removePunctuation)
    {
        await Task.WhenAll(inputFiles.Select(file => ProcessFileAsync(file, wordLength, removePunctuation)));
    }

    //public async Task ProcessFileAsync(string inputFile, int wordLength, bool removePunctuation)
    //{
    //    var outputFile = GetOutputFileName(inputFile);
    //    var text = await ReadTextFromFileAsync(inputFile);

    //    text = RemoveShortWords(text, wordLength);
    //    if (removePunctuation)
    //        text = RemovePunctuation(text);

    //    await WriteTextToFileAsync(outputFile, text);
    //}

    public async Task ProcessFileAsync(string inputFile, int wordLength, bool removePunctuation)
    {
        string outputFile = GetOutputFileName(inputFile);

        using var reader = new StreamReader(inputFile);
        using var writer = new StreamWriter(outputFile, false, Encoding.UTF8);

        char[] buffer = new char[GetBufferSize(inputFile)]; // Размер буфера чтения
        int bytesRead;

        while ((bytesRead = await reader.ReadBlockAsync(buffer, 0, buffer.Length)) > 0)
        {
            string textChunk = new string(buffer, 0, bytesRead);

            textChunk = RemoveShortWords(textChunk, wordLength);
            if (removePunctuation)
                textChunk = RemovePunctuation(textChunk);

            await writer.WriteAsync(textChunk);
        }

        await writer.FlushAsync(); // Убеждаемся, что все данные записаны на диск
    }

    private int GetBufferSize(string inputFile)
    {
        long fileSize = new FileInfo(inputFile).Length;
        const int maxBlockSize = 4096 * 1024; // Максимальный размер блока (например, 4 MB)

        int optimalBlockSize = (int)Math.Min(maxBlockSize, fileSize / 10); // Находим оптимальный размер блока (10% от размера файла)

        // Если оптимальный размер блока меньше минимально допустимого значения (например, 4096 символов),
        // устанавливаем его в минимальное значение.
        return Math.Max(4096, optimalBlockSize);
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
