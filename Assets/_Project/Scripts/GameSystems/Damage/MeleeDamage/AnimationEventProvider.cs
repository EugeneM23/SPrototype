using System;
using UnityEngine;

namespace Gameplay
{
    public class AnimationEventProvider : MonoBehaviour
    {
        public event Action<string> OnEventCall;

        public void CallEvent(string name) => OnEventCall?.Invoke(name);
    }
}