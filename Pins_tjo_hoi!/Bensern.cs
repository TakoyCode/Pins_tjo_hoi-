using System.Reflection.Metadata;
using System.Threading;

namespace Pins_tjo_hoi_
{
    internal class Bensern
    {
        private Player _player;
        private int _randomIndex;
        private List<string> _pins;
        private int _pinPrice;
        private int _gasPrice;

        public bool wantToLeave { get; private set; }
        public string Name { get;}

        public Bensern(Player player, List<string> pins, string name)
        {
            _player = player;
            _pins = pins;
            Name = name;

            var r = new Random();
            _randomIndex = r.Next(0, pins.Count);
            _pinPrice = r.Next(10, 100);
            _gasPrice = r.Next(20, 80);
        }

        public void ShowMeny()
        {
            Console.Clear();
            Console.WriteLine($"Du er nå på {Name}");
            Console.WriteLine("Hva har du lyst til å gjøre?");
            Console.WriteLine("1) Gå inn i butikken");
            Console.WriteLine("2) Fylle på bensin");
            Console.WriteLine("3) Spille guitar forran stasjonen for penger");
            Console.WriteLine("4) Dra til finere bensere");
        }


        public void ChooseMeny()
        {
            var UserInput = Console.ReadKey(true).KeyChar;
            switch (UserInput)
            {
                case '1':
                    Shop();
                    break;
                case '2':
                    PumpGas();
                    break;
                case '3':
                    _player.PlayForMoney();
                    Thread.Sleep(2000);
                    break;
                case '4':
                    LeaveStation();
                    break;
            }
        }

        private void LeaveStation()
        {
            if (_player.Drive())
            {
                wantToLeave = true;
            }
            Thread.Sleep(2000);
        }


        private void PumpGas()
        {
            Console.Clear();
            _player.ShowMoney();
            Console.WriteLine($"Det koster {_gasPrice}peng");
            Console.WriteLine("Har du lyst å fylle på bensin? y/n");
            var UserInput = Console.ReadKey(true).KeyChar;
            if (char.ToLower(UserInput) == 'y')
            {
                if (_player.Pay(_gasPrice)) _player.Refuel();
                Thread.Sleep(2000);
            }
            else if (char.ToLower(UserInput) == 'n')
            {
            }
            else
            {
                PumpGas();
            }
        }

        public void Shop()
        {
            Console.Clear();
            Console.WriteLine("Velkommen!\nVi har denne Pinsen");
            Console.WriteLine($"Navn: {_pins[_randomIndex]}\nPris: {_pinPrice}");
            Console.WriteLine();
            _player.ShowMoney();
            Console.WriteLine("\n1) Kjøp pinsen");
            Console.WriteLine("2) Gå ut av butta");
                var userInput = Console.ReadKey(true).KeyChar;
                if (userInput == '1')
                {
                    _player.BuyPins(_pins[_randomIndex], _pinPrice);
                }
                else if (userInput == '2')
                {
                    ShowMeny();
                }
                else Shop();
        }

    }
}
