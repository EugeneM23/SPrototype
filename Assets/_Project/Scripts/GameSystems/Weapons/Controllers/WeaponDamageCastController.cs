using System;
using Zenject;

namespace Gameplay
{
    public class WeaponDamageCastController : IInitializable, IDisposable
    {
        private readonly DamageCastHandler _damageCastHandler;
        private readonly AnimationEventProvider _eventProvider;

        public WeaponDamageCastController(DamageCastHandler damageCastHandler, AnimationEventProvider eventProvider)
        {
            _damageCastHandler = damageCastHandler;
            _eventProvider = eventProvider;
        }

        public void Initialize() => _eventProvider.OnCall += DoDamageCast;
        public void Dispose() => _eventProvider.OnCall -= DoDamageCast;

        private void DoDamageCast(string name)
        {
            if (name == "DamageCast")
                _damageCastHandler.EnebleDamageCast();
        }
    }
}