using System;
using System.Diagnostics.CodeAnalysis;

namespace StreamfileReader.Tests.Library {

    /// <summary>
    /// Used by CustomOrderer
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class OrderAttribute : Attribute {
        public int I { get; }

        public OrderAttribute(int i) {
            I = i;
        }
    }
}