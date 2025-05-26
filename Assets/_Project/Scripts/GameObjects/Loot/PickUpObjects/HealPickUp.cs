using UnityEngine;

namespace Gameplay.Loot.PickUpObjects
{
    public class HealPickUp : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterController>())
            {
                Entity go = other.GetComponent<Entity>();
                go.Get<HealthComponent>().Heal(500);
                gameObject.SetActive(false);
            }
        }
    }
}