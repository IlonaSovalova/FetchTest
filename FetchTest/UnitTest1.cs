using Microsoft.Playwright;

namespace FetchTest
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions()
            {
                ColorScheme = ColorScheme.Light,
                ViewportSize = new ViewportSize() { Width = 1920, Height = 1080 },
            };
        }

        [Test]
        public async Task FetchPage()
        {
            var page = new ScalePage(Page);
            await page.GotoAsync();
            

            // Expect a title "to contain" a substring.
            await Expect(Page).ToHaveTitleAsync(new Regex("React App"));


            await page.ResetLocator.ClickAsync();

            await page.c1LeftLocator.FillAsync("0");

            await page.c2LeftLocator.FillAsync("1");

            await page.c3LeftLocator.FillAsync("2");

            await page.c1RigthLocator.FillAsync("3");

            await page.c2RigthLocator.FillAsync("4");

            await page.c3RigthLocator.FillAsync("5");
           
            await page.WeighLocator.ClickAsync();
            await Expect(page.ResultLocator).Not.ToHaveTextAsync("?");

            
            var compare= await page.ResultLocator.InnerTextAsync();
            var found = -1;
            if (compare == "=")
            {
                await page.ResetLocator.ClickAsync();
                await page.c1LeftLocator.FillAsync("6");
                await page.c1RigthLocator.FillAsync("7");
                await page.WeighLocator.ClickAsync();
                await Expect(page.ResultLocator).Not.ToHaveTextAsync("?");
                var compare1 = await page.ResultLocator.InnerTextAsync();
                if (compare1 == ">")
                {
                    Console.WriteLine("Found: " + 7);
                    found = 7;
                }
                else if (compare1 == "<")
                {

                    Console.WriteLine("Found: " + 6);
                    found = 6;
                }
                else if (compare1 == "=")
                {
                    Console.WriteLine("Found:" + 8);
                    found = 8;
                }
            }
            else if (compare == "<")
            {
                await page.ResetLocator.ClickAsync();
                await page.c1LeftLocator.FillAsync("0");
                await page.c1RigthLocator.FillAsync("1");
                await page.WeighLocator.ClickAsync();
                await Expect(page.ResultLocator).Not.ToHaveTextAsync("?");
                var compare1 = await page.ResultLocator.InnerTextAsync();
                if (compare1 == ">")
                {
                    Console.WriteLine("Found: " + 0);
                    found = 0;
                }
                else if (compare1 == "<")
                {

                    Console.WriteLine("Found: " + 1);
                    found = 1;
                }
                else if (compare1 == "=")
                {
                    Console.WriteLine("Found:" + 2);
                    found = 2;
                }
            }
            else if (compare == ">")
            {
                // comparing 3,4,5
                await page.ResetLocator.ClickAsync();
                await page.c1LeftLocator.FillAsync("3");
                await page.c1RigthLocator.FillAsync("4");
                await page.WeighLocator.ClickAsync();
                await Expect(page.ResultLocator).Not.ToHaveTextAsync("?");
                var compare1 = await page.ResultLocator.InnerTextAsync();
                if (compare1 == ">")
                {
                    Console.WriteLine("Found: " + 4);
                    found = 4;
                }
                else if (compare1 == "<")
                {
                    Console.WriteLine("Found: " + 3);
                    found = 3;
                }
                else if (compare1 == "=")
                {
                    Console.WriteLine("Found:" + 5);
                    found = 5;
                }
            }
       
            await page.ClickOnNumber(found);
            Page.Dialog += async (sender, dialog) => {
                Console.WriteLine($"Alert: '{dialog.Message}'");
                await dialog.AcceptAsync();
                Assert.AreEqual("Yay! You find it!", dialog.Message);
            };
            var count = await page.MessageListLocator.CountAsync();
            for (int i = 0; i < count; i++)
            {
                var text = await page.MessageListLocator.Nth(i).InnerTextAsync();
                Console.WriteLine($"Compare[{i}]: {text}");
            }

            //await Page.WaitForTimeoutAsync(10000);
        }
    }
}
