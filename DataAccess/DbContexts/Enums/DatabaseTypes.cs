using DataAccessLayer.Utils.Attributes;

namespace DataAccessLayer.DbContexts.Enums
{
    internal enum DatabaseTypes
    {
        [StringValue("None")]
        None = 0,

        [StringValue("MSSQL_Mikrus")]
        MsSQL_Mikrus = 1,
    }
}
