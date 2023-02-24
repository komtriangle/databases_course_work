using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsApp.Data.Configuration
{
	public class MongoConfig
	{
		public string ConnectionString { get; set; }
		public string Database { get; set; }
		public string FilmsCollection { get; set; }
	}
}
