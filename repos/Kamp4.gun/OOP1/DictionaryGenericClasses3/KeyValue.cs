using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGenericClasses3
{
    class KeyValue<T>
    {
        public T Key { get; set; }
        public T Value { get; set; }
    }
}
