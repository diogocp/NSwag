Summary
-------

NSwag.ApiDescription.Client 13.13.2 fails to deserialize `text/plain`
responses, even though they are properly specified in the OpenAPI document
and the NSwag client explicitly sends an `Accept: text/plain` header.

To reproduce, simply run the test with `dotnet test` or Visual Studio.
If you debug the test in Visual Studio, you can see the following log line in
the debug output window, showing the client is indeed asking for a `text/plain`
response:
> NSwagPlainTextBug.Controllers.HelloWorldController: Information: Request with Accept: text/plain


Test log
--------

>     Starting test execution, please wait...
>     A total of 1 test files matched the specified pattern.
>     [xUnit.net 00:00:01.26]     NSwagPlainTextBug.Tests.ClientTests.GetHello_ReturnsOk [FAIL]
>       Failed NSwagPlainTextBug.Tests.ClientTests.GetHello_ReturnsOk [323 ms]
>       Error Message:
>        NSwagPlainTextBug.Client.ApiException : Could not deserialize the response body stream as System.String.
>     
>     Status: 200
>     Response:
>     
>     ---- Newtonsoft.Json.JsonReaderException : Unexpected character encountered while parsing value: H. Path '', line 1, position 1.


OpenAPI document
----------------

```json
{
  "openapi": "3.0.1",
  "info": {
    "title": "NSwagPlainTextBug",
    "version": "1.0"
  },
  "paths": {
    "/hello": {
      "get": {
        "tags": [
          "HelloWorld"
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "string"
                }
              },
              "application/json": {
                "schema": {
                  "type": "string"
                }
              },
              "text/json": {
                "schema": {
                  "type": "string"
                }
              }
            }
          }
        }
      }
    }
  },
  "components": { }
}
```
