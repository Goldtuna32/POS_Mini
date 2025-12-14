namespace POS.Domain.ResultPattern
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public bool IsError { get { return !IsSuccess; } }
        public bool IsNotFound { get { return Type == ResponseEnu.NotFound; } }
        public bool IsValidationError { get { return Type == ResponseEnu.ValidationError; } }
        public bool IsFailure { get { return Type == ResponseEnu.Failure; }  }
        public bool IsBadRequest { get { return Type == ResponseEnu.BadRequest; } }
        public T data { get; set; }

        private ResponseEnu Type;
        public string message { get; set; }

        public static Result<T> Success (T data, string message = "Success")
        {
            return new Result<T>
            {
                IsSuccess = true,
                Type = ResponseEnu.Success,
                data = data,
                message = message
            };
        }

        public static Result<T> Success (string message = "Success", T? data = default)
        {
            return new Result<T>
            {
                IsSuccess = true,
                Type = ResponseEnu.Success,
                data = data,
                message = message
            };
        }

        public static Result<T> Error (string message,T? data = default)
        {
            return new Result<T>
            {
                IsSuccess = false,
                Type = ResponseEnu.Error,
                data = data,
                message = message
            };
        }

        public static Result<T> NotFound (string message,T? data = default)
        {
            return new Result<T>
            {
                IsSuccess = false,
                Type = ResponseEnu.NotFound,
                data = data,
                message = message
            };
        }

        public static Result<T> ValidationError (string message,T? data = default)
        {
            return new Result<T>
            {
                IsSuccess = false,
                Type = ResponseEnu.ValidationError,
                data = data,
                message = message
            };
        }
        public static Result<T> Failure (string message,T? data = default)
        {
            return new Result<T>
            {
                IsSuccess = false,
                Type = ResponseEnu.Failure,
                data = data,
                message = message
            };
        }
        public static Result<T> BadRequest (string message,T? data = default)
        {
            return new Result<T>
            {
                IsSuccess = false,
                Type = ResponseEnu.BadRequest,
                data = data,
                message = message
            };
        }

    }
}
