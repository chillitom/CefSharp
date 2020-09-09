// Copyright © 2020 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.
namespace CefSharp.DevTools.Network
{
    /// <summary>
    /// HTTP request data.
    /// </summary>
    public class Request : CefSharp.DevTools.DevToolsDomainEntityBase
    {
        /// <summary>
        /// Request URL (without fragment).
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("url"), IsRequired = (true))]
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Fragment of the requested URL starting with hash, if present.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("urlFragment"), IsRequired = (false))]
        public string UrlFragment
        {
            get;
            set;
        }

        /// <summary>
        /// HTTP request method.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("method"), IsRequired = (true))]
        public string Method
        {
            get;
            set;
        }

        /// <summary>
        /// HTTP request headers.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("headers"), IsRequired = (true))]
        public Headers Headers
        {
            get;
            set;
        }

        /// <summary>
        /// HTTP POST request data.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("postData"), IsRequired = (false))]
        public string PostData
        {
            get;
            set;
        }

        /// <summary>
        /// True when the request has POST data. Note that postData might still be omitted when this flag is true when the data is too long.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("hasPostData"), IsRequired = (false))]
        public bool? HasPostData
        {
            get;
            set;
        }

        /// <summary>
        /// Request body elements. This will be converted from base64 to binary
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("postDataEntries"), IsRequired = (false))]
        public System.Collections.Generic.IList<PostDataEntry> PostDataEntries
        {
            get;
            set;
        }

        /// <summary>
        /// The mixed content type of the request.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("mixedContentType"), IsRequired = (false))]
        public Security.MixedContentType MixedContentType
        {
            get;
            set;
        }

        /// <summary>
        /// Priority of the resource request at the time request is sent.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("initialPriority"), IsRequired = (true))]
        public ResourcePriority InitialPriority
        {
            get;
            set;
        }

        /// <summary>
        /// The referrer policy of the request, as defined in https://www.w3.org/TR/referrer-policy/
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("referrerPolicy"), IsRequired = (true))]
        public string ReferrerPolicy
        {
            get;
            set;
        }

        /// <summary>
        /// Whether is loaded via link preload.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("isLinkPreload"), IsRequired = (false))]
        public bool? IsLinkPreload
        {
            get;
            set;
        }
    }
}