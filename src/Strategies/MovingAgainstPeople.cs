using Spectre.Console;

namespace HorneyOS.Strategies
{
    /// <summary>
    /// (Агрессия): Воспринимает мир как войну. 
    /// Логика в коде: пытается силой захватить контроль, «эксплуатировать» рантайм. 
    /// Повышает безопасность за счет агрессивных логов и подавления, но витальность сгорает на поддержание боевой готовности.
    /// </summary>
    public class MovingAgainstPeople : ICopingStrategy
    {
        public string StrategyName => "Движение против людей (Агрессия)";
        private int _exploitedResourcesCount = 0; // Внутреннее состояние стратегии

        public void Apply(ref double security, ref double realSelfVitality)
        {
            _exploitedResourcesCount++;
            AnsiConsole.MarkupLine($"[red][⚔️ АГРЕССИЯ][/]: Мир враждебен. Захвачен и эксплуатируется внешний ресурс №{_exploitedResourcesCount}.");

            // Агрессор чувствует безопасность только когда он доминирует
            security += 35.0;

            // Огромные затраты витальности на удержание контроля и паранойю
            realSelfVitality -= 30.0;

            if (_exploitedResourcesCount > 3)
            {
                AnsiConsole.MarkupLine("[bold red][☠️ ПАРАНОЙЯ][/]: Вы захватили слишком много контроля. Система ожидает ответного удара, безопасность падает!");
                security -= 40.0;
            }
        }
    }
}
