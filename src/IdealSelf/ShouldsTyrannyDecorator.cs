using Spectre.Console;
namespace HorneyOS.IdealSelf;

public class ShouldsTyrannyDecorator : IIdealizedSelf
{
    public void DeployPerfectProject(ref double security, ref double realSelfVitality, ref double alienationEnergyCost)
    {
        AnsiConsole.MarkupLine("[bold red][[ТИРАНИЯ ДОЛЖЕН]][/]: 'Проект задеплоен, но код неидеален! Ты должен был написать его лучше!'");
        security += 10;  // Внешний успех дает немного мнимой безопасности
        realSelfVitality -= 20;    // Сильнейший штраф к энергии из-за самокритики
        alienationEnergyCost += 15.0; // Повышаем долгосрочный налог на самоотчуждение

        AnsiConsole.MarkupLine($"[grey]Эффект тирании: Security (+10), Vitality (-20), AlienationCost (+15.0)[/]");
    }

    public void SuppressAllWeakness(ref double security, ref double realSelfVitality, ref double alienationEnergyCost)
    {
        AnsiConsole.MarkupLine("[bold red][[ТИРАНИЯ ДОЛЖЕН]][/]: 'Ты улыбнулся сквозь боль. Никто не заметил слабости, но внутри — выжженная земля'.");
        security += 15;
        realSelfVitality -= 25;    // Колоссальное выгорание на удержание маски совершенства
        alienationEnergyCost += 25.0; // Тотальное выгорание на удержание маски совершенства

        AnsiConsole.MarkupLine($"[grey]Эффект тирании: Security (+15), Vitality (-25), AlienationCost (+25.0)[/]");
    }
}