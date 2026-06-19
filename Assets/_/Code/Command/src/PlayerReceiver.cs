using System;
using UnityEngine;

namespace Command.Runtime
{
    public class PlayerReceiver : MonoBehaviour, IRotationReceiver, IMoveReceiver
    {  
        #region Unity API

        private void Update()
        {
            OnStayState();
        }

        #endregion

        #region State Machine
        private void ChangeState(State newState)
        {
            OnExitState();
            _currentState = newState;
            OnEnterState();
        }
        private void OnEnterState()
        {
            switch (_currentState)
            {
                case State.Waiting:
                    break;
                case State.Rotating:
                    break;
                case State.Moving:
                    break;
            }
        }

        private void OnStayState()
        {
            switch (_currentState)
            {
                case State.Waiting:
                    break;
                case State.Rotating:
                    break;
                case State.Moving:
                    break;
            }
        }

        private void OnExitState()
        {
            switch (_currentState)
            {
                case State.Waiting:
                    break;
                case State.Rotating:
                    break;
                case State.Moving:
                    break;
            }
        }

        #endregion


        #region Main API

        private void HandleRotation()
        {

        }
        private void HandleMovement()
        {

        }
        private void HandleTimer()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime < _animationLength) return;

            _currentTime = 0;
            _isMoving = false;
            _isRotating = false;
        }

        #endregion


        #region Initialization Methods

        public void Rotate(float angle, Action completionCallBack)
        {
            Quaternion initialRotation = transform.rotation;
        }

        public void Move(Vector3 direction, float distance, Action completionCallBack)
        {

        }

        #endregion

        #region Private and Protected

        private Quaternion _initialRotation;
        private Vector3 _initialPosition;

        private enum State
        {
            Waiting,
            Rotating,
            Moving
        }

        private State _currentState;

        private bool _isRotating;
        private bool _isMoving;
        private bool _isWaiting;

        private float _currentTime;

        [SerializeField] private float _animationLength;

        #endregion
    }
}