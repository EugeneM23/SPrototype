using System;
using Gameplay;
using UnityEngine;

namespace _Project.Scripts.Modules
{
    public class TestMove : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;
        [SerializeField] private float _height;
        
        private BezierCurveMover _curveMover;
        private float _time;

        private void OnEnable()
        {
            _curveMover = new BezierCurveMover(_height);
            _curveMover.Initialize(_startPoint.position, _endPoint.position);
        }

        private void Update()
        {
            _time += Time.deltaTime;
            if (_time > 2 && _time < 10) return;
            
            var asd = _curveMover.MoveAlongCurve(10);
            transform.position = asd;
        }
    }
}