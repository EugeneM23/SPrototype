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
                    .StackAction(SpawnStackEffects)
                    .ApplyAction(SawnApllyEffect)
                    .Build();


                _target.Get<BuffManager>().AddBuff(_baseBuff);
                _baseBuff.OnApply += SpawnStackEffects;
                gameObject.GetComponent<Entity>().Dispose();
            }
        }

        private void SpawnStackEffects()
        {
            var ui = _factory.Create(_uiPrefab);

            ui.GetComponent<RageUI>().SetDuration(10);

            _baseBuff.OnStack += ui.GetComponent<RageUI>().SetStuck;

            ui.GetComponent<RageUI>().SetStuck(_baseBuff.StackCount);
            _baseBuff.Ondiscad += ui.Dispose;
            _baseBuff.OnTick += ui.GetComponent<RageUI>().UpdateSlider;

            ui.Get<EffectCaster>().CastEffect(_target.transform, -1);
        }

        private void SawnApllyEffect()
        {
            var effect = _factory.Create(_effectPrefab);
            effect.Get<EffectCaster>().CastEffect(_target.transform, 2);
            _damageNumber.Spawn(_target.transform.position + new Vector3(0, 3, 0), _target.transform);
        }
    }
}