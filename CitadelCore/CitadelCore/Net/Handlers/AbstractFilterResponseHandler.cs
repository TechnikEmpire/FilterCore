﻿/*
* Copyright © 2017 Jesse Nicholson
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using CitadelCore.Net.Proxy;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CitadelCore.Net.Handlers
{
    /// <summary>
    /// Enforces a pattern of requiring message handlers on all filtering response handlers. 
    /// </summary>
    internal abstract class AbstractFilterResponseHandler
    {
        protected MessageBeginCallback m_msgBeginCb;

        protected MessageEndCallback m_msgEndCb;

        protected BadCertificateCallback m_onBadCertificate;

        protected static readonly byte[] m_nullBody = new byte[0];

        public AbstractFilterResponseHandler(MessageBeginCallback messageBeginCallback, MessageEndCallback messageEndCallback)
        {
            m_msgBeginCb = messageBeginCallback;
            m_msgEndCb = messageEndCallback;
            m_onBadCertificate = null;
        }

        public AbstractFilterResponseHandler(MessageBeginCallback messageBeginCallback, MessageEndCallback messageEndCallback, BadCertificateCallback onBadCertificate)
        {
            m_msgBeginCb = messageBeginCallback;
            m_msgEndCb = messageEndCallback;
            m_onBadCertificate = onBadCertificate;
        }

        public abstract Task Handle(HttpContext context);
    }
}