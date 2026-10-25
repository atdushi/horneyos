using HorneyOS.Core;
using HorneyOS.IdealSelf;
using HorneyOS.Strategies;
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        // Устанавливаем кодировку для корректного отображения эмодзи и спецсимволов в Windows-консоли
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // 1. Инициализация рантайма
        var mind = new NeuroticMind();
        var tyranny = new ShouldsTyrannyDecorator();
        var therapist = new Psychoanalyst();

        while (true)
        {
            AnsiConsole.Write(new FigletText("HorneyOS v9.0").Color(Color.DeepPink1));
            AnsiConsole.MarkupLine("[bold italic magenta]Ортодоксальный психоаналитический рантайм запущен успешно.[/]\n");

            // 2. Пассивное истощение ресурсов за счет Налога на Отчуждение при каждом цикле (тике) психики
            try
            {
                mind.OnRuntimeTick();
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
                AnsiConsole.MarkupLine("\n[bold red][[🚨 КОЛЛАПС]]:[/] Жизненная сила Реального Я упала до нуля. Наступил глубокий экзистенциальный ступор.");
                WaitForAnyKey();
                break; // Выход из симуляции или сброс рантайма
            }

            // 3. Отрисовка интерактивного дашборда Spectre.Console
            var table = new Table();
            table.AddColumn("[bold yellow]Психический Ресурс[/]");
            table.AddColumn("[bold green]Значение[/]");
            table.AddColumn("[bold blue]Визуальный График Состояния[/]");

            // Формируем динамические цветные полосы для каждого ресурса
            string securityBar = GetProgressBar((int)mind.Security, Color.Green, Color.Red, inverse: false);
            string vitalityBar = GetProgressBar((int)mind.RealSelfVitality, Color.SpringGreen3, Color.DarkRed_1, inverse: false);
            // Для налога цвет инвертирован: чем выше налог, тем «горячее» и опаснее должен быть бар
            string alienationBar = GetProgressBar((int)mind.AlienationEnergyCost, Color.DarkViolet, Color.Magenta1, inverse: true);

            table.AddRow("🛡️ Безопасность (_security)", $"{mind.Security:F1}%", securityBar);
            table.AddRow("🌱 Витальность Реального Я (_realSelfVitality)", $"{mind.RealSelfVitality:F1}%", vitalityBar);
            table.AddRow("💸 Налог на Отчуждение (_alienationEnergyCost)", $"{mind.AlienationEnergyCost:F1} ед.", alienationBar);

            // Выводим центрированную таблицу через Align, защищая рантайм от ошибки CS0311
            AnsiConsole.Write(new Align(table, HorizontalAlignment.Center));
            AnsiConsole.WriteLine();

            // 4. Интерактивное Меню Действий
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Выберите [underline yellow]жизненное событие[/] или действие:")
                    .PageSize(10)
                    .AddChoices([
                        "💥 Получить критику от руководства (-40 к Безопасности)",
                        "🚀 [[Идеал]] Сдать сложный проект по работе (Активация Тирании)",
                        "🎭 [[Идеал]] Подавить усталость и быть идеальным (Взлет Налога)",
                        "🩺 Пройти сеанс психоанализа (Reflection Injection)",
                        "🔄 Сбросить рантайм к базовым настройкам",
                        "❌ Выйти из симуляции"
                    ]));

            if (choice.StartsWith("❌")) break;

            try
            {
                if (choice.StartsWith("💥"))
                {
                    // Вектор уступчивой защиты по умолчанию для обработки кризиса
                    mind.ProcessLifeEvent("Критика руководства", new MovingTowardPeople());
                }
                else if (choice.StartsWith("🚀"))
                {
                    // Вызов метода через GoF-декоратор без изменения структуры оригинального меню
                    mind.PerformIdealAction(tyranny.DeployPerfectProject);
                }
                else if (choice.StartsWith("🎭"))
                {
                    mind.PerformIdealAction(tyranny.SuppressAllWeakness);
                }
                else if (choice.StartsWith("🩺"))
                {
                    AnsiConsole.MarkupLine("[yellow][[🩺 АНАЛИЗ]]:[/] Психоаналитик пытается пробиться к приватным полям через Reflection...");
                    therapist.ConductTherapySession(mind);
                }
                else if (choice.StartsWith("🔄"))
                {
                    mind = new NeuroticMind();
                    tyranny = new ShouldsTyrannyDecorator();
                    AnsiConsole.MarkupLine("[green]Рантайм перезапущен. Защитные механизмы сброшены.[/]");
                }
            }
            catch (BasicAnxietyException ex)
            {
                AnsiConsole.MarkupLine($"\n[bold red][[!]] Хронический сбой системы:[/] {ex.Message}");                
            }

            WaitForAnyKey();
            Console.Clear();
        }
    }

    // Хелпер для генерации красивых текстовых прогресс-баров со Spectre-разметкой
    private static string GetProgressBar(int value, Color activeColor, Color alertColor, bool inverse)
    {
        int totalBlocks = 20;
        // Ограничиваем значение в рамках от 0 до 100 для красивого рендеринга шкал
        int normalizedValue = Math.Clamp(value, 0, 100);
        int filledBlocks = (int)Math.Round((normalizedValue / 100.0) * totalBlocks);

        // Определяем цвет на основе порогов и флага инверсии
        bool isAlert = inverse ? normalizedValue > 60 : normalizedValue < 30;
        string colorStr = isAlert ? alertColor.ToMarkup() : activeColor.ToMarkup();

        string filled = new string('█', filledBlocks);
        string empty = new string('░', totalBlocks - filledBlocks);

        return $"[{colorStr}]{filled}{empty}[/]";
    }

    private static void WaitForAnyKey()
    {
        AnsiConsole.MarkupLine("\n[grey]Нажмите любую клавишу для продолжения психического цикла...[/]");
        Console.ReadKey(true);
    }
}
