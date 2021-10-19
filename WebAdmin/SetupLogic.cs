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


    }
}
