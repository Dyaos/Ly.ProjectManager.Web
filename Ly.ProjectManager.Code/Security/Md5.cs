using System.Security.Cryptography;
using System.Text;

namespace Ly.ProjectManager.Code
{
    /// <summary>
    /// MD5加密
    /// </summary>
    public class Md5
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">加密字符</param>
        /// <param name="code">加密位数16/32</param>
        /// <returns></returns>
        public static string md5(string str, int code)
        {
            string pwd = null;
            MD5 m = MD5.Create();
            string strEncrypt = string.Empty;

            byte[] s = m.ComputeHash(Encoding.Unicode.GetBytes(str));
            for (int i = 0; i < s.Length; i++)
            {
                pwd = pwd + s[i].ToString("X");
            }
            if (code == 16)
            {
                pwd = pwd.Substring(8, 16);
            }
            return pwd;
        }
    }
}
