﻿using System;
using System.Collections.Generic;

namespace Reed_Muller.Logic
{
    public static class Channel
    {
        private static readonly Random random = new Random();
        
        /// <summary>
        /// Simulate sending message through noisy channel with provided error probability.
        /// </summary>
        /// <param name="message">Vector made of 0s and 1s - message that is sent through the channel</param>
        /// <param name="p">Error probability (0<=p<=1)</param>
        /// <param name="distortedPlaces">Indexes where distortion happened in the "sent" message</param>
        /// <returns>Initial message vector but with possible distortion</returns>
        public static int[] SendBinaryMessage (int[] message, double p, out List<int> distortedPlaces)
        {
            var distortedMessage = new int[message.Length];
            distortedPlaces = new List<int>();
            for(int i = 0; i<message.Length; i++)
            {
                var randomValue = random.NextDouble();
                if (randomValue < p)
                {
                    distortedMessage[i] = message[i] == 0 ? 1 : 0;
                    distortedPlaces.Add(i + 1);
                } else
                {
                    distortedMessage[i] = message[i];
                }
            }
            return distortedMessage;

        }

        /// <summary>
        /// Accepts a list of vectors (arrays made of 0s and 1s) and sends them through the channel separately
        /// </summary>
        /// <param name="message">List of vectors to be sent through the channel</param>
        /// <param name="p">Distortion probability</param>
        /// <param name="distortedPlaces">Indexes where distortion happened in the "sent" message</param>
        /// <returns>List of initial vectors but with possible distortions </returns>
        public static List<int[]> SendBinaryMessage (List<int[]> message, double p, out List<int> distortedPlaces)
        {
            var result = new List<int[]>();
            distortedPlaces = new List<int>();
            foreach(var m in message)
            {
                var received = SendBinaryMessage(m, p, out distortedPlaces);
                result.Add(received);
            }
            return result;
        }
    }
}
