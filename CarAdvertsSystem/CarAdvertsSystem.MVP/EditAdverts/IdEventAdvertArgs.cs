using System;

namespace CarAdvertsSystem.MVP.EditAdverts
{
    public class IdEventAdvertArgs : EventArgs
    {
        public int Id { get; private set; }

        public IdEventAdvertArgs(int id)
        {
            this.Id = id;
        }
    }
}
