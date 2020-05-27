using System;

namespace Types
{
    public enum NeedType
    {
        Energy,
        Hunger,
        Fun,
        Hygiene,
        Mentality
    }

    public enum PlayerState
    {
        Idle,
        Move,
        Act,
    }

    public enum TaskType
    {
        Value,
        Action,
    }

    public enum ValueType
    {
        Money,
        Work,
    }

    [Serializable]
    public struct ValueAmount
    {
        public ValueType valueType;
        public int amount;
    }

    public enum GameState
    {
        Game,
        GameOver,
        Victory
    }
}



