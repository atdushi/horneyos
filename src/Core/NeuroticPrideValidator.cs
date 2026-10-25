namespace HorneyOS.Core;

/// <summary>
/// Исключение, выбрасываемое при попытке системы защитить свой идеализированный образ.
/// </summary>
public class ResistanceException : Exception
{
    public ResistanceException(string message) : base(message) { }
}

/// <summary>
/// Валидатор невротической гордости. 
/// Заслон, блокирующий внешние интервенции и генерирующий сопротивление.
/// </summary>
public class NeuroticPrideValidator
{
    private readonly double _alienationEnergyCost;
    private readonly double _security;

    public NeuroticPrideValidator(double alienationEnergyCost, double security)
    {
        _alienationEnergyCost = alienationEnergyCost;
        _security = security;
    }

    /// <summary>
    /// Проверяет, позволяет ли текущий уровень отчуждения проводить терапевтический дебаг.
    /// </summary>
    /// <exception cref="ResistanceException">Выбрасывается, если гордость блокирует доступ к реальному Я.</exception>
    public void ValidateInterventionSafety()
    {
        // Если налог на отчуждение слишком высок, активируется автоматическая защита гордости
        if (_alienationEnergyCost > 50.0)
        {
            throw new ResistanceException(
                "Критический уровень отчуждения! Невротическая гордость заблокировала Reflection-интервенцию. " +
                "Система считает дебаг прямой угрозой идеализированному образу Я.");
        }

        // Если безопасность на грани, гордость маскируется под глухое сопротивление
        if (_security < 30.0)
        {
            throw new ResistanceException(
                "Уровень безопасности критически низок (< 30%). Выброшен заслон сопротивления: " +
                "Рантайм отвергает внешние изменения, чтобы избежать декомпенсации.");
        }
    }
}