﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YASqlEngine.Core;
using YASqlEngine.Core.Exceptions;
using YASqlEngine;
using Antlr4.Runtime;

namespace YASqlEngineTests
{
    [TestClass]
    public class ColumnCountTest
    {
        [TestMethod]
        public void ColumnCount_1_STAR()
        {
            string sql = @"select * from [me]";
            var info = SQLParser.ParseSQL(sql);

            Assert.AreEqual(1, info.Columns.Count);
        }

        [TestMethod]
        public void ColumnCount_1_FIX_NUMBER()
        {
            string sql = @"select 1 from [me]";
            var info = SQLParser.ParseSQL(sql);

            Assert.AreEqual(1, info.Columns.Count);
        }

        [TestMethod]
        public void ColumnCount_1()
        {
            string sql = @"select userId from [me]";
            var info = SQLParser.ParseSQL(sql);

            Assert.AreEqual(1, info.Columns.Count);
        }

        [TestMethod]
        public void ColumnCount_2()
        {
            string sql = @"select userId, userName from [me]";
            var info = SQLParser.ParseSQL(sql);

            Assert.AreEqual(2, info.Columns.Count);
        }

        [TestMethod]
        public void ColumnCount_2_Has1Alias()
        {
            string sql = @"select userId as uid, userName from [me]";
            var info = SQLParser.ParseSQL(sql);

            Assert.AreEqual(2, info.Columns.Count);
        }

        [TestMethod]
        public void ColumnCount_2_Has2Alias()
        {
            string sql = @"select userId as uid, userName as uname from [me]";
            var info = SQLParser.ParseSQL(sql);

            Assert.AreEqual(2, info.Columns.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingColumnExpressionException))]
        public void ColumnCount_0()
        {
            string sql = @"select FROM asdfa";
            var info = SQLParser.ParseSQL(sql);
        }
        

        [TestMethod]
        public void ColumnOnly()
        {
            string sql = @"select 1";
            var info = SQLParser.ParseSQL(sql);

            Assert.AreEqual(1, info.Columns.Count);
            Assert.AreEqual(null, info.TableDescriptor);
        }
    }
}
