using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Xml.Content.Parser.API.Contracts;
using Xml.Content.Parser.API.Mappers;
using Xml.Content.Parser.Common.Exceptions;
using Xml.Content.Parser.Common.Interfaces;
using Xml.Content.Parser.Core.Domain;
using Xml.Content.Parser.Core.Interfaces;

namespace Xml.Content.Parser.API.Controllers
{
    /// <summary>
    /// Represents the <see cref="ExpenseController"/>.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseController"/> class.
        /// </summary>
        /// <param name="expenseService">The expense service.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">
        /// expenseService
        /// or
        /// logger
        /// </exception>
        public ExpenseController(IExpenseService expenseService, ILogger logger)
        {
            if (expenseService == null) throw new ArgumentNullException(nameof(expenseService));
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            _expenseService = expenseService;
            _logger = logger;
        }

        /// <summary>
        /// Extracts the XML content from the specified message content body.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">messageContent</exception>
        [HttpPost("Extract")]
        [ProducesResponseType(typeof(ExpenseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public ActionResult<ExpenseDto> ExtractExpense([FromBody]MessageContentDto messageContent)
        {
            if (messageContent == null) throw new ArgumentNullException(nameof(messageContent));

            try
            {
                Expense expense = _expenseService.Extract(messageContent.MessageContent);
                return Ok(expense.ToDto());
            }
            catch (XmlContentParserException exception)
            {
                _logger.Log("Failed to extract message content.", exception, messageContent);
                return BadRequest(exception.Message);
            }
        }
    }
}