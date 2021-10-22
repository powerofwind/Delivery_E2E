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
            var countSeccond = seccond.Count();
            var result = countSeccond - countFisrt;
            var res = result == 1 ? true : false;
            return res;
        }

        public async Task<bool> AdminDeleteRiderFinanceSuccess()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/finance");
            await page.WaitForTimeoutAsync(2000);
            var first = await page.QuerySelectorAllAsync("ion-card");
            var countFisrt = first.Count();
            await page.ClickAsync("text=นาย อานนท์ บางสาน");
            await page.ClickAsync("text=ลบ >> button");
            await page.ClickAsync("#ion-overlay-3 button:has-text(\"ตกลง\")");
            var seccond = await page.QuerySelectorAllAsync("ion-card");
            var countSeccond = seccond.Count();
            var result = countFisrt - countSeccond;
            var res = result == 1 ? true : false;
            return res;
        }

        public async Task<bool> AdminCreateRiderAndRiderExcepted()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/biker");
            await page.WaitForTimeoutAsync(2000);
            var countenable = await page.QuerySelectorAllAsync("ion-card[ng-reflect-disabled ='false']");
            var enablelist = countenable.Count();
            await page.ClickAsync("span");
            await page.FillAsync("input[name=\"ion-input-0\"]","0911234567");
            await page.FillAsync("input[name=\"ion-input-1\"]", "a1");
            await page.SetInputFilesAsync("input[name=\"file\"]", new[] { "C:\\Users\\sakul\\Desktop\\oldpic\\1.jpg" });
            await page.FillAsync("input[name=\"ion-input-3\"]", "น้อง2");
            await page.FillAsync("input[name=\"ion-input-4\"]", "99/99");
            await page.FillAsync("input[name=\"ion-input-5\"]", "คนใหม่");
            await page.ClickAsync("text=บันทึก");
            var seccondcount = await page.QuerySelectorAllAsync("ion-card[ng-reflect-disabled ='false']");
            var countSeccond = seccondcount.Count();
            var result = countSeccond - enablelist;
            var res = result == 1 ? true : false;
            return res;

        }

        public async Task<bool> AdminCreateRiderButRiderNotExcepted()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/biker");
            await page.WaitForTimeoutAsync(2000);
            var first = await page.QuerySelectorAllAsync("ion-card");
            var countFisrt = first.Count();
            await page.ClickAsync("span");
            await page.FillAsync("input[name=\"ion-input-0\"]", "0911234567");
            await page.FillAsync("input[name=\"ion-input-1\"]", "a1");
            await page.SetInputFilesAsync("input[name=\"file\"]", new[] { "C:\\Users\\sakul\\Desktop\\oldpic\\1.jpg" });
            await page.FillAsync("input[name=\"ion-input-3\"]", "น้อง2");
            await page.FillAsync("input[name=\"ion-input-4\"]", "99/99");
            await page.FillAsync("input[name=\"ion-input-5\"]", "คนใหม่");
            await page.ClickAsync("text=บันทึก");
            var seccond = await page.QuerySelectorAllAsync("ion-card");
            var countSeccond = seccond.Count();
            var result = countSeccond - countFisrt;
            var res = result == 1 ? true : false;
            return res;

        }

        public async Task<bool> RiderBeSuspendedFromJob()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/biker");
            await page.WaitForTimeoutAsync(2000);
            await page.ClickAsync("text=นาย อานนท์ บางสาน");
            await page.ClickAsync("text=พักงาน");
            await page.ClickAsync("[aria-label=\"back\"]");
            var res = await page.InnerTextAsync("text = นาย อานนท์ บางสาน");
            var actual = res == "นาย อานนท์ บางสาน" ? true : false;
            return actual;
        }

        public async Task<bool> RiderBeUnSuspendedFromJob()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/biker");
            await page.ClickAsync("text=นาย อานนท์ บางสาน");
            await page.ClickAsync("text=เลิกพักงาน");
            await page.ClickAsync("[aria-label=\"back\"]");
            var res = await page.InnerTextAsync("text = นาย อานนท์ บางสาน");
            var actual = res == "นาย อานนท์ บางสาน" ? true : false;
            return actual;
        }

        public async Task<bool> RiderHistoryLog()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/biker");
            await page.WaitForTimeoutAsync(2000);
            await page.ClickAsync("text=นาย อานนท์ บางสาน");
            await page.ClickAsync("text=ประวัติการรับงาน");
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

        //TODO : ยังไม่ได้ทำเรื่องเงิน (คืนเงิน)
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


        public async Task<bool> ApproveCreateRestaurant()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/restaurant");
            await page.ClickAsync("span");
            await page.FillAsync("input[name=\"ion-input-0\"]", "1111");
            await page.FillAsync("input[name=\"ion-input-1\"]", "2222");
            await page.FillAsync("input[name=\"ion-input-2\"]", "33333");
            await page.FillAsync("input[name=\"ion-input-3\"]", "44444");
            await page.ClickAsync("text=อาหารเครื่องดิ่ม >> button");
            await page.ClickAsync("button[role=\"radio\"]:has-text(\"อาหาร\")");
            await page.ClickAsync("button:has-text(\"OK\")");
            await page.ClickAsync("text=นานแรมปีลองๆ123สัญญาหน้าฝนสัญญาหน้าฝน2พรุ่งนี้รวยพรุ่งนี้รวย2พรุ่งนี้รวย3พรุ่งนี >> button");
            await page.ClickAsync("button[role=\"radio\"]:has-text(\"นานแรมปี\")");
            await page.ClickAsync("button:has-text(\"OK\")");
            await page.ClickAsync("text=ยืนยัน >> button");
            // TODO check Scenario
            return true;

        }

        public async Task<bool> RejectCreateRestaurant()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/restaurant");
            await page.ClickAsync("span");
            await page.FillAsync("input[name=\"ion-input-0\"]", "1111");
            await page.FillAsync("input[name=\"ion-input-1\"]", "2222");
            await page.FillAsync("input[name=\"ion-input-2\"]", "33333");
            await page.FillAsync("input[name=\"ion-input-3\"]", "44444");
            await page.ClickAsync("text=อาหารเครื่องดิ่ม >> button");
            await page.ClickAsync("button[role=\"radio\"]:has-text(\"อาหาร\")");
            await page.ClickAsync("button:has-text(\"OK\")");
            await page.ClickAsync("text=นานแรมปีลองๆ123สัญญาหน้าฝนสัญญาหน้าฝน2พรุ่งนี้รวยพรุ่งนี้รวย2พรุ่งนี้รวย3พรุ่งนี >> button");
            await page.ClickAsync("button[role=\"radio\"]:has-text(\"นานแรมปี\")");
            await page.ClickAsync("button:has-text(\"OK\")");
            await page.ClickAsync("text=ยืนยัน >> button");
            // TODO check Scenario
            return true;

        }

        public async Task<bool> RestaurantHistoryDetail()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/restaurant");
            await page.ClickAsync("text=ครัวระเบียง อาหารตามสั่ง");
            await page.ClickAsync("text=ประวัติการรับงาน");
            await page.ClickAsync("text=OrderID : 0037");
            // TODO check Scenario
            return true;
        }


        public async Task<bool> ApproveCreateOperator()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/operator");
            await page.ClickAsync("span");
            await page.FillAsync("input[name=\"ion-input-0\"]", "0252585458");
            await page.FillAsync("input[name=\"ion-input-1\"]", "123456700");
            await page.ClickAsync("input[name=\"file\"]");
            //TODO: เพิ่มรูปยังไม่ได้
            await page.SetInputFilesAsync("input[name=\"file\"]", new[] { "pto9.PNG" });
            await page.FillAsync("input[name=\"ion-input-3\"]", "เต");
            await page.FillAsync("input[name=\"ion-input-4\"]", "8/2");
            await page.FillAsync("input[name=\"ion-input-5\"]", "จุฟฟ");
            await page.ClickAsync("text=บันทึก");
            // TODO check Scenario
            return true;

        }

        public async Task<bool> RejectCreateOperator()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/operator");
            await page.ClickAsync("span");
            await page.FillAsync("input[name=\"ion-input-0\"]", "0252585458");
            await page.FillAsync("input[name=\"ion-input-1\"]", "123456700");
            await page.ClickAsync("input[name=\"file\"]");
            //TODO: เพิ่มรูปยังไม่ได้
            await page.SetInputFilesAsync("input[name=\"file\"]", new[] { "pto9.PNG" });
            await page.FillAsync("input[name=\"ion-input-3\"]", "เต");
            await page.FillAsync("input[name=\"ion-input-4\"]", "8/2");
            await page.FillAsync("input[name=\"ion-input-5\"]", "จุฟฟ");
            await page.ClickAsync("text=บันทึก");
            // TODO check Scenario
            return true;

        }


        //TODO: ยังไม่ได้ทำใน web Admin
        public async Task<bool> OperatorBeSuspendedFromJob()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/operator");
            await page.ClickAsync("#main-content >> text=น.ส ปทุมวดี โอภาศัย");
            // TODO check Scenario
            return true;
        }

        //TODO: ยังไม่ได้ทำใน web Admin
        public async Task<bool> OperatorBeUnSuspendedFromJob()
        {
            var browser = await BeforeScenario();
            page = await browser.NewPageAsync();
            await page.GotoAsync("https://delivery-3rd-admin.azurewebsites.net/#/operator");
            await page.ClickAsync("#main-content >> text=น.ส ปทุมวดี โอภาศัย");
            // TODO check Scenario
            return true;
        }

    }
}
