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
                go.Get<PlayerMoveComponent>().SetSpeed(5);
                gameObject.SetActive(false);
            }
        }
    }
}