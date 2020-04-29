using System;
using System.Collections.Generic;

namespace HelloWord2.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class Simple1
    {
        public String _Name { get; set; }
        public int _Age { get; set; }
        public List<String> values;

        public Simple1()
        {
            values = new List<String>();
        }
    }
}
