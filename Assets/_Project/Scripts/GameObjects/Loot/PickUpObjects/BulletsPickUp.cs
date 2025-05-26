using UnityEngine;

namespace Gameplay.Loot.PickUpObjects
{
    public class BulletsPickUp : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterController>())
            {
                Entity go = other.GetComponent<Entity>();
                go.Get<Inventory>().AddBullets(30);
                gameObject.SetActive(false);
            }
        }
    }
}