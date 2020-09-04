// Copyright © 2020 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.
namespace CefSharp.DevTools.DOM
{
    /// <summary>
    /// GetOuterHTMLResponse
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute]
    public class GetOuterHTMLResponse
    {
        [System.Runtime.Serialization.DataMemberAttribute]
        internal string outerHTML
        {
            get;
            set;
        }

        /// <summary>
        /// Outer HTML markup.
        /// </summary>
        public string OuterHTML
        {
            get
            {
                return outerHTML;
            }
        }
    }
}