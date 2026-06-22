using System;
using UnityEngine;

namespace Command.Runtime
{
    public class MoveCommand: ICommand
    {
        #region Main API

        public void Execute(Action completionCallBack)
        {
            _player.Move(_direction, _distance, completionCallBack);
        }
        
        public void Initialize(Vector3 direction, float distance, PlayerReceiver receiver)
        {
            _direction = direction;
            _distance = distance;
            _player = receiver;
        }
        #endregion


        #region Private and protected

        private PlayerReceiver _player;
        private float _distance;
        private Vector3 _direction;

        #endregion
    }
}

    