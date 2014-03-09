﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CefSharp
{
    public abstract class CefBrowserBase : ObjectBase
    {
        public long BrowserId { get; set; }

        protected CefBrowserBase()
        {
        }

        public abstract object EvaluateScript(long frameId, string script, double timeout);

    }
}
