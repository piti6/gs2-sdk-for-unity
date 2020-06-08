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
using System.Text.RegularExpressions;
using Gs2.Core.Model;
using Gs2.Util.LitJson;
using UnityEngine.Scripting;

namespace Gs2.Gs2Ranking.Model
{
	[Preserve]
	public class Score : IComparable
	{

        /** スコア */
        public string scoreId { set; get; }

        /**
         * スコアを設定
         *
         * @param scoreId スコア
         * @return this
         */
        public Score WithScoreId(string scoreId) {
            this.scoreId = scoreId;
            return this;
        }

        /** カテゴリ名 */
        public string categoryName { set; get; }

        /**
         * カテゴリ名を設定
         *
         * @param categoryName カテゴリ名
         * @return this
         */
        public Score WithCategoryName(string categoryName) {
            this.categoryName = categoryName;
            return this;
        }

        /** ユーザID */
        public string userId { set; get; }

        /**
         * ユーザIDを設定
         *
         * @param userId ユーザID
         * @return this
         */
        public Score WithUserId(string userId) {
            this.userId = userId;
            return this;
        }

        /** スコアのユニークID */
        public string uniqueId { set; get; }

        /**
         * スコアのユニークIDを設定
         *
         * @param uniqueId スコアのユニークID
         * @return this
         */
        public Score WithUniqueId(string uniqueId) {
            this.uniqueId = uniqueId;
            return this;
        }

        /** スコアを獲得したユーザID */
        public string scorerUserId { set; get; }

        /**
         * スコアを獲得したユーザIDを設定
         *
         * @param scorerUserId スコアを獲得したユーザID
         * @return this
         */
        public Score WithScorerUserId(string scorerUserId) {
            this.scorerUserId = scorerUserId;
            return this;
        }

        /** スコア */
        public long? score { set; get; }

        /**
         * スコアを設定
         *
         * @param score スコア
         * @return this
         */
        public Score WithScore(long? score) {
            this.score = score;
            return this;
        }

        /** メタデータ */
        public string metadata { set; get; }

        /**
         * メタデータを設定
         *
         * @param metadata メタデータ
         * @return this
         */
        public Score WithMetadata(string metadata) {
            this.metadata = metadata;
            return this;
        }

        /** 作成日時 */
        public long? createdAt { set; get; }

        /**
         * 作成日時を設定
         *
         * @param createdAt 作成日時
         * @return this
         */
        public Score WithCreatedAt(long? createdAt) {
            this.createdAt = createdAt;
            return this;
        }

        public void WriteJson(JsonWriter writer)
        {
            writer.WriteObjectStart();
            if(this.scoreId != null)
            {
                writer.WritePropertyName("scoreId");
                writer.Write(this.scoreId);
            }
            if(this.categoryName != null)
            {
                writer.WritePropertyName("categoryName");
                writer.Write(this.categoryName);
            }
            if(this.userId != null)
            {
                writer.WritePropertyName("userId");
                writer.Write(this.userId);
            }
            if(this.uniqueId != null)
            {
                writer.WritePropertyName("uniqueId");
                writer.Write(this.uniqueId);
            }
            if(this.scorerUserId != null)
            {
                writer.WritePropertyName("scorerUserId");
                writer.Write(this.scorerUserId);
            }
            if(this.score.HasValue)
            {
                writer.WritePropertyName("score");
                writer.Write(this.score.Value);
            }
            if(this.metadata != null)
            {
                writer.WritePropertyName("metadata");
                writer.Write(this.metadata);
            }
            if(this.createdAt.HasValue)
            {
                writer.WritePropertyName("createdAt");
                writer.Write(this.createdAt.Value);
            }
            writer.WriteObjectEnd();
        }

    public static string GetCategoryNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):ranking:(?<namespaceName>.*):user:(?<userId>.*):category:(?<categoryName>.*):score:(?<scorerUserId>.*):(?<uniqueId>.*)");
        if (!match.Groups["categoryName"].Success)
        {
            return null;
        }
        return match.Groups["categoryName"].Value;
    }

    public static string GetScorerUserIdFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):ranking:(?<namespaceName>.*):user:(?<userId>.*):category:(?<categoryName>.*):score:(?<scorerUserId>.*):(?<uniqueId>.*)");
        if (!match.Groups["scorerUserId"].Success)
        {
            return null;
        }
        return match.Groups["scorerUserId"].Value;
    }

    public static string GetUniqueIdFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):ranking:(?<namespaceName>.*):user:(?<userId>.*):category:(?<categoryName>.*):score:(?<scorerUserId>.*):(?<uniqueId>.*)");
        if (!match.Groups["uniqueId"].Success)
        {
            return null;
        }
        return match.Groups["uniqueId"].Value;
    }

    public static string GetUserIdFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):ranking:(?<namespaceName>.*):user:(?<userId>.*):category:(?<categoryName>.*):score:(?<scorerUserId>.*):(?<uniqueId>.*)");
        if (!match.Groups["userId"].Success)
        {
            return null;
        }
        return match.Groups["userId"].Value;
    }

    public static string GetNamespaceNameFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):ranking:(?<namespaceName>.*):user:(?<userId>.*):category:(?<categoryName>.*):score:(?<scorerUserId>.*):(?<uniqueId>.*)");
        if (!match.Groups["namespaceName"].Success)
        {
            return null;
        }
        return match.Groups["namespaceName"].Value;
    }

    public static string GetOwnerIdFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):ranking:(?<namespaceName>.*):user:(?<userId>.*):category:(?<categoryName>.*):score:(?<scorerUserId>.*):(?<uniqueId>.*)");
        if (!match.Groups["ownerId"].Success)
        {
            return null;
        }
        return match.Groups["ownerId"].Value;
    }

    public static string GetRegionFromGrn(
        string grn
    )
    {
        var match = Regex.Match(grn, "grn:gs2:(?<region>.*):(?<ownerId>.*):ranking:(?<namespaceName>.*):user:(?<userId>.*):category:(?<categoryName>.*):score:(?<scorerUserId>.*):(?<uniqueId>.*)");
        if (!match.Groups["region"].Success)
        {
            return null;
        }
        return match.Groups["region"].Value;
    }

    	[Preserve]
        public static Score FromDict(JsonData data)
        {
            return new Score()
                .WithScoreId(data.Keys.Contains("scoreId") && data["scoreId"] != null ? data["scoreId"].ToString() : null)
                .WithCategoryName(data.Keys.Contains("categoryName") && data["categoryName"] != null ? data["categoryName"].ToString() : null)
                .WithUserId(data.Keys.Contains("userId") && data["userId"] != null ? data["userId"].ToString() : null)
                .WithUniqueId(data.Keys.Contains("uniqueId") && data["uniqueId"] != null ? data["uniqueId"].ToString() : null)
                .WithScorerUserId(data.Keys.Contains("scorerUserId") && data["scorerUserId"] != null ? data["scorerUserId"].ToString() : null)
                .WithScore(data.Keys.Contains("score") && data["score"] != null ? (long?)long.Parse(data["score"].ToString()) : null)
                .WithMetadata(data.Keys.Contains("metadata") && data["metadata"] != null ? data["metadata"].ToString() : null)
                .WithCreatedAt(data.Keys.Contains("createdAt") && data["createdAt"] != null ? (long?)long.Parse(data["createdAt"].ToString()) : null);
        }

        public int CompareTo(object obj)
        {
            var other = obj as Score;
            var diff = 0;
            if (scoreId == null && scoreId == other.scoreId)
            {
                // null and null
            }
            else
            {
                diff += scoreId.CompareTo(other.scoreId);
            }
            if (categoryName == null && categoryName == other.categoryName)
            {
                // null and null
            }
            else
            {
                diff += categoryName.CompareTo(other.categoryName);
            }
            if (userId == null && userId == other.userId)
            {
                // null and null
            }
            else
            {
                diff += userId.CompareTo(other.userId);
            }
            if (uniqueId == null && uniqueId == other.uniqueId)
            {
                // null and null
            }
            else
            {
                diff += uniqueId.CompareTo(other.uniqueId);
            }
            if (scorerUserId == null && scorerUserId == other.scorerUserId)
            {
                // null and null
            }
            else
            {
                diff += scorerUserId.CompareTo(other.scorerUserId);
            }
            if (score == null && score == other.score)
            {
                // null and null
            }
            else
            {
                diff += (int)(score - other.score);
            }
            if (metadata == null && metadata == other.metadata)
            {
                // null and null
            }
            else
            {
                diff += metadata.CompareTo(other.metadata);
            }
            if (createdAt == null && createdAt == other.createdAt)
            {
                // null and null
            }
            else
            {
                diff += (int)(createdAt - other.createdAt);
            }
            return diff;
        }
	}
}