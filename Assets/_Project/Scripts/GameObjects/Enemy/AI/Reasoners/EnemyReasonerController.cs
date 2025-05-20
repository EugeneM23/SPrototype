using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyReasonerController : ITickable
    {
        private readonly List<IEnemyDecision> _reasoners;
        private IEnemyDecision _currentDecision;

        public EnemyReasonerController(List<IEnemyDecision> reasoners)
        {
            if (reasoners.Count == 0) return;

            _reasoners = reasoners;
            _currentDecision = _reasoners[0];
        }

        public void Tick()
        {
            if (_reasoners == null) return;

            IEnemyDecision bestDecision = _currentDecision;
            int highestPriority = int.MinValue;

            foreach (var reasoner in _reasoners)
            {
                if (reasoner.IsValid() && reasoner.Priority > highestPriority)
                {
                    bestDecision = reasoner;
                    highestPriority = reasoner.Priority;
                }
            }

            _currentDecision = bestDecision;
            _currentDecision?. ApplyReasoning();
        }
    }
}