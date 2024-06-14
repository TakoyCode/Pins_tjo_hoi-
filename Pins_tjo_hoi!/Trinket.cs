using System.Xml.Linq;

namespace Pins_tjo_hoi_
{
    internal class Trinket
    {
        private string _name;
        private string _effect;

        public Trinket(string name, string effect)
        {
            _name = name;
            _effect = effect;
        }

        public void Show()
        {
            Console.WriteLine(_name + " - " + _effect);
        }
    }
}
