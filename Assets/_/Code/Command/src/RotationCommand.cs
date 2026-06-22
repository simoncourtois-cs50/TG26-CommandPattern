using System;
namespace Command.Runtime
{
    public class RotationCommand: ICommand
    {
        #region Main API

        public void Execute(Action completionCallBack)
        {
            _player.Rotate(_angle, completionCallBack);
        }
        
        public void Initialize(float newAngle, PlayerReceiver receiver)
        {
            _angle = newAngle;
            _player = receiver;
        }
        #endregion


        #region Private and protected

        private PlayerReceiver _player;
        private float _angle;

        #endregion
    }
}
