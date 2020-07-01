using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace StockRankDataPull
{
    class Program
    {

        static HttpClient client = new HttpClient();

        

        static async Task Main(string[] args)
        {

            string[] tickers = new string[] { "MMM", "ABT", "ABBV", "ABMD", "ACN", "ATVI", "ADBE", "AMD", "AAP", "AES", "AFL", "A", "APD", "AKAM", "ALK", "ALB", "ARE", "ALXN", "ALGN", "ALLE", "ADS", "LNT", "ALL", "GOOGL", "GOOG", "MO", "AMZN", "AMCR", "AEE", "AAL", "AEP", "AXP", "AIG", "AMT", "AWK", "AMP", "ABC", "AME", "AMGN", "APH", "ADI", "ANSS", "ANTM", "AON", "AOS", "APA", "AIV", "AAPL", "AMAT", "APTV", "ADM", "ANET", "AJG", "AIZ", "T", "ATO", "ADSK", "ADP", "AZO", "AVB", "AVY", "BKR", "BLL", "BAC", "BK", "BAX", "BDX", "BRK.B", "BBY", "BIIB", "BLK", "BA", "BKNG", "BWA", "BXP", "BSX", "BMY", "AVGO", "BR", "BF.B", "CHRW", "COG", "CDNS", "CPB", "COF", "CAH", "KMX", "CCL", "CARR", "CAT", "CBOE", "CBRE", "CDW", "CE", "CNC", "CNP", "CTL", "CERN", "CF", "SCHW", "CHTR", "CVX", "CMG", "CB", "CHD", "CI", "CINF", "CTAS", "CSCO", "C", "CFG", "CTXS", "CLX", "CME", "CMS", "KO", "CTSH", "CL", "CMCSA", "CMA", "CAG", "CXO", "COP", "ED", "STZ", "COO", "CPRT", "GLW", "CTVA", "COST", "COTY", "CCI", "CSX", "CMI", "CVS", "DHI", "DHR", "DRI", "DVA", "DE", "DAL", "XRAY", "DVN", "DXCM", "FANG", "DLR", "DFS", "DISCA", "DISCK", "DISH", "DG", "DLTR", "D", "DPZ", "DOV", "DOW", "DTE", "DUK", "DRE", "DD", "DXC", "ETFC", "EMN", "ETN", "EBAY", "ECL", "EIX", "EW", "EA", "EMR", "ETR", "EOG", "EFX", "EQIX", "EQR", "ESS", "EL", "EVRG", "ES", "RE", "EXC", "EXPE", "EXPD", "EXR", "XOM", "FFIV", "FB", "FAST", "FRT", "FDX", "FIS", "FITB", "FE", "FRC", "FISV", "FLT", "FLIR", "FLS", "FMC", "F", "FTNT", "FTV", "FBHS", "FOXA", "FOX", "BEN", "FCX", "GPS", "GRMN", "IT", "GD", "GE", "GIS", "GM", "GPC", "GILD", "GL", "GPN", "GS", "GWW", "HRB", "HAL", "HBI", "HOG", "HIG", "HAS", "HCA", "PEAK", "HSIC", "HSY", "HES", "HPE", "HLT", "HFC", "HOLX", "HD", "HON", "HRL", "HST", "HWM", "HPQ", "HUM", "HBAN", "HII", "IEX", "IDXX", "INFO", "ITW", "ILMN", "INCY", "IR", "INTC", "ICE", "IBM", "IP", "IPG", "IFF", "INTU", "ISRG", "IVZ", "IPGP", "IQV", "IRM", "JKHY", "J", "JBHT", "SJM", "JNJ", "JCI", "JPM", "JNPR", "KSU", "K", "KEY", "KEYS", "KMB", "KIM", "KMI", "KLAC", "KSS", "KHC", "KR", "LB", "LHX", "LH", "LRCX", "LW", "LVS", "LEG", "LDOS", "LEN", "LLY", "LNC", "LIN", "LYV", "LKQ", "LMT", "L", "LOW", "LYB", "MTB", "MRO", "MPC", "MKTX", "MAR", "MMC", "MLM", "MAS", "MA", "MKC", "MXIM", "MCD", "MCK", "MDT", "MRK", "MET", "MTD", "MGM", "MCHP", "MU", "MSFT", "MAA", "MHK", "TAP", "MDLZ", "MNST", "MCO", "MS", "MOS", "MSI", "MSCI", "MYL", "NDAQ", "NOV", "NTAP", "NFLX", "NWL", "NEM", "NWSA", "NWS", "NEE", "NLSN", "NKE", "NI", "NBL", "JWN", "NSC", "NTRS", "NOC", "NLOK", "NCLH", "NRG", "NUE", "NVDA", "NVR", "ORLY", "OXY", "ODFL", "OMC", "OKE", "ORCL", "OTIS", "PCAR", "PKG", "PH", "PAYX", "PAYC", "PYPL", "PNR", "PBCT", "PEP", "PKI", "PRGO", "PFE", "PM", "PSX", "PNW", "PXD", "PNC", "PPG", "PPL", "PFG", "PG", "PGR", "PLD", "PRU", "PEG", "PSA", "PHM", "PVH", "QRVO", "PWR", "QCOM", "DGX", "RL", "RJF", "RTX", "O", "REG", "REGN", "RF", "RSG", "RMD", "RHI", "ROK", "ROL", "ROP", "ROST", "RCL", "SPGI", "CRM", "SBAC", "SLB", "STX", "SEE", "SRE", "NOW", "SHW", "SPG", "SWKS", "SLG", "SNA", "SO", "LUV", "SWK", "SBUX", "STT", "STE", "SYK", "SIVB", "SYF", "SNPS", "SYY", "TMUS", "TROW", "TTWO", "TPR", "TGT", "TEL", "FTI", "TFX", "TXN", "TXT", "TMO", "TIF", "TJX", "TSCO", "TT", "TDG", "TRV", "TFC", "TWTR", "TSN", "UDR", "ULTA", "USB", "UAA", "UA", "UNP", "UAL", "UNH", "UPS", "URI", "UHS", "UNM", "VFC", "VLO", "VAR", "VTR", "VRSN", "VRSK", "VZ", "VRTX", "VIAC", "V", "VNO", "VMC", "WRB", "WAB", "WMT", "WBA", "DIS", "WM", "WAT", "WEC", "WFC", "WELL", "WST", "WDC", "WU", "WRK", "WY", "WHR", "WMB", "WLTW", "WYNN", "XEL", "XRX", "XLNX", "XYL", "YUM", "ZBRA", "ZBH", "ZION", "ZTS" };

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");
            IWebDriver driver = new ChromeDriver(chromeOptions);


            //string[] tickers = new string[] { "A", "AAPL" };

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
         

            foreach (string tick in tickers)
            {
                Dictionary<string, string> data = grabBalanceSheetData(tick, driver);

                await callBackend(data);
                try
                {
                    Console.WriteLine(data["ticker"] + " completed");
                }
                catch
                {
                    Console.WriteLine("Dataless");
                }

            }

            driver.Close();

            sendEmail();

        }

        static Dictionary<string, string> grabBalanceSheetData(string ticker, IWebDriver driver)
        {

            Dictionary<string, string> data = new Dictionary<string, string>();

            try
            {
                string assetsUrl = "https://www.macrotrends.net/stocks/charts/" + ticker + "/apple/total-assets";
                string liabilitiesUrl = "https://www.macrotrends.net/stocks/charts/" + ticker + "/apple/total-liabilities";
                string epsUrl = "https://www.macrotrends.net/stocks/charts/" + ticker + "/apple/eps-earnings-per-share-diluted";
                string sharesUrl = "https://www.macrotrends.net/stocks/charts/" + ticker + "/apple/shares-outstanding";


                driver.Navigate().GoToUrl(assetsUrl);

                string totalAssets;
                string totalLiabilities;
                string latestEPS;
                string sharesOutstanding;


                totalAssets = driver.FindElement(By.CssSelector("#main_content > div:nth-child(2) > span > ul > li:nth-child(1) > strong:nth-child(1)")).Text;

                driver.Navigate().GoToUrl(liabilitiesUrl);

                totalLiabilities = driver.FindElement(By.CssSelector("#main_content > div:nth-child(2) > span > ul > li:nth-child(1) > strong:nth-child(1)")).Text;

                driver.Navigate().GoToUrl(epsUrl);

                latestEPS = driver.FindElement(By.CssSelector("#main_content > div:nth-child(2) > span > ul > li:nth-child(1) > strong:nth-child(1)")).Text;

                driver.Navigate().GoToUrl(sharesUrl);

                sharesOutstanding = driver.FindElement(By.CssSelector("#main_content > div:nth-child(2) > span > ul > li:nth-child(1) > strong:nth-child(1)")).Text;

                data.Add("ticker", ticker);
                data.Add("totalAssets", totalAssets);
                data.Add("totalLiabilities", totalLiabilities);
                data.Add("eps", latestEPS);
                data.Add("sharesOutstanding", sharesOutstanding);
            }
            catch
            {
                Console.WriteLine("Failure - " + ticker);
                return new Dictionary<string, string>();
            }


            return data;
        }

        public static async Task callBackend(Dictionary<string, string> values)
        {

            var content = new FormUrlEncodedContent(values);

            var url = "https://us-central1-stockrank.cloudfunctions.net/appendData";

            var response = await client.PostAsync(url, content);

            string result = await response.Content.ReadAsStringAsync();

            Console.WriteLine(result);
            
        }

        public static void sendEmail()
        {

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Yourself", "firstwsop@gmail.com"));
            message.To.Add(new MailboxAddress("Salvator Guarnera", "salvatorguarnera@gmail.com"));

            message.Body = new TextPart("plain")
            {
                Text = "Finished updating asset data"
            };

            using (var mailingClient = new SmtpClient())
            {
                mailingClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                mailingClient.Connect("smtp.gmail.com", 587, false);

                mailingClient.Authenticate("firstwsop@gmail.com", "poker123");

                mailingClient.Send(message);

                mailingClient.Disconnect(true);

            }


        }


    }
}
