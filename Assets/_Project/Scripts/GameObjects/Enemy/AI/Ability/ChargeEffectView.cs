using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class ChargeEffectView : MonoBehaviour

    {
        [Inject] private readonly HealthComponent _healthComponent;
        private void OnEnable() => _healthComponent.OnDead += _ => gameObject.SetActive(false);
    }
}