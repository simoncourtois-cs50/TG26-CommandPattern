using System;
using System.Collections.Generic;
using UnityEngine;

namespace Command.Runtime
{
    public class CommandCube : MonoBehaviour
    {
        #region

        private void Awake()
        {
            _moveForward = () => 
            {
                RegisterPosition();
                Vector3 position = Vector3.Lerp(_initialPosition, _initialPosition + transform.forward * 2f, _currentTimer);
                transform.position = position;
            };
            _rotate90ClockWise = () => {
                Debug.Log("rotate");
                RegisterPosition();
                Quaternion rotation = Quaternion.Lerp(_initialRotation, _initialRotation * Quaternion.Euler(new Vector3(0, 90, 0)), _currentTimer);
                transform.rotation = rotation;
            };
            _rotate90CounterClockWise = () => 
            {
                RegisterPosition();
                Quaternion rotation = Quaternion.Lerp(_initialRotation, _initialRotation * Quaternion.Euler(new Vector3(0, -90, 0)), _currentTimer);
                transform.rotation = rotation;
                 
            };
        }
        private void Update()
        {
            if (!_isStartPushed) return;
            HandleTimer();

            if (!_isPlaying) return;
            PlayList();
        }

        #endregion


        #region Main API
        public void RegisterMoveForward()
        {
            if (_isStartPushed) return;
            _commandList.Add(_moveForward);
        }
        public void RegisterRotate90ClockWise()
        {
            if (_isStartPushed) return;
            _commandList.Add(_rotate90ClockWise);
        }
        public void RegisterRotate90CounterClockWise()
        {
            if (_isStartPushed) return;
            _commandList.Add(_rotate90CounterClockWise);
        }
        public void ClearList()
        {
            _currentIndex = 0;
            _commandList.Clear();
        }
        public void PlayList()
        {
            if (_commandList.Count <= 0) return;

            _commandList[_currentIndex]();
            

           
        }
        
        public void HandleTimer()
        {
            _currentTimer += Time.deltaTime;

            if (_currentTimer < _timerLength) return;

            _currentIndex++;
            _currentTimer = 0;
            _isPlaying = true;
            _isRegisteringPosition = true;

            if (_currentIndex < _commandList.Count) return;

            ClearList();
            _isStartPushed = false;
            _isPlaying = false;
        }

        public void StartCommands()
        {
            _isStartPushed = true;
            _isRegisteringPosition = true;
            _isPlaying = true;
        }
        public void RegisterPosition()
        {
            if (!_isRegisteringPosition) return;

            _initialPosition = transform.position;
            _initialRotation = transform.rotation;
            _isRegisteringPosition = false;
        }
        #endregion


        #region private

        private Action _moveForward;
        private Action _rotate90ClockWise;
        private Action _rotate90CounterClockWise;
        private List<Action> _commandList = new();

        [SerializeField] private float _timerLength;
        private float _currentTimer;

        private Vector3 _initialPosition;
        private Vector3 _destinationPosition;
        private Quaternion _initialRotation;
        private Quaternion _destinationRotation;

        private bool _isPlaying;
        private bool _isStartPushed;
        private bool _isRegisteringPosition;

        private int _currentIndex;

        #endregion
    }
}