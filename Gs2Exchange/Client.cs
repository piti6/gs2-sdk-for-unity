/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
 * Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 *
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */

using Gs2.Gs2Exchange;
using Gs2.Unity.Gs2Exchange.Model;
using Gs2.Unity.Gs2Exchange.Result;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Gs2.Gs2Quest;
using Gs2.Gs2Quest.Model;
using Gs2.Gs2Quest.Request;
using Gs2.Gs2Quest.Result;
using Gs2.Unity.Gs2Quest.Model;
using Gs2.Unity.Gs2Quest.Result;
using Gs2.Core;
using Gs2.Core.Model;
using Gs2.Core.Net;
using Gs2.Unity.Util;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.Scripting;

// ReSharper disable once CheckNamespace
namespace Gs2.Unity.Gs2Exchange
{
	public class DisabledCertificateHandler : CertificateHandler {
		protected override bool ValidateCertificate(byte[] certificateData)
		{
			return true;
		}
	}

	[Preserve]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public partial class Client
	{
		private readonly Gs2.Unity.Util.Profile _profile;
		private readonly Gs2ExchangeWebSocketClient _client;
		private readonly Gs2ExchangeRestClient _restClient;

		public Client(Gs2.Unity.Util.Profile profile)
		{
			_profile = profile;
			_client = new Gs2ExchangeWebSocketClient(profile.Gs2Session);
			if (profile.checkRevokeCertificate)
			{
				_restClient = new Gs2ExchangeRestClient(profile.Gs2RestSession);
			}
			else
			{
				_restClient = new Gs2ExchangeRestClient(profile.Gs2RestSession, new DisabledCertificateHandler());
			}
		}

        public IEnumerator Acquire(
		        UnityAction<AsyncResult<Gs2.Unity.Gs2Exchange.Result.EzAcquireResult>> callback,
		        GameSession session,
                string namespaceName,
                string awaitName = null
        )
		{
            yield return _profile.Run(
                callback,
		        session,
                cb => _restClient.Acquire(
                    new Gs2.Gs2Exchange.Request.AcquireRequest()
                        .WithNamespaceName(namespaceName)
                        .WithAccessToken(session.AccessToken.Token)
                        .WithAwaitName(awaitName),
                    r => cb.Invoke(
                        new AsyncResult<Gs2.Unity.Gs2Exchange.Result.EzAcquireResult>(
                            r.Result == null ? null : Gs2.Unity.Gs2Exchange.Result.EzAcquireResult.FromModel(r.Result),
                            r.Error
                        )
                    )
                )
            );
		}

        public IEnumerator DeleteAwait(
		        UnityAction<AsyncResult<Gs2.Unity.Gs2Exchange.Result.EzDeleteAwaitResult>> callback,
		        GameSession session,
                string namespaceName,
                string awaitName = null
        )
		{
            yield return _profile.Run(
                callback,
		        session,
                cb => _client.DeleteAwait(
                    new Gs2.Gs2Exchange.Request.DeleteAwaitRequest()
                        .WithNamespaceName(namespaceName)
                        .WithAccessToken(session.AccessToken.Token)
                        .WithAwaitName(awaitName),
                    r => cb.Invoke(
                        new AsyncResult<Gs2.Unity.Gs2Exchange.Result.EzDeleteAwaitResult>(
                            r.Result == null ? null : Gs2.Unity.Gs2Exchange.Result.EzDeleteAwaitResult.FromModel(r.Result),
                            r.Error
                        )
                    )
                )
            );
		}

        public IEnumerator GetAwait(
		        UnityAction<AsyncResult<Gs2.Unity.Gs2Exchange.Result.EzGetAwaitResult>> callback,
		        GameSession session,
                string namespaceName,
                string awaitName = null
        )
		{
            yield return _profile.Run(
                callback,
		        session,
                cb => _client.GetAwait(
                    new Gs2.Gs2Exchange.Request.GetAwaitRequest()
                        .WithNamespaceName(namespaceName)
                        .WithAccessToken(session.AccessToken.Token)
                        .WithAwaitName(awaitName),
                    r => cb.Invoke(
                        new AsyncResult<Gs2.Unity.Gs2Exchange.Result.EzGetAwaitResult>(
                            r.Result == null ? null : Gs2.Unity.Gs2Exchange.Result.EzGetAwaitResult.FromModel(r.Result),
                            r.Error
                        )
                    )
                )
            );
		}

        public IEnumerator ListAwaits(
		        UnityAction<AsyncResult<Gs2.Unity.Gs2Exchange.Result.EzListAwaitsResult>> callback,
		        GameSession session,
                string namespaceName,
                string rateName = null,
                string pageToken = null
        )
		{
            yield return _profile.Run(
                callback,
		        session,
                cb => _restClient.DescribeAwaits(
                    new Gs2.Gs2Exchange.Request.DescribeAwaitsRequest()
                        .WithNamespaceName(namespaceName)
                        .WithRateName(rateName)
                        .WithAccessToken(session.AccessToken.Token)
                        .WithPageToken(pageToken),
                    r => cb.Invoke(
                        new AsyncResult<Gs2.Unity.Gs2Exchange.Result.EzListAwaitsResult>(
                            r.Result == null ? null : Gs2.Unity.Gs2Exchange.Result.EzListAwaitsResult.FromModel(r.Result),
                            r.Error
                        )
                    )
                )
            );
		}

        public IEnumerator Skip(
		        UnityAction<AsyncResult<Gs2.Unity.Gs2Exchange.Result.EzSkipResult>> callback,
		        GameSession session,
                string namespaceName,
                string awaitName = null
        )
		{
            yield return _profile.Run(
                callback,
		        session,
                cb => _restClient.Skip(
                    new Gs2.Gs2Exchange.Request.SkipRequest()
                        .WithNamespaceName(namespaceName)
                        .WithAccessToken(session.AccessToken.Token)
                        .WithAwaitName(awaitName),
                    r => cb.Invoke(
                        new AsyncResult<Gs2.Unity.Gs2Exchange.Result.EzSkipResult>(
                            r.Result == null ? null : Gs2.Unity.Gs2Exchange.Result.EzSkipResult.FromModel(r.Result),
                            r.Error
                        )
                    )
                )
            );
		}

        public IEnumerator GetRateModel(
		        UnityAction<AsyncResult<Gs2.Unity.Gs2Exchange.Result.EzGetRateModelResult>> callback,
                string namespaceName,
                string rateName
        )
		{
            yield return _profile.Run(
                callback,
                null,
                cb => _restClient.GetRateModel(
                    new Gs2.Gs2Exchange.Request.GetRateModelRequest()
                        .WithNamespaceName(namespaceName)
                        .WithRateName(rateName),
                    r => cb.Invoke(
                        new AsyncResult<Gs2.Unity.Gs2Exchange.Result.EzGetRateModelResult>(
                            r.Result == null ? null : Gs2.Unity.Gs2Exchange.Result.EzGetRateModelResult.FromModel(r.Result),
                            r.Error
                        )
                    )
                )
            );
		}

        public IEnumerator ListRateModels(
		        UnityAction<AsyncResult<Gs2.Unity.Gs2Exchange.Result.EzListRateModelsResult>> callback,
                string namespaceName
        )
		{
            yield return _profile.Run(
                callback,
                null,
                cb => _restClient.DescribeRateModels(
                    new Gs2.Gs2Exchange.Request.DescribeRateModelsRequest()
                        .WithNamespaceName(namespaceName),
                    r => cb.Invoke(
                        new AsyncResult<Gs2.Unity.Gs2Exchange.Result.EzListRateModelsResult>(
                            r.Result == null ? null : Gs2.Unity.Gs2Exchange.Result.EzListRateModelsResult.FromModel(r.Result),
                            r.Error
                        )
                    )
                )
            );
		}

        public IEnumerator Exchange(
		        UnityAction<AsyncResult<Gs2.Unity.Gs2Exchange.Result.EzExchangeResult>> callback,
		        GameSession session,
                string namespaceName,
                string rateName,
                int count,
                List<Gs2.Unity.Gs2Exchange.Model.EzConfig> config = null
        )
		{
            yield return _profile.Run(
                callback,
		        session,
                cb => _restClient.Exchange(
                    new Gs2.Gs2Exchange.Request.ExchangeRequest()
                        .WithNamespaceName(namespaceName)
                        .WithRateName(rateName)
                        .WithAccessToken(session.AccessToken.Token)
                        .WithCount(count)
                        .WithConfig(config?.Select(v => {
                            return v?.ToModel();
                        }).ToArray()),
                    r => cb.Invoke(
                        new AsyncResult<Gs2.Unity.Gs2Exchange.Result.EzExchangeResult>(
                            r.Result == null ? null : Gs2.Unity.Gs2Exchange.Result.EzExchangeResult.FromModel(r.Result),
                            r.Error
                        )
                    )
                )
            );
		}
    }
}