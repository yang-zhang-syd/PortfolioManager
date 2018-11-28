using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PortfolioManager.API.Attributes;
using PortfolioManager.Domain.AggregatesModel.AccountAggregate;
using Swashbuckle.AspNetCore.Annotations;

namespace PortfolioManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        /// <summary>
        /// Create a new account
        /// </summary>

        /// <param name="account">Account object to be created</param>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/account")]
        [ValidateModelState]
        [SwaggerOperation("CreateAccount")]
        public virtual IActionResult CreateAccount([FromBody]Account account)
        {
            //TODO: Uncomment the next line to return response 405 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(405);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a account
        /// </summary>

        /// <param name="accountId">Account id to delete</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Account not found</response>
        [HttpDelete]
        [Route("/account/{accountId}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteAccount")]
        public virtual IActionResult DeleteAccount([FromRoute][Required]long? accountId)
        {
            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Find account by ID
        /// </summary>
        /// <remarks>Returns a single account</remarks>
        /// <param name="accountId">ID of account to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Account not found</response>
        [HttpGet]
        [Route("/account/{accountId}")]
        [ValidateModelState]
        [SwaggerOperation("GetAccountById")]
        [SwaggerResponse(statusCode: 200, type: typeof(Account), description: "successful operation")]
        public virtual IActionResult GetAccountById([FromRoute][Required]long? accountId)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Account));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            string exampleJson = null;
            exampleJson = "{\n  \"name\" : \"name\",\n  \"id\" : 7,\n  \"domainEvents\" : [ null, null ],\n  \"transactions\" : [ {\n    \"dateTime\" : \"2000-01-23T04:56:07.000+00:00\",\n    \"transactionType\" : {\n      \"name\" : \"name\",\n      \"id\" : 9\n    },\n    \"accountId\" : 3,\n    \"price\" : 2.3021358869347655,\n    \"commission\" : 7.061401241503109,\n    \"units\" : 5,\n    \"id\" : 2,\n    \"domainEvents\" : [ null, null ],\n    \"stock\" : {\n      \"symbol\" : \"symbol\",\n      \"id\" : 5,\n      \"domainEvents\" : [ null, null ],\n      \"equityPrices\" : [ {\n        \"dateTime\" : \"2000-01-23T04:56:07.000+00:00\",\n        \"price\" : 6.027456183070403,\n        \"stockId\" : 0,\n        \"id\" : 1,\n        \"domainEvents\" : [ { }, { } ]\n      }, {\n        \"dateTime\" : \"2000-01-23T04:56:07.000+00:00\",\n        \"price\" : 6.027456183070403,\n        \"stockId\" : 0,\n        \"id\" : 1,\n        \"domainEvents\" : [ { }, { } ]\n      } ]\n    }\n  }, {\n    \"dateTime\" : \"2000-01-23T04:56:07.000+00:00\",\n    \"transactionType\" : {\n      \"name\" : \"name\",\n      \"id\" : 9\n    },\n    \"accountId\" : 3,\n    \"price\" : 2.3021358869347655,\n    \"commission\" : 7.061401241503109,\n    \"units\" : 5,\n    \"id\" : 2,\n    \"domainEvents\" : [ null, null ],\n    \"stock\" : {\n      \"symbol\" : \"symbol\",\n      \"id\" : 5,\n      \"domainEvents\" : [ null, null ],\n      \"equityPrices\" : [ {\n        \"dateTime\" : \"2000-01-23T04:56:07.000+00:00\",\n        \"price\" : 6.027456183070403,\n        \"stockId\" : 0,\n        \"id\" : 1,\n        \"domainEvents\" : [ { }, { } ]\n      }, {\n        \"dateTime\" : \"2000-01-23T04:56:07.000+00:00\",\n        \"price\" : 6.027456183070403,\n        \"stockId\" : 0,\n        \"id\" : 1,\n        \"domainEvents\" : [ { }, { } ]\n      } ]\n    }\n  } ],\n  \"stockHoldings\" : [ {\n    \"accountId\" : 7,\n    \"boughtPrice\" : 1.0246457001441578,\n    \"stockId\" : 4,\n    \"commission\" : 1.4894159098541704,\n    \"units\" : 1,\n    \"id\" : 6,\n    \"domainEvents\" : [ null, null ],\n    \"boughtDateTime\" : \"2000-01-23T04:56:07.000+00:00\"\n  }, {\n    \"accountId\" : 7,\n    \"boughtPrice\" : 1.0246457001441578,\n    \"stockId\" : 4,\n    \"commission\" : 1.4894159098541704,\n    \"units\" : 1,\n    \"id\" : 6,\n    \"domainEvents\" : [ null, null ],\n    \"boughtDateTime\" : \"2000-01-23T04:56:07.000+00:00\"\n  } ],\n  \"email\" : \"email\"\n}";
            exampleJson = "<null>\n  <name>aeiou</name>\n  <email>aeiou</email>\n  <id>123</id>\n</null>";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Account>(exampleJson)
            : default(Account);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Update an existing account
        /// </summary>

        /// <param name="body">Account object that needs to be updated</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Account not found</response>
        /// <response code="405">Validation exception</response>
        [HttpPut]
        [Route("/account")]
        [ValidateModelState]
        [SwaggerOperation("UpdateAccount")]
        public virtual IActionResult UpdateAccount([FromBody]Account body)
        {
            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            //TODO: Uncomment the next line to return response 405 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(405);


            throw new NotImplementedException();
        }
    }
}