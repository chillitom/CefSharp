// Copyright © 2020 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.
namespace CefSharp.DevTools.Network
{
    /// <summary>
    /// GetAllCookiesResponse
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute]
    public class GetAllCookiesResponse
    {
        [System.Runtime.Serialization.DataMemberAttribute]
        internal System.Collections.Generic.IList<Cookie> cookies
        {
            get;
            set;
        }

        /// <summary>
        /// Array of cookie objects.
        /// </summary>
        public System.Collections.Generic.IList<Cookie> Cookies
        {
            get
            {
                return cookies;
            }
        }
    }
}