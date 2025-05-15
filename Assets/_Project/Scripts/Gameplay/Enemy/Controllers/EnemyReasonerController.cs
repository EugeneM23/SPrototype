using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyReasonerController : ITickable
    {
        private readonly List<IEnemyReasoner> _reasoners;
        private IEnemyReasoner _currentReasoner;

        public EnemyReasonerController(List<IEnemyReasoner> reasoners)
        {
            if (reasoners.Count == 0) return;

            _reasoners = reasoners;
            _currentReasoner = _reasoners[0];
        }

        public void Tick()
        {
            if (_reasoners == null) return;

            IEnemyReasoner bestReasoner = _currentReasoner;
            int highestPriority = int.MinValue;

            foreach (var reasoner in _reasoners)
            {
                if (reasoner.CanReason() && reasoner.Priority > highestPriority)
                {
                    bestReasoner = reasoner;
                    highestPriority = reasoner.Priority;
                }
            }

            _currentReasoner = bestReasoner;
            _currentReasoner?.ApplyReasoning();
        }
    }
}