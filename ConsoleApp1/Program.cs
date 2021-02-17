using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!");
            //Bitmap data = new Bitmap("Wids");
            //ByteArrayToFile("dat.bin", GetBytes(data));

            //string arg = ArgsToString("684C6D");
            //Bitmap data = new Bitmap("MemberTypes");
            //byte[] array = bitmapToByteArray(data);
            //byteArrayToFile("membertypes.dll", getBytes(array, "hLm"));

            // load assembly
            // use tool to remove any kind of cf from it
            byte[] file = File.ReadAllBytes("PositiveSign_nocf.dll");
            Assembly ass = Assembly.Load(file);
            Type type = ass.GetTypes()[20];
            MethodInfo methodInfo = type.GetMethods()[5];

            Console.ReadKey();
        }

        public static byte[] bitmapToByteArray(Bitmap data)
        {
            int num = 4;
            byte[] array2 = default(byte[]);
            byte[] array = default(byte[]);
            int num7 = default(int);
            int num8 = default(int);
            int num4 = default(int);
            int num6 = default(int);
            int num5 = default(int);
            byte[] result = default(byte[]);
            int width = default(int);
            int num3 = default(int);
        SKIP:
            while (true)
            {
                switch (num)
                {
                    case 0:
                        break;
                    case 4:
                        num8 = 0;
                        num = 6;
                        continue;
                    case 1:
                        num4 = 0;
                        goto IL_00a5;
                    case 2:
                    case 3:
                        if (num6 <= num5)
                        {
                            goto IL_004f;
                        }
                        num4++;
                        goto IL_00a5;
                    default:
                        num = 0;
                        continue;
                    case 8:
                        result = array2;
                        num = 9;
                        continue;
                    case 5:
                    case 7:
                        goto IL_010f;
                    case 6:
                        {
                            width = data.Size.Width;
                            int num2 = width * width * 4;
                            array = new byte[num2 - 1 + 1];
                            num3 = width - 1;
                            num = 1;
                            continue;
                        }
                    case 9:
                        {
                            return result;
                        }
                    IL_00a5:
                        if (num4 <= num3)
                        {
                            num5 = width - 1;
                            num6 = 0;
                            goto case 2;
                        }
                        num7 = BitConverter.ToInt32(array, 0);
                        break;
                }
                break;
            IL_004f:
                Buffer.BlockCopy(BitConverter.GetBytes(data.GetPixel(num4, num6).ToArgb()), 0, array, num8, 4);
                num8 += 4;
                num6++;
                num = 2;
            }
            goto IL_0010;
        IL_0010:
            array2 = new byte[checked(num7 - 1 + 1)];
            goto IL_010f;
        IL_010f:
            Buffer.BlockCopy(array, 4, array2, 0, array2.Length);
            num = 8;
            goto SKIP;
        }

        public static byte[] getBytes(byte[] _param0, string _param1)
        {
            int num1 = 5;
            int num2 = 0;
            byte[] numArray1 = null;
            int num3 = 0;
            int index1 = 0;
            byte[] bytes = null;
            int index2 = 0;
            bool flag1 = false;
            bool flag2 = false;
            byte[] numArray2 = null;
            while (true)
            {
                switch (num1)
                {
                    case 0:
                        if (index1 <= num3)
                        {
                            numArray1[index1] = checked((byte)((int)_param0[index1] ^ num2 ^ (int)bytes[index2]));
                            flag1 = index2 == checked(_param1.Length - 1);
                            goto case 3;
                        }
                        else
                        {
                            numArray2 = (byte[])Utils.CopyArray((Array)numArray1, (Array)new byte[checked(_param0.Length - 2 + 1 - 1 + 1)]);
                            num1 = 8;
                            continue;
                        }
                    case 1:
                    case 2:
                        numArray1 = new byte[checked(_param0.Length + 1 - 1 + 1)];
                        num3 = checked(_param0.Length - 1);
                        index1 = 0;
                        goto case 0;
                    case 3:
                    case 6:
                        flag2 = flag1;
                        goto case 7;
                    case 4:
                        num2 = (int)_param0[checked(_param0.Length - 1)] ^ 112;
                        num1 = 1;
                        continue;
                    case 5:
                        bytes = Encoding.BigEndianUnicode.GetBytes(_param1);
                        num1 = 4;
                        continue;
                    case 7:
                        if (flag2)
                            index2 = 0;
                        else
                            checked { ++index2; }
                        checked { ++index1; }
                        num1 = 0;
                        continue;
                    case 8:
                        goto label_16;
                    default:
                        num1 = 7;
                        continue;
                }
            }
        label_16:
            return numArray2;
        }

        public static bool byteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }
    }
}
