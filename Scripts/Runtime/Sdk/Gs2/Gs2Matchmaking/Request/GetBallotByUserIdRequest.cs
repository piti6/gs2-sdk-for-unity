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
using System;
using System.Collections.Generic;
using System.Linq;
using Gs2.Core.Control;
using Gs2.Core.Model;
using Gs2.Gs2Matchmaking.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Matchmaking.Request
{
	[Preserve]
	[System.Serializable]
	public class GetBallotByUserIdRequest : Gs2Request<GetBallotByUserIdRequest>
	{

        /** ネームスペース名 */
		[UnityEngine.SerializeField]
        public string namespaceName;

        /**
         * ネームスペース名を設定
         *
         * @param namespaceName ネームスペース名
         * @return this
         */
        public GetBallotByUserIdRequest WithNamespaceName(string namespaceName) {
            this.namespaceName = namespaceName;
            return this;
        }


        /** レーティング名 */
		[UnityEngine.SerializeField]
        public string ratingName;

        /**
         * レーティング名を設定
         *
         * @param ratingName レーティング名
         * @return this
         */
        public GetBallotByUserIdRequest WithRatingName(string ratingName) {
            this.ratingName = ratingName;
            return this;
        }


        /** 投票対象のギャザリング名 */
		[UnityEngine.SerializeField]
        public string gatheringName;

        /**
         * 投票対象のギャザリング名を設定
         *
         * @param gatheringName 投票対象のギャザリング名
         * @return this
         */
        public GetBallotByUserIdRequest WithGatheringName(string gatheringName) {
            this.gatheringName = gatheringName;
            return this;
        }


        /** ユーザーID */
		[UnityEngine.SerializeField]
        public string userId;

        /**
         * ユーザーIDを設定
         *
         * @param userId ユーザーID
         * @return this
         */
        public GetBallotByUserIdRequest WithUserId(string userId) {
            this.userId = userId;
            return this;
        }


        /** 投票対象となる */
		[UnityEngine.SerializeField]
        public string gatheringId;

        /**
         * 投票対象となるを設定
         *
         * @param gatheringId 投票対象となる
         * @return this
         */
        public GetBallotByUserIdRequest WithGatheringId(string gatheringId) {
            this.gatheringId = gatheringId;
            return this;
        }


        /** 参加人数 */
		[UnityEngine.SerializeField]
        public int? numberOfPlayer;

        /**
         * 参加人数を設定
         *
         * @param numberOfPlayer 参加人数
         * @return this
         */
        public GetBallotByUserIdRequest WithNumberOfPlayer(int? numberOfPlayer) {
            this.numberOfPlayer = numberOfPlayer;
            return this;
        }


        /** 投票用紙の署名計算に使用する暗号鍵 のGRN */
		[UnityEngine.SerializeField]
        public string keyId;

        /**
         * 投票用紙の署名計算に使用する暗号鍵 のGRNを設定
         *
         * @param keyId 投票用紙の署名計算に使用する暗号鍵 のGRN
         * @return this
         */
        public GetBallotByUserIdRequest WithKeyId(string keyId) {
            this.keyId = keyId;
            return this;
        }


        /** 重複実行回避機能に使用するID */
		[UnityEngine.SerializeField]
        public string duplicationAvoider;

        /**
         * 重複実行回避機能に使用するIDを設定
         *
         * @param duplicationAvoider 重複実行回避機能に使用するID
         * @return this
         */
        public GetBallotByUserIdRequest WithDuplicationAvoider(string duplicationAvoider) {
            this.duplicationAvoider = duplicationAvoider;
            return this;
        }


    	[Preserve]
        public static GetBallotByUserIdRequest FromDict(JsonData data)
        {
            return new GetBallotByUserIdRequest {
                namespaceName = data.Keys.Contains("namespaceName") && data["namespaceName"] != null ? data["namespaceName"].ToString(): null,
                ratingName = data.Keys.Contains("ratingName") && data["ratingName"] != null ? data["ratingName"].ToString(): null,
                gatheringName = data.Keys.Contains("gatheringName") && data["gatheringName"] != null ? data["gatheringName"].ToString(): null,
                userId = data.Keys.Contains("userId") && data["userId"] != null ? data["userId"].ToString(): null,
                gatheringId = data.Keys.Contains("gatheringId") && data["gatheringId"] != null ? data["gatheringId"].ToString(): null,
                numberOfPlayer = data.Keys.Contains("numberOfPlayer") && data["numberOfPlayer"] != null ? (int?)int.Parse(data["numberOfPlayer"].ToString()) : null,
                keyId = data.Keys.Contains("keyId") && data["keyId"] != null ? data["keyId"].ToString(): null,
                duplicationAvoider = data.Keys.Contains("duplicationAvoider") && data["duplicationAvoider"] != null ? data["duplicationAvoider"].ToString(): null,
            };
        }

	}
}