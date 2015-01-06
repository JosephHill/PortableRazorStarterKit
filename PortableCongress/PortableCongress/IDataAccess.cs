using System;
using System.Collections.Generic;

namespace PortableCongress
{
	public interface IDataAccess
	{
		string FileName { get; set; }
		Politician LoadPolitician (int id);
		List<Politician> LoadAllPoliticans ();
        void SaveFavoriteBill (Bill bill);
        List<Bill> LoadFavoriteBills ();
        void DeleteFavoriteBill (int id);
        Bill LoadFavoriteBill (int id);
        void SaveNotes (int id, string notes);
	}
}