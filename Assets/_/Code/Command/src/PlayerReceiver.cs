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
                    Debug.Log("Enter Waiting");
                    CompletionCallBack();
                    break;
                case State.Rotating:
                    Debug.Log("Enter Rotation");
                    break;
                case State.Moving:
                    Debug.Log("Enter Moving");
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
                    HandleTimer();
                    HandleRotation();
                    break;
                case State.Moving:
                    HandleTimer();
                    HandleMovement();
                    break;
            }
        }

        private void OnExitState()
        {
            switch (_currentState)
            {
                case State.Waiting:
                    Debug.Log("Exit Waiting");
                    break;
                case State.Rotating:
                    Debug.Log("Exit Rotating");
                    break;
                case State.Moving:
                    Debug.Log("Exit Moving");
                    break;
            }
        }

        #endregion


        #region Main API

        private void HandleRotation()
        {
            if (_currentTime <= 0) return;
            transform.rotation = Quaternion.Lerp(_initialRotation, _destinationRotation, _currentTime);
        }
        private void HandleMovement()
        {
            if (_currentTime <= 0) return;
            transform.position = Vector3.Lerp(_initialPosition, _destinationPosition, _currentTime);
        }
        private void HandleTimer()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime < _animationLength) return;

            _currentTime = 0;
            ChangeState(State.Waiting);
        }

        private void CompletionCallBack()
        {
            _completionCallBack();
        }
        
        #endregion


        #region Initialization Methods

        public void Rotate(float angle, Action completionCallBack)
        {
            _initialRotation = transform.rotation;
            _destinationRotation = _initialRotation * Quaternion.Euler(new Vector3(0, angle, 0));
            _completionCallBack = completionCallBack;
            ChangeState(State.Rotating);
        }

        public void Move(Vector3 direction, float distance, Action completionCallBack)
        {
            _initialPosition = transform.position;
            Vector3 offsetTranslation = transform.TransformDirection(direction);
            _destinationPosition = _initialPosition + offsetTranslation * distance;
            _completionCallBack = completionCallBack;
            ChangeState(State.Moving);
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
        private float _currentTime;

        [SerializeField] private float _animationLength;

        #endregion
    }
}