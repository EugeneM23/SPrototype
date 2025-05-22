using System;
using Gameplay;
using UnityEngine;
using Zenject;

public class PlayerSpeedObserver : ITickable, IInitializable
{
    public float Speed { get; private set; }
    private readonly Transform _character;

    private float _timer;
    private Vector3 originPosition;
    private Vector3 lastPosition;
    private Quaternion lastRotation;

    public PlayerSpeedObserver(PlayerCharacterProvider character)
    {
        _character = character.Character.transform;
    }

    public void Initialize()
    {
        lastPosition = _character.position;
        lastRotation = _character.rotation;
    }

    public void Tick()
    {
        Speed = GetCharacterSpeed();
    }

    private float GetCharacterSpeed()
    {
        Vector3 deltaPosition = _character.transform.position - lastPosition;
        float linearSpeed = deltaPosition.magnitude / Time.deltaTime;

        Quaternion deltaRotation = _character.rotation * Quaternion.Inverse(lastRotation);

        deltaRotation.ToAngleAxis(out float angleInDegrees, out Vector3 rotationAxis);
        if (angleInDegrees > 180f)
            angleInDegrees -= 360f;

        float angularSpeed = Mathf.Abs(angleInDegrees) / Time.deltaTime;

        lastPosition = _character.position;
        lastRotation = _character.rotation;

        return Math.Max(0, linearSpeed - angularSpeed * 0.3f);
    }
}