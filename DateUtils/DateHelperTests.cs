using System;
using NUnit.Framework;
using DateUtils;

namespace DateUtils.Tests
{
    [TestFixture]
    public class DateHelperTests
    {
        [Test]
        public void IsLeapYear_WorksCorrectly()
        {
            Assert.IsTrue(DateHelper.IsLeapYear(2024));
            Assert.IsFalse(DateHelper.IsLeapYear(2023));
        }

        [Test]
        public void DaysBetween_ReturnsAbsoluteValue()
        {
            var d1 = new DateTime(2024, 1, 1);
            var d2 = new DateTime(2024, 1, 10);

            Assert.AreEqual(9, DateHelper.DaysBetween(d1, d2));
            Assert.AreEqual(9, DateHelper.DaysBetween(d2, d1));
        }

        [Test]
        public void FormatDate_FormatsCorrectly()
        {
            var date = new DateTime(2024, 12, 31, 23, 59, 0);
            Assert.AreEqual("31.12.2024 23:59", DateHelper.FormatDate(date));
        }

        [Test]
        public void HumanizeDifference_ShowsHumanReadableText()
        {
            var now = DateTime.Now;
            Assert.AreEqual("только что", DateHelper.HumanizeDifference(now, now));

            Assert.AreEqual("3 дней назад", DateHelper.HumanizeDifference(now.AddDays(3), now));
            Assert.AreEqual("через 2 недель", DateHelper.HumanizeDifference(now, now.AddDays(14)));
        }
    }
}
