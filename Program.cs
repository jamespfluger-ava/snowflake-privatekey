using System;
using System.IO;
using Snowflake.Data.Client;

string keyText = File.ReadAllText(@"C:\.keys\snowflake_key.p8").ReplaceLineEndings("\n");
string keyPwd = Environment.GetEnvironmentVariable("SNOWFLAKE_KEY_PASSPHRASE");

// NOTE: The following items with <[...]> need to be replaced with your own information (without the arrows)
SnowflakeDbConnectionStringBuilder connStringBuilder = new SnowflakeDbConnectionStringBuilder()
{
    ["ACCOUNT"] = "<ACCOUNT_NAME>",
    ["DB"] = "<DB_NAME>",
    ["SCHEMA"] = "<SCEHMA_NAME>",
    ["USER"] = "<USER_NAME>",
    ["ROLE"] = "<ROLE_NAME>",
    ["WAREHOUSE"] = "<WH_NAME>",
    ["AUTHENTICATOR"] = "SNOWFLAKE_JWT",
    ["PRIVATE_KEY"] = keyText,
    ["PRIVATE_KEY_PWD"] = keyPwd,
    ["CLIENT_CONFIG_FILE"] = @"C:\snowflake-privatekey\sf_client_config.json"
};

SnowflakeDbConnection conn = new SnowflakeDbConnection();
conn.ConnectionString = connStringBuilder.ConnectionString;
conn.Open();

Console.WriteLine("Connection successful!");
