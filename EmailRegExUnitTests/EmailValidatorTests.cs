using System;
using EmailRegEx;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmailRegExUnitTests
{
    [TestClass]
    public class EmailValidatorTests
    {
        #region Should not match
        [TestMethod]
        public void IsValid_Test_string_ShouldFail()
        {
            Assert.IsFalse(EmailValidator.IsValid("Joe"));
        }

        [TestMethod]
        public void IsValid_Test_string_at_string_ShouldFail()
        {
            Assert.IsFalse(EmailValidator.IsValid("Joe@home"));
        }

        [TestMethod]
        public void IsValid_Test_no_at_ShouldFail()
        {
            Assert.IsFalse(EmailValidator.IsValid("joe-bob[at]home.com"));
        }

        [TestMethod]
        public void IsValid_Test_5char_tld_ShouldFail()
        {
            Assert.IsFalse(EmailValidator.IsValid("joe@his.home.place"));
        }

        [TestMethod]
        public void IsValid_Test_string_period_at_ShouldFail()
        {
            Assert.IsFalse(EmailValidator.IsValid("joe.@bob.com"));
        }

        [TestMethod]
        public void IsValid_Test_period_string_at_ShouldFail()
        {
            Assert.IsFalse(EmailValidator.IsValid(".joe@bob.com"));
        }

        [TestMethod]
        public void IsValid_Test_two_period_together_ShouldFail()
        {
            Assert.IsFalse(EmailValidator.IsValid("john..doe@bob.com"));
        }

        [TestMethod]
        public void IsValid_Test_tld_ends_with_period_ShouldFail()
        {
            Assert.IsFalse(EmailValidator.IsValid("joe@his.home.com."));
        }

        [TestMethod]
        public void IsValid_Test_invalid_char_in_IP_ShouldFail()
        {
            Assert.IsFalse(EmailValidator.IsValid("a@10.1.100.1a"));
        }

        [TestMethod]
        public void IsValid_Test_Large_IP_ShouldFail()
        {
            Assert.IsFalse(EmailValidator.IsValid("a@256.1.100.1"));
        }

        [TestMethod]
        public void IsValid_Test_invalid_char_dash_to_start_domain_ShouldFail()
        {
            Assert.IsFalse(EmailValidator.IsValid("john@-doe.com"));
        }

        [TestMethod]
        public void IsValid_Test_invalid_char_dash_to_end_domain_ShouldFail()
        {
            Assert.IsFalse(EmailValidator.IsValid("john@doe-.com"));
        }
        
        [TestMethod]
        public void IsValid_Test_Space_start_ShouldFail()
        {
            Assert.IsFalse(EmailValidator.IsValid(" john@doe.com"));
        }

        [TestMethod]
        public void IsValid_Test_Space_end_ShouldFail()
        {
            Assert.IsFalse(EmailValidator.IsValid("john@doe.com "));
        }

        [TestMethod]
        public void IsValid_Test_NewLine_end_ShouldFail()
        {
            string email = "john@doe.com" + Environment.NewLine;
            Assert.IsFalse(EmailValidator.IsValid(email));
        }

        [TestMethod]
        public void IsValid_Test_NewLine_withSlashN_end_ShouldFail()
        {
            string email = "john@doe.com\n";
            Assert.IsFalse(EmailValidator.IsValid(email));
        }

        [TestMethod]
        public void IsValid_Test_NewLine_withSlashR_end_ShouldFail()
        {
            string email = "john@doe.com\r";
            Assert.IsFalse(EmailValidator.IsValid(email));
        }
        #endregion

        #region Should match

        [TestMethod]
        public void IsValid_Test_basic_valid_email_ShouldMatch()
        {
            Assert.IsTrue(EmailValidator.IsValid("joe@home.org"));
        }

        [TestMethod]
        public void IsValid_Test_four_letter_tld_ShouldMatch()
        {
            Assert.IsTrue(EmailValidator.IsValid("joe@joebob.name"));
        }

        [TestMethod]
        public void IsValid_Test_localpart_has_ampersand_ShouldMatch()
        {
            Assert.IsTrue(EmailValidator.IsValid("joe&bob@bob.com"));
        }

        [TestMethod]
        public void IsValid_Test_localpart_starts_with_special_char_tilde_ShouldMatch()
        {
            Assert.IsTrue(EmailValidator.IsValid("~joe@bob.com"));
        }

        [TestMethod]
        public void IsValid_Test_localpart_can_end_with_special_char_dollar_ShouldMatch()
        {
            Assert.IsTrue(EmailValidator.IsValid("joe$@bob.com"));
        }

        [TestMethod]
        public void IsValid_Test_localpart_can_contain_special_char_plus_ShouldMatch()
        {
            Assert.IsTrue(EmailValidator.IsValid("joe+bob@bob.com"));
        }

        [TestMethod]
        public void IsValid_Test_localpart_can_contain_special_char_singlequote_ShouldMatch()
        {
            Assert.IsTrue(EmailValidator.IsValid("o'reilly@there.com"));
        }

        [TestMethod]
        public void IsValid_Test_localpart_can_contain_special_char_period_ShouldMatch()
        {
            Assert.IsTrue(EmailValidator.IsValid("joe.bob@home.com"));
        }

        [TestMethod]
        public void IsValid_Test_long_domain_ShouldMatch()
        {
            Assert.IsTrue(EmailValidator.IsValid("joe@his.home.com"));
        }

        [TestMethod]
        public void IsValid_Test_longer_domain_ShouldMatch()
        {
            Assert.IsTrue(EmailValidator.IsValid("joe@an.extremely.long.tld.with.many.periods.like.at.a.college.edu"));
        }

        [TestMethod]
        public void IsValid_Test_single_char_localpart_ShouldMatch()
        {
            Assert.IsTrue(EmailValidator.IsValid("a@abc.org"));
        }

        [TestMethod]
        public void IsValid_Test_IP_Address_ShouldMatch()
        {
            Assert.IsTrue(EmailValidator.IsValid("a@192.168.0.1"));
        }

        [TestMethod]
        public void IsValid_domain_part_has_dash_ShouldMatch()
        {
            Assert.IsTrue(EmailValidator.IsValid("a@abc-domain.org"));
        }

        [TestMethod]
        public void IsValid_domain_single_char_ShouldMatch()
        {
            Assert.IsTrue(EmailValidator.IsValid("a@a.org"));
        }

        #endregion

    }
}
