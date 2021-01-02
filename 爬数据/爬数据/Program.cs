using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.HSSF.UserModel;
using NPOI.Util.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 爬数据
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<UI> add = new List<UI>();
            List<TIME> KX = new List<TIME>();
            int k = 0;
            Console.Write("数据正在初始化中请稍等..................");
            for (int i = 0; i < Properties.Settings.Default.SUM; i += 10)
            {
                Console.SetCursorPosition(0, 1);//设置光标位置,参数为第几列和第几
                Console.Write("当前进度为" + (i / 9000.0).ToString("F5") + "%");
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string retString = "";
                if (Properties.Settings.Default.URL == "Lung")
                {
                    retString = httpGet("https://clinicaltrials.gov/ct2/results/rpc/Ci0yqihHSdCLRi7xUnhgkdNgzwJ?start=" + i + "&length=10");//总共9005
                }
                else if (Properties.Settings.Default.URL == "Breast")
                {
                    retString = httpGet("https://clinicaltrials.gov/ct2/results/rpc/7i0yqihHSdCLoB1gWwNz0nhgkdNgzwJ?start=" + i + "&length=10");
                }
                else if (Properties.Settings.Default.URL == "Gastric")
                {
                    retString = httpGet("https://clinicaltrials.gov/ct2/results/rpc/Hi0yqihHSdCLYwNHkw-VJBcGuBcHS?start=" + i + "&length=10");//总共13000
                }
                else
                {
                    return;
                }
                if (retString == "") { continue; }
                try
                {
                    var QDATA = (JObject)JsonConvert.DeserializeObject(retString);
                    var DATA = QDATA["data"].Children().ToList();
                    DATA.ForEach(t =>
                    {
                        UI UL = new UI();
                        UL.TIME = t.Children().ToList()[22].ToString();
                        UL.NAME = Properties.Settings.Default.URL + " Cancer";//Breast cancer或者Gastric Cancer
                        add.Add(UL);
                        Console.WriteLine("正在写入第 " + k++ + "条数据");
                    });
                }
                catch
                {
                    continue;
                }

            }
            Console.Write("初始化完成!");
            for (int i = 0; i < add.Count; i++)
            {
                if (add[i].TIME.Contains("January"))
                {
                    add[i].TIME = add[i].TIME.Replace("January", "1").Split(',')[1] + "-" + add[i].TIME.Replace("January", "1").Split(',')[0].ToString().Split(' ')[0] + "-" + add[i].TIME.Replace("January", "1").Split(',')[0].ToString().Split(' ')[1];
                }
                if (add[i].TIME.Contains("February"))
                {
                    add[i].TIME = add[i].TIME.Replace("February", "2").Split(',')[1] + "-" + add[i].TIME.Replace("February", "2").Split(',')[0].ToString().Split(' ')[0] + "-" + add[i].TIME.Replace("February", "2").Split(',')[0].ToString().Split(' ')[1];
                }
                if (add[i].TIME.Contains("March"))
                {
                    add[i].TIME = add[i].TIME.Replace("March", "3").Split(',')[1] + "-" + add[i].TIME.Replace("March", "3").Split(',')[0].ToString().Split(' ')[0] + "-" + add[i].TIME.Replace("March", "3").Split(',')[0].ToString().Split(' ')[1];
                }
                if (add[i].TIME.Contains("April"))
                {
                    add[i].TIME = add[i].TIME.Replace("April", "4").Split(',')[1] + "-" + add[i].TIME.Replace("April", "4").Split(',')[0].ToString().Split(' ')[0] + "-" + add[i].TIME.Replace("April", "4").Split(',')[0].ToString().Split(' ')[1];
                }
                if (add[i].TIME.Contains("May"))
                {
                    add[i].TIME = add[i].TIME.Replace("May", "5").Split(',')[1] + "-" + add[i].TIME.Replace("May", "5").Split(',')[0].ToString().Split(' ')[0] + "-" + add[i].TIME.Replace("May", "5").Split(',')[0].ToString().Split(' ')[1];
                }
                if (add[i].TIME.Contains("June"))
                {
                    add[i].TIME = add[i].TIME.Replace("June", "6").Split(',')[1] + "-" + add[i].TIME.Replace("June", "6").Split(',')[0].ToString().Split(' ')[0] + "-" + add[i].TIME.Replace("June", "6").Split(',')[0].ToString().Split(' ')[1];
                }
                if (add[i].TIME.Contains("July"))
                {
                    add[i].TIME = add[i].TIME.Replace("July", "7").Split(',')[1] + "-" + add[i].TIME.Replace("July", "7").Split(',')[0].ToString().Split(' ')[0] + "-" + add[i].TIME.Replace("July", "7").Split(',')[0].ToString().Split(' ')[1];
                }
                if (add[i].TIME.Contains("August"))
                {
                    add[i].TIME = add[i].TIME.Replace("August", "8").Split(',')[1] + "-" + add[i].TIME.Replace("August", "8").Split(',')[0].ToString().Split(' ')[0] + "-" + add[i].TIME.Replace("August", "8").Split(',')[0].ToString().Split(' ')[1];
                }
                if (add[i].TIME.Contains("September"))
                {
                    add[i].TIME = add[i].TIME.Replace("September", "9").Split(',')[1] + "-" + add[i].TIME.Replace("September", "9").Split(',')[0].ToString().Split(' ')[0] + "-" + add[i].TIME.Replace("September", "9").Split(',')[0].ToString().Split(' ')[1];
                }
                if (add[i].TIME.Contains("October"))
                {
                    add[i].TIME = add[i].TIME.Replace("October", "10").Split(',')[1] + "-" + add[i].TIME.Replace("October", "10").Split(',')[0].ToString().Split(' ')[0] + "-" + add[i].TIME.Replace("October", "10").Split(',')[0].ToString().Split(' ')[1];
                }
                if (add[i].TIME.Contains("November"))
                {
                    add[i].TIME = add[i].TIME.Replace("November", "11").Split(',')[1] + "-" + add[i].TIME.Replace("November", "11").Split(',')[0].ToString().Split(' ')[0] + "-" + add[i].TIME.Replace("November", "11").Split(',')[0].ToString().Split(' ')[1];
                }
                if (add[i].TIME.Contains("December"))
                {
                    add[i].TIME = add[i].TIME.Replace("December", "12").Split(',')[1] + "-" + add[i].TIME.Replace("December", "12").Split(',')[0].ToString().Split(' ')[0] + "-" + add[i].TIME.Replace("December", "12").Split(',')[0].ToString().Split(' ')[1];
                }
            }
            string path = AppDomain.CurrentDomain.BaseDirectory + Properties.Settings.Default.Excel;
            using (FileStream fs = File.OpenRead(path))
            {
                HSSFWorkbook workbook = new HSSFWorkbook(fs);
                var TotalIndex = 0;
                var TotalBaseIndex = 2;
                var CurrentIndex = TotalBaseIndex - 1;
                var Sheet = workbook.GetSheetAt(0);
                add.ToList().ForEach(t =>
                {
                    TIME TI = new TIME();
                    TI.YEAR = DateTime.Parse(t.TIME.Replace(" ", "")).Year;
                    TI.MONTH = DateTime.Parse(t.TIME.Replace(" ", "")).Month;
                    TI.JD = (TI.MONTH == 1 || TI.MONTH == 2 || TI.MONTH == 3) ? 1 : ((TI.MONTH == 4 || TI.MONTH == 5 || TI.MONTH == 6) ? 2 : ((TI.MONTH == 7 || TI.MONTH == 8 || TI.MONTH == 9) ? 3 : 4));
                    KX.Add(TI);
                    CurrentIndex = TotalBaseIndex + TotalIndex++;
                    Sheet.GetRow(CurrentIndex).CopyRowTo(CurrentIndex + 1);
                    Sheet.GetRow(CurrentIndex + 1).Height = Sheet.GetRow(CurrentIndex).Height;
                    Sheet.GetRow(CurrentIndex).Cells[0].SetCellValue(TotalIndex);
                    Sheet.GetRow(CurrentIndex).Cells[1].SetCellValue(t.NAME);
                    Sheet.GetRow(CurrentIndex).Cells[2].SetCellValue(t.TIME);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("正在处理第" + TotalIndex + "条数据，总计" + add.Count + ".");
                });
                Sheet.RemoveRow(Sheet.GetRow(++CurrentIndex));
                var Path = /*AppDomain.CurrentDomain.BaseDirectory*/ @"F:\BASE\" + DateTime.Now.ToLongDateString() + Properties.Settings.Default.URL + "数据表.xls";
                using (var FS = File.Create(Path))
                {
                    workbook.Write(FS);
                    workbook.Close();
                }
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("生成文件：" + Path);
            }
            string path1 = AppDomain.CurrentDomain.BaseDirectory + Properties.Settings.Default.Excel1;
            using (FileStream fs = File.OpenRead(path1))
            {
                HSSFWorkbook workbook = new HSSFWorkbook(fs);
                var TotalIndex = 0;
                var TotalBaseIndex = 2;
                var CurrentIndex = TotalBaseIndex - 1;
                var Sheet = workbook.GetSheetAt(0);
                KX.GroupBy(X => X.YEAR).Select(T => new
                {
                    YEAR = T.Key,
                    JD = T.Key,
                    COUNT = T.Count()
                }).OrderByDescending(x => x.YEAR).ToList().ForEach(t =>
                      {
                          CurrentIndex = TotalBaseIndex + TotalIndex++;
                          Sheet.GetRow(CurrentIndex).CopyRowTo(CurrentIndex + 1);
                          Sheet.GetRow(CurrentIndex + 1).Height = Sheet.GetRow(CurrentIndex).Height;
                          Sheet.GetRow(CurrentIndex).Cells[0].SetCellValue(TotalIndex);
                          Sheet.GetRow(CurrentIndex).Cells[1].SetCellValue(Properties.Settings.Default.URL + " Cancer");
                          Sheet.GetRow(CurrentIndex).Cells[2].SetCellValue(t.YEAR);
                          Sheet.GetRow(CurrentIndex).Cells[3].SetCellValue("");
                          Sheet.GetRow(CurrentIndex).Cells[4].SetCellValue("");
                          Sheet.GetRow(CurrentIndex).Cells[5].SetCellValue(t.COUNT);
                      });
                Sheet.RemoveRow(Sheet.GetRow(++CurrentIndex));
                var Path = /*AppDomain.CurrentDomain.BaseDirectory*/ @"F:\BASE\" + DateTime.Now.ToLongDateString() + Properties.Settings.Default.URL + "年统计.xls";
                using (var FS = File.Create(Path))
                {
                    workbook.Write(FS);
                    workbook.Close();
                }
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("生成统计文件：" + Path);
            }
            using (FileStream fs = File.OpenRead(path1))
            {
                HSSFWorkbook workbook = new HSSFWorkbook(fs);
                var TotalIndex = 0;
                var TotalBaseIndex = 2;
                var CurrentIndex = TotalBaseIndex - 1;
                var Sheet = workbook.GetSheetAt(0);
                KX.GroupBy(X => X.JD).Select(T1 => new
                {
                    JD = T1.Key,
                    COUNT = T1.Count(),
                }).OrderByDescending(x => x.JD).ToList().ForEach(t =>
                {
                    CurrentIndex = TotalBaseIndex + TotalIndex++;
                    Sheet.GetRow(CurrentIndex).CopyRowTo(CurrentIndex + 1);
                    Sheet.GetRow(CurrentIndex + 1).Height = Sheet.GetRow(CurrentIndex).Height;
                    Sheet.GetRow(CurrentIndex).Cells[0].SetCellValue(TotalIndex);
                    Sheet.GetRow(CurrentIndex).Cells[1].SetCellValue(Properties.Settings.Default.URL + " Cancer");
                    Sheet.GetRow(CurrentIndex).Cells[2].SetCellValue("");
                    Sheet.GetRow(CurrentIndex).Cells[3].SetCellValue(t.JD);
                    Sheet.GetRow(CurrentIndex).Cells[4].SetCellValue("");
                    Sheet.GetRow(CurrentIndex).Cells[5].SetCellValue(t.COUNT);
                });
                Sheet.RemoveRow(Sheet.GetRow(++CurrentIndex));
                var Path = /*AppDomain.CurrentDomain.BaseDirectory*/ @"F:\BASE\" + DateTime.Now.ToLongDateString() + Properties.Settings.Default.URL + "季度统计.xls";
                using (var FS = File.Create(Path))
                {
                    workbook.Write(FS);
                    workbook.Close();
                }
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("生成统计文件：" + Path);
            }
            using (FileStream fs = File.OpenRead(path1))
            {
                HSSFWorkbook workbook = new HSSFWorkbook(fs);
                var TotalIndex = 0;
                var TotalBaseIndex = 2;
                var CurrentIndex = TotalBaseIndex - 1;
                var Sheet = workbook.GetSheetAt(0);
                KX.GroupBy(X => X.MONTH).Select(T2 => new
                {
                    MONTH = T2.Key,
                    COUNT = T2.Count(),
                }).OrderByDescending(x => x.MONTH).ToList().ForEach(t =>
                {
                    CurrentIndex = TotalBaseIndex + TotalIndex++;
                    Sheet.GetRow(CurrentIndex).CopyRowTo(CurrentIndex + 1);
                    Sheet.GetRow(CurrentIndex + 1).Height = Sheet.GetRow(CurrentIndex).Height;
                    Sheet.GetRow(CurrentIndex).Cells[0].SetCellValue(TotalIndex);
                    Sheet.GetRow(CurrentIndex).Cells[1].SetCellValue(Properties.Settings.Default.URL + " Cancer");
                    Sheet.GetRow(CurrentIndex).Cells[2].SetCellValue("");
                    Sheet.GetRow(CurrentIndex).Cells[3].SetCellValue("");
                    Sheet.GetRow(CurrentIndex).Cells[4].SetCellValue(t.MONTH);
                    Sheet.GetRow(CurrentIndex).Cells[5].SetCellValue(t.COUNT);
                });
                Sheet.RemoveRow(Sheet.GetRow(++CurrentIndex));
                var Path = /*AppDomain.CurrentDomain.BaseDirectory*/ @"F:\BASE\" + DateTime.Now.ToLongDateString() + Properties.Settings.Default.URL + "月统计.xls";
                using (var FS = File.Create(Path))
                {
                    workbook.Write(FS);
                    workbook.Close();
                }
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("生成统计文件：" + Path);
            }
            Console.ReadKey();
        }
        public static string httpGet(string URL)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
            req.Proxy = null;
            WebResponse resp = req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.Default);
            try
            {
                string sReturn = sr.ReadToEnd();
                resp.Close(); sr.Close();
                return sReturn;
            }
            catch
            {
                return "";
            }
        }

    }
    public class UI
    {
        public string NAME { get; set; }
        public string TIME { get; set; }
    }
    public class TIME
    {
        public int YEAR { get; set; }
        public int JD { get; set; }
        public int MONTH { get; set; }
        public int COUNT { get; set; }
    }
}
