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
        [Fact(DisplayName = "สามารถดูรายละเอียดสัญญาได้")]
        public async Task AdminCancleOrder()
        {
            var sut = new SetupLogic();
            var res = await sut.CancleOrder();
            res.Should().Be(true);
        }

        [Fact(DisplayName = "สามารถดูรายละเอียดสัญญาได้")]
        public async Task AdminRejectCancleOrder()
        {
            var sut = new SetupLogic();
            var res = await sut.RejectCancleOrder();
            res.Should().Be(true);
        }
    }
}
