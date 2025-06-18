using UnityEngine;

namespace Gameplay
{
    public class DamageLayerComponent
    {
        public readonly LayerMask LayerMask;

        public DamageLayerComponent(LayerMask layerMask)
        {
            LayerMask = layerMask;
        }

        /*public int GetDamageLayer()
        {
            int value = _layerMask.value;
            for (int i = 0; i < 32; i++)
            {
                if ((value & (1 << i)) != 0)
                    return i;
            }

            return 0;
        }*/
    }
}