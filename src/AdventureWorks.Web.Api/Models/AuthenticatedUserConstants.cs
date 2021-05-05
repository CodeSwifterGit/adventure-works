namespace AdventureWorks.Web.Api.Models
{
    public static class AuthenticatedUserConstants
    {
        public const string ClaimTypeUserId = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
        public const string ClaimTypeName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname";
        public const string ClaimTypeEmail = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
        public const string ClaimTypeEmailVerified = "https://adventureworks.com/identity/claims/email_verified";
        public const string ClaimTypeNickName = "https://adventureworks.com/identity/claims/nickname";
        public const string ClaimTypePicture = "https://adventureworks.com/identity/claims/picture";
        public const string ClaimTypeUpdatedAt = "https://adventureworks.com/identity/claims/updated_at";
        public const string ClaimTypeCreatedAt = "https://adventureworks.com/identity/claims/created_at";
        public const string ClaimTypePermissions = "https://adventureworks.com/identity/claims/permissions";
        public const string SessionHeaderIdentifier = "CODE-SWIFTER-SESSION-ID";
    }
}