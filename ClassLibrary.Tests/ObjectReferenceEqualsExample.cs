using System;
using Xunit;

namespace ClassLibrary.Tests
{
    public class ObjectReferenceEqualsExample
    {
        [Fact]
        public void ExampleWhereReferenceTypeUsesValueEqualitySematics()
        {
            Uri uri1 = new Uri("https://elixirhand.com/");
            Uri uri2 = new Uri("https://elixirhand.com/");

            var areEqual = uri1 == uri2;

            bool isSameRefernce = object.ReferenceEquals(uri1, uri2);

            uri2 = uri1;

            isSameRefernce = object.ReferenceEquals(uri1, uri2);

        }
    }
}
