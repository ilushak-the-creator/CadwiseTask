using Cadwise;

namespace CadwiseTest
{
    [TestFixture]
    public class TextProcessorTest
    {
        [Test]
        public async Task ProcessFile_ValidInput_SuccessfullyProcessed()
        {
            // Arrange
            string inputFile = "testInput.txt";
            string outputFile = "testInput.txt.processed.txt";

            // Создаем файл с текстом для тестирования
            File.WriteAllText(inputFile, "This is a test input file. Short words will be removed!");

            // Создаем экземпляр TextProcessor
            TextProcessor textProcessor = new TextProcessor();

            try
            {
                // Act
                await textProcessor.ProcessFileAsync(inputFile, 4, true);

                // Assert
                Assert.IsTrue(File.Exists(outputFile), "Выходной файл не был создан.");
                string outputText = File.ReadAllText(outputFile);
                Assert.AreEqual("This test input file. Short words removed!", outputText, "Текст не был обработан корректно.");
            }
            finally
            {
                // Чистим после теста
                File.Delete(inputFile);
                File.Delete(outputFile);
            }
        }

        [Test]
        public async Task ProcessFiles_MultipleInputs_SuccessfullyProcessed()
        {
            // Arrange
            string[] inputFiles = new string[]
            {
            "testInput1.txt",
            "testInput2.txt"
            };

            // Создаем файлы с текстом для тестирования
            File.WriteAllText(inputFiles[0], "This is test input file 1.");
            File.WriteAllText(inputFiles[1], "This is test input file 2.");

            // Создаем экземпляр TextProcessor
            TextProcessor textProcessor = new TextProcessor();

            try
            {
                // Act
                await textProcessor.ProcessFilesAsync(inputFiles, 0, false);

                // Assert
                Assert.IsTrue(File.Exists(inputFiles[0] + ".processed.txt"), "Выходной файл 1 не был создан.");
                Assert.IsTrue(File.Exists(inputFiles[1] + ".processed.txt"), "Выходной файл 2 не был создан.");
                string outputText1 = File.ReadAllText(inputFiles[0] + ".processed.txt");
                string outputText2 = File.ReadAllText(inputFiles[1] + ".processed.txt");
                Assert.AreEqual("This is test input file 1.", outputText1, "Текст файла 1 был изменен некорректно.");
                Assert.AreEqual("This is test input file 2.", outputText2, "Текст файла 2 был изменен некорректно.");
            }
            finally
            {
                // Чистим после теста
                File.Delete(inputFiles[0]);
                File.Delete(inputFiles[1]);
                File.Delete(inputFiles[0] + ".processed.txt");
                File.Delete(inputFiles[1] + ".processed.txt");
            }
        }
    }
}
