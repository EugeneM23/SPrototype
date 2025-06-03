using System;
using System.Collections.Generic;
using Zenject;

namespace Gameplay
{
    public class BuffManager : ITickable, IInitializable
    {
        private List<IBuff> _buffs;

        public List<IBuff> Buffs => _buffs;

        public void Initialize()
        {
            _buffs = new List<IBuff>(10);
        }

        public void AddBuff(IBuff newBuff)
        {
            var existingBuff = GetBuffOfType(newBuff.GetType());

            if (existingBuff == null)
            {
                AddNewBuff(newBuff);
                return;
            }

            UpdateExistingBuff(existingBuff);
        }

        public void RemoveBuff<T>() where T : IBuff
        {
            for (int i = _buffs.Count - 1; i >= 0; i--)
            {
                if (_buffs[i] is T)
                {
                    _buffs[i].Discard();
                    _buffs.RemoveAt(i);
                }
            }
        }

        public void Tick()
        {
            for (int i = _buffs.Count - 1; i >= 0; i--)
            {
                var buff = _buffs[i];
                buff.Tick();

                if (ShouldRemoveBuff(buff))
                {
                    buff.Discard();
                    _buffs.RemoveAt(i);
                }
            }
        }

        private IBuff GetBuffOfType(Type buffType)
        {
            return _buffs.Find(b => b.GetType() == buffType);
        }

        private void AddNewBuff(IBuff buff)
        {
            buff.Apply();
            _buffs.Add(buff);
        }

        private void UpdateExistingBuff(IBuff existingBuff)
        {
            if (existingBuff.IsStackable)
                existingBuff.AddStack();

            if (existingBuff.IsTimed)
                existingBuff.RefreshTimer();
        }

        private bool ShouldRemoveBuff(IBuff buff)
        {
            return buff.IsTimed && buff.IsExpired();
        }
    }
}