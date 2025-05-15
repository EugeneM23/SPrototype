using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class LobbyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _streetPrefab;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(_streetPrefab, transform.position, Quaternion.identity);
    }
}