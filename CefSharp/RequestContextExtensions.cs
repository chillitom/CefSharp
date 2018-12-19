// Copyright © 2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.


namespace CefSharp
{
    public static class RequestContextExtensions
    {
        /// <summary>
        /// Load an extension. If extension resources will be read from disk using the default load implementation then rootDirectoy
        /// should be the absolute path to the extension resources directory
        /// The loaded extension will be accessible in all contexts sharing the same storage (HasExtension returns true).
        /// However, only the context on which this method was called is considered the loader (DidLoadExtension returns true) and only the
        /// loader will receive IRequestContextHandler callbacks for the extension. <see cref="IExtensionHandler.OnExtensionLoaded"/> will be
        /// called on load success or <see cref="IExtensionHandler.OnExtensionLoadFailed"/> will be called on load failure.
        /// If the extension specifies a background script via the "background" manifest key then <see cref="IExtensionHandler.OnBeforeBackgroundBrowser"/>
        /// will be called to create the background browser. See that method for additional information about background scripts.
        /// For visible extension views the client application should evaluate the manifest to determine the correct extension URL to load and then pass
        /// that URL to the IBrowserHost.CreateBrowser* function after the extension has loaded. For example, the client can look for the "browser_action"
        /// manifest key as documented at https://developer.chrome.com/extensions/browserAction. Extension URLs take the form "chrome-extension:///".
        /// Browsers that host extensions differ from normal browsers as follows: - Can access chrome.* JavaScript APIs if allowed by the manifest.
        /// Visit chrome://extensions-support for the list of extension APIs currently supported by CEF. - Main frame navigation to non-extension
        /// content is blocked.
        /// - Pinch-zooming is disabled.
        /// - <see cref="IBrowserHost.GetExtension"/> returns the hosted extension.
        /// - <see cref="IBrowserHost.IsBackgroundHost"/> returns true for background hosts. See https://developer.chrome.com/extensions for extension implementation and usage documentation.
        /// </summary>
        /// <param name="requestContext">request context</param>
        /// <param name="rootDirectory">If extension resources will be read from disk using the default load implementation then rootDirectoy
        /// should be the absolute path to the extension resources directory and manifestJson should be null</param>
        /// <param name="handler">handle events related to browser extensions</param>
        public static void LoadExtensionFromDirectory(this IRequestContext requestContext, string rootDirectory, IExtensionHandler handler)
        {
            requestContext.LoadExtension(rootDirectory, null, handler);
        }
    }
}
