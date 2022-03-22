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
            ResultLabel.Text = "Текст с результатом классификации";
        }
    }
}