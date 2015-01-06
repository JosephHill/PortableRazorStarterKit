using System;
using System.IO;

namespace Congress
{
	public partial class DataAccess
	{
		public DataAccess() {
            var dbName = "congress.sqlite";
			var dataPath = Path.Combine (PCLStorage.FileSystem.Current.LocalStorage.Path, dbName);
			connectionString = "URI=file:" + dataPath;
		}
	}
}

