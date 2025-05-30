using System;
using UnityEngine;

namespace Gameplay
{
    using System;

    public class CharacterConditions
    {
        public event Action OnValueChanged;

        private bool _canPush;
        private bool _isBusy;
        private bool _isPatroling;
        private bool _isChasing;
        private bool _isAdling;

        public bool IsAdling
        {
            get => _isAdling;
            set => SetField(ref _isAdling, value);
        }

        public bool CanPush
        {
            get => _canPush;
            set => SetField(ref _canPush, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetField(ref _isBusy, value);
        }

        public bool IsPatroling
        {
            get => _isPatroling;
            set => SetField(ref _isPatroling, value);
        }

        public bool IsChasing
        {
            get => _isChasing;
            set => SetField(ref _isChasing, value);
        }

        private void SetField(ref bool field, bool value)
        {
            if (field != value)
            {
                field = value;
                OnValueChanged?.Invoke();
            }
        }
    }
}