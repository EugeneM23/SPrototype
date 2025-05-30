using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class BuffManager : ITickable, IInitializable
    {
        private List<BuffBase> buffs;

        public void Initialize()
        {
            buffs = new(10);
        }

        public void AddBuff(BuffBase newBuff)
        {
            BuffBase existingBuff = buffs.Find(b => b.GetType() == newBuff.GetType());

            if (existingBuff == null)
            {
                newBuff.Apply();
                buffs.Add(newBuff);
                return;
            }

            if (newBuff.IsStackable)
                existingBuff.AddStack();

            if (newBuff.IsTimed)
                existingBuff.RefreshTimer();
        }

        public void RemoveBuff(BuffBase buffToRemove)
        {
            BuffBase existingBuff = buffs.Find(b => b.GetType() == buffToRemove.GetType());
            existingBuff.Discard();
            buffs.Remove(buffToRemove);
        }

        public void Tick()
        {
            for (int i = buffs.Count - 1; i >= 0; i--)
            {
                buffs[i].Tick();

                var buff = buffs[i];
                if (buff.IsTimed && buff.IsExpired())
                {
                    buff.Discard();
                    buffs.RemoveAt(i);
                }
            }
        }
    }
}