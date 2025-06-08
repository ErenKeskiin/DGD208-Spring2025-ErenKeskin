namespace InteractivePetSimulator
{
    public class Player
    {
        public int Money { get; private set; }

        public Player(int initialMoney)
        {
            Money = initialMoney;
        }

        public bool SpendMoney(int amount)
        {
            if (Money >= amount)
            {
                Money -= amount;
                return true;
            }
            return false;
        }

        public void AddMoney(int amount)
        {
            Money += amount;
        }
    }
}