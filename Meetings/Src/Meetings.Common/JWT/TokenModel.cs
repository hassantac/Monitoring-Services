using Meetings.Common.Enums;
using System;

namespace Meetings.Common.JWT
{
    public class TokenModel
    {
        #region Private Fields

        #endregion


        #region Private Methods

        private DateTime FromUnixTime(long unixTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return epoch.AddSeconds(unixTime);
        }

        #endregion


        #region Constructors

        public TokenModel() { }

        public TokenModel(long id)
        {
            Id = id;
        }

        public TokenModel(long id, long issuedAt,
            long expiresAt, long notValidBefore, AccountType type)
        {
            Id = id;
            IssuedAtEpoch = issuedAt;
            IssuedAt = FromUnixTime(IssuedAtEpoch);
            ExpiresAtEpoch = expiresAt;
            ExpiresAt = FromUnixTime(expiresAt);
            NotValidBeforeEpoch = notValidBefore;
            NotValidBefore = FromUnixTime(notValidBefore);
            Type = type;
        }

        #endregion


        #region Properties

        public long Id { get; set; }

        public long IssuedAtEpoch { get; set; }

        public DateTime IssuedAt { get; set; }

        public long ExpiresAtEpoch { get; set; }

        public DateTime ExpiresAt { get; set; }

        public long NotValidBeforeEpoch { get; set; }

        public DateTime NotValidBefore { get; set; }

        public AccountType Type { get; set; }

        #endregion


        #region Fields

        #endregion


        #region Methods

        #endregion
    }
}
