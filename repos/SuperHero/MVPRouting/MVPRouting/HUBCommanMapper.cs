using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MVPRouting
{
    /*
     * на строковую команду маппим анонимную функцию
     * функция принимает аргументы
     * 
     */

    public class HUBCommanMapper
    {
        Dictionary<string, Func<object, object>> _actions = new Dictionary<string, Func<object, object>>();

        public void AddRoute(string actname, Func<object, object> fnc)
        {
            _actions.Add(actname, fnc);
        }

        public object Send(string actname, object data)
        {
            var act = _actions.Keys.FirstOrDefault(x => x.Equals(actname));

            if (string.IsNullOrEmpty(act)) throw new InvalidOperationException($"Request name {actname} is not recognized");

            return _actions[act](data);
        }
    }
}
