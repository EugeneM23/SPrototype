using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace DPrototype.Game
{
    public class CameraShaker : ITickable, IInitializable
    {
        private readonly Transform _camera;
        private float _shakeMagnitude;
        private float _shakeDuration;

        private Quaternion _originalRotation;
        private bool _isReturning;
        private float maxAngle = 2;

        public CameraShaker(Camera camera) => _camera = camera.transform;

        public void Initialize() => _originalRotation = _camera.localRotation;

        public void CameraShake(float shakeMagnitude, float shakeDuration)
        {
            _shakeDuration = shakeDuration;
            _shakeMagnitude = shakeMagnitude;
        }

        public void Tick()
        {
            if (_shakeDuration > 0)
            {
                float angleX = Random.Range(-maxAngle, maxAngle) * _shakeMagnitude;
                float angleY = Random.Range(-maxAngle, maxAngle) * _shakeMagnitude;
                float angleZ = Random.Range(-maxAngle, maxAngle) * _shakeMagnitude;

                Quaternion shakeRotation = Quaternion.Euler(angleX, angleY, angleZ);

                _camera.localRotation = _originalRotation * shakeRotation;

                _shakeDuration -= Time.deltaTime;

                if (_shakeDuration <= 0f)
                    _isReturning = true;
            }
            else if (_isReturning)
            {
                _camera.localRotation = Quaternion.Lerp(_camera.localRotation,
                    _originalRotation, Time.deltaTime * 0.3f);

                if (Quaternion.Angle(_camera.localRotation, _originalRotation) < 0.01f)
                {
                    _camera.localRotation = _originalRotation;
                    _isReturning = false;
                }
            }
        }
    }
}