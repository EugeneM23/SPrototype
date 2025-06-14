using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Gameplay
{
    public class CreateCubesOperation : IloadingOperation
    {
        private const int CUBES_COUNT = 10000;
        private const int CUBES_PER_FRAME = 10;

        private int _currentCubesCreated = 0;

        public float GetProgress() => (float)_currentCubesCreated / CUBES_COUNT;
        public float GetWeight() => 40f;

        public async UniTask<LoadingResult> Load(LoadingBundle bundle)
        {
            _currentCubesCreated = 0;

            GameObject cubesParent = new GameObject("Cubes");

            while (_currentCubesCreated < CUBES_COUNT)
            {
                int cubesToCreate = Mathf.Min(CUBES_PER_FRAME, CUBES_COUNT - _currentCubesCreated);

                for (int i = 0; i < cubesToCreate; i++)
                {
                    CreateCube(cubesParent.transform);
                    _currentCubesCreated++;
                }

                await UniTask.Yield(PlayerLoopTiming.Update);
            }

            return LoadingResult.SuccessOperation();
        }

        private void CreateCube(Transform parent)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetParent(parent);

            float x = Random.Range(-50f, 50f);
            float y = Random.Range(0f, 10f);
            float z = Random.Range(-50f, 50f);

            cube.transform.position = new Vector3(x, y, z);
            cube.transform.rotation = Random.rotation;

            float scale = Random.Range(0.5f, 2f);
            cube.transform.localScale = Vector3.one * scale;
        }
    }
}