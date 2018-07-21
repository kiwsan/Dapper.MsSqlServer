using Autofac;
using Autofac.CrossCutting.IoC;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Startup
{
    public class NUnitTestBase
    {

        protected IContainer _container;
        [SetUp]
        public void BaseSetUp()
        {

            _container = NativeInjectorBootStrapper.Registers();

        } // Exception thrown!

        [TearDown]
        public void BaseTearDown()
        {

        }

    }
}
