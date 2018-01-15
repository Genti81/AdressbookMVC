using AdressBookApp.Interface;
using System;

namespace AdressBookApp.Services
{
    public class FakeTimeProvider : ITimeProvider
    {
        private DateTime _now;
        public DateTime Now { get => _now; set => _now = value; }
    }
}
