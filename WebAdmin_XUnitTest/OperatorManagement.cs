using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAdmin;
using Xunit;

namespace WebAdmin_XUnitTest
{
    public class OperatorManagement
    {
        [Fact(DisplayName = "Admin - เพิ่ม Operator แล้ว Operator คนนั้นยอมรับ ผลลัพธ์คือ Operator เป็นพนังงานของบริษัทเดลิเวอร์รี่")]
        public async Task AdminCreateOperatorApprove()
        {
            var sut = new SetupLogic();
            var res = await sut.ApproveCreateOperator();
            res.Should().Be(true);
        }


        [Fact(DisplayName = "Admin - เพิ่ม Operator แล้ว Operator คนนั้นปฎิเสธ ผลลัพธ์คือ Operator ไม่ได้เป็นพนังงานของบริษัทเดลิเวอร์รี่")]
        public async Task AdminCreateOperatorReject()
        {
            var sut = new SetupLogic();
            var res = await sut.RejectCreateOperator();
            res.Should().Be(true);
        }


        [Fact(DisplayName = "Admin - พักงาน Operator แล้ว Operator จะไม่สามารถแสกนเข้าเว็บได้")]
        public async Task OperatorSuspended()
        {
            var sut = new SetupLogic();
            var res = await sut.OperatorBeSuspendedFromJob();
            res.Should().Be(true);
        }


        [Fact(DisplayName = "Admin - เลิกพักงาน Operator แล้ว Operator จะสามารถแสกนเข้าเว็บได้")]
        public async Task OperatorUnSuspended()
        {
            var sut = new SetupLogic();
            var res = await sut.OperatorBeUnSuspendedFromJob();
            res.Should().Be(true);
        }
    }
}
