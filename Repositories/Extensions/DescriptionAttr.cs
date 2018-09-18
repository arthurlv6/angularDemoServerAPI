using Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
namespace Repositories.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescription(this Enum EnumValue)
        {
            Type type = EnumValue.GetType();
            MemberInfo[] memberInfo = type.GetMember(EnumValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }
            return EnumValue.ToString();
        }

    }
}

