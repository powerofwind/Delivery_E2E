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
    public class RestaurantTest
    {
        [Fact(DisplayName = "Admin - เพิ่ม Restaurant แล้วเจ้าของร้านยอมรับ ผลลัพธ์คือ Restaurant ทำงานกับบริษัทเดลิเวอร์รี่")]
        public async Task AdminCreateRestaurantApprove()
        {
            var sut = new SetupLogic();
            var res = await sut.ApproveCreateRestaurant();
            res.Should().Be(true);
        }


        [Fact(DisplayName = "Admin - เพิ่ม Restaurant แล้วเจ้าของร้านปฎิเสธ ผลลัพธ์คือ Restaurant ไม่ได้ทำงานกับบริษัทเดลิเวอร์รี่")]
        public async Task AdminCreateRestaurantReject()
        {
            var sut = new SetupLogic();
            var res = await sut.RejectCreateRestaurant();
            res.Should().Be(true);
        }

        [Fact(DisplayName = "Admin - ดูประวัติออเดอร์ย้อนหลังเพื่อตรวจสอบคำร้องที่ user แจ้งเข้ามาเช่นทำอาหารให้ผิด")]
        public async Task RestaurantHistoryDetail()
        {
            var sut = new SetupLogic();
            var res = await sut.RestaurantHistoryDetail();
            res.Should().Be(true);
        }
    }
}
