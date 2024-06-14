using System.Security.Cryptography;

namespace Pins_tjo_hoi_
{
    internal class Player
    {
        private string _name;
        private Trinket _chosenTrinket;
        public int Money { get; private set; }
        private int _maxGas;
        private int _gas;
        private List<string> _collectedPins;

        public Player(string name, Trinket chosenTrinket,  int money, int gas)
        {
            _name = name;
            _chosenTrinket = chosenTrinket;
            Money = money;
            _gas = gas;
            _maxGas = gas;
            _collectedPins = new List<string>();
        }

        public void Refuel()
        {
            _gas = _maxGas;
        }

        public void PlayForMoney()
        {
            var r = new Random();
            var gainedMoney = r.Next(0, 100);
            Money += gainedMoney;
            Console.WriteLine($"Du tjente {gainedMoney} peng");
        }

        public void ShowPins()
        {
            if(_collectedPins.Count > 0)
            {
                foreach (var pin in _collectedPins)
                {
                    Console.WriteLine(pin);
                }
            }
            else
            {
                Console.WriteLine("You have no pins :(");
                Console.WriteLine("Go collect some!");
            }
        }

        public void BuyPins(string pin, int pinPrice)
        {
            if (Money >= pinPrice)
            {
                Money -= pinPrice;
                _collectedPins.Add(pin);
                Console.WriteLine($"Takk for at du kjøpt {pin} hos oss!");
            }
            else Console.WriteLine($"Ser ikke ut som du har nok penger :(");
        }
    }
}
