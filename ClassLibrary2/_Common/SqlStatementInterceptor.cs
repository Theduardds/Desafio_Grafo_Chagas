using NHibernate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Grafo.Infra._Common
{
    public class SqlStatementInterceptor : EmptyInterceptor
    {
        public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            Trace.WriteLine(sql.ToString() + ";");
            return sql;
        }
    }
}
