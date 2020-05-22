using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatalogPdf
{
    public partial class ProcessBar : Form
    {
        public int Count { get; set; }
        public bool Cancel { get; set; } = false;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                Text = title;
            }
        }
        /// <summary>
        /// Проверка открыт ли уже экземпляр прогресс бара
        /// </summary>
        private static bool _exist = false;
        private string title;

        public Stopwatch Timer;
        public Stopwatch TimerStep;

        private double secToEnd;
        private TimeSpan timeToEnd;
        private int i = 1;

        private double percent = 0;

        public ProcessBar()
        {
            _exist = true;
            InitializeComponent();
        }
    
    ~ProcessBar()
    {
        _exist = false;
    }
    
    public static ProcessBar Init(string title, int count, int step = 1, string info = "Процесс")
    {
        if (_exist) return null;

            ProcessBar pb = new ProcessBar()
        {
            Title = title,
            Count = count,
            Timer = Stopwatch.StartNew(),
            TimerStep = Stopwatch.StartNew()
        };
        pb.progressbar.Maximum = 100;
        pb.progressbar.Step = step;
        pb.LabelName.Text = info;
        pb.progressbar.Value = 0;
        return pb;
    }


    /// <summary>
    /// Выполнение итерации процесса
    /// </summary>
    /// <param name="nameAction">Название итерации</param>
    /// <param name="delay">Задержка</param>
    /// <returns></returns>
    public bool Action(string nameAction = "Выполняется", double delay = 500)
    {
        Application.DoEvents();
        if (TimerStep.Elapsed.TotalMilliseconds > delay || i == 1)
        {
            percent = (double)i / Count * 100;
            progressbar.Value = (int)percent;   // % выполнения
            LabelName.Text = nameAction;
            secToEnd = (Count - i) * (Timer.Elapsed.TotalMilliseconds / i);
            TimerStep.Restart();
            timeToEnd = TimeSpan.FromMilliseconds(secToEnd);
            string timeStr = timeToEnd.ToString(@"hh\:mm\:ss");
            lb_val.Text = $"Выполненно {progressbar.Value}%  Шаг {i} из {Count} Осталось: {timeStr} ";
        }
        i++;
        return Cancel;
    }

    public void Btn_cancel_Click(object sender, EventArgs e)
    {

        Close();
    }

    private void ProcessBar_FormClosing(object sender, FormClosingEventArgs e)
    {
        Timer.Stop();
        Cancel = true;
        _exist = false;
       // Functions.ExcelOptimizateOff();
    }

    private void ProcessBar_Load(object sender, EventArgs e)
    {
       // Functions.ExcelOptimizateOn();
    }

}
}
