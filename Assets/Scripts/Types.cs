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
        Exp,
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

    public class Data
    {
        public int money;
        public int tasksDone;
        public int needIncreased;
        public int needDecreased;
        public int exp;

        public Data(int money, int tasksDone, int needIncreased, int needDecreased, int exp)
        {
            this.money = money;
            this.tasksDone = tasksDone;
            this.needIncreased = needIncreased;
            this.needIncreased = needIncreased;
            this.needDecreased = needDecreased;
            this.exp = exp;
        }
    }
}



