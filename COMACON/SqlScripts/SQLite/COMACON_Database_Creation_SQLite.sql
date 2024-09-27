-- Drop existing tables if they exist
DROP TABLE IF EXISTS [securitylog];
DROP TABLE IF EXISTS [roleXpermissions];
DROP TABLE IF EXISTS [sessions];
DROP TABLE IF EXISTS [useraccounts];
DROP TABLE IF EXISTS [roles];
DROP TABLE IF EXISTS [permissions];
DROP TABLE IF EXISTS [systemtable];
DROP TABLE IF EXISTS [passwordrules];
DROP TABLE IF EXISTS [passwordpolicies];

-- Create the tables
CREATE TABLE [permissions](
    [permissionid] [INTEGER] PRIMARY KEY AUTOINCREMENT NOT NULL,
    [permission_name] [text] NOT NULL,
    [description] [text] NOT NULL,
    [creationdate] [datetime] NOT NULL,
    [lastupdateddate] [datetime] NOT NULL
);

CREATE TABLE [roles](
    [roleid] [INTEGER] PRIMARY KEY AUTOINCREMENT NOT NULL,
    [rolename] [text] NOT NULL,
    [roledescription] [text] NULL
);

CREATE TABLE [roleXpermissions](
    [permissionid] [int] PRIMARY KEY NOT NULL,
    [roleid] [int] NOT NULL,
    FOREIGN KEY ([roleid]) REFERENCES [roles]([roleid]),
    FOREIGN KEY ([permissionid]) REFERENCES [permissions]([permissionid])
);

CREATE TABLE [useraccounts](
    [usernum] [INTEGER] PRIMARY KEY AUTOINCREMENT NOT NULL,
    [username] [varchar](50) NOT NULL,
    [firstname] [varchar](100) NOT NULL,
    [lastname] [varchar](100) NOT NULL,
    [password] [varchar](250) NOT NULL,
    [emailaddress] [varchar](150) NULL,
    [status] [bit] NOT NULL,
    [passwordresetonnextlogin] [bit] NOT NULL,
    [passwordlastchanged] [datetime] NULL,
    [authmethod] [tinyint] NOT NULL,
    [creationdate] [datetime] NOT NULL,
    [createdby] [int] NULL,
    [lastediteddate] [datetime] NULL,
    [lasteditedby] [int] NULL,
    [roleid] [int] NULL,
    --[lockedout] [bit] NOT NULL,
    FOREIGN KEY ([roleid]) REFERENCES [roles]([roleid]),
    FOREIGN KEY ([createdby]) REFERENCES [useraccounts]([usernum]),
    FOREIGN KEY ([lasteditedby]) REFERENCES [useraccounts]([usernum])
);

CREATE TABLE [securitylog](
    [securitylogid] [INTEGER] PRIMARY KEY AUTOINCREMENT NOT NULL,
    [eventid] [smallint] NOT NULL,
    [usernum] [int] NOT NULL,
    [eventdescription] [text] NOT NULL,
    [affectedusernum] [int],
    [logdate] [datetime] NOT NULL,
    FOREIGN KEY ([usernum]) REFERENCES [useraccounts]([usernum]),
    FOREIGN KEY ([affectedusernum]) REFERENCES [useraccounts]([usernum])
);

CREATE TABLE [sessions](
    [access_token] [varchar](50) NOT NULL,
    [token_type] [text] NOT NULL,
    [creationdate] [datetime] NOT NULL,
    [expirationdate] [datetime] NOT NULL,
    [usernum] [int] NOT NULL,
    FOREIGN KEY ([usernum]) REFERENCES [useraccounts]([usernum])
);

CREATE TABLE [systemtable](
    [id] INT PRIMARY KEY CHECK ([id] = 1),
    [databaseversion] [varchar](10) NOT NULL
);

CREATE TABLE [passwordpolicies](
    [pswdpolicyid] [INTEGER] PRIMARY KEY AUTOINCREMENT NOT NULL,
    [policytype] [tinyint] NOT NULL,
    [policyname] [text] NOT NULL,
    [policydescription] [text] NOT NULL,
    [policyenabled] [bit] NOT NULL
);

CREATE TABLE [passwordrules](
    [pswdruleid] [INTEGER] PRIMARY KEY AUTOINCREMENT NOT NULL,
    [pswdpolicyid] [bigint] NOT NULL,
    [ruletype] [tinyint] NOT NULL,
    [rulevalue] [smallint],
    [ruleenabled] [bit] NOT NULL,
    FOREIGN KEY ([pswdpolicyid]) REFERENCES [passwordpolicies]([pswdpolicyid])
);

-- Insert default data
INSERT INTO [roles] (rolename, roledescription)
VALUES ('Admin', '');

INSERT INTO [useraccounts] (username, firstname, lastname, password, emailaddress, status, passwordresetonnextlogin, passwordlastchanged, authmethod, creationdate, createdby, lastediteddate, lasteditedby, roleid)
VALUES ('admin', 'admin', 'admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'admin@dummy.com', 1, 0, CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1, CURRENT_TIMESTAMP, 1, 1);

INSERT INTO [systemtable] (id, databaseversion)
VALUES (1, '1.0.0');

INSERT INTO [passwordpolicies] (policytype, policyname, policydescription, policyenabled)
VALUES (1, 'Global Password Policy','', 1);

INSERT INTO [passwordrules] (pswdpolicyid, ruletype, rulevalue, ruleenabled)
VALUES (1, 1, 30, 0), (1, 2, 5, 0);