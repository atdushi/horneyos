using Spectre.Console;
namespace HorneyOS.IdealSelf;

public class ShouldsTyrannyDecorator : IIdealizedSelf
{
    public void DeployPerfectProject(ref double security, ref double realSelfVitality)
    {
        AnsiConsole.MarkupLine("[bold red][[ТИРАНИЯ ДОЛЖЕН]][/]: 'Проект задеплоен, но код неидеален! Ты должен был написать его лучше!'");
        security += 10;  // Внешний успех дает немного мнимой безопасности
        realSelfVitality -= 35;    // Сильнейший штраф к энергии из-за самокритики
    }

    public void SuppressAllWeakness(ref double security, ref double realSelfVitality)
    {
        AnsiConsole.MarkupLine("[bold red][[ТИРАНИЯ ДОЛЖЕН]][/]: 'Ты улыбнулся сквозь боль. Никто не заметил слабости, но внутри — выжженная земля'.");
        security += 15;
        realSelfVitality -= 40;    // Колоссальное выгорание на удержание маски совершенства
    }
}