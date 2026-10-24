namespace HorneyOS.Strategies;

// Единый интерфейс совладания с тревогой
public interface ICopingStrategy
{
    string StrategyName { get; }

    void Apply(ref double securityLevel, ref double realSelfVitality);
}
