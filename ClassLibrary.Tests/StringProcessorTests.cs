﻿using ClassLibrary.Tuples;
using System.Collections.Generic;
using Xunit;

namespace ClassLibrary.Tests
{
    public class StringProcessorTests
    {
        [Fact]
        public void Return_lengths_and_uppercase_strings()
        {
            var sut = new StringProcessor();

            var inputStrings = new List<string>
            {
                "Hello",
                "Welcome",
                "Howdy"
            };

            var results = sut.ToUpperAndWithLength(inputStrings);

            Assert.Equal(3, results.Count);

            Assert.Equal("5-HELLO", results[0]);            
            Assert.Equal("7-WELCOME", results[1]);
            Assert.Equal("5-HOWDY", results[2]);
        }   
    }
}
