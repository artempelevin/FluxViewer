﻿using System.Drawing;

namespace FluxViewer.Core.GraphThemes;

public class BlackGraphTheme : GraphTheme
{
    /// <summary>
    /// Тёмная тема графика
    /// </summary>
    public BlackGraphTheme()
    {
        BorderColor = Color.Aqua;
        FillColor = Color.Silver;

        ChartBorderColor = Color.Green;
        ActiveChartFillColor = Color.Black;
        InactiveChartFillColor = Color.DimGray;

        CurveColor = Color.Yellow;

        XAxisColor = Color.Gray;
        YAxisColor = Color.Gray;

        XAxisMajorGridColor = Color.Cyan;
        YAxisMajorGridColor = Color.Cyan;

        XAxisTitleFontSpecFontColor = Color.Teal;
        YAxisTitleFontSpecFontColor = Color.Teal;

        XAxisScaleFontSpecFontColor = Color.Black;
        YAxisScaleFontSpecFontColor = Color.Black;

        TitleFontSpecFontColor = Color.Teal;
    }
}