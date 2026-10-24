using HorneyOS.Core;
using HorneyOS.IdealSelf;
using HorneyOS.Strategies;
using HorneyOS.Strategies.Implementations;
using Spectre.Console;

// Разрешаем конфликт имен, явно указывая типы для Spectre.Console
using Color = Spectre.Console.Color;
using Rule = Spectre.Console.Rule;

namespace HorneyOS;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Инициализируем ядро невротической психики
        var mind = new NeuroticMind();

        // По умолчанию выставляем уступчивую стратегию
        ICopingStrategy currentStrategy = new MovingTowardPeople();

        // Инициализация терапевтического инструмента
        var analyst = new Psychoanalyst();

        // Инициализируем Тиранию "Должен"
        var tyranny = new ShouldsTyrannyDecorator();

        AnsiConsole.Write(
            new FigletText("HorneyOS")
                .Centered()
                .Color(Color.Violet));

        AnsiConsole.MarkupLine("[bold grey]v1.0.0-alpha[/] | Рантайм Карен Хорни успешно инициализирован.\n");

        while (true)
        {
            //AnsiConsole.Clear();

            // 1. Отрисовка Дашборда Состояния
            var table = new Table().Border(TableBorder.Rounded);
            table.AddColumn("[bold]Метрика Психики[/]");
            table.AddColumn("[bold]Значение[/]");

            string securityColor = mind.Security > 40 ? "green" : "red";
            table.AddRow("Защита от Базальной тревоги (Security)", $"[{securityColor}]{mind.Security:F1}%[/]");
            table.AddRow("Жизненная сила Реального Я (RealSelfVitality)", $"[cyan]{mind.RealSelfVitality:F1} единиц[/]");
            table.AddRow("Текущая Стратегия Защиты", $"[yellow]{currentStrategy.StrategyName}[/]");

            AnsiConsole.Write(new Panel(table).Header("🧠 Монитор Эго").BorderColor(Color.Violet));

            // 2. Интерактивное Меню Действий
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Выберите [underline yellow]жизненное событие[/] или действие:")
                    .PageSize(10)
                    .AddChoices(new[] {
                        "💥 Получить критику от руководства (-40 к Безопасности)",
                        "🚀 [[Идеал]] Сдать сложный проект по работе",
                        "🎭 [[Идеал]] Подавить усталость и быть идеальным",
                        "🩺 Пройти сеанс психоанализа (Reflection Injection)",
                        "🤝 Попробовать сменить стратегию защиты",
                        "🔄 Восстановить ресурсы (Перезапуск рантайма)",
                        "❌ Выйти из симуляции"
                    }));

            // 3. Обработка Выбора
            if (choice.StartsWith("❌")) break;

            if (choice.StartsWith("🔄"))
            {
                mind = new NeuroticMind();
                AnsiConsole.MarkupLine("[green] Психика перезагружена к исходному состоянию.[/]");
                continue;
            }

            if (choice.StartsWith("🚀"))
            {
                try
                {
                    mind.PerformIdealAction(tyranny.DeployPerfectProject);
                }
                catch (BasicAnxietyException ex) { HandleAnxiety(ex); }
                continue;
            }

            if (choice.StartsWith("🎭"))
            {
                try
                {
                    mind.PerformIdealAction(tyranny.SuppressAllWeakness);
                }
                catch (BasicAnxietyException ex) { HandleAnxiety(ex); }
                continue;
            }

            if (choice.StartsWith("🩺"))
            {
                analyst.ConductTherapySession(mind);
                AnsiConsole.Prompt(new TextPrompt<string>("[grey]Нажмите Enter, чтобы продолжить...[/]").AllowEmpty());
                continue;
            }

            if (choice.StartsWith("🤝"))
            {
                var stratChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Выберите вектор адаптации (Coping Trend):")
                        .AddChoices(new[] {
                            "К людям (Уступчивость)",
                            "Против людей (Агрессия)",
                            "От людей (Обособленность)"
                        }));

                // Создаем реальные инстансы глубоких стратегий с внутренним состоянием
                currentStrategy = stratChoice switch
                {
                    "Против людей (Агрессия)" => new MovingAgainstPeople(),
                    "От людей (Обособленность)" => new MovingAwayFromPeople(),
                    _ => new MovingTowardPeople()
                };

                AnsiConsole.MarkupLine($"[green][[✓]] Внутренняя доминанта переключена на:[/] {currentStrategy.StrategyName}\n");
                continue;
            }

            if (choice.StartsWith("💥"))
            {
                try
                {
                    // Симулируем пропуск внешнего события через фильтры психики
                    mind.ProcessLifeEvent("Критика руководства", currentStrategy);
                }
                catch (BasicAnxietyException ex)
                {
                    // Перехватываем системную Базовую Тревогу
                    AnsiConsole.Write(new Rule("[bold red]КРИТИЧЕСКИЙ СБОЙ: БАЗОВАЯ ТРЕВОГА[/]") { Justification = Justify.Left });
                    AnsiConsole.MarkupLine($"[red]{Markup.Escape(ex.Message)}[/]");
                    AnsiConsole.MarkupLine("[bold yellow]🚨 ВНИМАНИЕ:[/] Психика заблокирована в терминальной стадии невроза.");
                    AnsiConsole.MarkupLine("[grey]Дальнейшие действия невозможны. Требуется полный перезапуск рантайма через меню.[/]\n");

                    // Просто уходим на следующую итерацию. Дашборд честно покажет аварийные проценты.
                    continue;
                }
            }
        }
    }

    private static void HandleAnxiety(BasicAnxietyException ex)
    {
        AnsiConsole.Write(new Rule("[bold red]КРИТИЧЕСКИЙ СБОЙ: БАЗОВАЯ ТРЕВОГА[/]") { Justification = Justify.Left });
        AnsiConsole.MarkupLine($"[red]{Markup.Escape(ex.Message)}[/]");
        AnsiConsole.MarkupLine("[bold yellow]🚨 ВНИМАНИЕ:[/] Психика заблокирована в терминальной стадии невроза.");
        AnsiConsole.MarkupLine("[grey]Дальнейшие действия невозможны. Требуется сеанс психоанализа или перезапуск рантайма.[/]\n");
    }
}


