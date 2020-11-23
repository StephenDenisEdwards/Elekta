using System;
using System.Reflection;

namespace PetReport.Reflective.Lib
{
    public abstract class ReportableReflective : IReportable
    {
        public virtual object this[string key]
        {
            get
            {
                var path = key.Split('.');

                if (path.Length > 1)
                {
                    PropertyInfo propertyInfo = GetType().BaseType.GetProperty(path[0]);

                    if (propertyInfo?.GetValue(this, null) is IReportable compositionObject)
                    {
                        string nextKey = string.Empty;

                        for (int i = 1; i < path.Length; i++)
                        {
                            nextKey += (i + 1) == path.Length ? path[i] : path[i] + ".";
                        }

                        return compositionObject[nextKey];
                    }
                }
                else
                {
                    PropertyInfo propertyInfo = GetType().GetProperty(key);

                    if (propertyInfo != null)
                        return propertyInfo.GetValue(this, null);
                }

                return null;
            }
        }
    }
}
