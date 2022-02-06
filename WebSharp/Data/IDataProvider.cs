using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSharp.Data
{
    public interface IDataProvider
    {
        object GetValue(string name);

        void SetValue(string name, object value);
    }
}
