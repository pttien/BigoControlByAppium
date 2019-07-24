using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigoController
{
    public partial class mainFrom : Form
    {
        public mainFrom()
        {
            InitializeComponent();
        }
        List<Device> devices = new List<Device>();
        List<AndroidDriver<IWebElement>> androidDrivers = new List<AndroidDriver<IWebElement>>();
        private static AppiumLocalService _appiumLocalService;
        private void buffViewBtn_Click(object sender, EventArgs e)
        {

            var id = idInput.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("vui lòng nhập Id .........");
            }
            else
            {
                thaTimBtn.Enabled = false;
                commentBtn.Enabled = false;
                DeviceConfiguration();
                _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
                _appiumLocalService.Start();

                foreach (var device in devices)
                {
                    AndroidDriver<IWebElement> _driver;
                    DesiredCapabilities cap = new DesiredCapabilities();
                    cap.SetCapability("deviceName", device.DeviceName);
                    cap.SetCapability("UDID", device.UDID);
                    cap.SetCapability("platformVersion", device.PlatformVersion);
                    cap.SetCapability("platformName", "Android");
                    cap.SetCapability("appPackage", "sg.bigo.live");
                    cap.SetCapability("appActivity", "com.yy.iheima.MainActivity");
                    cap.SetCapability("noReset", "true");
                    cap.SetCapability(MobileCapabilityType.NewCommandTimeout, 30000);
                    _driver = new AndroidDriver<IWebElement>(_appiumLocalService, cap);
                    androidDrivers.Add(_driver);
                    var switchToSearchElementButton = _driver.FindElementById("sg.bigo.live:id/iv_search");
                    switchToSearchElementButton.Click();
                    Thread.Sleep(500);
                    var textSearchInput = _driver.FindElementById("sg.bigo.live:id/search_et");
                    textSearchInput.SendKeys(id);
                    var searchButtonElement = _driver.FindElementById("sg.bigo.live:id/tv_search");
                    searchButtonElement.Click();
                    Thread.Sleep(1000);
                    try
                    {
                        var liveButtonElement = _driver.FindElementById("sg.bigo.live:id/rl_live");
                        liveButtonElement.Click();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("người dùng này chưa online", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                thaTimBtn.Enabled = true;
                commentBtn.Enabled = true;
                thoigianthatim.Enabled = true;
            }
        }

        public string ExecuteCommandSync(string command)
        {
            try
            {

                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                string result = proc.StandardOutput.ReadToEnd();
                return result;
            }
            catch (Exception objException)
            {
                return string.Empty;
                // Log the exception
            }
        }

        public void DeviceConfiguration()
        {
            ExecuteCommandSync("adb start-server");
            var result = ExecuteCommandSync("adb devices");
            string[] lines = result.Split(new string[] { "\n" }, StringSplitOptions.None);
            if (lines.Length <= 1)
                MessageBox.Show("chưa có điện thoại nào được kết nối !");
            else
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    lines[i] = lines[i].Replace("\\s+", "");
                    if (lines[i].Contains("device"))
                    {
                        lines[i] = lines[i].Replace("device", "");
                        string deviceID = lines[i];
                        string model = ExecuteCommandSync("adb -s " + deviceID + " shell getprop ro.product.model").Replace("\\s+", "");
                        string brand = ExecuteCommandSync("adb -s " + deviceID + " shell getprop ro.product.brand").Replace("\\s+", "");
                        string osVersion = ExecuteCommandSync("adb -s " + deviceID + " shell getprop ro.build.version.release").Replace("\\s+", "");
                        string deviceName = brand + " " + model;
                        var device = new Device()
                        {
                            DeviceName = deviceName,
                            PlatformVersion = osVersion,
                            UDID = deviceID
                        };
                        devices.Add(device);
                    }
                }
            }
        }

        private void thaTimBtn_Click(object sender, EventArgs e)
        {
            thaTimBtn.Enabled = false;
            commentBtn.Enabled = false;
            if(string.IsNullOrEmpty(thoigianthatim.Text))
            {
                MessageBox.Show("vui lòng nhập thời gian thả tim !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var thoigianthatims = int.Parse(thoigianthatim.Text);
                foreach (var driver in androidDrivers)
                {
                    TouchAction actions = new TouchAction(driver);
                    for (int i = 0; i < thoigianthatims; i++)
                    {
                        actions.Tap(500, 500);
                        actions.Perform();
                        Thread.Sleep(500);
                    }
                }
            }
            thaTimBtn.Enabled = true;
            commentBtn.Enabled = true;
        }

        private void commentBtn_Click(object sender, EventArgs e)
        {
            thaTimBtn.Enabled = false;
            commentBtn.Enabled = false;
            List<string> lines = new List<string>();
            string textFile = @"comments.txt";
            if (File.Exists(textFile))
            {
                // Read a text file line by line.
                lines = File.ReadAllLines(textFile).ToList();
            }

            foreach (var driver in androidDrivers)
            {
                try
                {
                    var chatElement = driver.FindElementById("sg.bigo.live:id/menu_chat");
                    chatElement.Click();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" chat da mo san roi");
                }

                try
                {
                    var chatBoxElement = driver.FindElementById("sg.bigo.live:id/et_live_video_chat");
                    var chatSendMessage = driver.FindElementById("sg.bigo.live:id/btn_live_video_ib_send");
                    Random r = new Random();
                    chatBoxElement.SendKeys(lines[r.Next(0, lines.Count - 1)]);
                    chatSendMessage.Click();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi khi nhập comment");
                }
            }
            thaTimBtn.Enabled = true;
            commentBtn.Enabled = true;
        }

        private void thoigianthatim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void mainFrom_Load(object sender, EventArgs e)
        {
            thaTimBtn.Enabled = false;
            commentBtn.Enabled = false;
            thoigianthatim.Enabled = false;
        }
    }

}
