using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using N9.Models;
using N9.Services.Implementations;

namespace N9
{
    public partial class UCDashBoard : UserControl
    {
        private User _currentUser;
        private ReportService _reportService;
        private CreditCardService _cardService;

        public UCDashBoard()
        {
            InitializeComponent();
        }

        public UCDashBoard(User user) : this()
        {
            _currentUser = user;
            _reportService = new ReportService();
            _cardService = new CreditCardService();
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            if (_currentUser == null) return;

            // Total debt
            var totalDebt = _reportService.GetTotalDebt(_currentUser.Id);
            lblTotalDebt.Text = $"{totalDebt:N0} VNĐ";

            // Due cards count
            var dueCards = _reportService.GetDueCardsCount(_currentUser.Id);
            lblDueCards.Text = dueCards.ToString();
            if (dueCards > 0)
            {
                lblDueCards.ForeColor = Color.Red;
            }

            // Total cards
            var cards = _cardService.GetAllCards(_currentUser.Id);
            lblTotalCards.Text = cards.Count.ToString();

            // Load mini chart - spending by category this month
            LoadMiniChart();
        }

        private void LoadMiniChart()
        {
            chartOverview.Series.Clear();
            chartOverview.Titles.Clear();

            var from = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var to = DateTime.Today;
            var data = _reportService.GetSpendingByCategory(_currentUser.Id, from, to);

            chartOverview.Titles.Add("Chi tiêu tháng này");
            var series = new Series("Chi tiêu")
            {
                ChartType = SeriesChartType.Doughnut
            };

            foreach (var item in data)
            {
                var point = series.Points.Add(Convert.ToDouble(item.Value));
                point.LegendText = item.Key;
            }

            chartOverview.Series.Add(series);
        }
    }
}
