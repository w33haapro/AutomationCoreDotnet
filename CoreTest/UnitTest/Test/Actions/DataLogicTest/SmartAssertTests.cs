using Core.UnitTest.Model;
using NUnit.Framework;
using System.Collections.Generic;

namespace Core.UnitTest.Test.Data.DataAssertion
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class SmartAssertTests : BaseFixture
    {
        [Test]
        public void AreEqual_CompareStrings_Successfully()
        {
            string expected = "string1";
            string actual = "string1";
            expected.AreEqual(actual);
        }

        [Test]
        public void AreContain_VerifyStringContainsOtherString_Successfully()
        {
            string target = "string1";
            string actual = "string1";
            actual.AreContain(target);
        }

        [Test]
        public void AreEqual_CompareInts_Successfully()
        {
            int expected = 1;
            int actual = 1;
            expected.AreEqual(actual);
        }

        [Test]
        public void AreEqual_CompareObjects_Successfully()
        {
            User expected = new User();
            expected.City = "Hanoi";
            expected.CurrentAddress = "Address";
            expected.Email = "12345";
            User actual = new User();
            actual.City = "Hanoi";
            actual.CurrentAddress = "Address";
            actual.Email = "12345";
            expected.AreEqual(actual);
        }

        [Test]
        public void AreEqual_CompareListObject_Successfully()
        {
            List<User> listExpected = new List<User>();
            User expected = new User();
            expected.City = "Hanoi";
            expected.CurrentAddress = "Address";
            expected.Email = "12345";
            listExpected.Add(expected);

            List<User> listActual = new List<User>();
            User actual = new User();
            actual.City = "Hanoi";
            actual.CurrentAddress = "Address";
            actual.Email = "12345";
            listActual.Add(actual);

            listExpected.AreEqual(listActual);
        }


        [Test]
        public void IsNotNull_VerifyObjectIsNotNull_Successfully()
        {
            User expected = new User();
            expected.City = "Hanoi";
            expected.CurrentAddress = "Address";
            expected.Email = "12345";

            int count = 1;

            expected.IsNotNull();
            expected.Email.IsNotNull();
            count.IsNotNull();
        }

        [Test]
        public void IsNull_VerifyObjectIsNull_Successfully()
        {
            User expected = null;
            expected.IsNull();
        }

        [Test]
        public void AreGreater_VerifyIntIsGreaterThanIntsTarget_Successfully()
        {
            int actual = 100;
            int target = 99;
            actual.AreGreaterThan(target);
        }

        [Test]
        public void AreLessThan_VerifyIntIsLessThanIntsTarget_Successfully()
        {
            int actual = 99;
            int target = 100;
            actual.AreLessThan(target);
        }

    }
}
