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
            FieldInfo realSelfVitalityField = mindType.GetField("_realSelfVitality", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo alienationField = mindType.GetField("_alienationEnergyCost", BindingFlags.NonPublic | BindingFlags.Instance);

            if (securityField != null && realSelfVitalityField != null && alienationField != null)
            {
                // Напрямую перезаписываем инкапсулированные данные инстанса
                securityField.SetValue(mind, 100.0);
                realSelfVitalityField.SetValue(mind, 100.0);
                alienationField.SetValue(mind, 10.0);

                AnsiConsole.MarkupLine("[bold green][[✓]] Успех:[/] Базовая безопасность восстановлена до [bold]100%[/].");
                AnsiConsole.MarkupLine("[bold green][[✓]] Успех:[/] Реальное Я получило [bold]100[/] единиц свободной энергии.");
                AnsiConsole.MarkupLine("[bold green][[✓]] Успех:[/] Налог на отчуждение снижен до базовых [bold]10[/] ед.\n");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]⚠ Ошибка метаданных: Не удалось сопоставить новые приватные поля ядра HorneyOS.[/]");
            }
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]⚠ Ошибка интервенции сопротивления психики: {ex.Message}[/]");
        }
    }
}
