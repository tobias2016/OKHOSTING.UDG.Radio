using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UDG.Radio.UI
{
    public interface IAudioPlayer
    {
        Uri Source { get; set; }
        void Play();
        void Pause();
        void Stop();
    }
}