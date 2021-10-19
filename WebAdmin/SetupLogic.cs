using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            await page.ClickAsync("text=เพิ่มรายการ >> span");
            await page.ClickAsync("text=1 637495843238686175 637496490865877251 637496493490656290 637498504432042681 63 >> button");
            await page.ClickAsync("button[role=\"radio\"]:has-text(\"1\")");
            await page.ClickAsync("button:has-text(\"OK\")");
            await page.FillAsync("input[name=\"ion-input-0\"]", "1500");
            await page.FillAsync("input[name=\"ion-input-1\"]", "รายเดือน");
            await page.ClickAsync("text=ยืนยัน >> button");
            return true;
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
