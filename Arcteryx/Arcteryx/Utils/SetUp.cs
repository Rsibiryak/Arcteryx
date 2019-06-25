using Arcteryx.Pages;
using Arcteryx.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcteryx.Tests
{
    [SetUpFixture]
    public class SetUp
    {
 
  
        [OneTimeTearDown]
        public void AfterTest()
        {
           AppManager.GetInstance().Driver.Quit();           
        }
    }
}
