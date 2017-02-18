using System;

namespace CarAdvertsSystem.MVP.EditUsers
{
    public class IdEventArgs : EventArgs
    {
        public Guid Id { get; private set; }

        public IdEventArgs(Guid id)
        {
            this.Id = id;
        }
    }
}
