using HorneyOS.Strategies;

namespace HorneyOS.Core;

// 1. Создаем собственный делегат, который легально поддерживает ref-параметры
public delegate void IdealActionDelegate(ref double security, ref double realSelfVitality);

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

    // Публичные свойства для чтения извне
    public double Security => _security;
    public double RealSelfVitality => _realSelfVitality;

    public void ProcessLifeEvent(string description, ICopingStrategy defense)
    {
        Console.WriteLine($"\n[⚡] Событие: {description}");
        _security -= 40; // Изменяем поле напрямую

        if (_security < 20) throw new BasicAnxietyException("Защита пробита!");

        // Передаем приватные поля по ссылке ref — теперь компилятор доволен
        defense.Apply(ref _security, ref _realSelfVitality);
    }

    // 2. Используем наш кастомный делегат вместо Action
    public void PerformIdealAction(IdealActionDelegate idealAction)
    {
        if (_security < 20) throw new BasicAnxietyException("Защита пробита! Вы парализованы тревожными мыслями.");

        idealAction(ref _security, ref _realSelfVitality);
    }
}
