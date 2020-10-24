using System;
namespace VirtualRock.Domain.Communication
{
    public class SaveResponse<T>
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public T Resource { get; private set; }

        public SaveResponse(string message)
        {
            Success = false;
            Message = message;
            Resource = default;
        }

        public SaveResponse(T resource)
        {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }

        public SaveResponse(bool success, string message)
        {
            Success = success;
            Message = message;
            Resource = default;
        }
    }
}
