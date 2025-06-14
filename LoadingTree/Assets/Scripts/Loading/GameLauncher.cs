using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Game
{
    public class GameLauncher : IInitializable
    {
        private IReadOnlyList<IloadingOperation> _operations;
        private readonly LoadingScreen _loadingScreen;

        private float _fullWeight;
        private float _currentWeight;
        private IloadingOperation _currentOperation;

        public GameLauncher(IReadOnlyList<IloadingOperation> operations, LoadingScreen loadingScreen)
        {
            _operations = operations;
            _loadingScreen = loadingScreen;
            _fullWeight = _operations.Sum(it => it.GetWeight());
        }

        public void Initialize()
        {
        }

        public void Launch(int level = 1)
        {
            UniTask load = LoadGame(level);
            UpdateProgress(load);
        }

        private async void UpdateProgress(UniTask load)
        {
            while (load.Status == UniTaskStatus.Pending)
            {
                _loadingScreen.SetProgress(GetProgress());
                await UniTask.Yield();
            }
        }

        private float GetProgress()
        {
            float currentWeight = _currentWeight;

            if (_currentOperation != null)
                currentWeight += _currentOperation.GetWeight() * _currentOperation.GetProgress();

            return currentWeight / _fullWeight;
        }

        private async UniTask LoadGame(int level)
        {
            _loadingScreen.Show();
            var bundle = new LoadingBundle();
            bundle.Add(BundleKeys.Level, level);
            bundle.Add(BundleKeys.BootLevel, 2);

            for (int i = 0; i < _operations.Count; i++)
            {
                _currentOperation = _operations[i];
                LoadingResult operation = await _currentOperation.Load(bundle);

                if (!operation.Success)
                {
                    _loadingScreen.PrintError(operation.Message);
                    break;
                }

                _currentWeight += _currentOperation.GetWeight();
            }

            _currentOperation = null;
            _currentWeight = _fullWeight;
            _loadingScreen.Hide();
        }
    }
}