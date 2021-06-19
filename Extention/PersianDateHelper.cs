using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestShaparak.SingletonWrapper;

namespace TestShaparak.Extention
{
    class PersianDateHelper : SingletonWrapper<PersianDateHelper>
    {
        public  string ConvertToPersianDate(DateTime date, bool showTime = false)
        {
            string result = string.Empty;
            if (date != default(DateTime))
            {
                PersianCalendar persianCalendar = new PersianCalendar();
                var day = persianCalendar.GetDayOfMonth(date).ToString().PadLeft(2, '0');
                var month = persianCalendar.GetMonth(date).ToString().PadLeft(2, '0');
                var year = persianCalendar.GetYear(date);
                var hour = persianCalendar.GetHour(date);
                var min = persianCalendar.GetMinute(date);
                var time = showTime ? $"-{hour}:{ min}" : "";
                result = $"{year}/{month}/{day} {time}";
            }
            return result;
        }

        public  DateTime ConvertToMiladiDate(string persianDate)
        {

            PersianCalendar persianCalender = new PersianCalendar();
            var seprateDate = persianDate.Split('-')[0];
            var splitDate = seprateDate.Split('/');
            int year = 0;
            int month = 0;
            int day = 0;

            if (splitDate.Length == 1)
            {
                year = Convert.ToInt32(persianDate.Substring(0, 4));
                month = Convert.ToInt32(persianDate.Substring(4, 2));
                day = Convert.ToInt32(persianDate.Substring(6, 2));
            }
            else
            {
                year = Convert.ToInt32(splitDate[0]);
                month = Convert.ToInt32(splitDate[1]);
                day = Convert.ToInt32(splitDate[2]);
            }

            DateTime dt = new DateTime(year, month, day, persianCalender);
            //Kaveh.Engine.Logger.Logger.Instance.Info($@"year {year} month {month} day : {day}");
            //Kaveh.Engine.Logger.Logger.Instance.Info(dt.ToString());
            return dt;

        }
    }
}
