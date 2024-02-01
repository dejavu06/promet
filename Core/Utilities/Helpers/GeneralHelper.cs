using System;

namespace Core.Utilities.Helpers
{
    public class GeneralHelper
    {
        public static long[] StringToLongArray(string value)
        {
            long[] result = new long[0];

            if (!string.IsNullOrEmpty(value))
            {
                string[] values = value.Split(',');

                result = new long[values.Length];

                for (int i = 0; i < values.Length; i++)
                {
                    result[i] = long.Parse(values[i]);
                }
            }

            return result;
        }

        public static long[] StringArrayToLongArray(string[] value)
        {
            long[] result = new long[0];

            if (value != null && value.Length > 0)
            {
                result = new long[value.Length];

                for (int i = 0; i < value.Length; i++)
                {
                    if (!String.IsNullOrEmpty(value[i]))
                    {
                        result[i] = long.Parse(value[i]);
                    }
                }
            }

            return result;
        }

        public static byte[] StringToByteArray(string value)
        {
            byte[] result = new byte[0];

            if (!String.IsNullOrEmpty(value))
            {
                string[] values = value.Split(',');

                result = new byte[values.Length];

                for (int i = 0; i < values.Length; i++)
                {
                    result[i] = byte.Parse(values[i]);
                }
            }

            return result;
        }

        public static string DateToStringFormat(DateTime value)
        {
            string result = value.ToShortDateString();

            string d = result.Split(".")[0];
            d = d.Length == 1 ? "0" + d : d;
            string m = result.Split(".")[1];
            m = m.Length == 1 ? "0" + m : m;
            string y = result.Split(".")[2];

            result = y + "-" + m + "-" + d;

            return result;
        }
    }
}