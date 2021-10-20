using FluentAssertions;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAdmin;
using Xunit;

namespace WebAdmin_XUnitTest
{
    public class RiderManagementTest
    {

        [Fact(DisplayName = "Admin - เพิ่ม Rider แล้ว Rider คนนั้นยอมรับ ผลลัพธ์คือ Rider เป็นพนังงานของบริษัทเดลิเวอร์รี่")]
        public async Task AdminCreateRiderAndRiderExcepted()
        {
            var sut = new SetupLogic();
            var res = await sut.AdminCreateRiderAndRiderExcepted();
            res.Should().Be(true);
        }

        [Fact(DisplayName = "Admin - เพิ่ม Rider แล้ว Rider คนนั้นปฎิเสธ  ผลลัพธ์คือ Rider ไม่ได้เป็นพนังงานของบริษัทเดลิเวอร์รี่")]
        public async Task AdminCreateRiderButRiderNotExcepted()
        {
            var sut = new SetupLogic();
            var res = await sut.AdminCreateRiderButRiderNotExcepted();
            res.Should().Be(true);
        }

        [Fact(DisplayName = "Admin - พักงาน Rider แล้ว Rider จะไม่สามารถรับงานได้")]
        public async Task RiderBeSuspendedFromJob()
        {
            var sut = new SetupLogic();
            var res = await sut.RiderBeSuspendedFromJob();
            res.Should().Be(true);
        }

        [Fact(DisplayName = "Admin - เลิกพักงาน Rider แล้ว Rider จะสามารถกลับมารับงานได้")]
        public async Task RiderBeUnSuspendedFromJob()
        {
            var sut = new SetupLogic();
            var res = await sut.RiderBeUnSuspendedFromJob();
            res.Should().Be(true);

        }

        [Fact(DisplayName = "Admin - ดูประวัติการเงินย้อนหลังของ Rider ได้ เอาไว้เช็คกับ app rider ซึ่งตอนนี้ยังไม่มี ui ใน rider")]
        public async Task RiderHistoryLog()
        {
            var sut = new SetupLogic();
            var res = await sut.RiderHistoryLog();
            res.Should().Be(true);

        }

    }
}
