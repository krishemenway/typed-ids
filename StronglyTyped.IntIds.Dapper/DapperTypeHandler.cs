﻿using System.Data;
using static Dapper.SqlMapper;

namespace StronglyTyped.IntIds.Dapper
{
	public class DapperTypeHandler<T> : TypeHandler<Id<T>>
	{
		public override Id<T> Parse(object value)
		{
			return new Id<T>((int)value);
		}

		public override void SetValue(IDbDataParameter parameter, Id<T> value)
		{
			parameter.DbType = DbType.Int32;
			parameter.Value = value.Value;
		}

		public static void Register()
		{
			AddTypeHandler(new DapperTypeHandler<T>());
		}
	}
}
