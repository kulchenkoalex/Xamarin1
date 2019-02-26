using System;
using System.Collections.Generic;
using System.Text;

namespace HelloApp
{
    interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
