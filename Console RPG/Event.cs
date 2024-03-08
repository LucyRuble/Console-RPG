using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Event
    {
        public bool isResloved;

        public Event(bool isResloved)
        {
            this.isResloved = isResloved;
        }

        public abstract void Resolve(List<Player> players);
    }
}
