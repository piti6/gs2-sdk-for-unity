/*
 * Copyright 2016 Game Server Services, Inc. or its affiliates. All Rights
 * Reserved.
 *
 * Licensed under the Apache License, Version 2.0(the "License").
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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gs2.Gs2Lottery;
using Gs2.Gs2Lottery.Model;
using Gs2.Gs2Lottery.Request;
using Gs2.Gs2Lottery.Result;
using Gs2.Unity.Gs2Lottery.Model;
using Gs2.Unity.Gs2Lottery.Result;
using Gs2.Core;
using Gs2.Core.Model;
using Gs2.Core.Net;
using Gs2.Unity.Util;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace Gs2.Unity.Gs2Lottery
{
	public class DisabledCertificateHandler : CertificateHandler {
		protected override bool ValidateCertificate(byte[] certificateData)
		{
			return true;
		}
	}

	public partial class Client
	{
		private readonly Gs2.Unity.Util.Profile _profile;
		private readonly Gs2LotteryWebSocketClient _client;
		private readonly Gs2LotteryRestClient _restClient;

		public Client(Gs2.Unity.Util.Profile profile)
		{
			_profile = profile;
			_client = new Gs2LotteryWebSocketClient(profile.Gs2Session);
			if (profile.checkRevokeCertificate)
			{
				_restClient = new Gs2LotteryRestClient(profile.Gs2RestSession);
			}
			else
			{
				_restClient = new Gs2LotteryRestClient(profile.Gs2RestSession, new DisabledCertificateHandler());
			}
		}

		/// <summary>
		///  ボックスの排出済みアイテム情報一覧を取得<br />
		/// </summary>
        ///
		/// <returns>IEnumerator</returns>
		/// <param name="callback">コールバックハンドラ</param>
		/// <param name="session">ゲームセッション</param>
		/// <param name="namespaceName">ネームスペース名</param>
		/// <param name="pageToken">データの取得を開始する位置を指定するトークン</param>
		/// <param name="limit">データの取得件数</param>
		public IEnumerator DescribeBoxes(
		        UnityAction<AsyncResult<EzDescribeBoxesResult>> callback,
		        GameSession session,
                string namespaceName,
                string pageToken=null,
                long? limit=null
        )
		{
            yield return _profile.Run(
                callback,
		        session,
                cb => _restClient.DescribeBoxes(
                    new DescribeBoxesRequest()
                        .WithNamespaceName(namespaceName)
                        .WithPageToken(pageToken)
                        .WithLimit(limit)
                        .WithAccessToken(session.AccessToken.token),
                    r => cb.Invoke(
                        new AsyncResult<EzDescribeBoxesResult>(
                            r.Result == null ? null : new EzDescribeBoxesResult(r.Result),
                            r.Error
                        )
                    )
                )
            );
		}

		/// <summary>
		///  ボックスの排出済みアイテム情報を取得<br />
		/// </summary>
        ///
		/// <returns>IEnumerator</returns>
		/// <param name="callback">コールバックハンドラ</param>
		/// <param name="session">ゲームセッション</param>
		/// <param name="namespaceName">ネームスペース名</param>
		/// <param name="prizeTableName">排出確率テーブル名</param>
		public IEnumerator GetBox(
		        UnityAction<AsyncResult<EzGetBoxResult>> callback,
		        GameSession session,
                string namespaceName,
                string prizeTableName
        )
		{
            yield return _profile.Run(
                callback,
		        session,
                cb => _client.GetBox(
                    new GetBoxRequest()
                        .WithNamespaceName(namespaceName)
                        .WithPrizeTableName(prizeTableName)
                        .WithAccessToken(session.AccessToken.token),
                    r => cb.Invoke(
                        new AsyncResult<EzGetBoxResult>(
                            r.Result == null ? null : new EzGetBoxResult(r.Result),
                            r.Error
                        )
                    )
                )
            );
		}

		/// <summary>
		///  ボックスのリセット<br />
		/// </summary>
        ///
		/// <returns>IEnumerator</returns>
		/// <param name="callback">コールバックハンドラ</param>
		/// <param name="session">ゲームセッション</param>
		/// <param name="namespaceName">ネームスペース名</param>
		/// <param name="prizeTableName">排出確率テーブル名</param>
		public IEnumerator ResetBox(
		        UnityAction<AsyncResult<EzResetBoxResult>> callback,
		        GameSession session,
                string namespaceName,
                string prizeTableName
        )
		{
            yield return _profile.Run(
                callback,
		        session,
                cb => _client.ResetBox(
                    new ResetBoxRequest()
                        .WithNamespaceName(namespaceName)
                        .WithPrizeTableName(prizeTableName)
                        .WithAccessToken(session.AccessToken.token),
                    r => cb.Invoke(
                        new AsyncResult<EzResetBoxResult>(
                            r.Result == null ? null : new EzResetBoxResult(r.Result),
                            r.Error
                        )
                    )
                )
            );
		}

		/// <summary>
		///  排出確率を取得<br />
		/// </summary>
        ///
		/// <returns>IEnumerator</returns>
		/// <param name="callback">コールバックハンドラ</param>
		/// <param name="session">ゲームセッション</param>
		/// <param name="namespaceName">ネームスペース名</param>
		/// <param name="lotteryName">抽選モデルの種類名</param>
		public IEnumerator ListProbabilities(
		        UnityAction<AsyncResult<EzListProbabilitiesResult>> callback,
		        GameSession session,
                string namespaceName,
                string lotteryName
        )
		{
            yield return _profile.Run(
                callback,
		        session,
                cb => _client.DescribeProbabilities(
                    new DescribeProbabilitiesRequest()
                        .WithNamespaceName(namespaceName)
                        .WithLotteryName(lotteryName)
                        .WithAccessToken(session.AccessToken.token),
                    r => cb.Invoke(
                        new AsyncResult<EzListProbabilitiesResult>(
                            r.Result == null ? null : new EzListProbabilitiesResult(r.Result),
                            r.Error
                        )
                    )
                )
            );
		}
	}
}