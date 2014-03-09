// Copyright � 2010-2013 The CefSharp Project. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

#include "Stdafx.h"
#include "SchemeHandlerResponse.h"

namespace CefSharp
{
    void SchemeHandlerResponseWrapper::OnRequestCompleted( Task^ previous )
    {
        _schemeHandlerWrapper->ProcessRequestCallback(previous);
    }
}