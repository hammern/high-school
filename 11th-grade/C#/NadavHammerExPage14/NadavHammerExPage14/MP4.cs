using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadavHammerExPage14
{
    class MP4 : MP3
    {
        private int screenLength;

        public MP4(string manufacturer, string model, int price, int amount, bool hasRadio, bool hasSpeaker, int screenLength) : base(manufacturer, model, price, amount, hasRadio, hasSpeaker)
        {
            this.screenLength = screenLength;
        }
    }
}
