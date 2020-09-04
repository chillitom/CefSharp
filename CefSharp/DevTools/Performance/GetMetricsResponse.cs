// Copyright © 2020 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.
namespace CefSharp.DevTools.Performance
{
    /// <summary>
    /// GetMetricsResponse
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute]
    public class GetMetricsResponse
    {
        [System.Runtime.Serialization.DataMemberAttribute]
        internal System.Collections.Generic.IList<Metric> metrics
        {
            get;
            set;
        }

        /// <summary>
        /// Current values for run-time metrics.
        /// </summary>
        public System.Collections.Generic.IList<Metric> Metrics
        {
            get
            {
                return metrics;
            }
        }
    }
}