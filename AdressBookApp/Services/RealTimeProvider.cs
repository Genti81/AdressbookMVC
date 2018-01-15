using AdressBookApp.Interface;
using System;

namespace AdressBookApp.Services
{
    public class RealTimeProvider : ITimeProvider
    {
        public DateTime Now { get => DateTime.Now; set => throw new NotImplementedException(); }
    }
}
