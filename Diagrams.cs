using System.Collections.Generic;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;

namespace FLEER.Monitoring
{
    public class Diagrams
    {
        public void DisplayDiagrams(CartesianChart Diagr, System.Data.Entity.Core.Objects.ObjectResult FED, string TitleValue, int Val, string Lab)
        {
            Diagr.Series.Clear();
            Diagr.AxisX.Clear();
            Diagr.AxisY.Clear();
            if (Diagr.Series.Count >= 1) { }
            else
                using (EDMX.fleerEntitiesDiagrams db = new EDMX.fleerEntitiesDiagrams())
                {
                    var data = FED;
                    RowSeries col = new RowSeries() { DataLabels = true, Values = new ChartValues<double>(), LabelPoint = point => point.X.ToString(), Title = TitleValue, Foreground = new SolidColorBrush(Colors.Black) };
                    Axis ax = new Axis() { Separator = new LiveCharts.Wpf.Separator() { Step = 1, IsEnabled = false }, Foreground = new SolidColorBrush(Colors.Black) };
                    ax.Labels = new List<string>();
                    foreach (var x in data)
                    {
                        col.Values.Add(Val);
                        ax.Labels.Add(Lab);

                    }

                    Diagr.Series.Add(col);
                    Diagr.AxisY.Add(ax);
                    Diagr.AxisX.Add(new Axis { LabelFormatter = value => value.ToString(), Separator = new LiveCharts.Wpf.Separator() { Stroke = new SolidColorBrush(Colors.LightGray) }, Foreground = new SolidColorBrush(Colors.Black) });
                }
        }
    }
}
