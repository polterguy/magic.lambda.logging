﻿/*
 * Magic, Copyright(c) Thomas Hansen 2019 - 2020, thomas@servergardens.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

using System;
using System.Threading.Tasks;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;
using magic.lambda.logging.helpers;

namespace magic.lambda.logging
{
    /// <summary>
    /// [log.debug] slot for logging debug log entries.
    /// </summary>
    [Slot(Name = "log.debug")]
    [Slot(Name = "wait.log.debug")]
    public class LogDebug : ISlotAsync, ISlot
    {
        readonly ILogger _logger;

        /// <summary>
        /// Creates an instance of your type.
        /// </summary>
        /// <param name="logger">Actual implementation.</param>
        public LogDebug(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Slot implementation.
        /// </summary>
        /// <param name="signaler">Signaler that raised the signal.</param>
        /// <param name="input">Arguments to slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            _logger.Debug(input.GetEx<string>());
        }

        /// <summary>
        /// Slot implementation.
        /// </summary>
        /// <param name="signaler">Signaler that raised the signal.</param>
        /// <param name="input">Arguments to slot.</param>
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            await _logger.DebugAsync(input.GetEx<string>());
        }
    }
}
