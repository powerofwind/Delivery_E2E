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
    public class FinanceTest
    {

        [Fact(DisplayName = "Admin - สร้างรายการการจ่ายเงินให้ Rider สำเร็จ")]
        public async Task AdminCreateRiderFinanceSuccess()
        {
            var sut = new SetupLogic();
            var res = sut.AdminCreateRiderFinanceSuccess();
            res.Should().Be(true);
        }

        [Fact(DisplayName = "Admin - สามารถลบรายละเอียดการจ่ายเงินได้")]
        public async Task AdminDeleteRiderFinanceSuccess()
        {
            var sut = new SetupLogic();
            var res = sut.AdminDeleteRiderFinanceSuccess();
            res.Should().Be(true);
        }

    }
}
