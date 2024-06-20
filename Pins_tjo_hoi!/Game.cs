using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace Pins_tjo_hoi_
{
    internal class Game
    {
        private List<string> _allPins;
        private List<string> _allBensernNames;
        private List <Trinket> _trinkets;
        private Player _player;
        private Bensern _bensern;

        public Game()
        {
            _allPins =
            [
                "Cowboy Pin",
                "Travler Pin",
                "Farmer Pin",
                "Cactus Pin",
                "Cow Pin",
                "Farm house Pin",
            ];

            _trinkets =
            [
                new Trinket("Balltre med glitter", "Gir deg avslag på bensin"),
                new Trinket("Pins Prins", "Mulig å få en ekstra pin når du kjøper en"),
                new Trinket("Wånderbævm i Ruta", "Bilen din når altid en ekstra stasjon"),
            ];

            _allBensernNames =
            [
                "7/11",
                "Circle K",
                "YX",
                "Esso",
                "Uno x",
                "Shell",
            ];
        }
        public void StartGame()
        {
            Createplayer();
            CreateNewStation();
            while (true)
            {
                _bensern.ShowMeny();
                _bensern.ChooseMeny();
                if (_bensern.wantToLeave == true)
                {
                    CreateNewStation();
                }
            }
        }

        private void CreateNewStation()
        {
            _bensern = new Bensern(_player, _allPins, GetRandomBenserName());
        }

        private string GetRandomBenserName()
        {
            var r = new Random();
            var randomIndex = r.Next(_allBensernNames.Count);
            return _allBensernNames[randomIndex];
        }

        private void Createplayer()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            _player = new Player(name, ChooseTrinket(), 100, 5);
        }

        private Trinket ChooseTrinket()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What trinket do you have on you?");
                for (int i = 0; i < _trinkets.Count; i++)
                {
                    Console.Write($"{i+1}) ");
                    _trinkets[i].Show();
                }
                var userInputStr = Console.ReadLine();
                if (int.TryParse(userInputStr, out int index))
                {
                    if (index > 0 && index <= _trinkets.Count)
                    {
                        return _trinkets[index - 1];
                    }
                }
            }
        }
    }
}
