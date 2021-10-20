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
    public class ContractTest
    {
        [Fact(DisplayName = "สามารถเพิ่มสัญญาได้")]
        public async Task AdminCreateContract()
        {
            var sut = new SetupLogic();
            var res = await sut.AdminCreateContract();
            res.Should().Be(true);
        }

        [Fact(DisplayName = "สามารถดูรายละเอียดสัญญาได้")]
        public async Task AdminContractDetail()
        {
            var sut = new SetupLogic();
            var res = await sut.ContractDetail();
            res.Should().Be(true);
        }
    }
}
