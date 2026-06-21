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
            _initialRotation = transform.rotation;
            _destinationRotation = Quaternion.Euler(new Vector3(0, angle, 0));
            _completionCallBack = completionCallBack;
        }

        public void Move(Vector3 direction, float distance, Action completionCallBack)
        {
            Vector3 initialPostion = transform.position;
        }

        #endregion

        #region Private and Protected

        private Quaternion _initialRotation;
        private Quaternion _destinationRotation;
        private Vector3 _initialPosition;
        private Vector3 _destinationPosition;
        private Action _completionCallBack;
        
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