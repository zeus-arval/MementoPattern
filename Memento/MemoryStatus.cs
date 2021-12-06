using System;

namespace Memento
{
    public sealed class MemoryStatus
    {
        private string _errorMessage;
        public bool HasFreeSpace { get; private set; }
        public string ErrorMessage 
        {
            get => _errorMessage;
            private set
            {
                HasFreeSpace = value is null;
                _errorMessage = value;
                if(_errorMessage is not null) PrintError();
            }
        }

        public MemoryStatus(string errorMessage) => ErrorMessage = errorMessage;
        public void AddErrorMessage(string error) => ErrorMessage = error;
        public void PrintError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[{_errorMessage}]");
            Console.ResetColor();
        }
    }
}