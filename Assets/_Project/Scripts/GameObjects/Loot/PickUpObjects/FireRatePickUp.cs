using System;
using UnityEngine;

namespace Gameplay.Loot.PickUpObjects
{
    public class FireRatePickUp : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterController>())
            {
                Entity go = other.GetComponent<Entity>();

                var asd = go.Get<PlayerWeaponManager>();
                asd.CurrentWeapon.Get<WeaponCooldownAction>().SetFireRate(-0.1f);
                gameObject.SetActive(false);
            }
        }
    }
}