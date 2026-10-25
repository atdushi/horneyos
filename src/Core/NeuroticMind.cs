using HorneyOS.Strategies;

namespace HorneyOS.Core;

// 1. Создаем собственный делегат, который легально поддерживает ref-параметры
public delegate void IdealActionDelegate(ref double security, ref double realSelfVitality, ref double alienationEnergyCost);

public class NeuroticMind
{
    // защита от Базальной Тревоги
    private double _security = 50.0;

    /// <summary>
    /// (Жизненная сила Реального Я): Хорни верила, что у каждого человека есть здоровое «Реальное Я» (Real Self) — внутренний центр, 
    /// который обладает природным стремлением к росту, спонтанности и искренним чувствам. Невроз не уничтожает его, но парализует. 
    /// Когда Тирания «Должен» заставляет нас быть идеальными, мы тратим не «топливо», а блокируем свою спонтанность и живые чувства.
    /// </summary>
    private double _realSelfVitality = 100.0;

    /// <summary>
    /// Налог на отчуждение. Энергия, расходуемая на удержание маски Идеального Я 
    /// и подавление сигналов от Реального Я. Растет при каждой карающей интервенции.
    /// </summary>
    private double _alienationEnergyCost = 10.0;

    // Публичные свойства для чтения извне
    public double Security => _security;
    public double RealSelfVitality => _realSelfVitality;
    public double AlienationEnergyCost => _alienationEnergyCost;

    public void ProcessLifeEvent(string description, ICopingStrategy defense)
    {
        Console.WriteLine($"\n[⚡] Событие: {description}");
        _security -= 40; // Изменяем поле напрямую

        if (_security < 20)
        {
            throw new BasicAnxietyException("Защита пробита!");
        }

        // Передаем приватные поля по ссылке ref — теперь компилятор доволен
        defense.Apply(ref _security, ref _realSelfVitality);
    }

    // 2. Используем наш кастомный делегат вместо Action
    public void PerformIdealAction(IdealActionDelegate idealAction)
    {
        if (_security < 20)
        {
            throw new BasicAnxietyException("Защита пробита! Вы парализованы тревожными мыслями.");
        }

        idealAction(ref _security, ref _realSelfVitality, ref _alienationEnergyCost);
    }

    /// <summary>
    /// Метод должен вызываться на каждой итерации бесконечного цикла Program.cs.
    /// Моделирует непрерывное, фоновое истощение ресурсов отчужденной личностью.
    /// </summary>
    public void OnRuntimeTick()
    {
        // Каждая единица налога на отчуждение вычитает 0.1 единицы витальности за тик
        _realSelfVitality -= _alienationEnergyCost * 0.1;

        if (_realSelfVitality <= 0)
        {
            _realSelfVitality = 0;
            throw new Exception("[💥 ЭКЗИСТЕНЦИАЛЬНЫЙ СТУПОР]: Психика полностью истощена удержанием идеального образа. Нет энергии на жизнь.");
        }
    }
}
