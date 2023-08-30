using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IWriterService:IGenericService<Writer>
	{
		Writer WriterLogin(Writer p);
		List<Writer>GetWriterByID (int id);
		int? TotalRecipeCount();
		int TotalRecipeCountByWriter(int id);
		int TotalRecipeCountLast7Days();
	}
}
