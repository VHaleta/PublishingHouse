using PublishingHouse.Constants;
using PublishingHouse.Helpers;
using PublishingHouse.Models;
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

namespace PublishingHouse
{
    public partial class StatisticsForm : Form
    {
        Table table;
        public StatisticsForm(Table table)
        {
            InitializeComponent();
            this.table = table;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            switch (table)
            {
                case Table.Publication:
                    chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    foreach (var item in Database.publicationTypes)
                    {
                        int countType = Database.publications.Count(x => x.Type == item.Type);
                        if (countType != 0)
                            chart.Series[0].Points.AddXY(item.Type, countType);
                    }
                    break;
                case Table.Authorship:
                    chart.Series[0].Name = "Кількість книжок";
                    chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    Dictionary<int, int> counter = new Dictionary<int, int>();
                    foreach (var publication in Database.publications)
                    {
                        int counterValue = 0, v;
                        foreach (var authorship in Database.authorships)
                            if (authorship.IdPublication == publication.Id) counterValue++;
                        if (counter.TryGetValue(counterValue, out v))
                            counter[counterValue]++;
                        else
                            counter.Add(counterValue, 1);
                    }

                    foreach (var item in counter)
                    {
                        chart.Series[0].Points.AddXY(item.Key, item.Value);
                    }
                    break;
                case Table.Representative:
                    chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chart.Series[0].Points.AddXY("Entity representative", Database.representatives.Count(x => x.IdAuthor == 0 && x.IdEntity != 0));
                    chart.Series[0].Points.AddXY("Author representative", Database.representatives.Count(x => x.IdAuthor != 0 && x.IdEntity == 0));
                    break;
                case Table.PublishingOrder:
                    chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    int count = Database.publishingOrders.Count(x => OrderStatusHelper.EnumToString(x.Status) == "Unknown");
                    if (count != 0)
                        chart.Series[0].Points.AddXY("Unknown", count);
                    count = Database.publishingOrders.Count(x => OrderStatusHelper.EnumToString(x.Status) == "Complited");
                    if (count != 0)
                        chart.Series[0].Points.AddXY("Complited", count);
                    count = Database.publishingOrders.Count(x => OrderStatusHelper.EnumToString(x.Status) == "InProcess");
                    if (count != 0)
                        chart.Series[0].Points.AddXY("InProcess", count);
                    count = Database.publishingOrders.Count(x => OrderStatusHelper.EnumToString(x.Status) == "DidntBegan");
                    if (count != 0)
                        chart.Series[0].Points.AddXY("DidntBegan", count);
                    break;
                case Table.Author:
                    chart.Series[0].Name = "Автори";
                    chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    foreach (var item in Database.GetAuthorStatistics())
                    {
                        chart.Series[0].Points.AddXY(item.Key, item.Value);
                    }
                    break;
                case Table.PrintingHouse:
                    chart.Series[0].Name = "Поліграфії";
                    chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    foreach (var item in Database.GetPrintingHouseStatistics())
                    {
                        chart.Series[0].Points.AddXY(item.Key, item.Value);
                    }
                    break;
            }
        }
    }
}
