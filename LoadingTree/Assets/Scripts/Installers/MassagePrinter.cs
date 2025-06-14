using UnityEngine;
using Zenject;

namespace Game
{
    public class MassagePrinter : IInitializable
    {
        public void Initialize()
        {
            Debug.Log("MassagePrinter initialized");
        }

        

        public void Printmassage(string message)
        {
            Debug.Log("message");
        }
    }
}