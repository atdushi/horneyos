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
                double currentAlienation = (double)alienationField.GetValue(mind)!;
                double currentSecurity = (double)securityField.GetValue(mind)!;

                // Динамически создаем валидатор гордости перед проведением интервенции
                var prideValidator = new NeuroticPrideValidator(currentAlienation, currentSecurity);

                // Запускаем валидацию. Если гордость уязвлена — выполнение прервется исключением
                prideValidator.ValidateInterventionSafety();

                // Если валидация пройдена (сопротивление преодолено), сбрасываем налог и возвращаем витальность
                Console.WriteLine("[Analyst] Сопротивление преодолено. Производится терапевтический сброс параметров...");

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
        catch (ResistanceException ex)
        {
            // Перехватываем кастомное исключение сопротивления
            Console.WriteLine($"\n[Spectre.Console - Error] {ex.Message}");
            Console.WriteLine("[Analyst] Интервенция провалена. Необходима предварительная проработка ShouldsTyrannyDecorator.");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]⚠ Ошибка интервенции сопротивления психики: {ex.Message}[/]");
        }
    }
}
