using System;
using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;


namespace FetchTest
{

    internal class ScalePage {
        private readonly IPage _page;

        public IPage Page => _page;

        public ScalePage(IPage page){
              _page= page;        
        }

        public ILocator ResetLocator => _page.GetByText("Reset");
        public ILocator WeighLocator => _page.GetByText("Weigh", new PageGetByTextOptions() { Exact = true });
        public ILocator ResultLocator => _page.Locator(".result").Locator("button");
        public ILocator MessageListLocator => _page.Locator("xpath=//ol/li");

        public async Task GotoAsync()
        {
            await _page.GotoAsync("http://sdetchallenge.fetch.com/");
        }


        public ILocator c1LeftLocator => _page.Locator("#left_0");
        public ILocator c2LeftLocator => _page.Locator("#left_1");
        public ILocator c3LeftLocator => _page.Locator("#left_2");
        public ILocator c1RigthLocator => _page.Locator("#right_0");
        public ILocator c2RigthLocator => _page.Locator("#right_1");
        public ILocator c3RigthLocator => _page.Locator("#right_2");

       public async Task ClickOnNumber(int number)
        {
           await  _page.Locator("#coin_" + number).ClickAsync();
        } 
     
    }

}