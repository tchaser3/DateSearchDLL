/* Title:           Date Search Class
 * Date:            3-13-16
 * Author:          Terry Holmes
 *
 * Description:     This class is the does date search */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateSearchDLL
{
    public class DateSearchClass
    {
        public DateTime RemoveTime(DateTime datDStartDate)
        {
            //Creating local variable
            DateTime datEndingDate;

            //Removing the time
            datEndingDate = datDStartDate.Date;

            return datEndingDate;
        }
        public DateTime AddingDays(DateTime datStartingDate, double douNumberOfDays)
        {
            //local variables
            DateTime datEndingDate;

            //doing the math
            datEndingDate = datStartingDate.AddDays(douNumberOfDays);

            return datEndingDate;
        }
        public int SubtractingHours(DateTime datStartingDate, DateTime datEndingDate)
        {
            int intHours = 0;

            intHours = Convert.ToInt32((datEndingDate - datStartingDate).TotalHours);

            return intHours;
        }
        public DateTime SubtractingDays(DateTime datStartingDate, double douNumberOfDays)
        {
            //local variables
            DateTime datEndingDate;

            douNumberOfDays = (douNumberOfDays * -1);

            //doing the math
            datEndingDate = datStartingDate.AddDays(douNumberOfDays);

            return datEndingDate;
        }
        public int DateDifference(DateTime datStartingDate, DateTime datEndingDate)
        {

            //Setting local variables
            int intStartingDay;
            int intStartingMonth;
            int intStartingYear;
            int intEndingDay;
            int intEndingMonth;
            int intEndingYear;
            int intTotalDays = 0;
            int intTotalMonth = 0;
            int intTotalYear = 0;
            int intLeapYear;
            bool blnFirstRotation;
            bool blnDateNotMatching = true;

            //Getting the starting variables
            intStartingYear = datStartingDate.Year;
            intStartingDay = datStartingDate.Day;
            intStartingMonth = datStartingDate.Month;

            //getting ending variables
            intEndingDay = datEndingDate.Day;
            intEndingMonth = datEndingDate.Month;
            intEndingYear = datEndingDate.Year;

            //Getting ready to the month
            intTotalMonth = intStartingMonth;
            intTotalYear = intStartingYear;
            blnFirstRotation = true;

            //Beginning date math
            //Checking to see if the dates are within the same month and year
            if (intStartingMonth == intEndingMonth && intStartingYear == intEndingYear)
            {
                intTotalDays = intEndingDay - intStartingDay;
            }
            else if(datStartingDate > datEndingDate)
            {
                intTotalDays = 0;
            }
            else
            {
                //checking multiple ways
                while (blnDateNotMatching == true)
                {
                    //Checking months with 31 days
                    if ((intTotalMonth == 1) || (intTotalMonth == 3) || (intTotalMonth == 5) || (intTotalMonth == 7) || (intTotalMonth == 8) || (intTotalMonth == 10) || (intTotalMonth == 12))
                    {
                        if (blnFirstRotation == true)
                        {
                            //initial math
                            intTotalDays = intTotalDays + 31 - intStartingDay;
                            blnFirstRotation = false;
                            intTotalMonth++;
                            if (intTotalMonth == 13)
                            {
                                intTotalMonth = 1;
                                intTotalYear++;
                            }
                        }
                        else if ((intTotalMonth == intEndingMonth) && (intTotalYear == intEndingYear))
                        {
                            intTotalDays = intTotalDays + intEndingDay;
                            blnDateNotMatching = false;
                        }
                        else
                        {
                            intTotalDays += 31;
                            intTotalMonth++;
                            if (intTotalMonth == 13)
                            {
                                intTotalMonth = 1;
                                intTotalYear++;
                            }
                        }

                    }
                    else if ((intTotalMonth == 4) || (intTotalMonth == 6) || (intTotalMonth == 9) || (intTotalMonth == 11))
                    {
                        if (blnFirstRotation == true)
                        {
                            //initial math
                            intTotalDays = intTotalDays + 30 - intStartingDay;
                            blnFirstRotation = false;
                            intTotalMonth++;
                        }
                        else if ((intTotalMonth == intEndingMonth) && (intTotalYear == intEndingYear))
                        {
                            intTotalDays = intTotalDays + intEndingDay;
                            blnDateNotMatching = false;
                        }
                        else
                        {
                            intTotalDays += 30;
                            intTotalMonth++;
                        }
                    }
                    else if (intTotalMonth == 2)
                    {
                        intLeapYear = intTotalYear % 4;
                        if (intLeapYear == 0)
                        {
                            if (blnFirstRotation == true)
                            {
                                //initial math
                                intTotalDays = intTotalDays + 29 - intStartingDay;
                                blnFirstRotation = false;
                                intTotalMonth++;
                            }
                            else if ((intTotalMonth == intEndingMonth) && (intTotalYear == intEndingYear))
                            {
                                intTotalDays = intTotalDays + intEndingDay;
                                blnDateNotMatching = false;
                            }
                            else
                            {
                                intTotalDays += 29;
                                intTotalMonth++;
                            }
                        }
                        else
                        {
                            if (blnFirstRotation == true)
                            {
                                //initial math
                                intTotalDays = intTotalDays + 28 - intStartingDay;
                                blnFirstRotation = false;
                                intTotalMonth++;
                            }
                            else if ((intTotalMonth == intEndingMonth) && (intTotalYear == intEndingYear))
                            {
                                intTotalDays = intTotalDays + intEndingDay;
                                blnDateNotMatching = false;
                            }
                            else
                            {
                                intTotalDays += 28;
                                intTotalMonth++;
                            }
                        }
                    }

                }

            }
            
            //returning value
            return intTotalDays;
        }
    }
}
