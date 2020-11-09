namespace GIP.Controls
{
    interface ITreeNodePath
    {
        string Path { get; }
        void ChangePathName(string inName);
    }

    public class ChangePathException : System.Exception
    { 
        public ChangePathException(string inMessage)
            : base(inMessage)
        { }
    }

    public class PathAlreadyExistException : ChangePathException
    {
        public PathAlreadyExistException(string inMessage)
            : base(inMessage)
        { }
    }

    public class OldPathNotFoundException : ChangePathException
    {
        public OldPathNotFoundException(string inMessage)
            : base(inMessage)
        { }
    }
}
