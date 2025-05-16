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
                if (cast.Request?.Source == null) continue;

                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(cast.Request.Source.position, cast.Request.Radius);
            }
        }
    }
}