using System;
using Cysharp.Threading.Tasks;

namespace Gameplay
{
    public struct LoadingResult
    {
        public bool Success;
        public string Message;

        public static LoadingResult  SuccessOperation()
        {
            LoadingResult result = new LoadingResult();
            result.Success = true;
            return result;
        }

        public static LoadingResult Error(string massage)
        {
            LoadingResult result = new LoadingResult();
            result.Success = false;
            result.Message = massage;
            return result;
        }
    }
}