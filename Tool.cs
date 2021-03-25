using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Hex2Bin
{
    class Tool
    {
        /// <summary>
        /// 从注册表中获取一个参数
        /// </summary>
        /// <param name="Name">参数名称</param>
        /// <returns></returns>
        public static string GetRegist(string Name)
        {
            String RegiPath = "HKEY_CURRENT_USER\\Software\\PPH_SOFT_" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace;//注册表位置
            String val = (string)Registry.GetValue(RegiPath, Name, null);
            return val;
        }
        /// <summary>
        /// 设置注册表参数
        /// </summary>
        /// <param name="Name">参数名称</param>
        /// <param name="Val">参数值</param>
        public static void SetRegist(string Name, string Val)
        {
            String RegiPath = "HKEY_CURRENT_USER\\Software\\PPH_SOFT_" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace;//注册表位置
            Registry.SetValue(RegiPath, Name, Val, RegistryValueKind.String);
        }
        /// <summary>
        /// 转换成Hex字符号
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToHexString(byte[] bytes)
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2") + " ");
                }
                hexString = strB.ToString();
            }
            return hexString;
        }

        /// <summary>
        /// 将String包内容传进去,然后返回Byte[]
        /// </summary>
        /// <param name="str">需要发包的明文字符串</param>
        /// <returns></returns>
        public static byte[] StringToByteArray(string str)
        {
            List<byte> bytelist = new List<byte>();
            str = str.Replace(" ", "");//去空格
            int length = str.Length / 2;//包长度
            try
            {
                for (int i = 0; i < length; i++)
                {
                    bytelist.Add(Convert.ToByte(str.Substring(2 * i, 2), 16));
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return (null);
            }
            return bytelist.ToArray();
        }
    }
}
