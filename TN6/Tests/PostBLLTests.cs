using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TN.BLL;

namespace TN.Tests
{
    public class PostBLLTests
    {
        [Test]
        public void PostTitleRemovesBadCharacters()
        {
            PostBLL postBLL = new PostBLL();

            string inputPostTitle = "And we're live! Kicking off with the gas all the way down!";

            string sut = postBLL.UrlTitleWithDashes(inputPostTitle);
            sut = postBLL.SanitizedUrlTitle(sut);

            string result = "And-were-live-Kicking-off-with-the-gas-all-the-way-down";

            Assert.That(sut, Is.EqualTo(result));

        }
        [Test]
        public void PostTitleAddedDashes()
        {
            PostBLL postBLL = new PostBLL();

            string inputPostTitle = "And we're live! Kicking off with the gas all the way down!";

            string sut = postBLL.UrlTitleWithDashes(inputPostTitle);

            string result = "And-we're-live!-Kicking-off-with-the-gas-all-the-way-down!";

            Console.WriteLine(sut);
            
            Assert.That(sut,Is.EqualTo(result));


        }

    }
}
