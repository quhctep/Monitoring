Diagr3.Series.Clear();
                        Diagr3.AxisX.Clear();
                        Diagr3.AxisY.Clear();
                        if (Diagr3.Series.Count >= 1) { }
                        else
                            using (EDMX.fleerEntities_GetResult db3 = new EDMX.fleerEntities_GetResult())
                            {
                                var data3 = db3.GetResult_all();
                                StackedRowSeries col3 = new StackedRowSeries() { DataLabels = true, Values = new ChartValues<double>(), LabelPoint = point => point.X.ToString(), Title = "Сумма отгрузки", Foreground = new SolidColorBrush(Colors.Black) };
                                Axis ax3 = new Axis() { Separator = new LiveCharts.Wpf.Separator() { Step = 1, IsEnabled = false }, Foreground = new SolidColorBrush(Colors.Black) };
                                ax3.Labels = new List<string>();
                                foreach (var x in data3)
                                {
                                    col3.Values.Add(x.sell.Value);
                                    ax3.Labels.Add(x.name.ToString());
                                }
                                Diagr3.Series.Add(col3);
                                Diagr3.AxisY.Add(ax3);
                                Diagr3.AxisX.Add(new Axis { LabelFormatter = value => value.ToString(), Separator = new LiveCharts.Wpf.Separator() { Stroke = new SolidColorBrush(Colors.LightGray) }, Foreground = new SolidColorBrush(Colors.Black) });

                                var data3_1 = db3.GetResult_all();
                                StackedRowSeries col3_1 = new StackedRowSeries() { DataLabels = true, Values = new ChartValues<double>(), LabelPoint = point => point.X.ToString(), Title = "Себестоимость", Foreground = new SolidColorBrush(Colors.Black) };
                                foreach (var x in data3_1)
                                {
                                    col3_1.Values.Add(-x.price.Value);
                                }
                                Diagr3.Series.Add(col3_1);
                            }