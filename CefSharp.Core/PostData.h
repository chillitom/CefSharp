// Copyright © 2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

#pragma once

#include "Stdafx.h"

#include "include\cef_request.h"

#include "PostDataElement.h"
#include "Internals\TypeConversion.h"
#include "Internals\CefWrapper.h"

using namespace System::Collections::Generic;
using namespace System::Collections::ObjectModel;

namespace CefSharp
{
    public ref class PostData : public IPostData, public CefWrapper
    {
        MCefRefPtr<CefPostData> _postData;
        List<IPostDataElement^>^ _postDataElements;

    internal:
        PostData(CefRefPtr<CefPostData> &postData) :
            _postData(postData)
        {

        }

        !PostData()
        {
            _postData = nullptr;
        }

        ~PostData()
        {
            this->!PostData();

            if (_postDataElements != nullptr)
            {
                //Make sure the unmanaged resources are handled
                for each (IPostDataElement^ element in _postDataElements)
                {
                    delete element;
                }

                _postDataElements = nullptr;
            }

            _disposed = true;
        }

    public:
        PostData()
        {
            _postData = CefPostData::Create();
        }

        virtual property bool IsReadOnly
        {
            bool get()
            {
                ThrowIfDisposed();

                return _postData->IsReadOnly();
            }
        }

        virtual property IList<IPostDataElement^>^ Elements
        {
            IList<IPostDataElement^>^ get()
            {
                ThrowIfDisposed();

                if (_postDataElements == nullptr)
                {
                    _postDataElements = gcnew List<IPostDataElement^>();

                    auto elementCount = _postData.get() ? _postData->GetElementCount() : 0;
                    if (elementCount == 0)
                    {
                        return gcnew ReadOnlyCollection<IPostDataElement^>(_postDataElements);
                    }
                    CefPostData::ElementVector ev;

                    _postData->GetElements(ev);

                    for (CefPostData::ElementVector::iterator it = ev.begin(); it != ev.end(); ++it)
                    {
                        CefPostDataElement *el = it->get();

                        _postDataElements->Add(gcnew PostDataElement(el));
                    }
                }

                return gcnew ReadOnlyCollection<IPostDataElement^>(_postDataElements);
            }
        }

        virtual bool AddElement(IPostDataElement^ element)
        {
            ThrowIfDisposed();

            ThrowIfReadOnly();

            //Access the Elements collection to initialize the underlying _postDataElements collection
            auto elements = Elements;

            //If the element has already been added then don't add it again
            if (elements->Contains(element))
            {
                return false;
            }

            _postDataElements->Add(element);

            auto elementWrapper = (PostDataElement^)element;

            return _postData->AddElement(elementWrapper);
        }

        virtual bool RemoveElement(IPostDataElement^ element)
        {
            ThrowIfDisposed();

            ThrowIfReadOnly();

            //Access the Elements collection to initialize the underlying _postDataElements collection
            auto elements = Elements;

            if (!elements->Contains(element))
            {
                return false;
            }

            _postDataElements->Remove(element);

            auto elementWrapper = (PostDataElement^)element;

            return _postData->RemoveElement(elementWrapper);
        }

        virtual void RemoveElements()
        {
            ThrowIfDisposed();

            ThrowIfReadOnly();

            _postData->RemoveElements();
        }

        virtual IPostDataElement^ CreatePostDataElement()
        {
            auto element = CefPostDataElement::Create();

            return gcnew PostDataElement(element);
        }

        virtual property bool HasExcludedElements
        {
            bool get()
            {
                ThrowIfDisposed();

                return _postData->HasExcludedElements();
            }
        }

        void ThrowIfReadOnly()
        {
            if (IsReadOnly)
            {
                throw gcnew Exception(gcnew String(L"This IPostDataWrapper is readonly and cannot be modified."));
            }
        }

        operator CefRefPtr<CefPostData>()
        {
            if (this == nullptr)
            {
                return NULL;
            }
            return _postData.get();
        }
    };
}
