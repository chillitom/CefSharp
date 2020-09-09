// Copyright © 2020 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.
namespace CefSharp.DevTools.Page
{
    /// <summary>
    /// Information about the Frame on the page.
    /// </summary>
    public class Frame : CefSharp.DevTools.DevToolsDomainEntityBase
    {
        /// <summary>
        /// Frame unique identifier.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("id"), IsRequired = (true))]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Parent frame identifier.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("parentId"), IsRequired = (false))]
        public string ParentId
        {
            get;
            set;
        }

        /// <summary>
        /// Identifier of the loader associated with this frame.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("loaderId"), IsRequired = (true))]
        public string LoaderId
        {
            get;
            set;
        }

        /// <summary>
        /// Frame's name as specified in the tag.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("name"), IsRequired = (false))]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Frame document's URL without fragment.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("url"), IsRequired = (true))]
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Frame document's URL fragment including the '#'.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("urlFragment"), IsRequired = (false))]
        public string UrlFragment
        {
            get;
            set;
        }

        /// <summary>
        /// Frame document's registered domain, taking the public suffixes list into account.
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("domainAndRegistry"), IsRequired = (true))]
        public string DomainAndRegistry
        {
            get;
            set;
        }

        /// <summary>
        /// Frame document's security origin.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("securityOrigin"), IsRequired = (true))]
        public string SecurityOrigin
        {
            get;
            set;
        }

        /// <summary>
        /// Frame document's mimeType as determined by the browser.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("mimeType"), IsRequired = (true))]
        public string MimeType
        {
            get;
            set;
        }

        /// <summary>
        /// If the frame failed to load, this contains the URL that could not be loaded. Note that unlike url above, this URL may contain a fragment.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("unreachableUrl"), IsRequired = (false))]
        public string UnreachableUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether this frame was tagged as an ad.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("adFrameType"), IsRequired = (false))]
        public AdFrameType AdFrameType
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether the main document is a secure context and explains why that is the case.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("secureContextType"), IsRequired = (true))]
        public SecureContextType SecureContextType
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether this is a cross origin isolated context.
        /// </summary>
        [System.Runtime.Serialization.DataMemberAttribute(Name = ("crossOriginIsolatedContextType"), IsRequired = (true))]
        public CrossOriginIsolatedContextType CrossOriginIsolatedContextType
        {
            get;
            set;
        }
    }
}