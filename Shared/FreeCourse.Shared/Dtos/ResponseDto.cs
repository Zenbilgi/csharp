using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FreeCourse.Shared.Dtos
{
    // Nesnelerin prop dışardan set edilemesin diye private yaptık.
    public class ResponseDto<T>
    {
        public T Data { get; private set; }

        [JsonIgnore] // Client bunu görmeyecek
        public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool IsSuccessful { get; private set; }

        public List<string> Errors { get; set; }


        // Static Factory Methods
        //
        // Nesne oluşturacak methodlar.
        // Static factory metotlar class içinde doğrudan interface olmadan kullanılır.
        public static ResponseDto<T> Success(T Data, int statusCode)
        {
            return new ResponseDto<T> { Data = Data, StatusCode = statusCode, IsSuccessful = true };
        }

        // Update veya Delete işleminde data almayabilir.
        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T> { Data=default(T), StatusCode = statusCode, IsSuccessful = true };
        }

        public static ResponseDto<T> Fail(List<string> errors, int statusCode)
        {
            return new ResponseDto<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

        public static ResponseDto<T> Fail(string error, int statusCode)
        {
            return new ResponseDto<T>
            {
                Errors = new List<string>() { error },
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

    }
}
