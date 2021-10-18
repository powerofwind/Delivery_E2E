using FluentAssertions;
using Microsoft.Playwright;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;


namespace WebAdmin_XUnitTest
{
    public class UnitTest1
    {
        private IPage page;

        public async Task<IBrowser> BeforeScenario()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                //SlowMo = 1000
            });
            return browser;
        }


        [Fact(DisplayName = "สามารถเพิ่มสัญญาได้")]
        public async Task AddContract()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            //await page.GotoAsync(Path.Combine("https:", "delivery-3rd-admin.azurewebsites.net", "#", "Contract"));
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/contract");
            await page.ClickAsync("text=เพิ่มรายการ >> span");
            await page.FillAsync("input[name=\"ion-input-0\"]", "พรุ่งนี้รวย10");
            await page.FillAsync("input[name=\"ion-input-1\"]", "1");
            await page.FillAsync("input[name=\"ion-input-2\"]", "3");
            await page.ClickAsync("text=ยืนยัน >> button");

            var actual = await page.InnerTextAsync("text=Contract : พรุ่งนี้รวย10");
            actual.Should().BeEquivalentTo("Contract : พรุ่งนี้รวย10");
            //Assert.Equal("Contract : พรุ่งนี้รวย", actual);
        }


        [Fact(DisplayName = "สามารถดูรายละเอียดสัญญาได้")]
        //TODO : เดวมาดูต่อ case - ตรวจสอบร้านอาหารไหนอยู่ในสัญญานี้บ้าง
        public async Task DetailContract()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/contract");
            await page.ClickAsync("p:has-text(\"Contract : นานแรมปี\")");
            var actual = await page.InnerTextAsync("h1:has-text(\"นานแรมปี\")");
            actual.Should().BeEquivalentTo("นานแรมปี");
        }


        [Fact(DisplayName = "ขอยกเลิก order สำเร็จ")]
        public async Task CancleOrder ()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/operation");
            await page.ClickAsync("ion-segment-button:has-text(\"Order\")");
            await page.ClickAsync("h1:has-text(\"OrderID : 0035\")");
            //TODO : ยังใช้คำสั่ง ยกเลิกคำสั่งซื้อ บรรทัดที่ 70 ไม่ได้ แก้ไข Code ใน web Admin
            await page.ClickAsync("ยกเลิกคำสั่งซื้อ");
            await page.ClickAsync("text=ร้านค้าไม่สามารถทำอาหารได้Bikerไม่สามารถส่งอาหารได้ >> button");
            await page.ClickAsync("button[role=\"radio\"]:has-text(\"ร้านค้าไม่สามารถทำอาหารได้\")");
            await page.ClickAsync("button:has-text(\"OK\")");
            await page.ClickAsync("h2:has-text(\"ตกลง\")");

            var actual = await page.InnerTextAsync("text=คำขอยกเลิกการสั่งอาหาร");
            actual.Should().BeEquivalentTo("คำขอยกเลิกการสั่งอาหาร");
        }


        [Fact(DisplayName = " ปฏิเสธคำขอยกเลิก order ทำให้ order ไม่ถูกยกเลิกและสามารถดำเนินการต่อได้จนจบ")]
        public async Task RejectCancleOrder()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/operation");
            await page.ClickAsync("text=OrderID : 0035");
            await page.ClickAsync("text=ปฏิเสธการขอยกเลิก >> button");
            await page.ClickAsync("#ion-overlay-3 button:has-text(\"ตกลง\")");
            var actual = await page.InnerTextAsync("text=ไม่มีรายการ");
            actual.Should().BeEquivalentTo("ไม่มีรายการ");
        }


        [Fact(DisplayName = "อนุมัติคำขอยกเลิก order ผลลัพธ์คือ order ถูกยกเลิกและได้รับเงินคืนตามสัญญา")]
        //TODO ยังไม่ได้ทำเกี่ยวกับการคืนเงิน
        public async Task ApproveCancleOrder()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/operation");
            await page.ClickAsync("text=OrderID : 0029");
            await page.ClickAsync("text=อนุมัติการขอยกเลิก >> button");
            await page.ClickAsync("text=ร้านค้าไม่สามารถทำอาหารได้ Bikerไม่สามารถส่งอาหารได้ >> button");
            await page.ClickAsync("button[role=\"radio\"]:has-text(\"ร้านค้าไม่สามารถทำอาหารได้\")");
            await page.ClickAsync("button:has-text(\"OK\")");
            await page.ClickAsync("text=คืนทั้งหมดชดเชยให้ร้านไม่ชดเชยให้ร้านคืนเฉพาะค่าอาหารไม่คืนเงิน >> button");
            //TODO: กดบันทึกในบรรทัดที่ 110 แล้วขึ้น error แก้ไข Code ใน web Admin
            await page.ClickAsync("h2:has-text(\"บันทึก\")");
            var actual = await page.InnerTextAsync("text=ไม่มีรายการ");
            actual.Should().BeEquivalentTo("ไม่มีรายการ");
        }


    }
}
