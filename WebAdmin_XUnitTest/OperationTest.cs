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
    public class OperationTest
    {
        [Fact(DisplayName = "Admin สามารถขอยกเลิกออเดอร์ได้")]
        public async Task AdminCancleOrder()
        {
            var sut = new SetupLogic();
            var res = await sut.CancleOrder();
            res.Should().Be(true);
        }

        [Fact(DisplayName = "Admin - ปฏิเสธคำขอยกเลิก order ทำให้ order ไม่ถูกยกเลิกและสามารถดำเนินการต่อได้จนจบ")]
        public async Task AdminRejectCancleOrder()
        {
            var sut = new SetupLogic();
            var res = await sut.RejectCancleOrder();
            res.Should().Be(true);
        }

        [Fact(DisplayName = "อนุมัติคำขอยกเลิกทำให้ user,rider,restaurant ได้เงินคืนตามสัญญา")]
        public async Task AdminApproveCancleOrder()
        {
            var sut = new SetupLogic();
            var res = await sut.ApproveCancleOrder();
            res.Should().Be(true);
        }
    }
}
