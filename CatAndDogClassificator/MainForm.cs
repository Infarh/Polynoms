namespace CatAndDogClassificator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadPictureButton_OnClick(object sender, EventArgs e)
        {
            //MessageBox.Show("Загрузка изображения");
            //ResultLabel.Text = "Текст с результатом классификации";

            var open_file_dialog = new OpenFileDialog();
            open_file_dialog.Title = "Выбор файла для классификации";
            open_file_dialog.Filter = "Файлы картинок (*.jpg)|*.jpg|Все файлы (*.*)|*.*";

            if (open_file_dialog.ShowDialog() != DialogResult.OK)
                return;

            ResultLabel.Text = "...";
            ResultPictureBox.Image = null;

            var file_path = open_file_dialog.FileName;
            if (!File.Exists(file_path))
            {
                MessageBox.Show("Выбранный файл отсутствует", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ResultPictureBox.Load(file_path);

            var image_bytes = File.ReadAllBytes(file_path);

            var sample_data = new CatAndDogClassificatorModel.ModelInput
            {
                ImageSource = image_bytes,
            };

            ResultLabel.Text = "Классификация ...";
            var prediction_result = CatAndDogClassificatorModel.Predict(sample_data);

            var label = prediction_result.PredictedLabel;
            var score = prediction_result.Score.Max();

            ResultLabel.Text = $"{label} : {score:p2}";

        }
    }
}