﻿using System;
using System.Diagnostics;

namespace FC.Framework
{

    public abstract class DisposableResource : IDisposable
    {
        ~DisposableResource()
        {
            Dispose(false);
        }

        [DebuggerStepThrough]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

        }
    }
}