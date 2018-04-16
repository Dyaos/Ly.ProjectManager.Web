using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("Ly.ProjectManager.Data.DLL", "Ly.ProjectManager.Mapping.DLL").Replace("file:///", "");


            Assembly asm = Assembly.LoadFile(assembleFileName);
        }
    }
}
