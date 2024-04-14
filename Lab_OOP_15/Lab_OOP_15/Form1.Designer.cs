using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab_OOP_15
{
    partial class Form1
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
            ThreadPriorityGroupBox = new GroupBox();
            SavePriorityThreadButton = new Button();
            ChoosePriorityThreadLabel = new Label();
            ChooseThreadLabel = new Label();
            PriorityThreadComboBox = new ComboBox();
            ThreadComboBox = new ComboBox();
            CountUnitTextBox = new TextBox();
            CountPortionTextBox = new TextBox();
            CreateUnitBtn = new Button();
            UnitLabel = new Label();
            CountPortionLabel = new Label();
            groupBoxCreateThread = new GroupBox();
            MineGroupBox = new GroupBox();
            PortionMineLabel = new Label();
            CreateMineBtn = new Button();
            PortionMineTextBox = new TextBox();
            ResultGroupBox = new GroupBox();
            CountLabel = new Label();
            ClearListBoxesButton = new Button();
            ResultLabel2 = new Label();
            ResultListBox2 = new ListBox();
            StartButton = new Button();
            ThreadPriorityGroupBox.SuspendLayout();
            groupBoxCreateThread.SuspendLayout();
            MineGroupBox.SuspendLayout();
            ResultGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // ThreadPriorityGroupBox
            // 
            ThreadPriorityGroupBox.Controls.Add(SavePriorityThreadButton);
            ThreadPriorityGroupBox.Controls.Add(ChoosePriorityThreadLabel);
            ThreadPriorityGroupBox.Controls.Add(ChooseThreadLabel);
            ThreadPriorityGroupBox.Controls.Add(PriorityThreadComboBox);
            ThreadPriorityGroupBox.Controls.Add(ThreadComboBox);
            ThreadPriorityGroupBox.Dock = DockStyle.Top;
            ThreadPriorityGroupBox.Location = new Point(0, 133);
            ThreadPriorityGroupBox.Margin = new Padding(3, 4, 3, 4);
            ThreadPriorityGroupBox.Name = "ThreadPriorityGroupBox";
            ThreadPriorityGroupBox.Padding = new Padding(3, 4, 3, 4);
            ThreadPriorityGroupBox.Size = new Size(640, 136);
            ThreadPriorityGroupBox.TabIndex = 3;
            ThreadPriorityGroupBox.TabStop = false;
            ThreadPriorityGroupBox.Text = "Выбор приоритета потока";
            // 
            // SavePriorityThreadButton
            // 
            SavePriorityThreadButton.Location = new Point(381, 29);
            SavePriorityThreadButton.Margin = new Padding(3, 4, 3, 4);
            SavePriorityThreadButton.Name = "SavePriorityThreadButton";
            SavePriorityThreadButton.Size = new Size(214, 83);
            SavePriorityThreadButton.TabIndex = 4;
            SavePriorityThreadButton.Text = "Сохранить";
            SavePriorityThreadButton.UseVisualStyleBackColor = true;
            SavePriorityThreadButton.Click += SavePriorityThreadButton_Click;
            // 
            // ChoosePriorityThreadLabel
            // 
            ChoosePriorityThreadLabel.AutoSize = true;
            ChoosePriorityThreadLabel.Location = new Point(181, 39);
            ChoosePriorityThreadLabel.Name = "ChoosePriorityThreadLabel";
            ChoosePriorityThreadLabel.Size = new Size(156, 20);
            ChoosePriorityThreadLabel.TabIndex = 3;
            ChoosePriorityThreadLabel.Text = "Выберите приоритет";
            // 
            // ChooseThreadLabel
            // 
            ChooseThreadLabel.AutoSize = true;
            ChooseThreadLabel.Location = new Point(22, 39);
            ChooseThreadLabel.Name = "ChooseThreadLabel";
            ChooseThreadLabel.Size = new Size(122, 20);
            ChooseThreadLabel.TabIndex = 2;
            ChooseThreadLabel.Text = "Выберите поток";
            // 
            // PriorityThreadComboBox
            // 
            PriorityThreadComboBox.FormattingEnabled = true;
            PriorityThreadComboBox.Location = new Point(181, 63);
            PriorityThreadComboBox.Margin = new Padding(3, 4, 3, 4);
            PriorityThreadComboBox.Name = "PriorityThreadComboBox";
            PriorityThreadComboBox.Size = new Size(138, 28);
            PriorityThreadComboBox.TabIndex = 1;
            // 
            // ThreadComboBox
            // 
            ThreadComboBox.FormattingEnabled = true;
            ThreadComboBox.Location = new Point(22, 63);
            ThreadComboBox.Margin = new Padding(3, 4, 3, 4);
            ThreadComboBox.Name = "ThreadComboBox";
            ThreadComboBox.Size = new Size(138, 28);
            ThreadComboBox.TabIndex = 0;
            // 
            // CountUnitTextBox
            // 
            CountUnitTextBox.Location = new Point(22, 59);
            CountUnitTextBox.Margin = new Padding(3, 4, 3, 4);
            CountUnitTextBox.Name = "CountUnitTextBox";
            CountUnitTextBox.Size = new Size(135, 27);
            CountUnitTextBox.TabIndex = 0;
            // 
            // CountPortionTextBox
            // 
            CountPortionTextBox.Location = new Point(181, 59);
            CountPortionTextBox.Margin = new Padding(3, 4, 3, 4);
            CountPortionTextBox.Name = "CountPortionTextBox";
            CountPortionTextBox.Size = new Size(139, 27);
            CountPortionTextBox.TabIndex = 1;
            // 
            // CreateUnitBtn
            // 
            CreateUnitBtn.Location = new Point(381, 24);
            CreateUnitBtn.Margin = new Padding(3, 4, 3, 4);
            CreateUnitBtn.Name = "CreateUnitBtn";
            CreateUnitBtn.Size = new Size(214, 96);
            CreateUnitBtn.TabIndex = 2;
            CreateUnitBtn.Text = "Создать юнитов";
            CreateUnitBtn.UseVisualStyleBackColor = true;
            CreateUnitBtn.Click += CreateUnitBtn_Click;
            // 
            // UnitLabel
            // 
            UnitLabel.AutoSize = true;
            UnitLabel.Location = new Point(22, 35);
            UnitLabel.Name = "UnitLabel";
            UnitLabel.Size = new Size(147, 20);
            UnitLabel.TabIndex = 3;
            UnitLabel.Text = "Количество юнитов";
            // 
            // CountPortionLabel
            // 
            CountPortionLabel.AutoSize = true;
            CountPortionLabel.Location = new Point(181, 35);
            CountPortionLabel.Name = "CountPortionLabel";
            CountPortionLabel.Size = new Size(141, 20);
            CountPortionLabel.TabIndex = 4;
            CountPortionLabel.Text = "Сколько добывают";
            // 
            // groupBoxCreateThread
            // 
            groupBoxCreateThread.Controls.Add(CountPortionLabel);
            groupBoxCreateThread.Controls.Add(UnitLabel);
            groupBoxCreateThread.Controls.Add(CreateUnitBtn);
            groupBoxCreateThread.Controls.Add(CountPortionTextBox);
            groupBoxCreateThread.Controls.Add(CountUnitTextBox);
            groupBoxCreateThread.Dock = DockStyle.Top;
            groupBoxCreateThread.Location = new Point(0, 0);
            groupBoxCreateThread.Margin = new Padding(3, 4, 3, 4);
            groupBoxCreateThread.Name = "groupBoxCreateThread";
            groupBoxCreateThread.Padding = new Padding(3, 4, 3, 4);
            groupBoxCreateThread.Size = new Size(640, 133);
            groupBoxCreateThread.TabIndex = 5;
            groupBoxCreateThread.TabStop = false;
            groupBoxCreateThread.Text = "Создание юнитов";
            // 
            // MineGroupBox
            // 
            MineGroupBox.Controls.Add(PortionMineLabel);
            MineGroupBox.Controls.Add(CreateMineBtn);
            MineGroupBox.Controls.Add(PortionMineTextBox);
            MineGroupBox.Dock = DockStyle.Top;
            MineGroupBox.Location = new Point(0, 269);
            MineGroupBox.Margin = new Padding(3, 4, 3, 4);
            MineGroupBox.Name = "MineGroupBox";
            MineGroupBox.Padding = new Padding(3, 4, 3, 4);
            MineGroupBox.Size = new Size(640, 133);
            MineGroupBox.TabIndex = 6;
            MineGroupBox.TabStop = false;
            MineGroupBox.Text = "Создание шахты";
            // 
            // PortionMineLabel
            // 
            PortionMineLabel.AutoSize = true;
            PortionMineLabel.Location = new Point(22, 35);
            PortionMineLabel.Name = "PortionMineLabel";
            PortionMineLabel.Size = new Size(166, 20);
            PortionMineLabel.TabIndex = 3;
            PortionMineLabel.Text = "Кол-во золота в шахте";
            // 
            // CreateMineBtn
            // 
            CreateMineBtn.Location = new Point(381, 24);
            CreateMineBtn.Margin = new Padding(3, 4, 3, 4);
            CreateMineBtn.Name = "CreateMineBtn";
            CreateMineBtn.Size = new Size(214, 96);
            CreateMineBtn.TabIndex = 2;
            CreateMineBtn.Text = "Сохранить";
            CreateMineBtn.UseVisualStyleBackColor = true;
            CreateMineBtn.Click += CreateMineBtn_Click;
            // 
            // PortionMineTextBox
            // 
            PortionMineTextBox.Location = new Point(22, 59);
            PortionMineTextBox.Margin = new Padding(3, 4, 3, 4);
            PortionMineTextBox.Name = "PortionMineTextBox";
            PortionMineTextBox.Size = new Size(166, 27);
            PortionMineTextBox.TabIndex = 0;
            // 
            // ResultGroupBox
            // 
            ResultGroupBox.Controls.Add(CountLabel);
            ResultGroupBox.Controls.Add(ClearListBoxesButton);
            ResultGroupBox.Controls.Add(ResultLabel2);
            ResultGroupBox.Controls.Add(ResultListBox2);
            ResultGroupBox.Controls.Add(StartButton);
            ResultGroupBox.Dock = DockStyle.Top;
            ResultGroupBox.Location = new Point(0, 402);
            ResultGroupBox.Margin = new Padding(3, 4, 3, 4);
            ResultGroupBox.Name = "ResultGroupBox";
            ResultGroupBox.Padding = new Padding(3, 4, 3, 4);
            ResultGroupBox.Size = new Size(640, 419);
            ResultGroupBox.TabIndex = 8;
            ResultGroupBox.TabStop = false;
            ResultGroupBox.Text = "Визуал";
            // 
            // CountLabel
            // 
            CountLabel.AutoSize = true;
            CountLabel.Location = new Point(312, 163);
            CountLabel.Name = "CountLabel";
            CountLabel.Size = new Size(50, 20);
            CountLabel.TabIndex = 10;
            CountLabel.Text = "label1";
            // 
            // ClearListBoxesButton
            // 
            ClearListBoxesButton.Location = new Point(347, 29);
            ClearListBoxesButton.Margin = new Padding(3, 4, 3, 4);
            ClearListBoxesButton.Name = "ClearListBoxesButton";
            ClearListBoxesButton.Size = new Size(209, 73);
            ClearListBoxesButton.TabIndex = 9;
            ClearListBoxesButton.Text = "Очистить поля ниже";
            ClearListBoxesButton.UseVisualStyleBackColor = true;
            ClearListBoxesButton.Click += ClearListBoxesButton_Click;
            // 
            // ResultLabel2
            // 
            ResultLabel2.AutoSize = true;
            ResultLabel2.Location = new Point(22, 120);
            ResultLabel2.Name = "ResultLabel2";
            ResultLabel2.Size = new Size(102, 20);
            ResultLabel2.TabIndex = 8;
            ResultLabel2.Text = "Информация";
            // 
            // ResultListBox2
            // 
            ResultListBox2.FormattingEnabled = true;
            ResultListBox2.Location = new Point(30, 201);
            ResultListBox2.Margin = new Padding(3, 4, 3, 4);
            ResultListBox2.Name = "ResultListBox2";
            ResultListBox2.Size = new Size(596, 204);
            ResultListBox2.TabIndex = 7;
            // 
            // StartButton
            // 
            StartButton.Location = new Point(94, 29);
            StartButton.Margin = new Padding(3, 4, 3, 4);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(209, 73);
            StartButton.TabIndex = 4;
            StartButton.Text = "Запустить";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 825);
            Controls.Add(ResultGroupBox);
            Controls.Add(MineGroupBox);
            Controls.Add(ThreadPriorityGroupBox);
            Controls.Add(groupBoxCreateThread);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Warcraft";
            ThreadPriorityGroupBox.ResumeLayout(false);
            ThreadPriorityGroupBox.PerformLayout();
            groupBoxCreateThread.ResumeLayout(false);
            groupBoxCreateThread.PerformLayout();
            MineGroupBox.ResumeLayout(false);
            MineGroupBox.PerformLayout();
            ResultGroupBox.ResumeLayout(false);
            ResultGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox ThreadPriorityGroupBox;
        private Button SavePriorityThreadButton;
        private Label ChoosePriorityThreadLabel;
        private Label ChooseThreadLabel;
        private ComboBox PriorityThreadComboBox;
        private ComboBox ThreadComboBox;
        private TextBox CountUnitTextBox;
        private TextBox CountPortionTextBox;
        private Button CreateUnitBtn;
        private Label UnitLabel;
        private Label CountPortionLabel;
        private GroupBox groupBoxCreateThread;
        private GroupBox MineGroupBox;
        private Label PortionMineLabel;
        private Button CreateMineBtn;
        private TextBox PortionMineTextBox;
        private GroupBox ResultGroupBox;
        private Button ClearListBoxesButton;
        private Label ResultLabel2;
        private ListBox ResultListBox2;
        private Button StartButton;
        private Label CountLabel;
    }
}