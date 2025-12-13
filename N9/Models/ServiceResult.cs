using System;

namespace N9.Models
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public ErrorCode ErrorCode { get; set; }

        public static ServiceResult<T> Ok(T data)
        {
            return new ServiceResult<T> { Success = true, Data = data, ErrorCode = ErrorCode.None };
        }

        public static ServiceResult<T> Fail(string message, ErrorCode code = ErrorCode.ValidationError)
        {
            return new ServiceResult<T> { Success = false, ErrorMessage = message, ErrorCode = code };
        }
    }

    public class ServiceResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public ErrorCode ErrorCode { get; set; }

        public static ServiceResult Ok()
        {
            return new ServiceResult { Success = true, ErrorCode = ErrorCode.None };
        }

        public static ServiceResult Fail(string message, ErrorCode code = ErrorCode.ValidationError)
        {
            return new ServiceResult { Success = false, ErrorMessage = message, ErrorCode = code };
        }
    }
}
