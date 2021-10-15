using FluentAssertions;
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class Contract_ManagementSteps
    {
        private readonly IBrowser browser;
        private IPage page;

        public Contract_ManagementSteps(ScenarioContext scenarioContext)
        {
            browser = scenarioContext.Get<IBrowser>();
        }

        [Given(@"จากหน้า '(.*)'")]
        public async Task Givenจากหนา(string url)
        {
            page ??= await browser.NewPageAsync();
            await page.GotoAsync(url);
        }
        
        [Given(@"กดปุ่มเพิ่มรายการ")]
        public async Task Givenกดปเพมรายการ()
        {
            //await page.RunAndWaitForNavigationAsync(async () =>
            //{
            //    await page.ClickAsync("text=เพิ่มรายการ >> span");
            //});
            await page.ClickAsync("text=เพิ่มรายการ >> span");
        }
        
        [When(@"กรอกชื่อสัญญา '(.*)'")]
        public async Task Whenกรอกชอสญญา(string contractName)
        {
            await page.FillAsync("input[name=\"ion-input-0\"]", contractName);
        }

        [When(@"กรอกเปอร์เซ็นต์ที่หักจากร้านอาหาร '(.*)'")]
        public async Task Whenกรอกเปอรเซนตทหกจากรานอาหาร(string percentage)
        {
            await page.FillAsync("input[name=\"ion-input-1\"]", percentage);
        }

        [When(@"กรอกค่าส่ง '(.*)'")]
        public async Task Whenกรอกคาสง(string deliveryfee)
        {
            await page.FillAsync("input[name=\"ion-input-2\"]", deliveryfee);
        }

        [Then(@"กดปุ่มยืนยัน")]
        public async Task Thenกดปมยนยน()
        {
            await page.ClickAsync("text=ยืนยัน >> button");
        }

        [Then(@"แสดงสัญญาที่สร้างขึ้นมาใหม่ '(.*)'")]
        public async Task Thenแสดงสญญาทสรางขนมาใหม(string contractName)
        {
            var actual = await page.InnerTextAsync("text=Contract : สัญญาหน้าฝน");
            actual.Should().BeEquivalentTo(contractName);
        }

        [Then(@"ในหน้า '(.*)'")]
        public void Thenในหนา(string urlExpect)
        {
            page.Url.Should().BeEquivalentTo(urlExpect);
        }

    }
}
