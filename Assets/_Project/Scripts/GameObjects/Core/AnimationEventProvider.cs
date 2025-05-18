using System;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class AnimationEventProvider : MonoBehaviour
    {
        public event Action<string> OnCall;

        public void SendEvent(string eventName) =>
            OnCall?.Invoke(eventName);
    }
}