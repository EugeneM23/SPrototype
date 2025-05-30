using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class DamageCasterManager : ITickable
    {
        public class TimedCast
        {
            public DamageCastParams Parameters;
            public float Timer;

            public TimedCast(DamageCastParams parameters)
            {
                Parameters = parameters;
                Timer = parameters.Time;
            }
        }

        private readonly List<TimedCast> _activeCasts = new();
        public IEnumerable<TimedCast> GetActiveCasts() => _activeCasts;

        public void CastDamage(DamageCastParams parameters)
        {
            _activeCasts.Add(new TimedCast(parameters));
        }

        public void Tick()
        {
            for (int i = _activeCasts.Count - 1; i >= 0; i--)
            {
                if (_activeCasts[i] == null) continue;

                TimedCast cast = _activeCasts[i];
                cast.Timer -= Time.deltaTime;

                bool damageApplied = false;

                if (cast.Parameters.Source == null) return;

                Collider[] hitColliders = Physics.OverlapSphere(
                    cast.Parameters.Source.position,
                    cast.Parameters.Radius,
                    cast.Parameters.LayerMask
                );

                foreach (Collider hit in hitColliders)
                {
                    IDamageable damageable = hit.GetComponent<Entity>().Get<IDamageable>();
                    if (damageable != null)
                    {
                        damageable.TakeDamage(cast.Parameters.Damage);
                        damageApplied = true;
                        break;
                    }
                }

                if (damageApplied || cast.Timer <= 0f || cast == null)
                {
                    _activeCasts.RemoveAt(i);
                }
            }
        }
    }

    public enum DamageCastLayer
    {
        Enemy,
        Player,
    }
}