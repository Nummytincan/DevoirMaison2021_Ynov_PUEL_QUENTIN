using System;
using System.Collections.Generic;
using System.Text;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT
{
    
    public class DeathEventArgs : EventArgs
    {
        public Character Body { get; set; }
            
    }

    public delegate void DeathEventHandler(Object sender, DeathEventArgs e);

}
