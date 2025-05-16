using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class DamageCasterManager : ITickable
    {
        public class TimedCast
        {
            public DamageCastRequest Request;
            public float Timer;

            public TimedCast(DamageCastRequest request)
            {
                Request = request;
                Timer = request.Time;
            }
        }

        private readonly List<TimedCast> _activeCasts = new();
        public IEnumerable<TimedCast> GetActiveCasts() => _activeCasts;

        public void CastDamage(int damage, float radius, float time, LayerMask layerMask, Transform source)
        {
            _activeCasts.Add(new TimedCast(new DamageCastRequest
            {
                Damage = damage,
                Radius = radius,
                Time = time,
                LayerMask = layerMask,
                Source = source
            }));
        }

        public void Tick()
        {
            for (int i = _activeCasts.Count - 1; i >= 0; i--)
            {
                TimedCast cast = _activeCasts[i];
                cast.Timer -= Time.deltaTime;

                bool damageApplied = false;

                Collider[] hitColliders = Physics.OverlapSphere(
                    cast.Request.Source.position,
                    cast.Request.Radius,
                    cast.Request.LayerMask
                );

                foreach (var hit in hitColliders)
                {
                    IDamageable damageable = hit.GetComponent<IDamageable>();
                    if (damageable != null)
                    {
                        damageable.TakeDamage(cast.Request.Damage);
                        damageApplied = true;
                        break;
                    }
                }

                if (damageApplied || cast.Timer <= 0f)
                {
                    _activeCasts.RemoveAt(i);
                }
            }
        }
    }
}