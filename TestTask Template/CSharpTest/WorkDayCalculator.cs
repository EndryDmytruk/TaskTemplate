using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            // check if weekEnds exists
            if (weekEnds != null) 
            {
                //a variable that stores the "index" of the beginning of the weekend that begins after startDate = 01.01.2017
                //example:
                //  [0] = 02.01.2016 - 05.01.2016
                //  [1] = 02.01.2017 - 05.01.2017
                //therefore we will begin processing with the second element of an array
                int index = 0;
                
                while (startDate > weekEnds[index].StartDate)
                {
                    ++index;
                }
                int q  = 4 / 2;

                //increase startDate for the number of  dayCount - 1, because the first day is taken into account
                startDate = startDate.AddDays(dayCount - 1);
                
                //logical variable to exit the cycle when the weekend is after the final result
                bool checkFor = true;
                
                //the cycle adds the number of days to the initial result
                for (int i = index; i < weekEnds.Count() && checkFor; ++i)
                {
                    if (startDate >= weekEnds[i].StartDate)
                    {
                        //the number of days off from the period is calculated
                        double count = weekEnds[i].EndDate.Subtract(weekEnds[i].StartDate).TotalDays + 1;
                        startDate = startDate.AddDays(count);
                    }
                    else
                    {
                        checkFor = false;
                    }
                }

                return startDate;
            }
            else
            {
                return startDate.AddDays(dayCount - 1);
            }
        }
    }
}
