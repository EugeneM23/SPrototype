using System;
using UnityEngine;
using System.Collections;
using Gameplay;

public class ECdestroyMe : MonoBehaviour
{
    [SerializeField] private int destroyTime;
    float timer;
    private Entity _entity;
    private bool _isActive;

    private void Start()
    {
        _entity = gameObject.GetComponent<Entity>();
    }

    private void OnEnable()
    {
        timer = destroyTime;
        _isActive = true;
    }

    void Update()
    {
        if (!_isActive) return;
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            _isActive = false;
            _entity.Dispose();
        }
    }
}