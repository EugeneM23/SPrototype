using System;
using System.Collections.Generic;
using Action = Unity.Plastic.Newtonsoft.Json.Serialization.Action;

namespace Gameplay
{
    public struct BuffConfig
    {
        public Entity Target;
        public bool IsStackable;
        public int MaxStack;
        public bool IsTimed;
        public float Duration;
        public KeyValuePair<BuffMultiplayerID, float>[] Stats;
        public System.Action StackAction { get; set; }
        public System.Action ApplyAction { get; set; }
    }
}