using MVCAssignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment.Models
{
    public static class Utility
    {
        public static int Counter { get; internal set; }

        public static string CheckFever(MVCAssignment.Model.Fever model)
        {
            string result;
            if (model.HasFever > 37)
            {
                result = "You have fever!";
            }
            else if (model.HasFever < 35)
            {
                result = "You are at risk of hypotermia!";
            }
            else
            {
                result = "You don't have fever!";
            }
            return result;

        }
      
    }
}
