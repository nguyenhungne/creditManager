using System;

namespace N9.Models
{
    public enum CardStatus
    {
        Active,
        Locked
    }

    public enum StatementStatus
    {
        NotIssued,
        Pending,
        Paid
    }

    public enum ErrorCode
    {
        None,
        ValidationError,
        AuthenticationFailed,
        AccountLocked,
        DatabaseError,
        FileAccessError,
        InvalidPassword,
        DuplicateEntry
    }
}
