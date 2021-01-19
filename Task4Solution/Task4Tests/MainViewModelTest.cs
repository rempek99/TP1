using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using ViewModel;

namespace Task4Tests
{
    [TestClass]
    public class MainViewModelTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            MainViewModel mvm = new MainViewModel(new Model.DataContext(new TestDataService()));
            Assert.IsNotNull(mvm.dataContext);
            Assert.IsNotNull(mvm.Products);
            Assert.IsNotNull(mvm.CurrentProduct);
            Assert.IsFalse(String.IsNullOrEmpty(mvm.CurrentMessage));
            Assert.IsNotNull(mvm.AddSampleProduct);
            Assert.IsNotNull(mvm.RemoveSampleProduct);
            Assert.IsNotNull(mvm.UpdateSampleProduct);
        }
        [TestMethod]
        public void CommandsTest()
        {
            MainViewModel mvm = new MainViewModel(new Model.DataContext(new TestDataService()));
            mvm.AddSampleProduct.Execute(null);
            Thread.Sleep(100);
            Assert.AreEqual("added", mvm.CurrentMessage);
            mvm.RemoveSampleProduct.Execute(null);
            Thread.Sleep(100);
            Assert.AreEqual("removed", mvm.CurrentMessage);
            mvm.UpdateSampleProduct.Execute(null);
            Thread.Sleep(100);
            Assert.AreEqual("updated", mvm.CurrentMessage);
        }
    }
}
