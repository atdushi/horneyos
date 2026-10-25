using Spectre.Console;

namespace HorneyOS.Strategies;

/// <summary>
/// (Уступчивость): Ищет безопасность через одобрение. 
/// Логика в коде: пытается «присосаться» к чужим ресурсам. 
/// Снижает витальность Реального Я ради ублажения внешних триггеров.
/// </summary>
public class MovingTowardPeople : ICopingStrategy
{
    public string StrategyName => "Движение к людям (Уступчивость)";

    public void Apply(ref double security, ref double realSelfVitality)
    {
        AnsiConsole.MarkupLine("[magenta][[🤝 УСТУПЧИВОСТЬ]][/]: Активен паттерн 'Если я уступлю, меня не тронут'.");

        // Попытка купить безопасность ценой стирания границ Реального Я
        security += 25.0;
        realSelfVitality -= 20.0;

        if (realSelfVitality < 30.0)
        {
            AnsiConsole.MarkupLine("[italic magenta][[⚠ ОБРЫВ ГРАНИЦ]][/]: Витальность критически низкая. Развивается патологическая зависимость от чужого мнения.");
        }
    }
}
