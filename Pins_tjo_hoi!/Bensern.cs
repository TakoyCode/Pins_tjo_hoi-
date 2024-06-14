namespace Pins_tjo_hoi_
{
    internal class Bensern
    {
        private Player _player;
        private int _randomIndex;
        private List<string> _pins;
        private int _pinPrice;

        public Bensern(Player player, List<string> pins)
        {
            _player = player;
            _pins = pins;
            var r = new Random();
            _randomIndex = r.Next(0, pins.Count);
            _pinPrice = r.Next(10, 100);
        }

        public void ShowMeny()
        {
            Console.Clear();
            Console.WriteLine("Hva har du lyst til å gjøre?");
            Console.WriteLine("1) Gå inn i butikken");
            Console.WriteLine("2) Fylle på bensin");
            Console.WriteLine("3) Spille guitar forran stasjonen for penger");
            Console.WriteLine("4) Dra til finere bensere");
        }

        public void Shop()
        {
            Console.Clear();
            Console.WriteLine("Velkommen!\nVi har denne Pinsen");
            Console.WriteLine($"Navn: {_pins[_randomIndex]}\nPris: {_pinPrice}");
            Console.WriteLine($"\nVi har: {_player.Money} peng");
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
