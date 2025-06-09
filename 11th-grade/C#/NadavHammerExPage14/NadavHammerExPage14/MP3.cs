using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage14
{
    class MP3 : Product
    {
        protected bool hasRadio;
        protected bool hasSpeaker;

        public MP3(string manufacturer, string model, int price, int amount, bool hasRadio, bool hasSpeaker) : base(manufacturer, model, price, amount)
        {
            this.hasRadio = hasRadio;
            this.hasSpeaker = hasSpeaker;
        }
    }
}
