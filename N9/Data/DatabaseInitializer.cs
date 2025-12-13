using System;
using System.Data.SQLite;

namespace N9.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            CreateTables();
            MigrateSchema();
            SeedCategories();
        }

        private static void MigrateSchema()
        {
            // Check if Salt column exists in Users table
            try
            {
                var dt = DatabaseContext.ExecuteQuery("PRAGMA table_info(Users)");
                bool hasSalt = false;
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    if (row["name"].ToString().Equals("Salt", StringComparison.OrdinalIgnoreCase))
                    {
                        hasSalt = true;
                        break;
                    }
                }

                if (!hasSalt)
                {
                    // Add Salt column if missing
                    DatabaseContext.ExecuteNonQuery("ALTER TABLE Users ADD COLUMN Salt TEXT DEFAULT ''");
                }
            }
            catch { }
        }

        private static void CreateTables()
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    PasswordHash TEXT NOT NULL,
                    Salt TEXT NOT NULL,
                    Email TEXT,
                    ReminderDays INTEGER DEFAULT 3,
                    RememberMe INTEGER DEFAULT 0,
                    CreatedAt TEXT NOT NULL,
                    LastLogin TEXT,
                    FailedLoginAttempts INTEGER DEFAULT 0,
                    LockoutEnd TEXT
                );

                CREATE TABLE IF NOT EXISTS CreditCards (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserId INTEGER NOT NULL,
                    BankName TEXT NOT NULL,
                    CardType TEXT NOT NULL,
                    Last4Digits TEXT NOT NULL,
                    CreditLimit REAL NOT NULL,
                    StatementDay INTEGER NOT NULL,
                    DueDayOffset INTEGER DEFAULT 15,
                    Status INTEGER DEFAULT 0,
                    CreatedAt TEXT NOT NULL,
                    FOREIGN KEY (UserId) REFERENCES Users(Id)
                );

                CREATE TABLE IF NOT EXISTS Categories (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Icon TEXT
                );

                CREATE TABLE IF NOT EXISTS StatementPeriods (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    CardId INTEGER NOT NULL,
                    StartDate TEXT NOT NULL,
                    EndDate TEXT NOT NULL,
                    DueDate TEXT NOT NULL,
                    TotalAmount REAL DEFAULT 0,
                    PaidAmount REAL DEFAULT 0,
                    Status INTEGER DEFAULT 0,
                    FOREIGN KEY (CardId) REFERENCES CreditCards(Id)
                );

                CREATE TABLE IF NOT EXISTS Transactions (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    CardId INTEGER NOT NULL,
                    StatementId INTEGER,
                    TransactionDate TEXT NOT NULL,
                    MerchantName TEXT NOT NULL,
                    Amount REAL NOT NULL,
                    CategoryId INTEGER NOT NULL,
                    IsInstallment INTEGER DEFAULT 0,
                    InstallmentMonths INTEGER,
                    InstallmentRate REAL,
                    CreatedAt TEXT NOT NULL,
                    FOREIGN KEY (CardId) REFERENCES CreditCards(Id),
                    FOREIGN KEY (StatementId) REFERENCES StatementPeriods(Id),
                    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
                );

                CREATE TABLE IF NOT EXISTS LoginAttempts (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserId INTEGER,
                    Username TEXT NOT NULL,
                    AttemptTime TEXT NOT NULL,
                    Success INTEGER NOT NULL,
                    IpAddress TEXT,
                    FOREIGN KEY (UserId) REFERENCES Users(Id)
                );

                CREATE TABLE IF NOT EXISTS BackupLogs (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserId INTEGER NOT NULL,
                    BackupTime TEXT NOT NULL,
                    FilePath TEXT NOT NULL,
                    IsRestore INTEGER DEFAULT 0,
                    FOREIGN KEY (UserId) REFERENCES Users(Id)
                );

                CREATE INDEX IF NOT EXISTS idx_cards_userid ON CreditCards(UserId);
                CREATE INDEX IF NOT EXISTS idx_transactions_cardid ON Transactions(CardId);
                CREATE INDEX IF NOT EXISTS idx_transactions_statementid ON Transactions(StatementId);
                CREATE INDEX IF NOT EXISTS idx_statements_cardid ON StatementPeriods(CardId);
            ";

            DatabaseContext.ExecuteNonQuery(sql);
        }

        private static void SeedCategories()
        {
            var count = DatabaseContext.ExecuteScalar("SELECT COUNT(*) FROM Categories");
            if (Convert.ToInt32(count) > 0) return;

            string[] categories = {
                "Ăn uống",
                "Mua sắm",
                "Giải trí",
                "Du lịch",
                "Y tế",
                "Giáo dục",
                "Hóa đơn & Tiện ích",
                "Giao thông",
                "Trả góp",
                "Khác"
            };

            foreach (var cat in categories)
            {
                DatabaseContext.ExecuteNonQuery(
                    "INSERT INTO Categories (Name, Icon) VALUES (@name, @icon)",
                    new SQLiteParameter("@name", cat),
                    new SQLiteParameter("@icon", "")
                );
            }
        }
    }
}
