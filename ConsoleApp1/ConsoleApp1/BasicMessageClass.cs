using System;

public class BasicMessageClass
{
    private string message; // message field
    public string Message // PROPERTY – Message contents
    {
        get { return message; }
        set { message = value; }
    }
}