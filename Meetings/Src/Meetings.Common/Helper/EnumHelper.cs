using System;
using System.Collections.Generic;
using System.Linq;

namespace Meetings.Common.Helper
{
    public static class EnumHelper
    {
        #region Methods

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static T GetEnumByString<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        #endregion Methods
    }
}