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

        [Fact]
        public async Task Test1()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            //await page.GotoAsync(Path.Combine("https:", "delivery-3rd-admin.azurewebsites.net", "#", "Contract"));
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/contract");
            page.Url.Should().EndWith("contract");
            //await page.ClickAsync("text=เพิ่มรายการ >> span");
            //await page.FillAsync("input[name=\"ion-input-0\"]", "สัญญาหน้าฝน2");
            //await page.FillAsync("input[name=\"ion-input-1\"]", "30");
            //await page.FillAsync("input[name=\"ion-input-2\"]", "10");
            //await page.ClickAsync("text=ยืนยัน >> button");
            var actual = await page.InnerTextAsync("text=Contract : สัญญาหน้าฝน");
            actual.Should().BeEquivalentTo("Contract : สัญญาหน้าฝน");
            //Assert.Equal("Contract : สัญญาหน้าฝน", actual);

        }
    }
}
