using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WebSharp.Data;
using WebSharp.Primitives;

namespace Tests
{
    [TestClass]
    public class ExpressionTests
    {
        private class DataProviderMockup : IDataProvider
        {
            public Dictionary<string, object> Data = new Dictionary<string, object>();

            public object GetValue(string name)
            {
                return Data.ContainsKey(name) ? Data[name] : null;
            }

            public void SetValue(string name, object value)
            {
                Data[name] = value;
            }
        }

        [TestMethod]
        public void TestAsignment()
        {
            DataProviderMockup dataProvider = new();
            Expression expression = new Expression("a=7", dataProvider);
            expression.Evaluate();
            Assert.AreEqual("7", dataProvider.Data["a"]);
        }
    }
}