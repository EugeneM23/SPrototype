using UnityEngine;

namespace Gameplay
{
    public class DamagelayerComponent
    {
        private readonly LayerMask _layerMask;

        public DamagelayerComponent(LayerMask layerMask)
        {
            _layerMask = layerMask;
        }

        public int GetDamageLayer()
        {
            int value = _layerMask.value;
            for (int i = 0; i < 32; i++)
            {
                if ((value & (1 << i)) != 0)
                    return i;
            }

            return 0;
        }
    }
}