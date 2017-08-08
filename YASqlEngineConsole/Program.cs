using YASqlEngine.Core;
using YASqlEngine.Core.SQLGenerator;
using System;

namespace YASqlEngineConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql = @"select * from [me]";
            var info = SQLParser.ParseSQL(sql);

            var generator = new DefaultSqlGenerator();

            Console.WriteLine(generator.Generate(info));
        }
    }
}