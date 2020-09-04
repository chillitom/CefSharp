// Copyright © 2020 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.
namespace CefSharp.DevTools.DOM
{
    /// <summary>
    /// GetAttributesResponse
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute]
    public class GetAttributesResponse
    {
        [System.Runtime.Serialization.DataMemberAttribute]
        internal string attributes
        {
            get;
            set;
        }

        /// <summary>
        /// An interleaved array of node attribute names and values.
        /// </summary>
        public string Attributes
        {
            get
            {
                return attributes;
            }
        }
    }
}