using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace OneSteps.Utils.WinOS
{
    public class WinOSInfo
    {
        const string UNKNOW = "unknow";

        /// <summary>
        /// CPU 信息
        /// 【序列号、型号】
        /// </summary>
        /// <returns></returns>
        public static Tuple<string, string> CpuInfo()
        {
            try
            {
                Tuple<string, string> result = null;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from  Win32_Processor");
                foreach (ManagementObject item in searcher.Get())
                {
                    result = new Tuple<string, string>(
                        item["ProcessorId"].ToString().Trim(),
                        item["Name"].ToString().Trim());
                    break;
                }
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 显卡型号
        /// 【型号、RAM】
        /// </summary>
        /// <returns></returns>
        public static List<Tuple<string, ulong>> GraphicsCardInfo()
        {
            try
            {
                List<Tuple<string, ulong>> rs = new List<Tuple<string, ulong>>();
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from  Win32_VideoController");
                foreach (ManagementObject item in searcher.Get())
                {
                    string name = item["Name"].ToString().Trim();
                    string ram = item["AdapterRAM"].ToString().Trim();
                    ulong ramnumber;
                    ulong.TryParse(ram, out ramnumber);
                    rs.Add(new Tuple<string, ulong>(name, ramnumber));
                }
                return rs;
            }
            catch { return null; }
        }

        /// <summary>
        /// 硬盘信息
        /// 【序列号、型号】
        /// </summary>
        /// <returns></returns>
        public static List<Tuple<string, string>> HardDiskInfo()
        {
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();
            try
            {
                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    result.Add(new Tuple<string, string>(
                        mo.Properties["SerialNumber"].Value.ToString().Trim(),
                        mo.Properties["Model"].Value.ToString().Trim()));
                }
                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }

        /// <summary>
        /// 计算机名
        /// </summary>
        /// <returns></returns>
        public static string MachineName()
        {
            try
            {
                return Environment.MachineName;
            }
            catch
            { return UNKNOW; }
        }

        /// <summary>
        /// 主板信息
        /// 【制造商、型号、序列号】
        /// </summary>
        /// <returns></returns>
        public static Tuple<string, string, string> BoardInfo()
        {
            try
            {
                Tuple<string, string, string> result = null;
                ManagementObjectSearcher MySearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                foreach (ManagementObject MyObject in MySearcher.Get())
                {
                    result = new Tuple<string, string, string>(
                        MyObject["Manufacturer"].ToString().Trim(),
                        MyObject["Product"].ToString().Trim(),
                        MyObject["SerialNumber"].ToString().Trim());
                    break;
                }
                return result;
            }
            catch (Exception e)
            { return null; }
        }

        /// <summary>
        /// 操作系统信息
        /// 【系统名称、系统路劲、安装时间】
        /// </summary>
        /// <returns></returns>
        public static Tuple<string, string, DateTime> OsInfo()
        {
            try
            {
                Tuple<string, string, DateTime> result = null;
                ManagementObjectSearcher MySearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                foreach (ManagementObject MyObject in MySearcher.Get())
                {
                    string caption = MyObject["Caption"].ToString().Trim();
                    string windowsdirectory = MyObject["WindowsDirectory"].ToString().Trim();
                    string installdate = MyObject["InstallDate"].ToString().Trim();
                    DateTime dtinstalldate = DateTime.Parse("2001-10-25");//设置初始值为WindowsXP发布日期

                    if (installdate.Length >= 14)
                    {
                        installdate = installdate.Substring(0, 14);
                        installdate = installdate.Insert(12, ":");
                        installdate = installdate.Insert(10, ":");
                        installdate = installdate.Insert(8, " ");
                        installdate = installdate.Insert(6, "-");
                        installdate = installdate.Insert(4, "-");
                        DateTime.TryParse(installdate, out dtinstalldate);
                    }
                    if (dtinstalldate.Year < 2001) dtinstalldate = DateTime.Parse("2001-10-25");

                    result = new Tuple<string, string, DateTime>(
                        caption, windowsdirectory, dtinstalldate);
                    break;
                }
                return result;
            }
            catch (Exception e)
            { return null; }
        }

        /// <summary>
        /// 系统类型
        /// </summary>
        /// <returns></returns>
        public static string SystemType()
        {
            try
            {
                string result = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    result = mo["SystemType"].ToString();
                }
                return result;
            }
            catch
            { return UNKNOW; }
        }

    }
}
