namespace Cadwise
{
    public partial class MainForm : Form
    {
        private readonly TextProcessor textProcessor;
        public MainForm()
        {
            InitializeComponent();

            textProcessor = new TextProcessor();

            AllowDrop = true;
            listBoxFiles.AllowDrop = true;

            DragEnter += MainForm_DragEnter;
            DragDrop += MainForm_DragDrop;

            listBoxFiles.DragEnter += MainForm_DragEnter;
            listBoxFiles.DragDrop += MainForm_DragDrop;

            buttonBrowse.Click += ButtonBrowse_Click;
            buttonProcess.Click += ButtonProcess_Click;
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            listBoxFiles.Items.Clear();
            listBoxFiles.Items.AddRange(files);
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog()
            {
                Multiselect = true
            };
        
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                listBoxFiles.Items.Clear();
                listBoxFiles.Items.AddRange(openFileDialog.FileNames);
            }
        }

        private async void ButtonProcess_Click(object sender, EventArgs e)
        {
            var wordLength = (int)numericUpDownWordLength.Value;
            var removePunctuation = checkBoxRemovePunctuation.Checked;
            var filesToProcess = listBoxFiles.Items.OfType<string>().ToArray();

            try
            {
                await textProcessor.ProcessFilesAsync(filesToProcess, wordLength, removePunctuation);

                MessageBox.Show("Обработка завершена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}