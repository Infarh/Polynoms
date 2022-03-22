namespace CatAndDogClassificator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadPictureButton = new System.Windows.Forms.Button();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.ResultPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ResultPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadPictureButton
            // 
            this.LoadPictureButton.Location = new System.Drawing.Point(12, 12);
            this.LoadPictureButton.Name = "LoadPictureButton";
            this.LoadPictureButton.Size = new System.Drawing.Size(141, 37);
            this.LoadPictureButton.TabIndex = 0;
            this.LoadPictureButton.Text = "Загрузка изображения";
            this.LoadPictureButton.UseVisualStyleBackColor = true;
            this.LoadPictureButton.Click += new System.EventHandler(this.LoadPictureButton_OnClick);
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(159, 23);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(150, 15);
            this.ResultLabel.TabIndex = 1;
            this.ResultLabel.Text = "Результат классификации";
            // 
            // ResultPictureBox
            // 
            this.ResultPictureBox.Location = new System.Drawing.Point(12, 55);
            this.ResultPictureBox.Name = "ResultPictureBox";
            this.ResultPictureBox.Size = new System.Drawing.Size(776, 383);
            this.ResultPictureBox.TabIndex = 2;
            this.ResultPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ResultPictureBox);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.LoadPictureButton);
            this.Name = "MainForm";
            this.Text = "Классификатор";
            ((System.ComponentModel.ISupportInitialize)(this.ResultPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button LoadPictureButton;
        private Label ResultLabel;
        private PictureBox ResultPictureBox;
    }
}