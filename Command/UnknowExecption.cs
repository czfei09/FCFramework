﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FC.Framework
{
    [Serializable]
    public class UnknowExecption : SystemException
    {
        public UnknowExecption(string message) : base(message) { }

        public UnknowExecption(string message, Exception innerException) : base(message, innerException) { }
    }
}
