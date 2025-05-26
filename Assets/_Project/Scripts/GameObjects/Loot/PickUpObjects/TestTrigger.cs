using System;
using UnityEngine;

namespace Gameplay.Loot.PickUpObjects
{
    public class TestTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterController>())
            {
                Entity go = other.GetComponent<Entity>();

                Debug.Log(go.name);
                go.Get<Inventory>().SetBullet(10);
                go.Get<PlayerMoveComponent>().SetSpeed(2);
                go.Get<HealthComponent>().Heal(500);
                go.Get<HealthComponent>().Heal(500);
                var asd = go.Get<PlayerWeaponManager>();
                asd.CurrentWeapon.Get<WeaponCooldownAction>().SetFireRate(-0.2f);
                Debug.Log(asd.CurrentWeapon == null);
            }
        }
    }
}