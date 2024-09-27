-- Drop existing tables if they exist
DROP TABLE IF EXISTS securitylog;
DROP TABLE IF EXISTS roleXpermissions;
DROP TABLE IF EXISTS sessions;
DROP TABLE IF EXISTS useraccounts;
DROP TABLE IF EXISTS roles;
DROP TABLE IF EXISTS permissions;
DROP TABLE IF EXISTS systemtable;
DROP TABLE IF EXISTS passwordrules;
DROP TABLE IF EXISTS passwordpolicies;

-- Create the tables
CREATE TABLE permissions (
    PermissionId INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    PermissionName TEXT NOT NULL,
    Description TEXT NOT NULL,
    CreationDate TEXT NOT NULL,
    LastUpdatedDate TEXT NOT NULL
);

CREATE TABLE roles (
    RoleId INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    RoleName TEXT NOT NULL,
    RoleDescription TEXT NULL
);

CREATE TABLE roleXpermissions (
    PermissionId INTEGER NOT NULL,
    RoleId INTEGER NOT NULL,
    PRIMARY KEY (PermissionId, RoleId),
    FOREIGN KEY (RoleId) REFERENCES roles (RoleId),
    FOREIGN KEY (PermissionId) REFERENCES permissions (PermissionId)
);

CREATE TABLE useraccounts (
    UserNum INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    Username TEXT NOT NULL,
    FirstName TEXT NOT NULL,
    LastName TEXT NOT NULL,
    Password TEXT NOT NULL,
    EmailAddress TEXT NULL,
    Status INTEGER NOT NULL,
    PasswordResetOnNextLogin INTEGER NOT NULL,
    PasswordLastChanged TEXT NULL,
    AuthMethod INTEGER NOT NULL,
    CreationDate TEXT NOT NULL,
    CreatedBy INTEGER NULL,
    LastEditedDate TEXT NULL,
    LastEditedBy INTEGER NULL,
    RoleId INTEGER NULL,
    FOREIGN KEY (RoleId) REFERENCES roles (RoleId),
    FOREIGN KEY (CreatedBy) REFERENCES useraccounts (UserNum),
    FOREIGN KEY (LastEditedBy) REFERENCES useraccounts (UserNum)
);

CREATE TABLE securitylog (
    SecurityLogId INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    EventId INTEGER NOT NULL,
    UserNum INTEGER NOT NULL,
    EventDescription TEXT NOT NULL,
    AffectedUserNum INTEGER NULL,
    LogDate TEXT NOT NULL,
    FOREIGN KEY (UserNum) REFERENCES useraccounts (UserNum),
    FOREIGN KEY (AffectedUserNum) REFERENCES useraccounts (UserNum)
);

CREATE TABLE sessions (
    AccessToken TEXT PRIMARY KEY NOT NULL,
    TokenType TEXT NOT NULL,
    CreationDate TEXT NOT NULL,
    ExpirationDate TEXT NOT NULL,
    UserNum INTEGER NOT NULL,
    FOREIGN KEY (UserNum) REFERENCES useraccounts (UserNum)
);

CREATE TABLE systemtable (
    Id INTEGER PRIMARY KEY CHECK (Id = 1),
    DatabaseVersion TEXT NOT NULL
);

CREATE TABLE passwordpolicies (
    PswdPolicyId INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    PolicyType INTEGER NOT NULL,
    PolicyName TEXT NOT NULL,
    PolicyDescription TEXT NOT NULL,
    PolicyEnabled INTEGER NOT NULL
);

CREATE TABLE passwordrules (
    PswdRuleId INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    PswdPolicyId INTEGER NOT NULL,
    RuleType INTEGER NOT NULL,
    RuleValue INTEGER NULL,
    RuleEnabled INTEGER NOT NULL,
    FOREIGN KEY (PswdPolicyId) REFERENCES passwordpolicies (PswdPolicyId)
);

-- Insert default data
INSERT INTO roles (RoleName, RoleDescription)
VALUES ('Admin', '');

INSERT INTO useraccounts (Username,
FirstName,
LastName,
Password,
EmailAddress,
Status,
PasswordResetOnNextLogin,
PasswordLastChanged,
AuthMethod,
CreationDate,
CreatedBy,
LastEditedDate,
LastEditedBy,
RoleId)
VALUES ('admin',
'admin',
'admin',
'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918',
'admin@dummy.com',
1,
0,
CURRENT_TIMESTAMP,
1,
CURRENT_TIMESTAMP,
1,
CURRENT_TIMESTAMP,
1,
1);

INSERT INTO systemtable (Id, DatabaseVersion)
VALUES (1, '1.0.0');

INSERT INTO passwordpolicies (PolicyType, PolicyName, PolicyDescription, PolicyEnabled)
VALUES (1, 'Global Password Policy', '', 1);

INSERT INTO passwordrules (PswdPolicyId, RuleType, RuleValue, RuleEnabled)
VALUES (1, 1, 30, 0), (1, 2, 5, 0);