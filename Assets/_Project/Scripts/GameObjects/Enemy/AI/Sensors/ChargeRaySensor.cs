using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class ChargeRaySensor
    {
        [Inject(Id = CharacterParameterID.CharacterEntity)]
        private readonly Entity _entity;

        private readonly LayerMask _detectionLayer;
        private float rayLength = 20f;

        public ChargeRaySensor(LayerMask detectionLayer)
        {
            _detectionLayer = detectionLayer;
        }

        public Vector3 CastRay()
        {
            Ray ray = new Ray(_entity.transform.position, _entity.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayLength, _detectionLayer))
            {
                Vector3 hitPoint = hit.point;
                Debug.DrawLine(_entity.transform.position, hitPoint, Color.green);
                return hitPoint;
            }
            else
            {
                Vector3 endPoint = _entity.transform.position + _entity.transform.forward * rayLength;
                Debug.DrawLine(_entity.transform.position, endPoint, Color.red);
                return endPoint;
            }
        }
    }
}