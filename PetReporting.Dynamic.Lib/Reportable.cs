using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace PetReporting.Dynamic.Lib
{
    public abstract class Reportable : DynamicObject, IReportable
    {
        /// <summary>
        /// Called if the property cannot be found. For reporting purposes we will return
        /// null and success. Reports may be configured with fields that don't exist on
        /// all objects.
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            return true;
        }

        public override DynamicMetaObject GetMetaObject(Expression parameter)
        {
            var meta = base.GetMetaObject(parameter);
            return meta;
        }

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