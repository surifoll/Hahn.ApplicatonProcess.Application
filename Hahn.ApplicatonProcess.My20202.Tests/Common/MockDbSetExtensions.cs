using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Moq;

namespace Hahn.ApplicatonProcess.My20202.Tests.Common
{
    public static class MockDbSetExtensions
    {
        public static void SetUpDbSet<T>(this Mock<DbSet<T>> mock, List<T> list)
            where T : class
        {
            var queryable = list.AsQueryable();
            Mock<DbSet<T>> dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(p => p.GetEnumerator())
                .Returns(queryable.GetEnumerator());

            dbSetMock.As<IQueryable<T>>().Setup(p => p.Provider)
                .Returns(queryable.Provider);

            dbSetMock.As<IQueryable<T>>().Setup(p => p.ElementType)
                .Returns(queryable.ElementType);

            dbSetMock.As<IQueryable<T>>().Setup(p => p.Expression)
                .Returns(queryable.Expression);
        }
    }
}
