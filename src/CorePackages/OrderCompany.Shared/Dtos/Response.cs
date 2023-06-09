﻿using System.Text.Json.Serialization;

namespace OrderCompany.Shared.Dtos;

public class Response<T> where T : class
{
    public T? Data { get; set; }
    public int StatusCode { get; set; }
    public ErrorDto? Error { get; set; }
    public string? Message { get; set; }
    
    [JsonIgnore]
    public bool IsSuccessful { get; set; }
    public static Response<T> Success(T data, string message, int statusCode) => new Response<T> {Data = data,Message = message, StatusCode = statusCode,IsSuccessful = true};
    public static Response<T> Success(int statusCode,string message) => new Response<T> {Data =default ,Message =message, StatusCode = statusCode,IsSuccessful = true};
    public static Response<T> Fail(ErrorDto errorDto, int statusCode) => new Response<T> {Error = errorDto,StatusCode = statusCode,IsSuccessful = false};

    public static Response<T> Fail(string errorMessage, int statusCode)
    {
        var dto = new ErrorDto(errorMessage);
        return new Response<T> { Error = dto,StatusCode = statusCode, IsSuccessful = false};
    }
}