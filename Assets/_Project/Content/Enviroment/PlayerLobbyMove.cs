using UnityEngine;

public class PlayerLobbyMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * _moveSpeed;
    }
}