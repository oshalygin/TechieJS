using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TN.BLL;
using TN.Models;

namespace TN.Tests
{
    public class TagBLLTests
    {

        [Test]

        public void TagListCreatedSuccessfully()
        {
            string tags = "visual studio c# hello world";

            TagBLL tagBLL = new TagBLL();

            List<Tag> sut = tagBLL.CreateTag(tags);

            Tag tag1 = new Tag {Name = "visual"};
            Tag tag2 = new Tag { Name = "studio" };
            Tag tag3 = new Tag { Name = "c#" };
            Tag tag4 = new Tag { Name = "hello" };
            Tag tag5 = new Tag { Name = "world" };
            
            Assert.That(tag1.Name, Is.EqualTo(sut[0].Name));
            Assert.That(tag2.Name, Is.EqualTo(sut[1].Name));
            Assert.That(tag3.Name, Is.EqualTo(sut[2].Name));
            Assert.That(tag4.Name, Is.EqualTo(sut[3].Name));
            Assert.That(tag5.Name, Is.EqualTo(sut[4].Name));
            

            Assert.That(sut.Count, Is.EqualTo(5));



        }

    }
}
