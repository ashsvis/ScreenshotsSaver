using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.Windows.Forms;

namespace ScreenshotsSaver
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Size = new Size();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Process process = RunningInstance();
            if (process != null)
            {
                Application.Exit();
                return;
            }
            timer1.Enabled = true;
        }

        [EnvironmentPermission(SecurityAction.LinkDemand, Unrestricted = true)]
        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            // Просматриваем все процессы
            foreach (Process process in processes)
            {
                // игнорируем текщий процесс
                if (process.Id != current.Id)
                {
                    // проверяем, что процесс запущен из того же файла
                    if (Assembly.GetExecutingAssembly().Location.Replace(
                        "/", "\\") == current.MainModule.FileName)
                    {
                        // Да, это и есть копия нашего приложения
                        return process;
                    }
                }
            }
            // нет, таких процессов не найдено
            return null;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void miClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void miTuning_Click(object sender, EventArgs e)
        {
            var frm = new TuningForm();
            frm.Build(Properties.Settings.Default.SelectedPath);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                Properties.Settings.Default.SelectedPath = frm.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Признак возможности вставки данных из буфера обмена
        /// </summary>
        public bool CanPasteFromClipboard
        {
            get { return Clipboard.ContainsData(DataFormats.Bitmap); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (CanPasteFromClipboard)
            {
                var clipboardRetrievedObject = Clipboard.GetDataObject();
                if (clipboardRetrievedObject != null)
                {
                    var pastedObject = (Bitmap)clipboardRetrievedObject.GetData(DataFormats.Bitmap);
                    var path = Directory.Exists(Properties.Settings.Default.SelectedPath) 
                        ? Properties.Settings.Default.SelectedPath 
                        : Application.StartupPath;
                    var npp = 1;
                    var fileName = Path.Combine(path, $"{npp}.png");
                    while (File.Exists(fileName))
                        fileName = Path.Combine(path, $"{++npp}.png");
                    pastedObject.Save(fileName, ImageFormat.Png);
                }
                Clipboard.Clear();
            }
            timer1.Enabled = true;
        }
    }
}
