// Author: Dhruv Kushwaha
// Assignment: Cognizant Digital Nurture 4.0
// Skill: Design Principles & Patterns
// Week: 1 - Exercise 1: Singleton Pattern

using System;

namespace SingletonPatternExample
{
    public class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();

        // Private constructor to prevent external instantiation
        private Logger()
        {
            Console.WriteLine("Logger Initialized.");
        }

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }

        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }
}
