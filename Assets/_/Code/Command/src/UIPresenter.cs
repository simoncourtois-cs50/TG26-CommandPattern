using System;
using UnityEngine;

namespace Command.Runtime
{
    public class UIPresenter : MonoBehaviour
    {
        public void AddClockRotation()
        {
            if (_isPlaying) return;
            RotationCommand clockRotation = new RotationCommand();
            clockRotation.Initialize(90f, _playerReceiver);
            _invoker.AddCommand(clockRotation);
        }
        public void AddCounterClockRotation()
        {
            if (_isPlaying) return;
            RotationCommand counterClockRotation = new RotationCommand();
            counterClockRotation.Initialize(-90f, _playerReceiver);
            _invoker.AddCommand(counterClockRotation);
        }

        public void AddMoveForward()
        {
            if (_isPlaying) return;
            MoveCommand moveForward = new MoveCommand();
            moveForward.Initialize(Vector3.forward, 2f, _playerReceiver);
            _invoker.AddCommand(moveForward);
        }

        public void Play()
        {
            if (_isPlaying) return;
            _isPlaying = true;
            _invoker.ExecuteNext();
            _isPlaying = false;
        }
        
        
        #region Private and protected

        [SerializeField] private PlayerReceiver _playerReceiver;

     
        private Invoker _invoker = new Invoker();
        private bool _isPlaying;

        #endregion
    }
}