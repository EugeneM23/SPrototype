using System.Collections;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(nameof(Despawn));
    }

    public IEnumerator Despawn()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}