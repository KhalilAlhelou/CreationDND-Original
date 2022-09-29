using NUnit.Framework;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestCreationDND
{
    public class TestCreationAttribut
    {
        Models model;

        [SetUp]
        public void Setup()
        {
            model = new Models();
        }

        [Test]
        public void CreationDUnAttributAPartirDUnAttributDTO()
        {
            Assert.Pass();
        }
    }
}
