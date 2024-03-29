﻿using System.Media;
using FluxViewer.Core.Log;

namespace FluxViewer.WindowsClient;

partial class MainForm
{
    /// <summary>
    /// Нажали на вкладку "Журнал регистрации"
    /// </summary>
    private void logsTabPage_Enter(object sender, EventArgs e)
    {
        UpdateLogs();
    }

    // Изменили дату, за которую выбирать лог
    private void logsDateTimePicker_ValueChanged(object sender, EventArgs e)
    {
        UpdateLogs();
    }

    private void UpdateLogs()
    {
        logsListBox.Items.Clear();
        var date = logsDateTimePicker.Value;
        if (!FileSystemLogger.HasLogsForThisData(date))
        {
            // Сообщаем пользователю звуком и цветом, что не найдено необходимых логов
            logsListBox.BackColor = Color.Gray;
            SystemSounds.Beep.Play();
            return;
        }

        logsListBox.BackColor = SystemColors.Window;
        logsListBox.Enabled = true;

        var allLogs = FileSystemLogger.GetLogsByDate(date);
        foreach (var log in allLogs)
        {
            logsListBox.Items.Add(log);
        }
    }
}