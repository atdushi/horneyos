using Spectre.Console;

namespace HorneyOS.Strategies
{
    /// <summary>
    /// (Изоляция): Строит стену. 
    /// Логика в коде: включает глубокое кеширование и игнорирование входящих событий. 
    /// Замораживает показатели безопасности на среднем уровне, но полностью блокирует развитие системы.
    /// </summary>
    public class MovingAwayFromPeople : ICopingStrategy
    {
        public string StrategyName => "Движение от людей (Изоляция)";
        private bool _isShieldActive = false;

        public void Apply(ref double security, ref double realSelfVitality)
        {
            if (!_isShieldActive)
            {
                AnsiConsole.MarkupLine("[grey][🔌 ИЗОЛЯЦИЯ][/]: Активация ментального файрвола. Входящие пакеты отношений заблокированы.");
                _isShieldActive = true;

                // Изоляция дает мощный, но искусственный скачок безопасности
                security += 45.0;
                // Личность кастрирует свою спонтанность, уходя в онемение
                realSelfVitality -= 15.0;
            }
            else
            {
                AnsiConsole.MarkupLine("[italic grey][...][/] Система находится в режиме анабиоза. Никакие внешние стимулы не могут достучаться до Эго.");
                // В режиме «стены» входящие удары по безопасности частично игнорируются
                security += 10.0;
                realSelfVitality -= 5.0;
            }
        }
    }
}
