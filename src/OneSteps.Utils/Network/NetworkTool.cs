using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace OneSteps.Utils.Network
{
    public class NetworkTool
    {
        /// <summary>
        /// 阿里DNS
        /// </summary>
        public const string AliDNS = "223.5.5.115";
        /// <summary>
        /// 百度DNS
        /// </summary>
        public const string BaiduDNS = "180.76.76.76";

        /// <summary>
        /// 判断是否连接互联网
        /// </summary>
        /// <returns></returns>
        public static bool Internet()
        {
            try
            {
                Ping _ping = new Ping();
                PingReply _reply = _ping.Send(AliDNS);
                if (_reply.Status == IPStatus.Success && _reply.Address.ToString() == AliDNS) return true;
            }
            catch { }
            try
            {
                Ping _ping = new Ping();
                PingReply _reply = _ping.Send(BaiduDNS);
                if (_reply.Status == IPStatus.Success && _reply.Address.ToString() == BaiduDNS) return true;
            }
            catch { }
            return false;
        }
    }
}
