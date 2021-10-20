using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace WebAdmin
{
    public class SetupLogic
    {
        private IPage page;

        public async Task<IBrowser> BeforeScenario()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 2000
            });
            return browser;
        }

        public async Task<bool> AdminCreateRiderFinanceSuccess()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/finance");
            await page.WaitForTimeoutAsync(2000);
            var first = await page.QuerySelectorAllAsync("ion-card");
            var countFisrt = first.Count();
            await page.ClickAsync("text=เพิ่มรายการ >> span");
            await page.ClickAsync("text=1 637495843238686175 637496490865877251 637496493490656290 637498504432042681 63 >> button");
            await page.ClickAsync("button[role=\"radio\"]:has-text(\"1\")");
            await page.ClickAsync("button:has-text(\"OK\")");
            await page.FillAsync("input[name=\"ion-input-0\"]", "1500");
            await page.FillAsync("input[name=\"ion-input-1\"]", "รายเดือน");
            await page.ClickAsync("text=ยืนยัน >> button");
            await page.WaitForTimeoutAsync(2000);
            var seccond = await page.QuerySelectorAllAsync("ion-card");
            var countSeccon = seccond.Count();
            var result = countSeccon - countFisrt;
            var res = result == 1 ? true : false;
            return res;
        }

        public async Task<bool> AdminDeleteRiderFinanceSuccess()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/finance");
            await page.ClickAsync("text=นาย อานนท์ บางสาน");
            await page.ClickAsync("text=ลบ >> button");
            await page.ClickAsync("#ion-overlay-3 button:has-text(\"ตกลง\")");
            return true;
        }

        public async Task<bool> AdminCreateRiderAndRiderExcepted()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/biker");
            await page.ClickAsync("span");
            await page.FillAsync("input[name=\"ion-input-6\"]","0911234567");
            await page.FillAsync("input[name=\"ion-input-7\"]", "a1");
            await page.ClickAsync("input[name=\"file\"]");
            await page.SetInputFilesAsync("input[name=\"file\"]", new[] { "1.jpg" });
            await page.FillAsync("input[name=\"ion-input-9\"]", "น้อง");
            await page.FillAsync("input[name=\"ion-input-10\"]", "99/99");
            await page.FillAsync("input[name=\"ion-input-11\"]", "คนใหม่");
            await page.ClickAsync("text=ยกเลิกบันทึก >> div div");
        
            return true;

        }

        public async Task<bool> AdminCreateRiderButRiderNotExcepted()
        {
            return true;

        }

        public async Task<bool> RiderBeSuspendedFromJob()
        {
            return true;

        }

        public async Task<bool> RiderBeUnSuspendedFromJob()
        {
            return true;

        }

        public async Task<bool> RiderHistoryLog()
        {
            return true;

        }

        public async Task<bool> AdminCreateContract()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            //await page.GotoAsync(Path.Combine("https:", "delivery-3rd-admin.azurewebsites.net", "#", "Contract"));
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/contract");
            await page.WaitForTimeoutAsync(2000);
            var first = await page.QuerySelectorAllAsync("ion-card");
            var countFisrt = first.Count();
            await page.ClickAsync("text=เพิ่มรายการ >> span");
            await page.FillAsync("input[name=\"ion-input-0\"]", "พรุ่งนี้รวย299");
            await page.FillAsync("input[name=\"ion-input-1\"]", "1");
            await page.FillAsync("input[name=\"ion-input-2\"]", "3");
            await page.ClickAsync("text=ยืนยัน >> button");
            var seccond = await page.QuerySelectorAllAsync("ion-card");
            var countSeccon = seccond.Count();
            var result = countSeccon - countFisrt;
            var res = result == 1 ? true : false;
            return res;
        }

        public async Task<bool> ContractDetail()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/contract");
            await page.ClickAsync("p:has-text(\"Contract : นานแรมปี\")");
            // TODO check Scenario
            return true;
        }

        public async Task<bool> CancleOrder()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/operation");
            await page.ClickAsync("ion-segment-button:has-text(\"Order\")");
            await page.ClickAsync("h1:has-text(\"OrderID : 0032\")");
            //TODO : ใช้คำสั่ง Playwright กดยกเลิกคำสั่งซื้อไม่ได้ แก้ไข Code ใน web Admin
            await page.ClickAsync("ยกเลิกคำสั่งซื้อ");
            await page.ClickAsync("text=ร้านค้าไม่สามารถทำอาหารได้Bikerไม่สามารถส่งอาหารได้ >> button");
            await page.ClickAsync("button[role=\"radio\"]:has-text(\"ร้านค้าไม่สามารถทำอาหารได้\")");
            await page.ClickAsync("button:has-text(\"OK\")");
            await page.ClickAsync("h2:has-text(\"ตกลง\")");
            // TODO check Scenario
            return true;
        }

        public async Task<bool> RejectCancleOrder()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/operation");
            await page.ClickAsync("text=OrderID : 0032");
            await page.ClickAsync("text=ปฏิเสธการขอยกเลิก >> button");
            await page.ClickAsync("#ion-overlay-3 button:has-text(\"ตกลง\")");
            // TODO check Scenario
            return true;
        }

        public async Task<bool> ApproveCancleOrder()
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
            //TODO: กดบันทึกอนุมัติการขอยกเลิก แล้วขึ้น error แก้ไข Code ใน web Admin
            await page.ClickAsync("h2:has-text(\"บันทึก\")");
            // TODO check Scenario
            return true;
        }








    }
}
