using UnityEngine;
using DamageNumbersPro;
using Zenject;

namespace Gameplay
{
    public class DamageNumberSpawner
    {
        private DamageNumber _popupPrefab;
        private Entity _target;

        public DamageNumberSpawner(
            DamageNumber popupPrefab,
            [Inject(Id = CharacterParameterID.CharacterEntity)]
            Entity target
        )
        {
            _popupPrefab = popupPrefab;
            _target = target;
        }

        public void SpawnPopup(int damage)
        {
            _popupPrefab.Spawn(_target.transform.position + new Vector3(0, 3, 0), damage);
        }
    }
}