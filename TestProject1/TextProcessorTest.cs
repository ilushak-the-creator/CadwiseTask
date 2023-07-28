using Cadwise;

namespace TestProject1;

[TestFixture]
public class TextProcessorTests
{

    [Test]
    public async Task ProcessFile_SingleInput_SuccesfullyProcessed()
    {
        var inputFile = "testInput.txt";
        var outputFile = "testInput.txt_processed.txt";

        File.WriteAllText(inputFile, "This is test input file!");

        var textProcessor = new TextProcessor();

        try
        {
            await textProcessor.ProcessFileAsync(inputFile, 0, false);

            Assert.IsTrue(File.Exists(outputFile), "Выходной файл не был создан.");
            var outputText = File.ReadAllText(outputFile);
            Assert.AreEqual("This is test input file!", outputText, "Текст не был обработан корректно");
        }
        finally
        {
            File.Delete(inputFile);
            File.Delete(outputFile);
        }
    }

    [Test]
    public async Task ProcessFiles_MultipleInputs_SuccessfullyProcessed()
    {
        var inputFiles = new string[]
        {
        "testInput1.txt",
        "testInput2.txt"
        };

        File.WriteAllText(inputFiles[0], "This is test input file 1.");
        File.WriteAllText(inputFiles[1], "This is test input file 2.");

        TextProcessor textProcessor = new TextProcessor();

        try
        {
            await textProcessor.ProcessFilesAsync(inputFiles, 0, false);

            Assert.IsTrue(File.Exists(inputFiles[0] + "_processed.txt"), "Выходной файл 1 не был создан.");
            Assert.IsTrue(File.Exists(inputFiles[1] + "_processed.txt"), "Выходной файл 2 не был создан.");
            var outputText1 = File.ReadAllText(inputFiles[0] + "_processed.txt");
            var outputText2 = File.ReadAllText(inputFiles[1] + "_processed.txt");
            Assert.AreEqual("This is test input file 1.", outputText1, "Текст файла 1 был изменен некорректно.");
            Assert.AreEqual("This is test input file 2.", outputText2, "Текст файла 2 был изменен некорректно.");
        }
        finally
        {
            File.Delete(inputFiles[0]);
            File.Delete(inputFiles[1]);
            File.Delete(inputFiles[0] + "_processed.txt");
            File.Delete(inputFiles[1] + "_processed.txt");
        }
    }

    [Test]
    public async Task ProcessFile_ShouldRemoveWordsLessInputLength_SuccessfullyProcessed()
    {
        var inputFile = "testInput.txt";
        var outputFile = "testInput.txt_processed.txt";

        File.WriteAllText(inputFile, "This is a test input file. Short words will be removed!");

        var textProcessor = new TextProcessor();

        try
        {
            await textProcessor.ProcessFileAsync(inputFile, 4, false);

            Assert.IsTrue(File.Exists(outputFile), "Выходной файл не был создан.");
            var outputText = File.ReadAllText(outputFile);
            Assert.AreEqual("This test input file. Short words will removed!", outputText, "Текст не был обработан корректно.");
        }
        finally
        {
            File.Delete(inputFile);
            File.Delete(outputFile);
        }
    }
    
    [Test]
    public async Task ProcessFile_ShouldRemovePunctuation_SuccessfullyProcessed()
    {
        var inputFile = "testInput.txt";
        var outputFile = "testInput.txt_processed.txt";

        File.WriteAllText(inputFile, "This is a test input file. Punctuation will be removed!,. :;?");

        var textProcessor = new TextProcessor();

        try
        {
            await textProcessor.ProcessFileAsync(inputFile, 0, true);

            Assert.IsTrue(File.Exists(outputFile), "Выходной файл не был создан.");
            var outputText = File.ReadAllText(outputFile);
            Assert.AreEqual("This is a test input file Punctuation will be removed ", outputText, "Текст не был обработан корректно.");
        }
        finally
        {
            File.Delete(inputFile);
            File.Delete(outputFile);
        }
    }
}