﻿/*
 * Magic, Copyright(c) Thomas Hansen 2019 - 2020, thomas@servergardens.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

using System;
using System.Linq;
using System.Text;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.logging
{
    /*
     * Internal helper class to create a string out of parameters supplied to any one of our logging methods.
     */
    internal static class Helper
    {
        internal static string GetLogInfo(ISignaler signaler, Node input)
        {
            var xResult = input.Evaluate();
            if (xResult.Count() == 0)
                return "";
            if (xResult.Count() == 1 && xResult.All(x => x.Children.Count() == 0))
                return xResult.First().GetEx<string>();
            else
            {
                var tmpNode = new Node("", null, xResult.Select(x => x.Clone()));
                signaler.Signal("lambda2hyper", tmpNode);
                return tmpNode.GetEx<string>();
            }
        }
    }
}