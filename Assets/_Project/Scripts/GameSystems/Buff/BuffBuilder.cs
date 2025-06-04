using System;
using System.Collections.Generic;
using System.Linq;

namespace Gameplay
{
    public class BuffBuilder<T> where T : IBuff, new()
    {
        private BuffConfig config = new BuffConfig();

        public BuffBuilder<T> Target(Entity target)
        {
            config.Target = target;
            return this;
        }

        public BuffBuilder<T> Stackable(int max = 5)
        {
            config.IsStackable = true;
            config.MaxStack = max;
            return this;
        }

        public BuffBuilder<T> StackAction(Action action = null)
        {
            config.StackAction = action;
            return this;
        }

        public BuffBuilder<T> ApplyAction(Action action = null)
        {
            config.ApplyAction = action;
            return this;
        }

        public BuffBuilder<T> Timed(float time)
        {
            config.IsTimed = true;
            config.Duration = time;
            return this;
        }

        public BuffBuilder<T> Stats(params (BuffMultiplayerID id, float value)[] stats)
        {
            config.Stats = stats
                .Select(s => new KeyValuePair<BuffMultiplayerID, float>(s.id, s.value))
                .ToArray();
            return this;
        }

        public T Build()
        {
            T buff = new T();
            buff.Configure(config);
            return buff;
        }
    }
}