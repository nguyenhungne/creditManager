using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using N9.Models;
using N9.Services.Implementations;

namespace N9
{
    public partial class UCBaoCao : UserControl
    {
        private User _currentUser;
        private ReportService _reportService;

        public UCBaoCao()
        {
            InitializeComponent();
        }

        public UCBaoCao(User user) : this()
        {
            _currentUser = user;
            _reportService = new ReportService();
            LoadReport();
        }

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void cboPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            chart.Series.Clear();
            chart.Titles.Clear();

            var reportType = cboReportType.SelectedIndex;
            DateTime from, to;
            GetDateRange(out from, out to);

            switch (reportType)
            {
                case 0: // Cơ cấu chi tiêu
                    LoadSpendingByCategory(from, to);
                    break;
                case 1: // Lịch sử chi tiêu
                    LoadMonthlySpending();
                    break;
                case 2: // Dư nợ theo thẻ
                    LoadBalanceByCard();
                    break;
            }
        }

        private void GetDateRange(out DateTime from, out DateTime to)
        {
            to = DateTime.Today;
            switch (cboPeriod.SelectedIndex)
            {
                case 0: // Tháng này
                    from = new DateTime(to.Year, to.Month, 1);
                    break;
                case 1: // Quý này
                    int quarter = (to.Month - 1) / 3;
                    from = new DateTime(to.Year, quarter * 3 + 1, 1);
                    break;
                case 2: // Năm nay
                    from = new DateTime(to.Year, 1, 1);
                    break;
                default:
                    from = to.AddMonths(-1);
                    break;
            }
        }

        private void LoadSpendingByCategory(DateTime from, DateTime to)
        {
            var data = _reportService.GetSpendingByCategory(_currentUser.Id, from, to);
            
            chart.Titles.Add("Cơ cấu chi tiêu");
            var series = new Series("Chi tiêu")
            {
                ChartType = SeriesChartType.Pie
            };

            foreach (var item in data)
            {
                var point = series.Points.Add(Convert.ToDouble(item.Value));
                point.LegendText = item.Key;
                point.Label = $"{item.Key}\n{item.Value:N0}";
            }

            chart.Series.Add(series);
        }

        private void LoadMonthlySpending()
        {
            var data = _reportService.GetMonthlySpending(_currentUser.Id, DateTime.Today.Year);
            
            chart.Titles.Add($"Chi tiêu theo tháng - Năm {DateTime.Today.Year}");
            var series = new Series("Chi tiêu")
            {
                ChartType = SeriesChartType.Column
            };

            foreach (var item in data)
            {
                series.Points.AddXY(item.Key, Convert.ToDouble(item.Value));
            }

            series.Color = Color.FromArgb(0, 122, 204);
            chart.Series.Add(series);
            
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
        }

        private void LoadBalanceByCard()
        {
            var data = _reportService.GetBalanceByCard(_currentUser.Id);
            
            chart.Titles.Add("Dư nợ theo thẻ");
            var series = new Series("Dư nợ")
            {
                ChartType = SeriesChartType.Bar
            };

            foreach (var item in data)
            {
                series.Points.AddXY(item.Key, Convert.ToDouble(item.Value));
            }

            series.Color = Color.FromArgb(225, 58, 58);
            chart.Series.Add(series);
            
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "N0";
        }
    }
}
