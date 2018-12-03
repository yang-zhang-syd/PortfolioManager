using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PortfolioManager.API.Attributes;
using PortfolioManager.API.Models;
using PortfolioManager.Domain.AggregatesModel.AccountAggregate;
using Swashbuckle.AspNetCore.Annotations;

namespace PortfolioManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        /// <summary>
        /// Create a new account
        /// </summary>
        /// <param name="data">Account object to be created</param>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [ValidateModelState]
        [SwaggerOperation("CreateAccount")]
        public async Task<Account> CreateAccount([FromBody]AccountCreateModel data)
        {
            var entity = _accountRepository.Add(new Account(data.Name, data.Email, AccountStatus.Created));
            await _accountRepository.UnitOfWork.SaveEntitiesAsync();

            return entity;
        }

        /// <summary>
        /// Deletes a account
        /// </summary>
        /// <param name="accountId">Account id to delete</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Account not found</response>
        [HttpDelete]
        [Route("{accountId}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteAccount")]
        public async Task<IActionResult> DeleteAccount([FromRoute][Required]int accountId)
        {
            var account = await _accountRepository.GetAsync(accountId);
            if (account == null)
            {
                return NotFound();
            }

            var result = await _accountRepository.DeleteAsync(accountId);
            await _accountRepository.UnitOfWork.SaveEntitiesAsync();
            return StatusCode(204);
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
        [Route("{accountId}")]
        [ValidateModelState]
        [SwaggerOperation("GetAccountById")]
        [SwaggerResponse(statusCode: 200, type: typeof(Account), description: "successful operation")]
        public async Task<IActionResult> GetAccountById([FromRoute][Required]int accountId)
        {

            var account = await _accountRepository.GetAsync(accountId);
            if (account == null)
            {
                return NotFound();
            }

            return new ObjectResult(account);
        }

        /// <summary>
        /// Update an existing account
        /// </summary>
        /// /// <param name="accountId">Id of account</param>
        /// <param name="body">Account object that needs to be updated</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Account not found</response>
        /// <response code="405">Validation exception</response>
        [HttpPut]
        [Route("{accountId}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount(int accountId, [FromBody]AccountUpdateModel body)
        {
            var account = await _accountRepository.GetAsync(accountId);
            if (account == null)
            {
                return NotFound();
            }

            account.Name = body.Name;
            account.Email = body.Email;

            await _accountRepository.UpdateAsync(account);
            await _accountRepository.UnitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        /// <summary>
        /// Patch an existing account
        /// </summary>
        /// /// <param name="accountId">Id of account</param>
        /// <param name="patchData">Account object that needs to be updated</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Account not found</response>
        /// <response code="405">Validation exception</response>
        [HttpPatch]
        [Route("{accountId}")]
        [ValidateModelState]
        [SwaggerOperation("PatchAccount")]
        public async Task<IActionResult> PatchAccount(int accountId, [FromBody] JsonPatchDocument patchData)
        {
            var account = await _accountRepository.GetAsync(accountId);
            if (account == null)
            {
                return NotFound();
            }

            patchData.ApplyTo(account);
            await _accountRepository.UpdateAsync(account);
            await _accountRepository.UnitOfWork.SaveEntitiesAsync();
            return Ok();
        }
    }
}