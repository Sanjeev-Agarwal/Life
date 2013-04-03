using System;

namespace Life.API.Contracts
{
    public interface ICell
    {
        Boolean IsAlive { get; set; }
    }
}