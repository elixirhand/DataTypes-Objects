using System;
using Xunit;

namespace ClassLibrary.Tests
{
    public class ObjectReferenceEqualsExample
    {
        [Fact]
        public void ExampleWhereReferenceTypeUsesValueEqualitySematics()
        {
            //http:/elixirhand.com/
            Uri uri1 = new Uri("http://elixirhand.com");
            Uri uri2 = new Uri("http://elixirhand.com");

            var areEqual = uri1 == uri2;

            bool isSameRefernce = object.ReferenceEquals(uri1, uri2);

            uri2 = uri1;

            isSameRefernce = object.ReferenceEquals(uri1, uri2);

        }
    }
}
