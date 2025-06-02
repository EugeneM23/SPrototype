using System;
using System.Collections.Generic;

namespace Gameplay
{
    public struct BuffConfig
    {
        public Entity Target;
        public Entity UI;
        public bool IsStackable;
        public int MaxStack;
        public bool IsTimed;
        public float Duration;
        public KeyValuePair<BuffMultiplayerID, float>[] Stats;
    }
}