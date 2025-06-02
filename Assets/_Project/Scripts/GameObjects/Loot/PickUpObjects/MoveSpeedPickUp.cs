using UnityEngine;

namespace Gameplay.Loot.PickUpObjects
{
    public class MoveSpeedPickUp : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterController>())
            {
                Entity go = other.GetComponent<Entity>();
                gameObject.SetActive(false);
            }
        }
    }
}