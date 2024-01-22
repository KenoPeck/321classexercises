using System;

namespace HelloWorldMsg
{
    internal class BasicMessageClass
    {
        // DEFAULT CONSTRUCTOR
        public BasicMessageClass() => message = null!;

        // EXPLICIT CONSTRUCTOR
        public BasicMessageClass(string messageInput) => message = messageInput;

        // MESSAGE FIELD
        private string? message;

        // MESSAGE PROPERTY
        public string? Message { get; set; }

        // SHOWMESSAGE METHOD // writes message to console
        public void ShowMessage() => Console.WriteLine(message);

    }
}