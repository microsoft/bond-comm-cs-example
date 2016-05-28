// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Net;
using Bond.Comm.Epoxy;

namespace Bond.Comm.Examples.Calculator
{
    class CalculatorClient
    {
        public static void Main()
        {
            // Bond has an abstraction for network protocols called a Transport. Epoxy is a custom protocol that is
            // lightweight and built into Bond.Comm. If it doesn't meet your needs, you can write your own Transport.
            var transport = new EpoxyTransportBuilder().Construct();
            var connection = transport.ConnectToAsync(new IPEndPoint(IPAddress.Loopback, EpoxyTransport.DefaultPort)).Result;

            // For each service, Bond will generate a proxy with methods corresponding to the service methods you defined.
            var proxy = new CalculatorProxy<EpoxyConnection>(connection);

            var addArgs = new BinaryOpArgs
            {
                left = 2,
                right = 2
            };
            // The result of a Bond call is a IMessage, which is either a payload or an error.
            // Display() shows how to handle both cases.
            var addResult = proxy.AddAsync(addArgs).Result;
            Display("Add", addArgs, addResult);

            var divArgs = new BinaryOpArgs
            {
                left = 1,
                right = 0
            };
            var divResult = proxy.DivideAsync(divArgs).Result;
            Display("Divide", divArgs, divResult);

            Console.ReadLine();
        }

        private static void Display(string call, BinaryOpArgs args, IMessage<Result> result)
        {
            var callStr = $"{call}({args.left}, {args.right})";
            if (result.IsError)
            {
                var error = result.Error.Deserialize();
                Console.WriteLine($"{callStr} returned error code {error.error_code} with {error.message}");
            }
            else
            {
                var answer = result.Payload.Deserialize().value;
                Console.WriteLine($"{callStr} => {answer}");
            }
        }
    }
}
