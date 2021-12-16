namespace MarsRover.Exceptions
{
    [System.Serializable]
    public class OutOfAreaException : System.Exception
    {
        public OutOfAreaException() { }
        public OutOfAreaException(string message) : base(message) { }
        public OutOfAreaException(string message, System.Exception inner) : base(message, inner) { }
        protected OutOfAreaException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}