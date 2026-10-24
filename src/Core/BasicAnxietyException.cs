namespace HorneyOS.Core;

// Хронический сбой системы при потере безопасности
public class BasicAnxietyException : Exception
{
    public BasicAnxietyException(string msg)
        : base($"[🚨 БАЗОВАЯ ТРЕВОГА: Изоляция во враждебной среде] {msg}") { }
}