// Copyright © 2020 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.
namespace CefSharp.DevTools.Schema
{
    /// <summary>
    /// GetDomainsResponse
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute]
    public class GetDomainsResponse
    {
        [System.Runtime.Serialization.DataMemberAttribute]
        internal System.Collections.Generic.IList<Domain> domains
        {
            get;
            set;
        }

        /// <summary>
        /// List of supported domains.
        /// </summary>
        public System.Collections.Generic.IList<Domain> Domains
        {
            get
            {
                return domains;
            }
        }
    }
}