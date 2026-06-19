using System.Collections.Generic;

namespace Command.Runtime
{
    public class Invoker
    {
        private List<ICommand> _commandList = new();
        private int _currentIndex;

        public void AddCommand(ICommand command)
        {
            _commandList.Add(command);
        }

        public void ExecuteNext()
        {
            if (_commandList.Count <= 0) return;

            ICommand nextCommand = _commandList[_currentIndex];

            _commandList.Remove(nextCommand);

            _currentIndex++;

            nextCommand.Execute(ExecuteNext);
        }
    }
}
