using Gameplay;
using UnityEngine;
using Zenject;

public class RagDollSpawne : MonoBehaviour
{
    [SerializeField] private GameObject _dollPrefab;

    [Inject] private readonly HealthComponent _collision;

    private void OnEnable()
    {
        _collision.OnDespawn += Spawn;
    }

    private void OnDisable()
    {
        _collision.OnDespawn -= Spawn;
    }

    private void Spawn(Entity entity)
    {
        var go = Instantiate(_dollPrefab, transform.position, transform.rotation);

        // Определяем направление и силу импульса
        Vector3 impulseDirection = -transform.forward + Vector3.up; // можно кастомизировать
        float impulseForce = 30f; // сила импульса

        // Получаем все Rigidbody в регдолле
        Rigidbody[] rigidbodies = go.GetComponentsInChildren<Rigidbody>();

        foreach (var rb in rigidbodies)
        {
            rb.AddForce(impulseDirection.normalized * impulseForce, ForceMode.Impulse);
            rb.AddTorque(impulseDirection.normalized * impulseForce, ForceMode.Impulse);
        }
    }
}