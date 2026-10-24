using System.Reflection;
using Spectre.Console;

namespace HorneyOS.Core;

public class Psychoanalyst
{
    /// <summary>
    /// Сессия психотерапии. Взламывает приватное состояние невротика, 
    /// снижает тревогу и восстанавливает базовые ресурсы Реального Я.
    /// </summary>
    public void ConductTherapySession(NeuroticMind mind)
    {
        AnsiConsole.Write(new Rule("[bold green]🩺 СЕАНС ПСИХОАНАЛИЗА[/]") { Justification = Justify.Left });
        AnsiConsole.MarkupLine("[italic green]Аналитик деконструирует идеализированный образ и невротические претензии...[/]");

        try
        {
            // Используем Reflection, чтобы найти приватные поля
            Type mindType = typeof(NeuroticMind);
            FieldInfo securityField = mindType.GetField("_security", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo energyField = mindType.GetField("_energy", BindingFlags.NonPublic | BindingFlags.Instance);

            if (securityField != null && energyField != null)
            {
                // Напрямую перезаписываем инкапсулированные данные инстанса
                securityField.SetValue(mind, 100.0);
                energyField.SetValue(mind, 100.0);

                AnsiConsole.MarkupLine("[bold green][[✓]] Успех:[/] Базовая безопасность восстановлена до [bold]100%[/].");
                AnsiConsole.MarkupLine("[bold green][[✓]] Успех:[/] Реальное Я получило [bold]100[/] единиц свободной энергии.\n");
            }
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]⚠ Ошибка интервенции сопротивления психики: {ex.Message}[/]");
        }
    }
}
