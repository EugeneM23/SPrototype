using DamageNumbersPro;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class RagePickUp : MonoBehaviour
    {
        [SerializeField] private float _fireRatePercentage;
        [SerializeField] private float _speedPercentage;
        [SerializeField] private Entity _effectPrefab;
        [SerializeField] private Entity _uiPrefab;
        [SerializeField] private DamageNumber _damageNumber;

        [Inject] private readonly GameFactory _factory;
        [Inject] private readonly DiContainer _container;

        private BaseBuff _baseBuff;
        private Entity _target;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Entity>().TryGet<CharacterController>(out var value))
            {
                _target = other.GetComponent<Entity>();

                _baseBuff = new BuffBuilder<BaseBuff>()
                    .Target(_target)
                    .Timed(10)
                    .Stackable(8)
                    .Stats((BuffMultiplayerID.Speed, _speedPercentage),
                        (BuffMultiplayerID.FireRate, _fireRatePercentage))
                    .Build();


                _target.Get<BuffManager>().AddBuff(_baseBuff);
                SpawnEffects(_target);

                gameObject.GetComponent<Entity>().Dispose();
            }
        }

        private void SpawnEffects(Entity target)
        {
            var effect = _factory.Create(_effectPrefab);
            effect.Get<EffectCaster>().CastEffect(target.transform, 2);
            _damageNumber.Spawn(target.transform.position + new Vector3(0, 3, 0), target.transform);
            gameObject.GetComponent<Entity>().Dispose();

            var ui = _factory.Create(_uiPrefab);

            ui.GetComponent<RageUI>().SetDuration(10);

            _baseBuff.OnStack += ui.Dispose;

            ui.GetComponent<RageUI>().SetStuck(_baseBuff.StackCount);
            _baseBuff.Ondiscad += ui.Dispose;
            _baseBuff.OnTick += ui.GetComponent<RageUI>().UpdateSlider;

            ui.Get<EffectCaster>().CastEffect(target.transform, -1);
        }
    }
}