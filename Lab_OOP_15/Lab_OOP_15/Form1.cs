using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Lab_OOP_15
{
    public partial class Form1 : Form
    {

        static readonly Random rnd = new();

        Thread threadMine;
        List<Thread> threads; // юниты (потоки)

        int portion = 10; // сколько добывают юниты (равные порции)

        int portionMine = 100; // сколько золота в руднике

        bool MineHaveGold;
        bool MineHaveGoldDisplay = false;

        public Form1()
        {
            InitializeComponent();

            PriorityThreadComboBox.Items.AddRange(Enum.GetValues(typeof(ThreadPriority)).Cast<object>().ToArray());
            threads = new();

            MineHaveGold = false;

            UpdateTextCount();
        }


        private void ProduceGold(string nameUnit)
        {
            while (MineHaveGold)
            {
                lock (this)
                {
                    portionMine -= portion;
                    var timeDelay = rnd.Next(300, 1000); // на сколько задерживаются юниты (рандомное время) 
                    Thread.Sleep(timeDelay);

                    if (!MineHaveGold)
                    {
                        if (!MineHaveGoldDisplay)
                        {
                            MineHaveGoldDisplay = true;
                            Invoke(() => Restart());
                        }
                        break;
                    }

                    
                    Invoke(() => UpdateText($"{nameUnit} добыл {portion} ед. золота, в пути: {(double)timeDelay / 1000}с."));
                    Invoke(UpdateTextCount);
                }
                if (portionMine <= 0)
                    MineHaveGold = false;
            }
        }


        private void Restart()
        {
            MessageBox.Show($"Золото закончилось");
            ThreadComboBox.Items.Clear();
            threads.Clear();
        }

        private void UpdateTextCount()
        {
            CountLabel.Text = $"{portionMine} ед. золота";
        }

        private void UpdateText(string message)
        {
            ResultListBox2.Items.Add(message);
        }

        private void CreateUnitBtn_Click(object sender, EventArgs e)
        {
            var flag1 = int.TryParse(CountUnitTextBox.Text, out int countUnit);
            var flag2 = int.TryParse(CountPortionTextBox.Text, out int portion2);

            if (flag1 && flag2 && countUnit > 0 && portion2 > 0)
            {
                portion = portion2;
                for (int i = 0; i < countUnit; i++)
                {
                    var nameUnit = "Юнит_" + rnd.Next(1, 1000);
                    var thread = new Thread(() => ProduceGold(nameUnit))
                    {
                        Name = nameUnit
                    };

                    // добавляем в список потоков
                    threads.Add(thread);

                    // Добавляем в панель ниже
                    ThreadComboBox.Items.Add(thread.Name);
                }

                MessageBox.Show("Потоки созданы успешно", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CountUnitTextBox.Text = null;
                CountPortionTextBox.Text = null;
            }
            else
            {
                MessageBox.Show("Неверно заданный формат", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SavePriorityThreadButton_Click(object sender, EventArgs e)
        {
            if (ThreadComboBox.SelectedIndex == -1 || PriorityThreadComboBox.SelectedIndex == -1)
                return;

            var thread = threads.First(thread => thread.Name == ThreadComboBox.Text);

            if (Enum.TryParse(PriorityThreadComboBox.Text, out ThreadPriority threadPriority))
            {
                thread.Priority = threadPriority;

                MessageBox.Show("Приоритет потока успешно изменен", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ThreadComboBox.SelectedIndex = -1;
                PriorityThreadComboBox.SelectedIndex = -1;
            }
        }

        private void CreateMineBtn_Click(object sender, EventArgs e)
        {
            var flag1 = int.TryParse(PortionMineTextBox.Text, out int portionMine2);

            if (flag1 && portionMine2 > 0)
            {
                portionMine = portionMine2;
                MessageBox.Show("Успешно", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PortionMineTextBox.Text = null;

            }
            else
            {
                MessageBox.Show("Неверно заданный формат", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (threads.Count <= 0)
            {
                MessageBox.Show("Создайте юнитов");
                return;
            }

            if (!MineHaveGold)
            {
                MineHaveGold = true;
                MineHaveGoldDisplay = false;
            }

            StartThreads();
        }

        private void StartThreads()
        {
            foreach (var thread in threads)
            {
                if (thread.ThreadState == ThreadState.Unstarted)
                {
                    thread.IsBackground = true; // потоки в фоновом режиме - завершается основной. завершается и он.
                    thread.Start();
                }
            }

        }

        private void ClearListBoxesButton_Click(object sender, EventArgs e)
        {
            ResultListBox2.Items.Clear();
            ThreadComboBox.Items.Clear();
        }
    }
}