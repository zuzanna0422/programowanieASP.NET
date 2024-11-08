using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace programowanieASP.NET.Models
{
    public static class EnumExtensions 
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attribute = memberInfo[0].GetCustomAttribute<DisplayAttribute>();

                if (attribute != null)
                {
                    return attribute.Name;
                }
            }

            return enumValue.ToString();
        }
    }
}
