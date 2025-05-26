using UnityEngine;

namespace Gameplay.Loot.PickUpObjects
{
    public class TestWeaponPickUp : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterController>())
            {
                Entity go = other.GetComponent<Entity>();

                var asd = go.Get<Inventory>();
            }
        }
    }
}