using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class DamageCasterDebugDrawer : MonoBehaviour
    {
        [Inject] private DamageCasterManager Manager;

        private void OnDrawGizmos()
        {
            if (Manager == null) return;

            foreach (var cast in Manager.GetActiveCasts())
            {
                if (cast.Parameters?.Source == null) continue;

                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(cast.Parameters.Source.position, cast.Parameters.Radius);
            }
        }
    }
}