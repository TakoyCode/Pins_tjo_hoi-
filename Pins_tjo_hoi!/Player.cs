using System.Security.Cryptography;

namespace Pins_tjo_hoi_
{
    internal class Player
    {
        private string _name;
        private Trinket _chosenTrinket;
        private int _money;
        private int _maxGas;
        private int _gas;
        private List<string> _collectedPins;

        public Player(string name, Trinket chosenTrinket,  int money, int gas)
        {
            _name = name;
            _chosenTrinket = chosenTrinket;
            _money = money;
            _gas = gas;
            _maxGas = gas;
            _collectedPins = new List<string>();
        }

        public bool Drive()
        {
            if (_gas >= 1)
            {
                _gas -= 1;
                Console.Clear();
                Console.WriteLine("Finere bensere er rett rundt svingen :)");
                return true;
            }
            Console.WriteLine("Du har ikke nok bensin, til å dra til finere bensere :(");
            return false;
        }

        public void Refuel()
        {
                _gas = _maxGas;
        }

        public bool Pay(int price)
        {
            if (_money >= price)
            {
                _money -= price;
                return true;
            }
            Console.WriteLine("Du har ikke nok penger :(");
            return false;
        }

        public void PlayForMoney()
        {
            var r = new Random();
            var gainedMoney = r.Next(0, 100);
            _money += gainedMoney;
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
            if (_money >= pinPrice)
            {
                _money -= pinPrice;
                _collectedPins.Add(pin);
                Console.WriteLine($"Takk for at du kjøpt {pin} hos oss!");
            }
            else Console.WriteLine($"Ser ikke ut som du har nok penger :(");
        }

        public void ShowMoney()
        {
            Console.WriteLine($"Du har: {_money} peng");
        }
    }
}
