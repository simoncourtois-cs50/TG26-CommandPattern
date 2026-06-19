using System;
using UnityEngine;

namespace Command.Runtime
{
    public interface ICommand
    {
        void Execute(Action completionCallBack);
    }

    public interface IRotationReceiver
    {
        void Rotate(float angle, Action completionCallback);
    }
    public interface IMoveReceiver
    {
        void Move(Vector3 direction, float distance, Action completionCallBack);
    }
}
